using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;
using Titanium.Web.Proxy;
using System.Threading;
using System.IO;
using System.Data.SQLite;

namespace ProxyMain
{
    public partial class FMain : Form
    {
        SynchronizationContext _syncContext = null;
        private string dbPath;
        private SQLiteConnection conn = null;
        private List<String[]> custom = null;
        private List<string> adList = null;
        private string path = "\\ad.txt";

        public FMain()
        {
            InitializeComponent();
            _syncContext = SynchronizationContext.Current;

            custom = new List<String[]>();
            adList = new List<String>();

            //checkFile
            checkFileReady();
            updateList();
            formData();
            adData();

            Console.WriteLine("Listening on");
            StartProxy();
        }

        private string bts(byte[] b)
        {
            if (b == null) return "";
            return System.Text.Encoding.UTF8.GetString(b);
        }

        private void adData()
        {
            path = Environment.CurrentDirectory + path;
            if(!File.Exists(path)) return;
            FileStream fs = File.Open(path, FileMode.Open);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();

            string contents = bts(buffer).Trim();
            string[] data = Regex.Split(contents, "\n");

            for(var i=0; i< data.Length; i++){
                adList.Add(data[i].Trim());
            }
        }


        //填入数据
        private void formData()
        {
            for (var i = 0; i < custom.Count; i++)
            {
                bool enable = custom[i][1]=="1";
                string value = custom[i][2];
                checkedListBoxFilter.Items.Insert(0, value);  
                checkedListBoxFilter.SetItemChecked(0, enable);
            }
        }

        private string idWithVal(string str)
        {
            for (var i = 0; i < custom.Count; i++)
            {
                string value = custom[i][2];
                if (value == str)
                {
                    return custom[i][0];
                }
            }
            return "-1";
        }

        private void checkFileReady()
        {
            dbPath = "Data Source =" + Environment.CurrentDirectory + "/proxy.db";
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  

            string sql = "CREATE TABLE IF NOT EXISTS data(id varchar(2), enable varchar(2), name varchar(100));";//建表语句  
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();//如果表不存在，创建数据表  

            //SQLiteCommand cmdInsert = new SQLiteCommand(conn);
            //cmdInsert.CommandText = "INSERT INTO student VALUES(1, '小红', '男')";//插入几条数据 
        }

        private void updateList()
        {
            if (custom.Count > 0) custom.Clear();

            string sql = "select * from data";
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);

            SQLiteDataReader reader = cmdQ.ExecuteReader();

            while (reader.Read())
            {
                String id = reader.GetString(0);
                String enable = reader.GetString(1);
                String value = reader.GetString(2);
                String[] one = { id, enable, value };
                custom.Add(one);

                Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2));
            }
        }

        private Boolean add(String[] row)
        {
            string enable = row[0];
            string value = row[1];
            string sql = "insert into data values('" + nextId() + "','" + enable + "', '" + value + "')";

            SQLiteCommand cmdInsert = new SQLiteCommand(conn);
            cmdInsert.CommandText = sql;//插入几条数据  
            try
            {
                cmdInsert.ExecuteNonQuery();
                updateList();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private Boolean delete(String val)
        {
            string doId = idWithVal(val);
            Console.WriteLine(doId);
            if (doId == "-1") return false;

            string sql = "DELETE FROM data WHERE id='" + doId + "'";
            SQLiteCommand cmdInsert = new SQLiteCommand(conn);
            cmdInsert.CommandText = sql;
            try
            {
                cmdInsert.ExecuteNonQuery();

                //clean 
                for (var i = 0; i < custom.Count; i++)
                {
                    string atId = custom[i][0];
                    if (atId == doId) custom.RemoveAt(i);

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string nextId()
        {
            string sql = "select count(*) from data";
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmdQ.ExecuteReader();
            reader.Read();
            int iMax = reader.GetInt32(0);
            iMax++;
            return iMax.ToString();
        }

        override protected void OnFormClosed(FormClosedEventArgs e)
        {
            //proxy
            Stop();

            //sqlite
            conn.Close(); 
        }

        public void StartProxy()
        {
            ProxyServer.BeforeRequest += OnRequest;
            ProxyServer.BeforeResponse += OnResponse;

            //Exclude Https addresses you don't want to proxy
            //Usefull for clients that use certificate pinning
            //for example dropbox.com
            var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Parse(GetAddressIP()), 8020, true)
            {
                // ExcludedHttpsHostNameRegex = new List<string>() { "google.com", "dropbox.com" }
            };

            //An explicit endpoint is where the client knows about the existance of a proxy
            //So client sends request in a proxy friendly manner
            ProxyServer.AddEndPoint(explicitEndPoint);
            ProxyServer.Start();

            this._syncContext.Post(SetIPLabel, explicitEndPoint);

            //Transparent endpoint is usefull for reverse proxying (client is not aware of the existance of proxy)
            //A transparent endpoint usually requires a network router port forwarding HTTP(S) packets to this endpoint
            //Currently do not support Server Name Indication (It is not currently supported by SslStream class)
            //That means that the transparent endpoint will always provide the same Generic Certificate to all HTTPS requests
            //In this example only google.com will work for HTTPS requests
            //Other sites will receive a certificate mismatch warning on browser
            //Please read about it before asking questions!
            

            //Only explicit proxies can be set as system proxy!
            ProxyServer.SetAsSystemHttpProxy(explicitEndPoint);
            ProxyServer.SetAsSystemHttpsProxy(explicitEndPoint);
        }

        public void Stop()
        {
            ProxyServer.BeforeRequest -= OnRequest;
            ProxyServer.BeforeResponse -= OnResponse;

            ProxyServer.Stop();
        }

        /// <summary>
        /// 获取本地IP地址信息
        /// </summary>
        String GetAddressIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    if (_IPAddress.ToString().IndexOf("192.168") != -1)
                        AddressIP = _IPAddress.ToString();
                }
            }
            Console.WriteLine(AddressIP);
            return AddressIP;
        }

        private void SetIPLabel(Object data)
        {
            labelIp.Text = ((ProxyEndPoint)data).IpAddress + ":" + ((ProxyEndPoint)data).Port;
        }

        private void StayUrl(Object uri)
        {
            ListBox.ObjectCollection items = listBoxRequest.Items;
            items.Insert(0, uri.ToString());
            int count = listBoxRequest.Items.Count;
            if (count > 30) items.RemoveAt(count - 1);
        }

        private void BlockUrl(Object uri)
        {
            ListBox.ObjectCollection items = listBoxBlock.Items;
            items.Insert(0, uri.ToString());
            int count = listBoxBlock.Items.Count;
            if (count > 30) items.RemoveAt(count - 1);
        }

        //Test On Request, intecept requests
        //Read browser URL send back to proxy by the injection script in OnResponse event
        public void OnRequest(object sender, SessionEventArgs e)
        {

            String uri = e.ProxySession.Request.Url;
            this._syncContext.Post(StayUrl,uri);

            //read request headers
            var requestHeaders = e.ProxySession.Request.RequestHeaders;

            if ((e.RequestMethod.ToUpper() == "POST" || e.RequestMethod.ToUpper() == "PUT"))
            {
                //Get/Set request body bytes
                byte[] bodyBytes = e.GetRequestBody();
                e.SetRequestBody(bodyBytes);

                //Get/Set request body as string
                string bodyString = e.GetRequestBodyAsString();
                e.SetRequestBodyString(bodyString);

            }

            //To cancel a request with a custom HTML content
            //Filter URL
            if (checkIsFiltered(uri) && !isIgnore(uri))
            {
                _syncContext.Post(BlockUrl, uri);
                e.Ok("");
            }

            if (e.ProxySession.Request.RequestUri.AbsoluteUri.Contains("google.com"))
            {
                //e.Ok("<!DOCTYPE html><html><body><h1>Website Blocked</h1><p>Blocked by titanium web proxy.</p></body></html>");
            }
        }

        //Test script injection
        //Insert script to read the Browser URL and send it back to proxy
        public void OnResponse(object sender, SessionEventArgs e)
        {

            //read response headers
            var responseHeaders = e.ProxySession.Response.ResponseHeaders;

            //if (!e.ProxySession.Request.Host.Equals("medeczane.sgk.gov.tr")) return;
            if (e.RequestMethod == "GET" || e.RequestMethod == "POST")
            {
                if (e.ProxySession.Response.ResponseStatusCode == "200")
                {
                    if (e.ProxySession.Response.ContentType.Trim().ToLower().Contains("text/html"))
                    {
                        string body = e.GetResponseBodyAsString();
                    }
                }
            }
        }

        private Boolean checkIsFiltered(String uri)
        {
            //custom filter
            if (cBCustomFilter.Checked)
            {
                CheckedListBox.CheckedItemCollection items = checkedListBoxFilter.CheckedItems;
                if (items.Count == 0) return false;
                for (var i = 0; i < items.Count; i++)
                {                    
                    String str = items[i].ToString();
                    //String[] arr = Regex.Split(str, "=", RegexOptions.IgnoreCase);
                    if (uri.IndexOf(str) != -1) return true;
                }
            }

            //txt ad
            if (cBADFilter.Checked)
            {
                for (var i = 0; i < adList.Count; i++)
                {
                    if (uri.IndexOf(adList[i]) != -1) return true;
                }
            }

            //ad filter txt


            return false;
        }
        
        private void listBoxRequest_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (-1 == e.Index) return;

            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(
                listBoxRequest.Items[e.Index].ToString(),
                e.Font,
                new SolidBrush(ColorTranslator.FromHtml("#226")),
                e.Bounds);       
        }

        private void listBoxRequest_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 22;
        }

        private void buttonFilterAdd_Click(object sender, EventArgs e)
        {
            var text = textBoxFilter.Text.Replace(" ", "");
            CheckedListBox.ObjectCollection items = checkedListBoxFilter.Items;
            if (!items.Contains(text))
            {
                string[] one = {"1", text};
                if (add(one))
                {
                    checkedListBoxFilter.Items.Insert(0, text);
                    checkedListBoxFilter.SetItemChecked(0, true);
                    textBoxFilter.Text = "";
                };
            }
        }


        private void listBoxRequest_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 67 && e.Control)
            {
                Clipboard.SetDataObject(listBoxRequest.SelectedItem.ToString());
            }
        }

        private void listBoxRequest_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(listBoxRequest.SelectedItem.ToString()); 
        }

        private void checkedListBoxFilter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                string sval = checkedListBoxFilter.SelectedItem.ToString();
                if (delete(sval))
                {
                    checkedListBoxFilter.Items.Remove(sval);
                };
            }
        }

        private void listBoxBlock_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 67 && e.Control)
            {
                string url = listBoxBlock.SelectedItem.ToString();
                Clipboard.SetDataObject(ignoreUrl(url));
            }
        }

        private void listBoxBlock_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string url = listBoxBlock.SelectedItem.ToString();

            System.Diagnostics.Process.Start(ignoreUrl(url)); 
        }

        private string ignoreUrl(string url)
        {
            string tag = "proxy_ignore";
            string b = "";
            if (url.IndexOf(tag) == -1)
            {
                if (url.IndexOf("?") != -1)
                {
                    b = "&";
                }
                else
                {
                    b = "?";
                }
            }
            else
            {
                return url;
            }
            return url + b + tag;
        }

        private bool isIgnore(string url)
        {
            if (url.IndexOf("proxy_ignore") != -1)
            {
                return true;
            }
            return false;
        }

        private void listBoxTxt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(path);
            if(File.Exists(path))
                System.Diagnostics.Process.Start(path); 
        }


    }
}

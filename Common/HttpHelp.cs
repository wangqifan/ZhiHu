using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ProxyPool;
using System.Diagnostics;
using System.IO.Compression;

namespace Common
{
    public class HttpHelp
    {
        /// <summary>
        /// 下载字符资源
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>字符资源</returns>
        public static string DownLoadString(string url)
        {
            string Source = string.Empty;
            try
            {
                          //      string proxyHost = "http://proxy.abuyun.com";
                          //          string proxyPort = "9020";
                         //// 代理隧道验证信息
                         //           string proxyUser = "H71T6AMK";
                          //            string proxyPass = "D3F01F3AEFE";
                           //var proxy = new WebProxy();
                           //proxy.Address = new Uri(string.Format("{0}:{1}", proxyHost, proxyPort));
                         //proxy.Credentials = new NetworkCredential(proxyUser, proxyPass);
                       //ServicePointManager.Expect100Continue = false;

                Stopwatch watch = new Stopwatch();
                watch.Start();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0";
                request.Headers.Add("Cookie", "q_c1=bef33ea683c14b638c2fef767de44dfe|1487172008000|1487172008000; nweb_qa=heifetz; cap_id=\"YjA0YzE2NTNiNmJiNGJmNTg5OWU3ODg3MDViMmNlNGY=|1487172008|c117e23d8e30ece55661986f488fc71b1cac2d70\"; l_cap_id=\"NTUyNzI1YmI3YjFiNDIzZmFhMDFjMmRkZTQ1NTNiNTE=|1487172008|cef37823572d115e0516d9cd5636ee7b3d685aac\"; d_c0=\"ADACTKuqUAuPTqRNK1jlwFVVB5UMAWF2xa4=|1487172010\"; __utma=51854390.823056867.1487172012.1487172012.1487297915.2; __utmz=51854390.1487297915.2.2.utmcsr=baidu|utmccn=(organic)|utmcmd=organic; __utmv=51854390.100-1|2=registration_date=20160110=1^3=entry_date=20160110=1; _zap=d23fbaba-162b-4589-abc8-c522db9ea51c; login=\"YzQ5NWYwZmM2MjUwNGY5YmExY2ZmOTU5NWZkNmZjNTA=|1487172024|8083272b8da6b9f4748ca16aa0f0911237571cb8\"; z_c0=Mi4wQUJCS0c2ZmVTUWtBTUFKTXE2cFFDeGNBQUFCaEFsVk51UDdMV0FEZUVVeG5uemstVGp3QWpTNmFhaDhUZEp2ajNB|1487297910|e245fa93d2b5dfc750ec8cb8905b05b45b23c42a; aliyungf_tc=AQAAAAKFqQWEjA0A4p80OppgoVoEOjW+; _xsrf=0c935ac469ee8be47b7e6dabc801ccd0; __utmb=51854390.0.10.1487297915; __utmc=51854390");
                request.Headers.Add("Upgrade-Insecure-Requests", "1");
                request.Headers.Add("Cache-Control", "no-cach");
                request.Accept = "*/*";
                request.Method = "GET";
                request.Referer = "https://www.zhihu.com/";
                request.Headers.Add("Accept-Encoding", " gzip, deflate, br");
                request.KeepAlive = true;//启用长连接
               // request.Proxy = proxy;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {

                    using (Stream dataStream = response.GetResponseStream())
                    {

                        if (response.ContentEncoding.ToLower().Contains("gzip"))//解压
                        {
                            using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {
                                    Source = reader.ReadToEnd();
                                }
                            }
                        }
                        else if (response.ContentEncoding.ToLower().Contains("deflate"))//解压
                        {
                            using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {
                                    Source = reader.ReadToEnd();
                                }

                            }
                        }
                        else
                        {
                            using (Stream stream = response.GetResponseStream())//原始
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {

                                    Source = reader.ReadToEnd();
                                }
                            }
                        }

                    }
                }
                request.Abort();
                watch.Stop();
                Console.WriteLine("请求网页用了{0}毫秒", watch.ElapsedMilliseconds.ToString());
            }
            catch
            {
                Console.WriteLine("出错了，请求的URL为{0}", url);

            }
            return Source;
        }
        public static async Task<string> DownLoadStringAsync(string url)
        {
            return await Task<string>.Run(() =>
            {
                var Source = string.Empty;
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0";
                    request.Headers.Add("Authorization", "Bearer Mi4wQUJCS0c2ZmVTUWtBZ0FMRXpRWUxDeGNBQUFCaEFsVk5xLUNGV0FCSV96RnhlMFhXTEdyRDJLcHBBazVzYllFUmhB|1482576928|e8eb7aeafaa8967040018749e51b6117aac6268a");
                    request.Headers.Add("Cookie", "q_c1=83e6114181b446cf8d7466b7170722aa|1482498542000|1482498542000; l_cap_id=\"NWE1NTA1OTY4YzhkNGJkOWE5ZjlkMzRmNzJiZDJlN2Q=|1482576778|229fbce9a467bb4d775a2da16ad487d881f72985\"; cap_id=\"ZmIzZWIzZGE0OTAyNGI4Y2I2MDhjMjZiYjFmNzRlZDk=|1482576778|86cc3a713579014bb2842a210e2dbc697b9a7eac\"; d_c0=\"AIACxM0GCwuPThs-yU5VfWR2bZkix3yL2gI=|1482498542\"; r_cap_id=\"ZTI0OWVjYzNhNjZhNDM1MDg1YzEzYzMzZTY1NWYxNmY=|1482576780|c5947a54eb95b365735892d0048786cb0e87515c\"; __utma=51854390.1994869475.1482498545.1482498545.1482576782.2; __utmz=51854390.1482576782.2.2.utmcsr=baidu|utmccn=(organic)|utmcmd=organic; __utmv=51854390.100-1|2=registration_date=20160110=1^3=entry_date=20160110=1; _xsrf=4d75dd8958dfe9b129bef878f8d330a4; n_c=1; _zap=b4e1f464-b1e6-4a52-b272-231e749d5009; __utmb=51854390.13.9.1482576890989; __utmc=51854390; login=\"YTViZjk0Mzc2YjkwNDU1NDkyYjYwNzUzNGFlMmMyNTY=|1482576798|0d4999bd33997683a2677d550674cb9cedd772c0\"; z_c0=Mi4wQUJCS0c2ZmVTUWtBZ0FMRXpRWUxDeGNBQUFCaEFsVk5xLUNGV0FCSV96RnhlMFhXTEdyRDJLcHBBazVzYllFUmhB|1482576928|e8eb7aeafaa8967040018749e51b6117aac6268a");
                    request.Timeout = 6000;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream dataStream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(dataStream, Encoding.UTF8))
                            {
                                Source = reader.ReadToEnd();
                            }
                        }
                    }
                    request.Abort();
                }
                catch
                {
                    Console.WriteLine("请求资源出错，url为{0}", url);
                    DownLoadString(url);
                }
                return Source;
            });
        }
    }
}

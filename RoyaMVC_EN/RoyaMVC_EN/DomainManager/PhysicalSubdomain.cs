using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.Administration;
using System.IO;

namespace RoyaMVC_EN.DomainManager
{
    public class PhysicalSubdomain
    {
        public string ServerIP { get; set; }
        public int ServerPort { get; set; }
        public string LocalServerPath { get; set; }

        public PhysicalSubdomain(string serverIP, int serverPort, string localServerPath) {
            this.ServerIP = serverIP;
            this.ServerPort = serverPort;
            this.LocalServerPath = localServerPath;
        }


        public string CreatePhysicalSubdomain(string user, string subdomainName, string appPoolName, Action<string> sendMoreInfo) {
            //string path = this.LocalServerPath + subdomainName + "\\";
            //string userpath = path + user;
            //string userUrl = user + "." + subdomainName;

            //string path = this.LocalServerPath + user + "\\";
            string userpath = this.LocalServerPath + user + "\\" + subdomainName;
            string userUrl = subdomainName;

            using (ServerManager serverManager = new ServerManager()) {
                bool siteExists = false;
                int number = serverManager.Sites.Where(p => p.Name.ToLower() == userUrl.ToLower()).Count();

                siteExists = (number > 0);
                
                if (!siteExists) {
                    //create user directory
                    Directory.CreateDirectory(userpath);

                    try {

                        #region Copy default files

                        File.WriteAllText(userpath, Properties.Resources.Index.Replace("{BlogAddress}", userUrl)
                                                                              .Replace("{BlogPhysicalPath}", userpath));
                        ////copy every files from a-base to a new created folder
                        //FileInfo[] d = new DirectoryInfo(path + @"\a-base").GetFiles();
                        //foreach (FileInfo fi in d) {
                        //    File.Copy(fi.FullName, userpath + @"\" + fi.Name, true);
                        //}

                        ////create a directory
                        //Directory.CreateDirectory(userpath + @"\swfobject");

                        //FileInfo[] d1 = new DirectoryInfo(path + @"\a-base\swfobject").GetFiles();
                        //foreach (FileInfo fi in d1) {
                        //    File.Copy(fi.FullName, userpath + @"\swfobject\" + fi.Name, true);
                        //}
                        #endregion
                    }
                    catch (Exception ex) {
                        sendMoreInfo(ex.Message + ex.StackTrace);
                    }


                    //create site
                    //Site mySite = serverManager.Sites.Add(userUrl, path + user, ServerPort);
                    Site mySite = serverManager.Sites.Add(userUrl, userpath, ServerPort);
                    mySite.ServerAutoStart = true;
                    mySite.Applications[0].ApplicationPoolName = appPoolName;

                    //create bindings
                    mySite.Bindings.Clear();
                    mySite.Bindings.Add(string.Format("{0}:{2}:{1}", ServerIP, userUrl, ServerPort), "http");
                    mySite.Bindings.Add(string.Format("{0}:{2}:www.{1}", ServerIP, userUrl, ServerPort), "http");


                    Configuration config = serverManager.GetApplicationHostConfiguration();
                    ConfigurationSection httpLoggingSection = config.GetSection("system.webServer/httpLogging", userUrl);
                    httpLoggingSection["dontLog"] = true;

                    sendMoreInfo("IsLocallyStored: " + httpLoggingSection.IsLocallyStored.ToString());
                    sendMoreInfo("IsLocked: " + httpLoggingSection.IsLocked.ToString());

                    serverManager.CommitChanges();

                    //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('" + userUrl + " created');", true);
                }
                else {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "error", "alert('user exists. Please use other name');", true);
                    throw new Exception("user exists. Please use other name");
                }


                return userUrl + " has been successfully created";
            }
        }
    }
}

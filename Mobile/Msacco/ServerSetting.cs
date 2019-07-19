// Decompiled with JetBrains decompiler
// Type: M_SACCO_Webservice.ServerSetting
// Assembly: M-SACCO Webservice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F0157AEC-175E-4D5E-A397-15B9A7805B87
// Assembly location: D:\M-Sacco\Bandari\M-SACCO Webservice.dll

using System.IO;

namespace Msacco
{
  public class ServerSetting
  {
    public string server;
    public string db;
    public string user;
    public string pass;
    public string Companyname;
    public string domain;
    public string Port;
    public string Instance;

    public void getsettings(string path)
    {
      using (StreamReader streamReader = new StreamReader(path))
      {
        this.server = streamReader.ReadLine();
        this.Port = streamReader.ReadLine();
        this.db = streamReader.ReadLine();
        this.user = streamReader.ReadLine();
        this.pass = streamReader.ReadLine();
        this.domain = streamReader.ReadLine();
        this.Companyname = streamReader.ReadLine();
        this.Instance = streamReader.ReadLine();
        CUtilities.logpath = streamReader.ReadLine();
      }
    }
  }
}

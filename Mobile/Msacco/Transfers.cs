// Decompiled with JetBrains decompiler
// Type: M_SACCO_Webservice.Transfers
// Assembly: M-SACCO Webservice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F0157AEC-175E-4D5E-A397-15B9A7805B87
// Assembly location: D:\M-Sacco\Bandari\M-SACCO Webservice.dll

using System;

namespace Msacco
{
  public class Transfers
  {
    public bool Hasresults = true;
    public string From_Account;
    public string To_Account;
    public Decimal Amount;
    public string Reference;
    public string Results;
    public string Errors;
    public Transfers.transfertype ttype;

    public enum transfertype
    {
      FosaFosa,
      FosaBosa,
    }
  }
}

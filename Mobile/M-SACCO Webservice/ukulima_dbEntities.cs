// Decompiled with JetBrains decompiler
// Type: M_SACCO_Webservice.ukulima_dbEntities
// Assembly: M-SACCO Webservice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F0157AEC-175E-4D5E-A397-15B9A7805B87
// Assembly location: D:\M-Sacco\Bandari\M-SACCO Webservice.dll

using System.Data.EntityClient;
using System.Data.Objects;

namespace M_SACCO_Webservice
{
  public class ukulima_dbEntities : ObjectContext
  {
    private ObjectSet<M_SACCO_Webservice.UKULIMA_SACCO_LTD_ATM_Transactions> _UKULIMA_SACCO_LTD_ATM_Transactions;
    private ObjectSet<M_SACCO_Webservice.UKULIMA_SACCO_LTD_Vendor> _UKULIMA_SACCO_LTD_Vendor;

    public ObjectSet<M_SACCO_Webservice.UKULIMA_SACCO_LTD_ATM_Transactions> UKULIMA_SACCO_LTD_ATM_Transactions
    {
      get
      {
        if (this._UKULIMA_SACCO_LTD_ATM_Transactions == null)
          this._UKULIMA_SACCO_LTD_ATM_Transactions = this.CreateObjectSet<M_SACCO_Webservice.UKULIMA_SACCO_LTD_ATM_Transactions>("UKULIMA_SACCO_LTD_ATM_Transactions");
        return this._UKULIMA_SACCO_LTD_ATM_Transactions;
      }
    }

    public ObjectSet<M_SACCO_Webservice.UKULIMA_SACCO_LTD_Vendor> UKULIMA_SACCO_LTD_Vendor
    {
      get
      {
        if (this._UKULIMA_SACCO_LTD_Vendor == null)
          this._UKULIMA_SACCO_LTD_Vendor = this.CreateObjectSet<M_SACCO_Webservice.UKULIMA_SACCO_LTD_Vendor>("UKULIMA_SACCO_LTD_Vendor");
        return this._UKULIMA_SACCO_LTD_Vendor;
      }
    }

    public ukulima_dbEntities()
      : base("name=ukulima_dbEntities", "ukulima_dbEntities")
    {
    }

    public ukulima_dbEntities(string connectionString)
      : base(connectionString, "ukulima_dbEntities")
    {
    }

    public ukulima_dbEntities(EntityConnection connection)
      : base(connection, "ukulima_dbEntities")
    {
    }

    public void AddToUKULIMA_SACCO_LTD_ATM_Transactions(M_SACCO_Webservice.UKULIMA_SACCO_LTD_ATM_Transactions uKULIMA_SACCO_LTD_ATM_Transactions)
    {
      this.AddObject("UKULIMA_SACCO_LTD_ATM_Transactions", (object) uKULIMA_SACCO_LTD_ATM_Transactions);
    }

    public void AddToUKULIMA_SACCO_LTD_Vendor(M_SACCO_Webservice.UKULIMA_SACCO_LTD_Vendor uKULIMA_SACCO_LTD_Vendor)
    {
      this.AddObject("UKULIMA_SACCO_LTD_Vendor", (object) uKULIMA_SACCO_LTD_Vendor);
    }
  }
}

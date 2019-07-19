// Decompiled with JetBrains decompiler
// Type: M_SACCO_Webservice.UKULIMA_SACCO_LTD_ATM_Transactions
// Assembly: M-SACCO Webservice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F0157AEC-175E-4D5E-A397-15B9A7805B87
// Assembly location: D:\M-Sacco\Bandari\M-SACCO Webservice.dll

using System;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace M_SACCO_Webservice
{
  [DataContract(IsReference = true)]
  [EdmEntityType(Name = "UKULIMA_SACCO_LTD_ATM_Transactions", NamespaceName = "Model")]
  [Serializable]
  public class UKULIMA_SACCO_LTD_ATM_Transactions : EntityObject
  {
    private byte[] _timestamp;
    private int _Entry_No;
    private string _Trace_ID;
    private DateTime _Posting_Date;
    private string _Account_No;
    private string _Description;
    private Decimal _Amount;
    private string _Posting_S;
    private byte _Posted;
    private string _Unit_ID;
    private string _Transaction_Type;
    private string _Trans_Time;
    private string _Process_Code;
    private byte _Reversed;
    private byte _Reversed_Posted;
    private string _Reversal_Trace_ID;
    private string _Transaction_Description;
    private string _Withdrawal_Location;
    private int _Source;
    private int _Transaction_Type_Charges;
    private string _Card_Acceptor_Terminal_ID;
    private string _ATM_Card_No;
    private DateTime _Transaction_Date;
    private byte _Is_Coop_Bank;
    private int _POS_Vendor;
    private string _Reference_No;

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public byte[] timestamp
    {
      get
      {
        return StructuralObject.GetValidValue(this._timestamp);
      }
      set
      {
        this.ReportPropertyChanging("timestamp");
        this._timestamp = StructuralObject.SetValidValue(value, true);
        this.ReportPropertyChanged("timestamp");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false)]
    public int Entry_No
    {
      get
      {
        return this._Entry_No;
      }
      set
      {
        if (this._Entry_No == value)
          return;
        this.ReportPropertyChanging("Entry_No");
        this._Entry_No = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Entry_No");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Trace_ID
    {
      get
      {
        return this._Trace_ID;
      }
      set
      {
        this.ReportPropertyChanging("Trace_ID");
        this._Trace_ID = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Trace_ID");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public DateTime Posting_Date
    {
      get
      {
        return this._Posting_Date;
      }
      set
      {
        this.ReportPropertyChanging("Posting_Date");
        this._Posting_Date = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Posting_Date");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Account_No
    {
      get
      {
        return this._Account_No;
      }
      set
      {
        this.ReportPropertyChanging("Account_No");
        this._Account_No = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Account_No");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Description
    {
      get
      {
        return this._Description;
      }
      set
      {
        this.ReportPropertyChanging("Description");
        this._Description = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Description");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public Decimal Amount
    {
      get
      {
        return this._Amount;
      }
      set
      {
        this.ReportPropertyChanging("Amount");
        this._Amount = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Amount");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Posting_S
    {
      get
      {
        return this._Posting_S;
      }
      set
      {
        this.ReportPropertyChanging("Posting_S");
        this._Posting_S = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Posting_S");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public byte Posted
    {
      get
      {
        return this._Posted;
      }
      set
      {
        this.ReportPropertyChanging("Posted");
        this._Posted = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Posted");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Unit_ID
    {
      get
      {
        return this._Unit_ID;
      }
      set
      {
        this.ReportPropertyChanging("Unit_ID");
        this._Unit_ID = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Unit_ID");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Transaction_Type
    {
      get
      {
        return this._Transaction_Type;
      }
      set
      {
        this.ReportPropertyChanging("Transaction_Type");
        this._Transaction_Type = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Transaction_Type");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Trans_Time
    {
      get
      {
        return this._Trans_Time;
      }
      set
      {
        this.ReportPropertyChanging("Trans_Time");
        this._Trans_Time = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Trans_Time");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Process_Code
    {
      get
      {
        return this._Process_Code;
      }
      set
      {
        this.ReportPropertyChanging("Process_Code");
        this._Process_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Process_Code");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public byte Reversed
    {
      get
      {
        return this._Reversed;
      }
      set
      {
        this.ReportPropertyChanging("Reversed");
        this._Reversed = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Reversed");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public byte Reversed_Posted
    {
      get
      {
        return this._Reversed_Posted;
      }
      set
      {
        this.ReportPropertyChanging("Reversed_Posted");
        this._Reversed_Posted = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Reversed_Posted");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Reversal_Trace_ID
    {
      get
      {
        return this._Reversal_Trace_ID;
      }
      set
      {
        this.ReportPropertyChanging("Reversal_Trace_ID");
        this._Reversal_Trace_ID = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Reversal_Trace_ID");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Transaction_Description
    {
      get
      {
        return this._Transaction_Description;
      }
      set
      {
        this.ReportPropertyChanging("Transaction_Description");
        this._Transaction_Description = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Transaction_Description");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Withdrawal_Location
    {
      get
      {
        return this._Withdrawal_Location;
      }
      set
      {
        this.ReportPropertyChanging("Withdrawal_Location");
        this._Withdrawal_Location = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Withdrawal_Location");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public int Source
    {
      get
      {
        return this._Source;
      }
      set
      {
        this.ReportPropertyChanging("Source");
        this._Source = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Source");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public int Transaction_Type_Charges
    {
      get
      {
        return this._Transaction_Type_Charges;
      }
      set
      {
        this.ReportPropertyChanging("Transaction_Type_Charges");
        this._Transaction_Type_Charges = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Transaction_Type_Charges");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Card_Acceptor_Terminal_ID
    {
      get
      {
        return this._Card_Acceptor_Terminal_ID;
      }
      set
      {
        this.ReportPropertyChanging("Card_Acceptor_Terminal_ID");
        this._Card_Acceptor_Terminal_ID = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Card_Acceptor_Terminal_ID");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string ATM_Card_No
    {
      get
      {
        return this._ATM_Card_No;
      }
      set
      {
        this.ReportPropertyChanging("ATM_Card_No");
        this._ATM_Card_No = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("ATM_Card_No");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public DateTime Transaction_Date
    {
      get
      {
        return this._Transaction_Date;
      }
      set
      {
        this.ReportPropertyChanging("Transaction_Date");
        this._Transaction_Date = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Transaction_Date");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public byte Is_Coop_Bank
    {
      get
      {
        return this._Is_Coop_Bank;
      }
      set
      {
        this.ReportPropertyChanging("Is_Coop_Bank");
        this._Is_Coop_Bank = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Is_Coop_Bank");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public int POS_Vendor
    {
      get
      {
        return this._POS_Vendor;
      }
      set
      {
        this.ReportPropertyChanging("POS_Vendor");
        this._POS_Vendor = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("POS_Vendor");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Reference_No
    {
      get
      {
        return this._Reference_No;
      }
      set
      {
        this.ReportPropertyChanging("Reference_No");
        this._Reference_No = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Reference_No");
      }
    }

    public static UKULIMA_SACCO_LTD_ATM_Transactions CreateUKULIMA_SACCO_LTD_ATM_Transactions(byte[] timestamp, int entry_No, string trace_ID, DateTime posting_Date, string account_No, string description, Decimal amount, string posting_S, byte posted, string unit_ID, string transaction_Type, string trans_Time, string process_Code, byte reversed, byte reversed_Posted, string reversal_Trace_ID, string transaction_Description, string withdrawal_Location, int source, int transaction_Type_Charges, string card_Acceptor_Terminal_ID, string aTM_Card_No, DateTime transaction_Date, byte is_Coop_Bank, int pOS_Vendor, string reference_No)
    {
      return new UKULIMA_SACCO_LTD_ATM_Transactions()
      {
        timestamp = timestamp,
        Entry_No = entry_No,
        Trace_ID = trace_ID,
        Posting_Date = posting_Date,
        Account_No = account_No,
        Description = description,
        Amount = amount,
        Posting_S = posting_S,
        Posted = posted,
        Unit_ID = unit_ID,
        Transaction_Type = transaction_Type,
        Trans_Time = trans_Time,
        Process_Code = process_Code,
        Reversed = reversed,
        Reversed_Posted = reversed_Posted,
        Reversal_Trace_ID = reversal_Trace_ID,
        Transaction_Description = transaction_Description,
        Withdrawal_Location = withdrawal_Location,
        Source = source,
        Transaction_Type_Charges = transaction_Type_Charges,
        Card_Acceptor_Terminal_ID = card_Acceptor_Terminal_ID,
        ATM_Card_No = aTM_Card_No,
        Transaction_Date = transaction_Date,
        Is_Coop_Bank = is_Coop_Bank,
        POS_Vendor = pOS_Vendor,
        Reference_No = reference_No
      };
    }
  }
}

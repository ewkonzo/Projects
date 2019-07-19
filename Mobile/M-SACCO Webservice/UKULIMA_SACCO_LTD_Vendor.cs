// Decompiled with JetBrains decompiler
// Type: M_SACCO_Webservice.UKULIMA_SACCO_LTD_Vendor
// Assembly: M-SACCO Webservice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F0157AEC-175E-4D5E-A397-15B9A7805B87
// Assembly location: D:\M-Sacco\Bandari\M-SACCO Webservice.dll

using System;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace M_SACCO_Webservice
{
  [DataContract(IsReference = true)]
  [EdmEntityType(Name = "UKULIMA_SACCO_LTD_Vendor", NamespaceName = "Model")]
  [Serializable]
  public class UKULIMA_SACCO_LTD_Vendor : EntityObject
  {
    private byte[] _timestamp;
    private string _No_;
    private string _Name;
    private string _Search_Name;
    private string _Name_2;
    private string _Address;
    private string _Address_2;
    private string _City;
    private string _Contact;
    private string _Phone_No_;
    private string _Telex_No_;
    private string _Our_Account_No_;
    private string _Territory_Code;
    private string _Global_Dimension_1_Code;
    private string _Global_Dimension_2_Code;
    private Decimal _Budgeted_Amount;
    private string _Vendor_Posting_Group;
    private string _Currency_Code;
    private string _Language_Code;
    private int _Statistics_Group;
    private string _Payment_Terms_Code;
    private string _Fin__Charge_Terms_Code;
    private string _Purchaser_Code;
    private string _Shipment_Method_Code;
    private string _Shipping_Agent_Code;
    private string _Invoice_Disc__Code;
    private string _Country_Region_Code;
    private int _Blocked;
    private string _Pay_to_Vendor_No_;
    private int _Priority;
    private string _Payment_Method_Code;
    private DateTime _Last_Date_Modified;
    private int _Application_Method;
    private byte _Prices_Including_VAT;
    private string _Fax_No_;
    private string _Telex_Answer_Back;
    private string _VAT_Registration_No_;
    private string _Gen__Bus__Posting_Group;
    private byte[] _Picture;
    private string _Post_Code;
    private string _County;
    private string _E_Mail;
    private string _Home_Page;
    private string _No__Series;
    private string _Tax_Area_Code;
    private byte _Tax_Liable;
    private string _VAT_Bus__Posting_Group;
    private byte _Block_Payment_Tolerance;
    private string _IC_Partner_Code;
    private Decimal _Prepayment__;
    private string _Primary_Contact_No_;
    private string _Responsibility_Center;
    private string _Location_Code;
    private string _Lead_Time_Calculation;
    private string _Base_Calendar_Code;
    private int _Creditor_Type;
    private string _Staff_No;
    private string _ID_No_;
    private DateTime _Last_Maintenance_Date;
    private byte _Activate_Sweeping_Arrangement;
    private Decimal _Sweeping_Balance;
    private string _Sweep_To_Account;
    private int _Fixed_Deposit_Status;
    private byte _Call_Deposit;
    private string _Mobile_Phone_No;
    private int _Marital_Status;
    private DateTime _Registration_Date;
    private string _BOSA_Account_No;
    private byte[] _Signature;
    private string _Passport_No_;
    private string _Company_Code;
    private int _Status;
    private string _Account_Type;
    private int _Account_Category;
    private byte _FD_Marked_for_Closure;
    private DateTime _Last_Withdrawal_Date;
    private DateTime _Last_Overdraft_Date;
    private DateTime _Last_Min__Balance_Date;
    private DateTime _Last_Deposit_Date;
    private DateTime _Last_Transaction_Posting_Date;
    private DateTime _Date_Closed;
    private DateTime _Expected_Maturity_Date;
    private DateTime _Date_of_Birth;
    private string _E_Mail__Personal_;
    private string _Section;
    private string _ATM_No_;
    private string _Home_Address;
    private string _Location;
    private string _Sub_Location;
    private string _District;
    private string _Resons_for_Status_Change;
    private DateTime _Closure_Notice_Date;
    private string _Fixed_Deposit_Type;
    private DateTime _FD_Maturity_Date;
    private string _Savings_Account_No_;
    private string _Old_Account_No_;
    private byte _Salary_Processing;
    private Decimal _Amount_to_Transfer;
    private string _Proffesion;
    private string _Signing_Instructions;
    private byte _Hide;
    private Decimal _Monthly_Contribution;
    private byte _Not_Qualify_for_Interest;
    private int _Gender;
    private string _Fixed_Duration;
    private byte _System_Created;
    private string _External_Account_No;
    private string _Bank_Code;
    private byte _Enabled;
    private byte _Defaulted_Loans_Recovered;
    private string _Formation_Province;
    private string _Division_Department;
    private string _Station_Sections;
    private Decimal _Neg__Interest_Rate;
    private DateTime _Date_Renewed;
    private byte _Don_t_Transfer_to_Savings;
    private int _Type_Of_Organisation;
    private int _Source_Of_Funds;
    private string _MPESA_Mobile_No;
    private string _Force_No_;
    private DateTime _Card_Expiry_Date;
    private DateTime _Card_Valid_From;
    private DateTime _Card_Valid_To;
    private string _Service;
    private Decimal _Fox_SBal;
    private Decimal _ABal_Fox;
    private string _ATM_Prov__No;
    private byte _ATM_Approve;
    private byte _Reconciled;
    private int _FD_Duration;
    private string _Employer_P_F;
    private byte _Atm_card_ready;
    private DateTime _Date_ATM_Linked;
    private byte _Fosa_s_no_Bosa_No;
    private Decimal _Outstanding_Balance;

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
    public string No_
    {
      get
      {
        return this._No_;
      }
      set
      {
        if (!(this._No_ != value))
          return;
        this.ReportPropertyChanging("No_");
        this._No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("No_");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Name
    {
      get
      {
        return this._Name;
      }
      set
      {
        this.ReportPropertyChanging("Name");
        this._Name = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Name");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Search_Name
    {
      get
      {
        return this._Search_Name;
      }
      set
      {
        this.ReportPropertyChanging("Search_Name");
        this._Search_Name = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Search_Name");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Name_2
    {
      get
      {
        return this._Name_2;
      }
      set
      {
        this.ReportPropertyChanging("Name_2");
        this._Name_2 = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Name_2");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Address
    {
      get
      {
        return this._Address;
      }
      set
      {
        this.ReportPropertyChanging("Address");
        this._Address = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Address");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Address_2
    {
      get
      {
        return this._Address_2;
      }
      set
      {
        this.ReportPropertyChanging("Address_2");
        this._Address_2 = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Address_2");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string City
    {
      get
      {
        return this._City;
      }
      set
      {
        this.ReportPropertyChanging("City");
        this._City = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("City");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Contact
    {
      get
      {
        return this._Contact;
      }
      set
      {
        this.ReportPropertyChanging("Contact");
        this._Contact = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Contact");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Phone_No_
    {
      get
      {
        return this._Phone_No_;
      }
      set
      {
        this.ReportPropertyChanging("Phone_No_");
        this._Phone_No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Phone_No_");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Telex_No_
    {
      get
      {
        return this._Telex_No_;
      }
      set
      {
        this.ReportPropertyChanging("Telex_No_");
        this._Telex_No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Telex_No_");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Our_Account_No_
    {
      get
      {
        return this._Our_Account_No_;
      }
      set
      {
        this.ReportPropertyChanging("Our_Account_No_");
        this._Our_Account_No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Our_Account_No_");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Territory_Code
    {
      get
      {
        return this._Territory_Code;
      }
      set
      {
        this.ReportPropertyChanging("Territory_Code");
        this._Territory_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Territory_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Global_Dimension_1_Code
    {
      get
      {
        return this._Global_Dimension_1_Code;
      }
      set
      {
        this.ReportPropertyChanging("Global_Dimension_1_Code");
        this._Global_Dimension_1_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Global_Dimension_1_Code");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Global_Dimension_2_Code
    {
      get
      {
        return this._Global_Dimension_2_Code;
      }
      set
      {
        this.ReportPropertyChanging("Global_Dimension_2_Code");
        this._Global_Dimension_2_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Global_Dimension_2_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public Decimal Budgeted_Amount
    {
      get
      {
        return this._Budgeted_Amount;
      }
      set
      {
        this.ReportPropertyChanging("Budgeted_Amount");
        this._Budgeted_Amount = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Budgeted_Amount");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Vendor_Posting_Group
    {
      get
      {
        return this._Vendor_Posting_Group;
      }
      set
      {
        this.ReportPropertyChanging("Vendor_Posting_Group");
        this._Vendor_Posting_Group = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Vendor_Posting_Group");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Currency_Code
    {
      get
      {
        return this._Currency_Code;
      }
      set
      {
        this.ReportPropertyChanging("Currency_Code");
        this._Currency_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Currency_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Language_Code
    {
      get
      {
        return this._Language_Code;
      }
      set
      {
        this.ReportPropertyChanging("Language_Code");
        this._Language_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Language_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public int Statistics_Group
    {
      get
      {
        return this._Statistics_Group;
      }
      set
      {
        this.ReportPropertyChanging("Statistics_Group");
        this._Statistics_Group = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Statistics_Group");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Payment_Terms_Code
    {
      get
      {
        return this._Payment_Terms_Code;
      }
      set
      {
        this.ReportPropertyChanging("Payment_Terms_Code");
        this._Payment_Terms_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Payment_Terms_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Fin__Charge_Terms_Code
    {
      get
      {
        return this._Fin__Charge_Terms_Code;
      }
      set
      {
        this.ReportPropertyChanging("Fin__Charge_Terms_Code");
        this._Fin__Charge_Terms_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Fin__Charge_Terms_Code");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Purchaser_Code
    {
      get
      {
        return this._Purchaser_Code;
      }
      set
      {
        this.ReportPropertyChanging("Purchaser_Code");
        this._Purchaser_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Purchaser_Code");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Shipment_Method_Code
    {
      get
      {
        return this._Shipment_Method_Code;
      }
      set
      {
        this.ReportPropertyChanging("Shipment_Method_Code");
        this._Shipment_Method_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Shipment_Method_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Shipping_Agent_Code
    {
      get
      {
        return this._Shipping_Agent_Code;
      }
      set
      {
        this.ReportPropertyChanging("Shipping_Agent_Code");
        this._Shipping_Agent_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Shipping_Agent_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Invoice_Disc__Code
    {
      get
      {
        return this._Invoice_Disc__Code;
      }
      set
      {
        this.ReportPropertyChanging("Invoice_Disc__Code");
        this._Invoice_Disc__Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Invoice_Disc__Code");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Country_Region_Code
    {
      get
      {
        return this._Country_Region_Code;
      }
      set
      {
        this.ReportPropertyChanging("Country_Region_Code");
        this._Country_Region_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Country_Region_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public int Blocked
    {
      get
      {
        return this._Blocked;
      }
      set
      {
        this.ReportPropertyChanging("Blocked");
        this._Blocked = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Blocked");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Pay_to_Vendor_No_
    {
      get
      {
        return this._Pay_to_Vendor_No_;
      }
      set
      {
        this.ReportPropertyChanging("Pay_to_Vendor_No_");
        this._Pay_to_Vendor_No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Pay_to_Vendor_No_");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public int Priority
    {
      get
      {
        return this._Priority;
      }
      set
      {
        this.ReportPropertyChanging("Priority");
        this._Priority = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Priority");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Payment_Method_Code
    {
      get
      {
        return this._Payment_Method_Code;
      }
      set
      {
        this.ReportPropertyChanging("Payment_Method_Code");
        this._Payment_Method_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Payment_Method_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public DateTime Last_Date_Modified
    {
      get
      {
        return this._Last_Date_Modified;
      }
      set
      {
        this.ReportPropertyChanging("Last_Date_Modified");
        this._Last_Date_Modified = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Last_Date_Modified");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public int Application_Method
    {
      get
      {
        return this._Application_Method;
      }
      set
      {
        this.ReportPropertyChanging("Application_Method");
        this._Application_Method = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Application_Method");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public byte Prices_Including_VAT
    {
      get
      {
        return this._Prices_Including_VAT;
      }
      set
      {
        this.ReportPropertyChanging("Prices_Including_VAT");
        this._Prices_Including_VAT = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Prices_Including_VAT");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Fax_No_
    {
      get
      {
        return this._Fax_No_;
      }
      set
      {
        this.ReportPropertyChanging("Fax_No_");
        this._Fax_No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Fax_No_");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Telex_Answer_Back
    {
      get
      {
        return this._Telex_Answer_Back;
      }
      set
      {
        this.ReportPropertyChanging("Telex_Answer_Back");
        this._Telex_Answer_Back = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Telex_Answer_Back");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string VAT_Registration_No_
    {
      get
      {
        return this._VAT_Registration_No_;
      }
      set
      {
        this.ReportPropertyChanging("VAT_Registration_No_");
        this._VAT_Registration_No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("VAT_Registration_No_");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Gen__Bus__Posting_Group
    {
      get
      {
        return this._Gen__Bus__Posting_Group;
      }
      set
      {
        this.ReportPropertyChanging("Gen__Bus__Posting_Group");
        this._Gen__Bus__Posting_Group = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Gen__Bus__Posting_Group");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true)]
    [DataMember]
    public byte[] Picture
    {
      get
      {
        return StructuralObject.GetValidValue(this._Picture);
      }
      set
      {
        this.ReportPropertyChanging("Picture");
        this._Picture = StructuralObject.SetValidValue(value, true);
        this.ReportPropertyChanged("Picture");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Post_Code
    {
      get
      {
        return this._Post_Code;
      }
      set
      {
        this.ReportPropertyChanging("Post_Code");
        this._Post_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Post_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string County
    {
      get
      {
        return this._County;
      }
      set
      {
        this.ReportPropertyChanging("County");
        this._County = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("County");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string E_Mail
    {
      get
      {
        return this._E_Mail;
      }
      set
      {
        this.ReportPropertyChanging("E_Mail");
        this._E_Mail = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("E_Mail");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Home_Page
    {
      get
      {
        return this._Home_Page;
      }
      set
      {
        this.ReportPropertyChanging("Home_Page");
        this._Home_Page = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Home_Page");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string No__Series
    {
      get
      {
        return this._No__Series;
      }
      set
      {
        this.ReportPropertyChanging("No__Series");
        this._No__Series = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("No__Series");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Tax_Area_Code
    {
      get
      {
        return this._Tax_Area_Code;
      }
      set
      {
        this.ReportPropertyChanging("Tax_Area_Code");
        this._Tax_Area_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Tax_Area_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public byte Tax_Liable
    {
      get
      {
        return this._Tax_Liable;
      }
      set
      {
        this.ReportPropertyChanging("Tax_Liable");
        this._Tax_Liable = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Tax_Liable");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string VAT_Bus__Posting_Group
    {
      get
      {
        return this._VAT_Bus__Posting_Group;
      }
      set
      {
        this.ReportPropertyChanging("VAT_Bus__Posting_Group");
        this._VAT_Bus__Posting_Group = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("VAT_Bus__Posting_Group");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public byte Block_Payment_Tolerance
    {
      get
      {
        return this._Block_Payment_Tolerance;
      }
      set
      {
        this.ReportPropertyChanging("Block_Payment_Tolerance");
        this._Block_Payment_Tolerance = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Block_Payment_Tolerance");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string IC_Partner_Code
    {
      get
      {
        return this._IC_Partner_Code;
      }
      set
      {
        this.ReportPropertyChanging("IC_Partner_Code");
        this._IC_Partner_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("IC_Partner_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public Decimal Prepayment__
    {
      get
      {
        return this._Prepayment__;
      }
      set
      {
        this.ReportPropertyChanging("Prepayment__");
        this._Prepayment__ = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Prepayment__");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Primary_Contact_No_
    {
      get
      {
        return this._Primary_Contact_No_;
      }
      set
      {
        this.ReportPropertyChanging("Primary_Contact_No_");
        this._Primary_Contact_No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Primary_Contact_No_");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Responsibility_Center
    {
      get
      {
        return this._Responsibility_Center;
      }
      set
      {
        this.ReportPropertyChanging("Responsibility_Center");
        this._Responsibility_Center = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Responsibility_Center");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Location_Code
    {
      get
      {
        return this._Location_Code;
      }
      set
      {
        this.ReportPropertyChanging("Location_Code");
        this._Location_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Location_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Lead_Time_Calculation
    {
      get
      {
        return this._Lead_Time_Calculation;
      }
      set
      {
        this.ReportPropertyChanging("Lead_Time_Calculation");
        this._Lead_Time_Calculation = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Lead_Time_Calculation");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Base_Calendar_Code
    {
      get
      {
        return this._Base_Calendar_Code;
      }
      set
      {
        this.ReportPropertyChanging("Base_Calendar_Code");
        this._Base_Calendar_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Base_Calendar_Code");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public int Creditor_Type
    {
      get
      {
        return this._Creditor_Type;
      }
      set
      {
        this.ReportPropertyChanging("Creditor_Type");
        this._Creditor_Type = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Creditor_Type");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Staff_No
    {
      get
      {
        return this._Staff_No;
      }
      set
      {
        this.ReportPropertyChanging("Staff_No");
        this._Staff_No = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Staff_No");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string ID_No_
    {
      get
      {
        return this._ID_No_;
      }
      set
      {
        this.ReportPropertyChanging("ID_No_");
        this._ID_No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("ID_No_");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public DateTime Last_Maintenance_Date
    {
      get
      {
        return this._Last_Maintenance_Date;
      }
      set
      {
        this.ReportPropertyChanging("Last_Maintenance_Date");
        this._Last_Maintenance_Date = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Last_Maintenance_Date");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public byte Activate_Sweeping_Arrangement
    {
      get
      {
        return this._Activate_Sweeping_Arrangement;
      }
      set
      {
        this.ReportPropertyChanging("Activate_Sweeping_Arrangement");
        this._Activate_Sweeping_Arrangement = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Activate_Sweeping_Arrangement");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public Decimal Sweeping_Balance
    {
      get
      {
        return this._Sweeping_Balance;
      }
      set
      {
        this.ReportPropertyChanging("Sweeping_Balance");
        this._Sweeping_Balance = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Sweeping_Balance");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Sweep_To_Account
    {
      get
      {
        return this._Sweep_To_Account;
      }
      set
      {
        this.ReportPropertyChanging("Sweep_To_Account");
        this._Sweep_To_Account = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Sweep_To_Account");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public int Fixed_Deposit_Status
    {
      get
      {
        return this._Fixed_Deposit_Status;
      }
      set
      {
        this.ReportPropertyChanging("Fixed_Deposit_Status");
        this._Fixed_Deposit_Status = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Fixed_Deposit_Status");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public byte Call_Deposit
    {
      get
      {
        return this._Call_Deposit;
      }
      set
      {
        this.ReportPropertyChanging("Call_Deposit");
        this._Call_Deposit = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Call_Deposit");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Mobile_Phone_No
    {
      get
      {
        return this._Mobile_Phone_No;
      }
      set
      {
        this.ReportPropertyChanging("Mobile_Phone_No");
        this._Mobile_Phone_No = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Mobile_Phone_No");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public int Marital_Status
    {
      get
      {
        return this._Marital_Status;
      }
      set
      {
        this.ReportPropertyChanging("Marital_Status");
        this._Marital_Status = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Marital_Status");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public DateTime Registration_Date
    {
      get
      {
        return this._Registration_Date;
      }
      set
      {
        this.ReportPropertyChanging("Registration_Date");
        this._Registration_Date = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Registration_Date");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string BOSA_Account_No
    {
      get
      {
        return this._BOSA_Account_No;
      }
      set
      {
        this.ReportPropertyChanging("BOSA_Account_No");
        this._BOSA_Account_No = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("BOSA_Account_No");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true)]
    public byte[] Signature
    {
      get
      {
        return StructuralObject.GetValidValue(this._Signature);
      }
      set
      {
        this.ReportPropertyChanging("Signature");
        this._Signature = StructuralObject.SetValidValue(value, true);
        this.ReportPropertyChanged("Signature");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Passport_No_
    {
      get
      {
        return this._Passport_No_;
      }
      set
      {
        this.ReportPropertyChanging("Passport_No_");
        this._Passport_No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Passport_No_");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Company_Code
    {
      get
      {
        return this._Company_Code;
      }
      set
      {
        this.ReportPropertyChanging("Company_Code");
        this._Company_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Company_Code");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public int Status
    {
      get
      {
        return this._Status;
      }
      set
      {
        this.ReportPropertyChanging("Status");
        this._Status = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Status");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Account_Type
    {
      get
      {
        return this._Account_Type;
      }
      set
      {
        this.ReportPropertyChanging("Account_Type");
        this._Account_Type = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Account_Type");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public int Account_Category
    {
      get
      {
        return this._Account_Category;
      }
      set
      {
        this.ReportPropertyChanging("Account_Category");
        this._Account_Category = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Account_Category");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public byte FD_Marked_for_Closure
    {
      get
      {
        return this._FD_Marked_for_Closure;
      }
      set
      {
        this.ReportPropertyChanging("FD_Marked_for_Closure");
        this._FD_Marked_for_Closure = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("FD_Marked_for_Closure");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public DateTime Last_Withdrawal_Date
    {
      get
      {
        return this._Last_Withdrawal_Date;
      }
      set
      {
        this.ReportPropertyChanging("Last_Withdrawal_Date");
        this._Last_Withdrawal_Date = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Last_Withdrawal_Date");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public DateTime Last_Overdraft_Date
    {
      get
      {
        return this._Last_Overdraft_Date;
      }
      set
      {
        this.ReportPropertyChanging("Last_Overdraft_Date");
        this._Last_Overdraft_Date = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Last_Overdraft_Date");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public DateTime Last_Min__Balance_Date
    {
      get
      {
        return this._Last_Min__Balance_Date;
      }
      set
      {
        this.ReportPropertyChanging("Last_Min__Balance_Date");
        this._Last_Min__Balance_Date = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Last_Min__Balance_Date");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public DateTime Last_Deposit_Date
    {
      get
      {
        return this._Last_Deposit_Date;
      }
      set
      {
        this.ReportPropertyChanging("Last_Deposit_Date");
        this._Last_Deposit_Date = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Last_Deposit_Date");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public DateTime Last_Transaction_Posting_Date
    {
      get
      {
        return this._Last_Transaction_Posting_Date;
      }
      set
      {
        this.ReportPropertyChanging("Last_Transaction_Posting_Date");
        this._Last_Transaction_Posting_Date = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Last_Transaction_Posting_Date");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public DateTime Date_Closed
    {
      get
      {
        return this._Date_Closed;
      }
      set
      {
        this.ReportPropertyChanging("Date_Closed");
        this._Date_Closed = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Date_Closed");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public DateTime Expected_Maturity_Date
    {
      get
      {
        return this._Expected_Maturity_Date;
      }
      set
      {
        this.ReportPropertyChanging("Expected_Maturity_Date");
        this._Expected_Maturity_Date = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Expected_Maturity_Date");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public DateTime Date_of_Birth
    {
      get
      {
        return this._Date_of_Birth;
      }
      set
      {
        this.ReportPropertyChanging("Date_of_Birth");
        this._Date_of_Birth = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Date_of_Birth");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string E_Mail__Personal_
    {
      get
      {
        return this._E_Mail__Personal_;
      }
      set
      {
        this.ReportPropertyChanging("E_Mail__Personal_");
        this._E_Mail__Personal_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("E_Mail__Personal_");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Section
    {
      get
      {
        return this._Section;
      }
      set
      {
        this.ReportPropertyChanging("Section");
        this._Section = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Section");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string ATM_No_
    {
      get
      {
        return this._ATM_No_;
      }
      set
      {
        this.ReportPropertyChanging("ATM_No_");
        this._ATM_No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("ATM_No_");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Home_Address
    {
      get
      {
        return this._Home_Address;
      }
      set
      {
        this.ReportPropertyChanging("Home_Address");
        this._Home_Address = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Home_Address");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Location
    {
      get
      {
        return this._Location;
      }
      set
      {
        this.ReportPropertyChanging("Location");
        this._Location = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Location");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Sub_Location
    {
      get
      {
        return this._Sub_Location;
      }
      set
      {
        this.ReportPropertyChanging("Sub_Location");
        this._Sub_Location = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Sub_Location");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string District
    {
      get
      {
        return this._District;
      }
      set
      {
        this.ReportPropertyChanging("District");
        this._District = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("District");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Resons_for_Status_Change
    {
      get
      {
        return this._Resons_for_Status_Change;
      }
      set
      {
        this.ReportPropertyChanging("Resons_for_Status_Change");
        this._Resons_for_Status_Change = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Resons_for_Status_Change");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public DateTime Closure_Notice_Date
    {
      get
      {
        return this._Closure_Notice_Date;
      }
      set
      {
        this.ReportPropertyChanging("Closure_Notice_Date");
        this._Closure_Notice_Date = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Closure_Notice_Date");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Fixed_Deposit_Type
    {
      get
      {
        return this._Fixed_Deposit_Type;
      }
      set
      {
        this.ReportPropertyChanging("Fixed_Deposit_Type");
        this._Fixed_Deposit_Type = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Fixed_Deposit_Type");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public DateTime FD_Maturity_Date
    {
      get
      {
        return this._FD_Maturity_Date;
      }
      set
      {
        this.ReportPropertyChanging("FD_Maturity_Date");
        this._FD_Maturity_Date = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("FD_Maturity_Date");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Savings_Account_No_
    {
      get
      {
        return this._Savings_Account_No_;
      }
      set
      {
        this.ReportPropertyChanging("Savings_Account_No_");
        this._Savings_Account_No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Savings_Account_No_");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Old_Account_No_
    {
      get
      {
        return this._Old_Account_No_;
      }
      set
      {
        this.ReportPropertyChanging("Old_Account_No_");
        this._Old_Account_No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Old_Account_No_");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public byte Salary_Processing
    {
      get
      {
        return this._Salary_Processing;
      }
      set
      {
        this.ReportPropertyChanging("Salary_Processing");
        this._Salary_Processing = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Salary_Processing");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public Decimal Amount_to_Transfer
    {
      get
      {
        return this._Amount_to_Transfer;
      }
      set
      {
        this.ReportPropertyChanging("Amount_to_Transfer");
        this._Amount_to_Transfer = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Amount_to_Transfer");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Proffesion
    {
      get
      {
        return this._Proffesion;
      }
      set
      {
        this.ReportPropertyChanging("Proffesion");
        this._Proffesion = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Proffesion");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Signing_Instructions
    {
      get
      {
        return this._Signing_Instructions;
      }
      set
      {
        this.ReportPropertyChanging("Signing_Instructions");
        this._Signing_Instructions = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Signing_Instructions");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public byte Hide
    {
      get
      {
        return this._Hide;
      }
      set
      {
        this.ReportPropertyChanging("Hide");
        this._Hide = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Hide");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public Decimal Monthly_Contribution
    {
      get
      {
        return this._Monthly_Contribution;
      }
      set
      {
        this.ReportPropertyChanging("Monthly_Contribution");
        this._Monthly_Contribution = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Monthly_Contribution");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public byte Not_Qualify_for_Interest
    {
      get
      {
        return this._Not_Qualify_for_Interest;
      }
      set
      {
        this.ReportPropertyChanging("Not_Qualify_for_Interest");
        this._Not_Qualify_for_Interest = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Not_Qualify_for_Interest");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public int Gender
    {
      get
      {
        return this._Gender;
      }
      set
      {
        this.ReportPropertyChanging("Gender");
        this._Gender = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Gender");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Fixed_Duration
    {
      get
      {
        return this._Fixed_Duration;
      }
      set
      {
        this.ReportPropertyChanging("Fixed_Duration");
        this._Fixed_Duration = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Fixed_Duration");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public byte System_Created
    {
      get
      {
        return this._System_Created;
      }
      set
      {
        this.ReportPropertyChanging("System_Created");
        this._System_Created = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("System_Created");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string External_Account_No
    {
      get
      {
        return this._External_Account_No;
      }
      set
      {
        this.ReportPropertyChanging("External_Account_No");
        this._External_Account_No = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("External_Account_No");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Bank_Code
    {
      get
      {
        return this._Bank_Code;
      }
      set
      {
        this.ReportPropertyChanging("Bank_Code");
        this._Bank_Code = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Bank_Code");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public byte Enabled
    {
      get
      {
        return this._Enabled;
      }
      set
      {
        this.ReportPropertyChanging("Enabled");
        this._Enabled = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Enabled");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public byte Defaulted_Loans_Recovered
    {
      get
      {
        return this._Defaulted_Loans_Recovered;
      }
      set
      {
        this.ReportPropertyChanging("Defaulted_Loans_Recovered");
        this._Defaulted_Loans_Recovered = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Defaulted_Loans_Recovered");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Formation_Province
    {
      get
      {
        return this._Formation_Province;
      }
      set
      {
        this.ReportPropertyChanging("Formation_Province");
        this._Formation_Province = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Formation_Province");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Division_Department
    {
      get
      {
        return this._Division_Department;
      }
      set
      {
        this.ReportPropertyChanging("Division_Department");
        this._Division_Department = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Division_Department");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string Station_Sections
    {
      get
      {
        return this._Station_Sections;
      }
      set
      {
        this.ReportPropertyChanging("Station_Sections");
        this._Station_Sections = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Station_Sections");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public Decimal Neg__Interest_Rate
    {
      get
      {
        return this._Neg__Interest_Rate;
      }
      set
      {
        this.ReportPropertyChanging("Neg__Interest_Rate");
        this._Neg__Interest_Rate = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Neg__Interest_Rate");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public DateTime Date_Renewed
    {
      get
      {
        return this._Date_Renewed;
      }
      set
      {
        this.ReportPropertyChanging("Date_Renewed");
        this._Date_Renewed = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Date_Renewed");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public byte Don_t_Transfer_to_Savings
    {
      get
      {
        return this._Don_t_Transfer_to_Savings;
      }
      set
      {
        this.ReportPropertyChanging("Don_t_Transfer_to_Savings");
        this._Don_t_Transfer_to_Savings = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Don_t_Transfer_to_Savings");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public int Type_Of_Organisation
    {
      get
      {
        return this._Type_Of_Organisation;
      }
      set
      {
        this.ReportPropertyChanging("Type_Of_Organisation");
        this._Type_Of_Organisation = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Type_Of_Organisation");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public int Source_Of_Funds
    {
      get
      {
        return this._Source_Of_Funds;
      }
      set
      {
        this.ReportPropertyChanging("Source_Of_Funds");
        this._Source_Of_Funds = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Source_Of_Funds");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string MPESA_Mobile_No
    {
      get
      {
        return this._MPESA_Mobile_No;
      }
      set
      {
        this.ReportPropertyChanging("MPESA_Mobile_No");
        this._MPESA_Mobile_No = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("MPESA_Mobile_No");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Force_No_
    {
      get
      {
        return this._Force_No_;
      }
      set
      {
        this.ReportPropertyChanging("Force_No_");
        this._Force_No_ = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Force_No_");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public DateTime Card_Expiry_Date
    {
      get
      {
        return this._Card_Expiry_Date;
      }
      set
      {
        this.ReportPropertyChanging("Card_Expiry_Date");
        this._Card_Expiry_Date = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Card_Expiry_Date");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public DateTime Card_Valid_From
    {
      get
      {
        return this._Card_Valid_From;
      }
      set
      {
        this.ReportPropertyChanging("Card_Valid_From");
        this._Card_Valid_From = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Card_Valid_From");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public DateTime Card_Valid_To
    {
      get
      {
        return this._Card_Valid_To;
      }
      set
      {
        this.ReportPropertyChanging("Card_Valid_To");
        this._Card_Valid_To = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Card_Valid_To");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Service
    {
      get
      {
        return this._Service;
      }
      set
      {
        this.ReportPropertyChanging("Service");
        this._Service = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Service");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public Decimal Fox_SBal
    {
      get
      {
        return this._Fox_SBal;
      }
      set
      {
        this.ReportPropertyChanging("Fox_SBal");
        this._Fox_SBal = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Fox_SBal");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public Decimal ABal_Fox
    {
      get
      {
        return this._ABal_Fox;
      }
      set
      {
        this.ReportPropertyChanging("ABal_Fox");
        this._ABal_Fox = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("ABal_Fox");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public string ATM_Prov__No
    {
      get
      {
        return this._ATM_Prov__No;
      }
      set
      {
        this.ReportPropertyChanging("ATM_Prov__No");
        this._ATM_Prov__No = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("ATM_Prov__No");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public byte ATM_Approve
    {
      get
      {
        return this._ATM_Approve;
      }
      set
      {
        this.ReportPropertyChanging("ATM_Approve");
        this._ATM_Approve = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("ATM_Approve");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public byte Reconciled
    {
      get
      {
        return this._Reconciled;
      }
      set
      {
        this.ReportPropertyChanging("Reconciled");
        this._Reconciled = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Reconciled");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public int FD_Duration
    {
      get
      {
        return this._FD_Duration;
      }
      set
      {
        this.ReportPropertyChanging("FD_Duration");
        this._FD_Duration = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("FD_Duration");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public string Employer_P_F
    {
      get
      {
        return this._Employer_P_F;
      }
      set
      {
        this.ReportPropertyChanging("Employer_P_F");
        this._Employer_P_F = StructuralObject.SetValidValue(value, false);
        this.ReportPropertyChanged("Employer_P_F");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public byte Atm_card_ready
    {
      get
      {
        return this._Atm_card_ready;
      }
      set
      {
        this.ReportPropertyChanging("Atm_card_ready");
        this._Atm_card_ready = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Atm_card_ready");
      }
    }

    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    [DataMember]
    public DateTime Date_ATM_Linked
    {
      get
      {
        return this._Date_ATM_Linked;
      }
      set
      {
        this.ReportPropertyChanging("Date_ATM_Linked");
        this._Date_ATM_Linked = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Date_ATM_Linked");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public byte Fosa_s_no_Bosa_No
    {
      get
      {
        return this._Fosa_s_no_Bosa_No;
      }
      set
      {
        this.ReportPropertyChanging("Fosa_s_no_Bosa_No");
        this._Fosa_s_no_Bosa_No = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Fosa_s_no_Bosa_No");
      }
    }

    [DataMember]
    [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
    public Decimal Outstanding_Balance
    {
      get
      {
        return this._Outstanding_Balance;
      }
      set
      {
        this.ReportPropertyChanging("Outstanding_Balance");
        this._Outstanding_Balance = StructuralObject.SetValidValue(value);
        this.ReportPropertyChanged("Outstanding_Balance");
      }
    }

    public static UKULIMA_SACCO_LTD_Vendor CreateUKULIMA_SACCO_LTD_Vendor(byte[] timestamp, string no_, string name, string search_Name, string name_2, string address, string address_2, string city, string contact, string phone_No_, string telex_No_, string our_Account_No_, string territory_Code, string global_Dimension_1_Code, string global_Dimension_2_Code, Decimal budgeted_Amount, string vendor_Posting_Group, string currency_Code, string language_Code, int statistics_Group, string payment_Terms_Code, string fin__Charge_Terms_Code, string purchaser_Code, string shipment_Method_Code, string shipping_Agent_Code, string invoice_Disc__Code, string country_Region_Code, int blocked, string pay_to_Vendor_No_, int priority, string payment_Method_Code, DateTime last_Date_Modified, int application_Method, byte prices_Including_VAT, string fax_No_, string telex_Answer_Back, string vAT_Registration_No_, string gen__Bus__Posting_Group, string post_Code, string county, string e_Mail, string home_Page, string no__Series, string tax_Area_Code, byte tax_Liable, string vAT_Bus__Posting_Group, byte block_Payment_Tolerance, string iC_Partner_Code, Decimal prepayment__, string primary_Contact_No_, string responsibility_Center, string location_Code, string lead_Time_Calculation, string base_Calendar_Code, int creditor_Type, string staff_No, string iD_No_, DateTime last_Maintenance_Date, byte activate_Sweeping_Arrangement, Decimal sweeping_Balance, string sweep_To_Account, int fixed_Deposit_Status, byte call_Deposit, string mobile_Phone_No, int marital_Status, DateTime registration_Date, string bOSA_Account_No, string passport_No_, string company_Code, int status, string account_Type, int account_Category, byte fD_Marked_for_Closure, DateTime last_Withdrawal_Date, DateTime last_Overdraft_Date, DateTime last_Min__Balance_Date, DateTime last_Deposit_Date, DateTime last_Transaction_Posting_Date, DateTime date_Closed, DateTime expected_Maturity_Date, DateTime date_of_Birth, string e_Mail__Personal_, string section, string aTM_No_, string home_Address, string location, string sub_Location, string district, string resons_for_Status_Change, DateTime closure_Notice_Date, string fixed_Deposit_Type, DateTime fD_Maturity_Date, string savings_Account_No_, string old_Account_No_, byte salary_Processing, Decimal amount_to_Transfer, string proffesion, string signing_Instructions, byte hide, Decimal monthly_Contribution, byte not_Qualify_for_Interest, int gender, string fixed_Duration, byte system_Created, string external_Account_No, string bank_Code, byte enabled, byte defaulted_Loans_Recovered, string formation_Province, string division_Department, string station_Sections, Decimal neg__Interest_Rate, DateTime date_Renewed, byte don_t_Transfer_to_Savings, int type_Of_Organisation, int source_Of_Funds, string mPESA_Mobile_No, string force_No_, DateTime card_Expiry_Date, DateTime card_Valid_From, DateTime card_Valid_To, string service, Decimal fox_SBal, Decimal aBal_Fox, string aTM_Prov__No, byte aTM_Approve, byte reconciled, int fD_Duration, string employer_P_F, byte atm_card_ready, DateTime date_ATM_Linked, byte fosa_s_no_Bosa_No, Decimal outstanding_Balance)
    {
      return new UKULIMA_SACCO_LTD_Vendor()
      {
        timestamp = timestamp,
        No_ = no_,
        Name = name,
        Search_Name = search_Name,
        Name_2 = name_2,
        Address = address,
        Address_2 = address_2,
        City = city,
        Contact = contact,
        Phone_No_ = phone_No_,
        Telex_No_ = telex_No_,
        Our_Account_No_ = our_Account_No_,
        Territory_Code = territory_Code,
        Global_Dimension_1_Code = global_Dimension_1_Code,
        Global_Dimension_2_Code = global_Dimension_2_Code,
        Budgeted_Amount = budgeted_Amount,
        Vendor_Posting_Group = vendor_Posting_Group,
        Currency_Code = currency_Code,
        Language_Code = language_Code,
        Statistics_Group = statistics_Group,
        Payment_Terms_Code = payment_Terms_Code,
        Fin__Charge_Terms_Code = fin__Charge_Terms_Code,
        Purchaser_Code = purchaser_Code,
        Shipment_Method_Code = shipment_Method_Code,
        Shipping_Agent_Code = shipping_Agent_Code,
        Invoice_Disc__Code = invoice_Disc__Code,
        Country_Region_Code = country_Region_Code,
        Blocked = blocked,
        Pay_to_Vendor_No_ = pay_to_Vendor_No_,
        Priority = priority,
        Payment_Method_Code = payment_Method_Code,
        Last_Date_Modified = last_Date_Modified,
        Application_Method = application_Method,
        Prices_Including_VAT = prices_Including_VAT,
        Fax_No_ = fax_No_,
        Telex_Answer_Back = telex_Answer_Back,
        VAT_Registration_No_ = vAT_Registration_No_,
        Gen__Bus__Posting_Group = gen__Bus__Posting_Group,
        Post_Code = post_Code,
        County = county,
        E_Mail = e_Mail,
        Home_Page = home_Page,
        No__Series = no__Series,
        Tax_Area_Code = tax_Area_Code,
        Tax_Liable = tax_Liable,
        VAT_Bus__Posting_Group = vAT_Bus__Posting_Group,
        Block_Payment_Tolerance = block_Payment_Tolerance,
        IC_Partner_Code = iC_Partner_Code,
        Prepayment__ = prepayment__,
        Primary_Contact_No_ = primary_Contact_No_,
        Responsibility_Center = responsibility_Center,
        Location_Code = location_Code,
        Lead_Time_Calculation = lead_Time_Calculation,
        Base_Calendar_Code = base_Calendar_Code,
        Creditor_Type = creditor_Type,
        Staff_No = staff_No,
        ID_No_ = iD_No_,
        Last_Maintenance_Date = last_Maintenance_Date,
        Activate_Sweeping_Arrangement = activate_Sweeping_Arrangement,
        Sweeping_Balance = sweeping_Balance,
        Sweep_To_Account = sweep_To_Account,
        Fixed_Deposit_Status = fixed_Deposit_Status,
        Call_Deposit = call_Deposit,
        Mobile_Phone_No = mobile_Phone_No,
        Marital_Status = marital_Status,
        Registration_Date = registration_Date,
        BOSA_Account_No = bOSA_Account_No,
        Passport_No_ = passport_No_,
        Company_Code = company_Code,
        Status = status,
        Account_Type = account_Type,
        Account_Category = account_Category,
        FD_Marked_for_Closure = fD_Marked_for_Closure,
        Last_Withdrawal_Date = last_Withdrawal_Date,
        Last_Overdraft_Date = last_Overdraft_Date,
        Last_Min__Balance_Date = last_Min__Balance_Date,
        Last_Deposit_Date = last_Deposit_Date,
        Last_Transaction_Posting_Date = last_Transaction_Posting_Date,
        Date_Closed = date_Closed,
        Expected_Maturity_Date = expected_Maturity_Date,
        Date_of_Birth = date_of_Birth,
        E_Mail__Personal_ = e_Mail__Personal_,
        Section = section,
        ATM_No_ = aTM_No_,
        Home_Address = home_Address,
        Location = location,
        Sub_Location = sub_Location,
        District = district,
        Resons_for_Status_Change = resons_for_Status_Change,
        Closure_Notice_Date = closure_Notice_Date,
        Fixed_Deposit_Type = fixed_Deposit_Type,
        FD_Maturity_Date = fD_Maturity_Date,
        Savings_Account_No_ = savings_Account_No_,
        Old_Account_No_ = old_Account_No_,
        Salary_Processing = salary_Processing,
        Amount_to_Transfer = amount_to_Transfer,
        Proffesion = proffesion,
        Signing_Instructions = signing_Instructions,
        Hide = hide,
        Monthly_Contribution = monthly_Contribution,
        Not_Qualify_for_Interest = not_Qualify_for_Interest,
        Gender = gender,
        Fixed_Duration = fixed_Duration,
        System_Created = system_Created,
        External_Account_No = external_Account_No,
        Bank_Code = bank_Code,
        Enabled = enabled,
        Defaulted_Loans_Recovered = defaulted_Loans_Recovered,
        Formation_Province = formation_Province,
        Division_Department = division_Department,
        Station_Sections = station_Sections,
        Neg__Interest_Rate = neg__Interest_Rate,
        Date_Renewed = date_Renewed,
        Don_t_Transfer_to_Savings = don_t_Transfer_to_Savings,
        Type_Of_Organisation = type_Of_Organisation,
        Source_Of_Funds = source_Of_Funds,
        MPESA_Mobile_No = mPESA_Mobile_No,
        Force_No_ = force_No_,
        Card_Expiry_Date = card_Expiry_Date,
        Card_Valid_From = card_Valid_From,
        Card_Valid_To = card_Valid_To,
        Service = service,
        Fox_SBal = fox_SBal,
        ABal_Fox = aBal_Fox,
        ATM_Prov__No = aTM_Prov__No,
        ATM_Approve = aTM_Approve,
        Reconciled = reconciled,
        FD_Duration = fD_Duration,
        Employer_P_F = employer_P_F,
        Atm_card_ready = atm_card_ready,
        Date_ATM_Linked = date_ATM_Linked,
        Fosa_s_no_Bosa_No = fosa_s_no_Bosa_No,
        Outstanding_Balance = outstanding_Balance
      };
    }
  }
}

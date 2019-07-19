package com.example.paul.a_sacco;

import android.app.ActionBar;
import android.app.AlertDialog;
import android.app.AlertDialog.Builder;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.DialogInterface.OnClickListener;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnFocusChangeListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;
import com.example.paul.a_sacco.dummy.Menu;
import com.example.paul.a_sacco.dummy.Menu.DummyItem;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import java.lang.reflect.Type;
import java.util.List;
import java.util.Map;

public class AgencyDetailFragment
  extends Fragment
{
  public static final String ARG_ITEM_ID = "item_id";
  public static final String ARG_TWOPANE = "Pane";
  TextView Account_Name = null;
  TextView Account_Name2 = null;
  EditText Account_Name3 = null;
  TextView Account_No = null;
  EditText Account_No2 = null;
  TextView Info = null;
  EditText Tel = null;
  EditText amount = null;
  Button cancel = null;
  Button confirm = null;
  Database db = null;
  EditText id_no = null;
  EditText id_no2 = null;
  TextView loanNo = null;
  TextView loan_Type = null;
  TextView loan_bal = null;
  TextView loan_source = null;
  private Menu.DummyItem mItem;
  Member member = null;
  ProgressBar pacc = null;
  ProgressBar pacc2 = null;
  ProgressBar paccname = null;
  ProgressBar paccno = null;
  AlertDialog pindialog = null;
  ProgressBar ploan = null;
  View rootView = null;
  AutoCompleteTextView society = null;
  EditText society_no = null;
  Transaction trans = null;
  boolean twopane;
  
  private void Activation(View paramView)
  {
    this.id_no = ((EditText)paramView.findViewById(2131296322));
    this.Account_No = ((TextView)paramView.findViewById(2131296326));
    this.Account_Name = ((TextView)paramView.findViewById(2131296329));
    this.confirm = ((Button)paramView.findViewById(2131296332));
    this.cancel = ((Button)paramView.findViewById(2131296331));
    this.pacc = ((ProgressBar)paramView.findViewById(2131296324));
    this.trans.status = Transaction.Status.Pending;
    this.confirm.setOnClickListener(new View.OnClickListener()
    {
      public void onClick(View paramAnonymousView)
      {
        AgencyDetailFragment.this.id_no.setError(null);
        paramAnonymousView = AgencyDetailFragment.this.id_no.getText().toString();
        int i = 0;
        if (TextUtils.isEmpty(paramAnonymousView))
        {
          AgencyDetailFragment.this.id_no.setError(AgencyDetailFragment.this.getString(2131492891));
          i = 1;
        }
        if (i != 0) {
          return;
        }
        AgencyDetailFragment.this.member = new Member();
        AgencyDetailFragment.this.member.id_no = AgencyDetailFragment.this.id_no.getText().toString();
        AgencyDetailFragment.this.trans.member_1 = AgencyDetailFragment.this.member;
        AgencyDetailFragment.this.pacc.setVisibility(0);
        new AgencyDetailFragment.GetaccountTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
      }
    });
  }
  
  private void Balance(View paramView)
  {
    this.id_no = ((EditText)paramView.findViewById(2131296322));
    this.Account_No = ((TextView)paramView.findViewById(2131296326));
    this.Account_Name = ((TextView)paramView.findViewById(2131296329));
    this.confirm = ((Button)paramView.findViewById(2131296332));
    this.cancel = ((Button)paramView.findViewById(2131296331));
    this.pacc = ((ProgressBar)paramView.findViewById(2131296324));
    this.trans.status = Transaction.Status.Pending;
    this.confirm.setOnClickListener(new View.OnClickListener()
    {
      public void onClick(View paramAnonymousView)
      {
        AgencyDetailFragment.this.id_no.setError(null);
        paramAnonymousView = AgencyDetailFragment.this.id_no.getText().toString();
        int i = 0;
        if (TextUtils.isEmpty(paramAnonymousView))
        {
          AgencyDetailFragment.this.id_no.setError(AgencyDetailFragment.this.getString(2131492891));
          i = 1;
        }
        if (i != 0) {
          return;
        }
        if (AgencyDetailFragment.this.trans.member_1 == null)
        {
          AgencyDetailFragment.this.member = new Member();
          AgencyDetailFragment.this.member.id_no = AgencyDetailFragment.this.id_no.getText().toString();
          AgencyDetailFragment.this.trans.member_1 = AgencyDetailFragment.this.member;
        }
        AgencyDetailFragment.this.pacc.setVisibility(0);
        new AgencyDetailFragment.GetaccountTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
      }
    });
  }
  
  private void Deposit(View paramView)
  {
    this.Account_No = ((TextView)paramView.findViewById(2131296341));
    this.Account_Name = ((TextView)paramView.findViewById(2131296329));
    this.Tel = ((EditText)paramView.findViewById(2131296346));
    this.Account_Name3 = ((EditText)paramView.findViewById(2131296344));
    this.amount = ((EditText)paramView.findViewById(2131296335));
    this.confirm = ((Button)paramView.findViewById(2131296332));
    this.cancel = ((Button)paramView.findViewById(2131296331));
    this.pacc = ((ProgressBar)paramView.findViewById(2131296324));
    this.trans.status = Transaction.Status.Pending;
    this.Account_No.setOnFocusChangeListener(new View.OnFocusChangeListener()
    {
      public void onFocusChange(View paramAnonymousView, boolean paramAnonymousBoolean)
      {
        if ((!paramAnonymousBoolean) && (!AgencyDetailFragment.this.Account_No.getText().toString().equals("")))
        {
          paramAnonymousView = new Account();
          paramAnonymousView.Account_No = AgencyDetailFragment.this.Account_No.getText().toString();
          AgencyDetailFragment.this.trans.account_1 = paramAnonymousView;
          AgencyDetailFragment.this.pacc.setVisibility(0);
          new AgencyDetailFragment.GetaccountTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
        }
      }
    });
    this.confirm.setOnClickListener(new View.OnClickListener()
    {
      public void onClick(View paramAnonymousView)
      {
        AgencyDetailFragment.this.Account_No.setError(null);
        AgencyDetailFragment.this.amount.setError(null);
        AgencyDetailFragment.this.Tel.setError(null);
        AgencyDetailFragment.this.Account_Name3.setError(null);
        paramAnonymousView = AgencyDetailFragment.this.Account_No.getText().toString();
        String str1 = AgencyDetailFragment.this.amount.getText().toString();
        String str2 = AgencyDetailFragment.this.Tel.getText().toString();
        String str3 = AgencyDetailFragment.this.Account_Name3.getText().toString();
        if (TextUtils.isEmpty(paramAnonymousView))
        {
          AgencyDetailFragment.this.Account_No.setError(AgencyDetailFragment.this.getString(2131492891));
          AgencyDetailFragment.this.Account_No.requestFocus();
          return;
        }
        if (TextUtils.isEmpty(str1))
        {
          AgencyDetailFragment.this.amount.setError(AgencyDetailFragment.this.getString(2131492891));
          AgencyDetailFragment.this.amount.requestFocus();
          return;
        }
        if (TextUtils.isEmpty(str2))
        {
          AgencyDetailFragment.this.Tel.setError(AgencyDetailFragment.this.getString(2131492891));
          AgencyDetailFragment.this.Tel.requestFocus();
          return;
        }
        if (!AgencyDetailFragment.this.trans.account_1.Account_ok)
        {
          AgencyDetailFragment.this.Account_No.setError(AgencyDetailFragment.this.getString(2131492887));
          AgencyDetailFragment.this.Account_No.requestFocus();
          return;
        }
        AgencyDetailFragment.this.trans.amount = Double.valueOf(str1).doubleValue();
        AgencyDetailFragment.this.trans.Telephone_No = str2;
        AgencyDetailFragment.this.trans.Depositor_Name = str3;
        if (AgencyDetailFragment.this.trans.account_1 != null) {
          new AgencyDetailFragment.TransactionrequestTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
        }
      }
    });
  }
  
  private void LoanRepayment(View paramView)
  {
    this.id_no = ((EditText)paramView.findViewById(2131296322));
    this.Account_No = ((TextView)paramView.findViewById(2131296326));
    this.Account_Name = ((TextView)paramView.findViewById(2131296329));
    this.Info = ((TextView)paramView.findViewById(2131296336));
    this.loanNo = ((TextView)paramView.findViewById(2131296351));
    this.loan_Type = ((TextView)paramView.findViewById(2131296353));
    this.amount = ((EditText)paramView.findViewById(2131296335));
    this.confirm = ((Button)paramView.findViewById(2131296332));
    this.cancel = ((Button)paramView.findViewById(2131296331));
    this.ploan = ((ProgressBar)paramView.findViewById(2131296349));
    this.trans.status = Transaction.Status.Pending;
    this.id_no.setOnFocusChangeListener(new View.OnFocusChangeListener()
    {
      public void onFocusChange(View paramAnonymousView, boolean paramAnonymousBoolean)
      {
        if ((!paramAnonymousBoolean) && (!AgencyDetailFragment.this.id_no.getText().toString().equals("")))
        {
          AgencyDetailFragment.this.member = new Member();
          AgencyDetailFragment.this.member.id_no = AgencyDetailFragment.this.id_no.getText().toString();
          AgencyDetailFragment.this.trans.member_1 = AgencyDetailFragment.this.member;
          AgencyDetailFragment.this.ploan.setVisibility(0);
          new AgencyDetailFragment.GetaccountTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
        }
      }
    });
    this.confirm.setOnClickListener(new View.OnClickListener()
    {
      public void onClick(View paramAnonymousView)
      {
        AgencyDetailFragment.this.id_no.setError(null);
        AgencyDetailFragment.this.amount.setError(null);
        paramAnonymousView = AgencyDetailFragment.this.id_no.getText().toString();
        String str = AgencyDetailFragment.this.amount.getText().toString();
        int i = 0;
        if (TextUtils.isEmpty(paramAnonymousView))
        {
          AgencyDetailFragment.this.id_no.setError(AgencyDetailFragment.this.getString(2131492891));
          i = 1;
        }
        if (TextUtils.isEmpty(str))
        {
          AgencyDetailFragment.this.amount.setError(AgencyDetailFragment.this.getString(2131492891));
          i = 1;
        }
        if (i != 0) {
          return;
        }
        AgencyDetailFragment.this.trans.amount = Double.valueOf(str).doubleValue();
        if (AgencyDetailFragment.this.trans.loan_no == null)
        {
          new AgencyDetailFragment.GetaccountTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
          return;
        }
        new AgencyDetailFragment.TransactionrequestTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
      }
    });
  }
  
  private void Registration(View paramView)
  {
    this.id_no = ((EditText)paramView.findViewById(2131296322));
    this.Account_Name3 = ((EditText)paramView.findViewById(2131296329));
    this.Tel = ((EditText)paramView.findViewById(2131296365));
    this.amount = ((EditText)paramView.findViewById(2131296335));
    this.society = ((AutoCompleteTextView)paramView.findViewById(2131296367));
    this.society_no = ((EditText)paramView.findViewById(2131296369));
    this.confirm = ((Button)paramView.findViewById(2131296332));
    this.cancel = ((Button)paramView.findViewById(2131296331));
    this.trans.status = Transaction.Status.Pending;
    List localList = Societies.getSocieties(this.db);
    paramView = new ArrayAdapter(paramView.getContext(), 17367048, localList);
    paramView.setDropDownViewResource(17367049);
    this.society.setAdapter(paramView);
    this.society.setOnItemClickListener(new AdapterView.OnItemClickListener()
    {
      public void onItemClick(AdapterView<?> paramAnonymousAdapterView, View paramAnonymousView, int paramAnonymousInt, long paramAnonymousLong)
      {
        AgencyDetailFragment.this.trans.society = ((Societies)paramAnonymousAdapterView.getItemAtPosition(paramAnonymousInt));
      }
    });
    this.confirm.setOnClickListener(new View.OnClickListener()
    {
      public void onClick(View paramAnonymousView)
      {
        AgencyDetailFragment.this.id_no.setError(null);
        AgencyDetailFragment.this.Account_Name3.setError(null);
        AgencyDetailFragment.this.Tel.setError(null);
        AgencyDetailFragment.this.amount.setError(null);
        paramAnonymousView = AgencyDetailFragment.this.id_no.getText().toString();
        String str1 = AgencyDetailFragment.this.amount.getText().toString();
        String str2 = AgencyDetailFragment.this.Account_Name3.getText().toString();
        String str3 = AgencyDetailFragment.this.Tel.getText().toString();
        String str4 = AgencyDetailFragment.this.society.getText().toString();
        String str5 = AgencyDetailFragment.this.society_no.getText().toString();
        if (TextUtils.isEmpty(paramAnonymousView))
        {
          AgencyDetailFragment.this.id_no.setError(AgencyDetailFragment.this.getString(2131492891));
          AgencyDetailFragment.this.id_no.requestFocus();
          return;
        }
        if (TextUtils.isEmpty(str1))
        {
          AgencyDetailFragment.this.amount.setError(AgencyDetailFragment.this.getString(2131492891));
          AgencyDetailFragment.this.amount.requestFocus();
          return;
        }
        if (TextUtils.isEmpty(str2))
        {
          AgencyDetailFragment.this.Account_Name3.setError(AgencyDetailFragment.this.getString(2131492891));
          AgencyDetailFragment.this.Account_Name3.requestFocus();
          return;
        }
        if (TextUtils.isEmpty(str3))
        {
          AgencyDetailFragment.this.Tel.setError(AgencyDetailFragment.this.getString(2131492891));
          AgencyDetailFragment.this.Tel.requestFocus();
          return;
        }
        if (TextUtils.isEmpty(str4))
        {
          AgencyDetailFragment.this.society.setError(AgencyDetailFragment.this.getString(2131492891));
          AgencyDetailFragment.this.society.requestFocus();
          return;
        }
        if (TextUtils.isEmpty(str5))
        {
          AgencyDetailFragment.this.society_no.setError(AgencyDetailFragment.this.getString(2131492891));
          AgencyDetailFragment.this.society_no.requestFocus();
          return;
        }
        if (str3.length() < 9)
        {
          AgencyDetailFragment.this.Tel.setError(AgencyDetailFragment.this.getString(2131492897));
          AgencyDetailFragment.this.Tel.requestFocus();
          return;
        }
        if (0 != 0) {
          return;
        }
        AgencyDetailFragment.this.trans.amount = Double.valueOf(str1).doubleValue();
        AgencyDetailFragment.this.member = new Member();
        AgencyDetailFragment.this.member.id_no = paramAnonymousView;
        AgencyDetailFragment.this.member.telephone = str3;
        AgencyDetailFragment.this.member.name = str2;
        AgencyDetailFragment.this.trans.member_1 = AgencyDetailFragment.this.member;
        AgencyDetailFragment.this.trans.society.memberid = str5;
        new AgencyDetailFragment.TransactionrequestTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
      }
    });
  }
  
  private void Sharedeposit(View paramView)
  {
    this.id_no = ((EditText)paramView.findViewById(2131296322));
    this.Account_No = ((TextView)paramView.findViewById(2131296326));
    this.Account_Name = ((TextView)paramView.findViewById(2131296329));
    this.amount = ((EditText)paramView.findViewById(2131296335));
    this.confirm = ((Button)paramView.findViewById(2131296332));
    this.cancel = ((Button)paramView.findViewById(2131296331));
    this.pacc = ((ProgressBar)paramView.findViewById(2131296324));
    this.trans.status = Transaction.Status.Pending;
    this.id_no.setOnFocusChangeListener(new View.OnFocusChangeListener()
    {
      public void onFocusChange(View paramAnonymousView, boolean paramAnonymousBoolean)
      {
        if ((!paramAnonymousBoolean) && (!AgencyDetailFragment.this.id_no.getText().toString().equals("")))
        {
          AgencyDetailFragment.this.member = new Member();
          AgencyDetailFragment.this.member.id_no = AgencyDetailFragment.this.id_no.getText().toString();
          AgencyDetailFragment.this.trans.member_1 = AgencyDetailFragment.this.member;
          AgencyDetailFragment.this.pacc.setVisibility(0);
          new AgencyDetailFragment.GetaccountTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
        }
      }
    });
    this.confirm.setOnClickListener(new View.OnClickListener()
    {
      public void onClick(View paramAnonymousView)
      {
        AgencyDetailFragment.this.id_no.setError(null);
        AgencyDetailFragment.this.amount.setError(null);
        paramAnonymousView = AgencyDetailFragment.this.id_no.getText().toString();
        String str = AgencyDetailFragment.this.amount.getText().toString();
        int i = 0;
        if (TextUtils.isEmpty(paramAnonymousView))
        {
          AgencyDetailFragment.this.id_no.setError(AgencyDetailFragment.this.getString(2131492891));
          i = 1;
        }
        if (TextUtils.isEmpty(str))
        {
          AgencyDetailFragment.this.amount.setError(AgencyDetailFragment.this.getString(2131492891));
          i = 1;
        }
        if (i != 0) {
          return;
        }
        AgencyDetailFragment.this.trans.amount = Double.valueOf(str).doubleValue();
        if (AgencyDetailFragment.this.trans.account_1 == null)
        {
          new AgencyDetailFragment.GetaccountTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
          return;
        }
        new AgencyDetailFragment.TransactionrequestTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
      }
    });
  }
  
  private void Transfer(View paramView)
  {
    this.id_no = ((EditText)paramView.findViewById(2131296322));
    this.Account_No = ((TextView)paramView.findViewById(2131296326));
    this.Account_Name = ((TextView)paramView.findViewById(2131296329));
    this.Account_No2 = ((EditText)paramView.findViewById(2131296375));
    this.Account_Name2 = ((TextView)paramView.findViewById(2131296377));
    this.amount = ((EditText)paramView.findViewById(2131296335));
    this.confirm = ((Button)paramView.findViewById(2131296332));
    this.cancel = ((Button)paramView.findViewById(2131296331));
    this.pacc = ((ProgressBar)paramView.findViewById(2131296324));
    this.pacc2 = ((ProgressBar)paramView.findViewById(2131296373));
    this.trans.status = Transaction.Status.Pending;
    this.id_no.setOnFocusChangeListener(new View.OnFocusChangeListener()
    {
      public void onFocusChange(View paramAnonymousView, boolean paramAnonymousBoolean)
      {
        if ((!paramAnonymousBoolean) && (!AgencyDetailFragment.this.id_no.getText().toString().equals("")))
        {
          AgencyDetailFragment.this.member = new Member();
          AgencyDetailFragment.this.member.id_no = AgencyDetailFragment.this.id_no.getText().toString();
          AgencyDetailFragment.this.trans.member_1 = AgencyDetailFragment.this.member;
          AgencyDetailFragment.this.pacc.setVisibility(0);
          new AgencyDetailFragment.GetaccountTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
        }
      }
    });
    this.Account_No2.setOnFocusChangeListener(new View.OnFocusChangeListener()
    {
      public void onFocusChange(View paramAnonymousView, boolean paramAnonymousBoolean)
      {
        if ((!paramAnonymousBoolean) && (!AgencyDetailFragment.this.Account_No2.getText().toString().equals("")))
        {
          paramAnonymousView = new Account();
          paramAnonymousView.Account_No = AgencyDetailFragment.this.Account_No2.getText().toString();
          AgencyDetailFragment.this.trans.account_2 = paramAnonymousView;
          AgencyDetailFragment.this.pacc2.setVisibility(0);
          new AgencyDetailFragment.GetaccountTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
        }
      }
    });
    this.confirm.setOnClickListener(new View.OnClickListener()
    {
      public void onClick(View paramAnonymousView)
      {
        AgencyDetailFragment.this.id_no.setError(null);
        AgencyDetailFragment.this.Account_No2.setError(null);
        AgencyDetailFragment.this.amount.setError(null);
        paramAnonymousView = AgencyDetailFragment.this.id_no.getText().toString();
        String str1 = AgencyDetailFragment.this.Account_No2.getText().toString();
        String str2 = AgencyDetailFragment.this.amount.getText().toString();
        int i = 0;
        if (TextUtils.isEmpty(paramAnonymousView))
        {
          AgencyDetailFragment.this.id_no.setError(AgencyDetailFragment.this.getString(2131492891));
          i = 1;
        }
        if (TextUtils.isEmpty(str1))
        {
          AgencyDetailFragment.this.Account_No2.setError(AgencyDetailFragment.this.getString(2131492891));
          i = 1;
        }
        if (TextUtils.isEmpty(str2))
        {
          AgencyDetailFragment.this.amount.setError(AgencyDetailFragment.this.getString(2131492891));
          i = 1;
        }
        int j;
        if (!AgencyDetailFragment.this.trans.account_2.Account_ok)
        {
          AgencyDetailFragment.this.Account_No2.setError(AgencyDetailFragment.this.getString(2131492887));
          j = 1;
        }
        while (j != 0)
        {
          return;
          j = i;
          if (AgencyDetailFragment.this.trans.account_1 != null)
          {
            j = i;
            if (AgencyDetailFragment.this.trans.account_1.Account_No.equalsIgnoreCase(AgencyDetailFragment.this.trans.account_2.Account_No))
            {
              AgencyDetailFragment.this.Account_No2.setError(AgencyDetailFragment.this.getString(2131492896));
              j = 1;
            }
          }
        }
        AgencyDetailFragment.this.trans.amount = Double.valueOf(str2).doubleValue();
        if (AgencyDetailFragment.this.trans.account_1 == null)
        {
          new AgencyDetailFragment.GetaccountTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
          return;
        }
        new AgencyDetailFragment.TransactionrequestTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
      }
    });
  }
  
  private void changepin(View paramView)
  {
    this.id_no = ((EditText)paramView.findViewById(2131296322));
    final EditText localEditText1 = (EditText)paramView.findViewById(2131296360);
    final EditText localEditText2 = (EditText)paramView.findViewById(2131296361);
    final EditText localEditText3 = (EditText)paramView.findViewById(2131296362);
    this.confirm = ((Button)paramView.findViewById(2131296332));
    this.cancel = ((Button)paramView.findViewById(2131296331));
    this.trans.status = Transaction.Status.Pending;
    this.id_no.setOnFocusChangeListener(new View.OnFocusChangeListener()
    {
      public void onFocusChange(View paramAnonymousView, boolean paramAnonymousBoolean)
      {
        if ((!paramAnonymousBoolean) && (!AgencyDetailFragment.this.id_no.getText().toString().equals("")))
        {
          AgencyDetailFragment.this.member = new Member();
          AgencyDetailFragment.this.member.id_no = AgencyDetailFragment.this.id_no.getText().toString();
          AgencyDetailFragment.this.trans.member_1 = AgencyDetailFragment.this.member;
          new AgencyDetailFragment.GetaccountTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
        }
      }
    });
    this.confirm.setOnClickListener(new View.OnClickListener()
    {
      public void onClick(View paramAnonymousView)
      {
        AgencyDetailFragment.this.id_no.setError(null);
        if (TextUtils.isEmpty(AgencyDetailFragment.this.id_no.getText().toString()))
        {
          AgencyDetailFragment.this.id_no.setError(AgencyDetailFragment.this.getString(2131492891));
          AgencyDetailFragment.this.id_no.requestFocus();
          return;
        }
        paramAnonymousView = localEditText1.getText().toString();
        String str1 = localEditText2.getText().toString();
        String str2 = localEditText3.getText().toString();
        if (TextUtils.isEmpty(paramAnonymousView))
        {
          localEditText1.setError(AgencyDetailFragment.this.getString(2131492891));
          localEditText1.requestFocus();
          return;
        }
        if (TextUtils.isEmpty(str1))
        {
          localEditText2.setError(AgencyDetailFragment.this.getString(2131492891));
          localEditText2.requestFocus();
          return;
        }
        if (TextUtils.isEmpty(str2))
        {
          localEditText3.setError(AgencyDetailFragment.this.getString(2131492891));
          localEditText3.requestFocus();
          return;
        }
        if (!paramAnonymousView.equals(AgencyDetailFragment.this.trans.member_1.pin))
        {
          localEditText1.setError(AgencyDetailFragment.this.getString(2131492890));
          localEditText1.requestFocus();
          return;
        }
        if (!str1.equals(str2))
        {
          localEditText3.setError(AgencyDetailFragment.this.getString(2131492889));
          localEditText3.requestFocus();
          return;
        }
        AgencyDetailFragment.this.trans.newpin = str1;
        new AgencyDetailFragment.ChangepinTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
      }
    });
  }
  
  private void withdrawal(View paramView)
  {
    this.id_no = ((EditText)paramView.findViewById(2131296322));
    this.Account_No = ((TextView)paramView.findViewById(2131296326));
    this.Account_Name = ((TextView)paramView.findViewById(2131296329));
    this.Info = ((TextView)paramView.findViewById(2131296336));
    this.amount = ((EditText)paramView.findViewById(2131296335));
    this.confirm = ((Button)paramView.findViewById(2131296332));
    this.cancel = ((Button)paramView.findViewById(2131296331));
    this.pacc = ((ProgressBar)paramView.findViewById(2131296324));
    this.trans.status = Transaction.Status.Pending;
    this.id_no.setOnFocusChangeListener(new View.OnFocusChangeListener()
    {
      public void onFocusChange(View paramAnonymousView, boolean paramAnonymousBoolean)
      {
        if ((!paramAnonymousBoolean) && (!AgencyDetailFragment.this.id_no.getText().toString().equals("")))
        {
          AgencyDetailFragment.this.member = new Member();
          AgencyDetailFragment.this.member.id_no = AgencyDetailFragment.this.id_no.getText().toString();
          AgencyDetailFragment.this.trans.member_1 = AgencyDetailFragment.this.member;
          AgencyDetailFragment.this.pacc.setVisibility(0);
          new AgencyDetailFragment.GetaccountTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
        }
      }
    });
    this.confirm.setOnClickListener(new View.OnClickListener()
    {
      public void onClick(View paramAnonymousView)
      {
        AgencyDetailFragment.this.id_no.setError(null);
        AgencyDetailFragment.this.amount.setError(null);
        paramAnonymousView = AgencyDetailFragment.this.id_no.getText().toString();
        String str = AgencyDetailFragment.this.amount.getText().toString();
        int i = 0;
        if (TextUtils.isEmpty(paramAnonymousView))
        {
          AgencyDetailFragment.this.id_no.setError(AgencyDetailFragment.this.getString(2131492891));
          i = 1;
        }
        if (TextUtils.isEmpty(str))
        {
          AgencyDetailFragment.this.amount.setError(AgencyDetailFragment.this.getString(2131492891));
          i = 1;
        }
        if (i != 0) {
          return;
        }
        AgencyDetailFragment.this.trans.amount = Double.valueOf(str).doubleValue();
        if (AgencyDetailFragment.this.trans.account_1 == null)
        {
          new AgencyDetailFragment.GetaccountTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
          return;
        }
        new AgencyDetailFragment.TransactionrequestTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
      }
    });
  }
  
  public void onCreate(Bundle paramBundle)
  {
    super.onCreate(paramBundle);
    if (getArguments().containsKey("item_id"))
    {
      this.mItem = ((Menu.DummyItem)Menu.ITEM_MAP.get(getArguments().getString("item_id")));
      this.twopane = getArguments().getBoolean("Pane");
      paramBundle = getActivity().getActionBar();
      paramBundle.setTitle(this.mItem.content);
      paramBundle.setIcon(this.mItem.image);
    }
  }
  
  public View onCreateView(LayoutInflater paramLayoutInflater, ViewGroup paramViewGroup, Bundle paramBundle)
  {
    if (this.mItem != null)
    {
      this.trans = new Transaction();
      this.trans.agent = Login.agent;
      this.db = new Database(getActivity());
      switch (Integer.parseInt(this.mItem.id))
      {
      }
    }
    for (;;)
    {
      this.cancel = ((Button)this.rootView.findViewById(2131296331));
      this.cancel.setOnClickListener(new View.OnClickListener()
      {
        public void onClick(View paramAnonymousView)
        {
          if (AgencyDetailFragment.this.cancel != null) {
            AgencyDetailFragment.this.getActivity().finish();
          }
        }
      });
      return this.rootView;
      this.rootView = paramLayoutInflater.inflate(2130903075, paramViewGroup, false);
      this.trans.transactiontype = Transaction.Transtype.Registration;
      Registration(this.rootView);
      continue;
      this.rootView = paramLayoutInflater.inflate(2130903079, paramViewGroup, false);
      this.trans.transactiontype = Transaction.Transtype.Withdrawal;
      withdrawal(this.rootView);
      continue;
      this.rootView = paramLayoutInflater.inflate(2130903070, paramViewGroup, false);
      this.trans.transactiontype = Transaction.Transtype.Deposit;
      Deposit(this.rootView);
      continue;
      this.rootView = paramLayoutInflater.inflate(2130903071, paramViewGroup, false);
      this.trans.transactiontype = Transaction.Transtype.LoanRepayment;
      LoanRepayment(this.rootView);
      continue;
      this.rootView = paramLayoutInflater.inflate(2130903078, paramViewGroup, false);
      this.trans.transactiontype = Transaction.Transtype.Transfer;
      Transfer(this.rootView);
      continue;
      this.rootView = paramLayoutInflater.inflate(2130903079, paramViewGroup, false);
      this.trans.transactiontype = Transaction.Transtype.Sharedeposit;
      Sharedeposit(this.rootView);
      continue;
      this.rootView = paramLayoutInflater.inflate(2130903068, paramViewGroup, false);
      this.trans.transactiontype = Transaction.Transtype.Balance;
      Balance(this.rootView);
      continue;
      this.rootView = paramLayoutInflater.inflate(2130903068, paramViewGroup, false);
      this.trans.transactiontype = Transaction.Transtype.Ministatment;
      Balance(this.rootView);
      continue;
      this.rootView = paramLayoutInflater.inflate(2130903078, paramViewGroup, false);
      this.trans.transactiontype = Transaction.Transtype.Paybill;
      Transfer(this.rootView);
      continue;
      this.rootView = paramLayoutInflater.inflate(2130903074, paramViewGroup, false);
      this.trans.transactiontype = Transaction.Transtype.Changepin;
      changepin(this.rootView);
      continue;
      this.rootView = paramLayoutInflater.inflate(2130903082, paramViewGroup, false);
      this.trans.transactiontype = Transaction.Transtype.Memberactivation;
      Activation(this.rootView);
      continue;
      this.rootView = paramLayoutInflater.inflate(2130903075, paramViewGroup, false);
      this.trans.transactiontype = Transaction.Transtype.MemberRegistration;
      Registration(this.rootView);
    }
  }
  
  public class ChangepinTask
    extends AsyncTask<Void, Void, Transaction>
  {
    private Transaction tr;
    
    ChangepinTask(Transaction paramTransaction)
    {
      this.tr = paramTransaction;
    }
    
    protected Transaction doInBackground(Void... paramVarArgs)
    {
      try
      {
        paramVarArgs = new Gson().toJson(this.tr);
        paramVarArgs = JsonParser.SendHttpPost(AgencyDetailFragment.this.getActivity(), "Changepin", paramVarArgs, "data");
        Type localType = new TypeToken() {}.getType();
        this.tr = ((Transaction)new Gson().fromJson(paramVarArgs, localType));
        paramVarArgs = this.tr;
        return paramVarArgs;
      }
      catch (Exception paramVarArgs)
      {
        paramVarArgs.printStackTrace();
        if (!paramVarArgs.getMessage().contains("Connection to")) {}
      }
      for (this.tr.message = "No Connection, make sure that your mobile data is enabled, or you are on a wifi.";; this.tr.message = paramVarArgs.getMessage()) {
        return this.tr;
      }
    }
    
    protected void onCancelled() {}
    
    protected void onPostExecute(Transaction paramTransaction)
    {
      AgencyDetailFragment.this.trans = paramTransaction;
      if (AgencyDetailFragment.this.trans.status == Transaction.Status.Successful)
      {
        Toast.makeText(AgencyDetailFragment.this.getActivity(), "Pin changed", 1).show();
        if (AgencyDetailFragment.this.twopane) {
          AgencyDetailFragment.this.getActivity().finish();
        }
        return;
      }
      AgencyDetailFragment.this.id_no.setError(this.tr.message);
      AgencyDetailFragment.this.id_no.requestFocus();
    }
  }
  
  public class GetaccountTask
    extends AsyncTask<Void, Void, Transaction>
  {
    private Transaction mmember;
    
    GetaccountTask(Transaction paramTransaction)
    {
      this.mmember = paramTransaction;
    }
    
    private void SelectAcc(Member paramMember)
    {
      AlertDialog.Builder localBuilder = new AlertDialog.Builder(AgencyDetailFragment.this.rootView.getContext());
      localBuilder.setTitle("Accounts");
      localBuilder.setMessage("Select Account to use");
      ListView localListView = new ListView(AgencyDetailFragment.this.rootView.getContext());
      localListView.setChoiceMode(1);
      localListView.setAdapter(new BindAccounts(AgencyDetailFragment.this.getActivity(), paramMember.accounts));
      localBuilder.setView(localListView);
      localBuilder.setPositiveButton("Ok", new DialogInterface.OnClickListener()
      {
        public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt)
        {
          AgencyDetailFragment.this.trans.account_1 = BindAccounts.outdata;
          if (AgencyDetailFragment.this.trans.account_1 != null)
          {
            AgencyDetailFragment.this.Account_No.setText(BindAccounts.outdata.Account_No);
            AgencyDetailFragment.this.Account_Name.setText(BindAccounts.outdata.Account_Name);
            switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[AgencyDetailFragment.this.trans.transactiontype.ordinal()])
            {
            }
          }
          do
          {
            return;
          } while (AgencyDetailFragment.this.trans.account_1 == null);
          new AgencyDetailFragment.TransactionrequestTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
        }
      });
      localBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener()
      {
        public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt)
        {
          AgencyDetailFragment.this.trans.account_1 = null;
          AgencyDetailFragment.this.Account_No.setText("");
          AgencyDetailFragment.this.Account_Name.setText("");
        }
      });
      localBuilder.show();
    }
    
    private void changepin()
    {
      View localView = LayoutInflater.from(AgencyDetailFragment.this.rootView.getContext()).inflate(2130903074, null);
      final EditText localEditText1 = (EditText)localView.findViewById(2131296360);
      final EditText localEditText2 = (EditText)localView.findViewById(2131296361);
      final EditText localEditText3 = (EditText)localView.findViewById(2131296362);
      AlertDialog.Builder localBuilder = new AlertDialog.Builder(AgencyDetailFragment.this.rootView.getContext());
      localBuilder.setTitle("Client Change Pin");
      localBuilder.setView(localView);
      localBuilder.setPositiveButton("Ok", new DialogInterface.OnClickListener()
      {
        public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {}
      });
      localBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener()
      {
        public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {}
      });
      AgencyDetailFragment.this.pindialog = localBuilder.create();
      AgencyDetailFragment.this.pindialog.show();
      AgencyDetailFragment.this.pindialog.getButton(-1).setOnClickListener(new View.OnClickListener()
      {
        public void onClick(View paramAnonymousView)
        {
          paramAnonymousView = localEditText1.getText().toString();
          String str1 = localEditText2.getText().toString();
          String str2 = localEditText3.getText().toString();
          if (TextUtils.isEmpty(paramAnonymousView))
          {
            localEditText1.setError(AgencyDetailFragment.this.getString(2131492891));
            localEditText1.requestFocus();
            return;
          }
          if (TextUtils.isEmpty(str1))
          {
            localEditText2.setError(AgencyDetailFragment.this.getString(2131492891));
            localEditText2.requestFocus();
            return;
          }
          if (TextUtils.isEmpty(str2))
          {
            localEditText3.setError(AgencyDetailFragment.this.getString(2131492891));
            localEditText3.requestFocus();
            return;
          }
          if (!paramAnonymousView.equals(AgencyDetailFragment.this.trans.member_1.pin))
          {
            localEditText1.setError(AgencyDetailFragment.this.getString(2131492890));
            localEditText1.requestFocus();
            return;
          }
          if (!str1.equals(str2))
          {
            localEditText3.setError(AgencyDetailFragment.this.getString(2131492889));
            localEditText3.requestFocus();
            return;
          }
          AgencyDetailFragment.this.trans.member_1.pin = str2;
          AgencyDetailFragment.this.trans.pinchanged = true;
          AgencyDetailFragment.this.trans.newpin = str2;
          AgencyDetailFragment.this.pindialog.dismiss();
          AgencyDetailFragment.this.pindialog = null;
        }
      });
      AgencyDetailFragment.this.pindialog.getButton(-2).setOnClickListener(new View.OnClickListener()
      {
        public void onClick(View paramAnonymousView)
        {
          AgencyDetailFragment.this.pindialog.dismiss();
          AgencyDetailFragment.this.pindialog = null;
        }
      });
    }
    
    protected Transaction doInBackground(Void... paramVarArgs)
    {
      try
      {
        paramVarArgs = new Gson();
        this.mmember.message = null;
        paramVarArgs = paramVarArgs.toJson(this.mmember);
        paramVarArgs = JsonParser.SendHttpPost(AgencyDetailFragment.this.getActivity(), "Accounts", paramVarArgs, "data");
        Type localType = new TypeToken() {}.getType();
        this.mmember = ((Transaction)new Gson().fromJson(paramVarArgs, localType));
        paramVarArgs = this.mmember;
        return paramVarArgs;
      }
      catch (Exception paramVarArgs)
      {
        paramVarArgs.printStackTrace();
        if (!paramVarArgs.getMessage().contains("Connection to")) {}
      }
      for (this.mmember.message = "No Connection, make sure that your mobile data is enabled, or you are on a wifi.";; this.mmember.message = paramVarArgs.getMessage()) {
        return this.mmember;
      }
    }
    
    protected void onCancelled() {}
    
    protected void onPostExecute(Transaction paramTransaction)
    {
      AgencyDetailFragment.this.trans = paramTransaction;
      if (paramTransaction.status != Transaction.Status.Failed) {
        switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[paramTransaction.transactiontype.ordinal()])
        {
        default: 
          switch (paramTransaction.member_1.accounts.size())
          {
          default: 
            switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[AgencyDetailFragment.this.trans.transactiontype.ordinal()])
            {
            default: 
              AgencyDetailFragment.this.trans.account_1 = ((Account)paramTransaction.member_1.accounts.get(0));
              if (AgencyDetailFragment.this.Account_No != null) {
                AgencyDetailFragment.this.Account_No.setText(AgencyDetailFragment.this.trans.account_1.Account_No);
              }
              if (AgencyDetailFragment.this.Account_Name != null) {
                AgencyDetailFragment.this.Account_Name.setText(AgencyDetailFragment.this.trans.account_1.Account_Name);
              }
              if (AgencyDetailFragment.this.trans.transactiontype == Transaction.Transtype.LoanRepayment) {
                switch (paramTransaction.member_1.loans.size())
                {
                default: 
                  AlertDialog.Builder localBuilder = new AlertDialog.Builder(AgencyDetailFragment.this.rootView.getContext());
                  localBuilder.setTitle("Loans");
                  localBuilder.setMessage("Select Loan to pay");
                  ListView localListView = new ListView(AgencyDetailFragment.this.rootView.getContext());
                  localListView.setChoiceMode(1);
                  localListView.setAdapter(new BindLoans(AgencyDetailFragment.this.getActivity(), paramTransaction.member_1.loans));
                  localBuilder.setView(localListView);
                  localBuilder.setPositiveButton("Ok", new DialogInterface.OnClickListener()
                  {
                    public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt)
                    {
                      if (BindLoans.outdata != null)
                      {
                        AgencyDetailFragment.this.loanNo.setText(BindLoans.outdata.Loan_No);
                        AgencyDetailFragment.this.loan_Type.setText(BindLoans.outdata.Loan_Type);
                        AgencyDetailFragment.this.trans.loan_no = BindLoans.outdata;
                        return;
                      }
                      AgencyDetailFragment.this.loanNo.setText("");
                      AgencyDetailFragment.this.loan_Type.setText("");
                    }
                  });
                  localBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener()
                  {
                    public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt)
                    {
                      AgencyDetailFragment.this.Account_No.setText("");
                      AgencyDetailFragment.this.Account_Name.setText("");
                    }
                  });
                  localBuilder.show();
                  AgencyDetailFragment.this.ploan.setVisibility(8);
                }
              }
              break;
            }
            break;
          }
          break;
        }
      }
      for (;;)
      {
        if (AgencyDetailFragment.this.pacc != null) {
          AgencyDetailFragment.this.pacc.setVisibility(8);
        }
        if (AgencyDetailFragment.this.pacc2 != null) {
          AgencyDetailFragment.this.pacc2.setVisibility(8);
        }
        return;
        if (AgencyDetailFragment.this.trans.account_1.Account_ok)
        {
          AgencyDetailFragment.this.Account_Name.setText(paramTransaction.account_1.Account_Name);
          break;
        }
        AgencyDetailFragment.this.Account_Name.setText(paramTransaction.account_1.Message);
        break;
        switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[paramTransaction.transactiontype.ordinal()])
        {
        default: 
          AgencyDetailFragment.this.id_no.setError("No Active Account");
          AgencyDetailFragment.this.id_no.requestFocus();
          break;
        case 1: 
          AgencyDetailFragment.this.id_no.setError("Invalid ID");
          AgencyDetailFragment.this.id_no.setText("");
          AgencyDetailFragment.this.id_no.requestFocus();
          break;
          AgencyDetailFragment.this.trans.account_1 = ((Account)paramTransaction.member_1.accounts.get(0));
          switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[AgencyDetailFragment.this.trans.transactiontype.ordinal()])
          {
          default: 
            AgencyDetailFragment.this.trans.account_1 = ((Account)paramTransaction.member_1.accounts.get(0));
            if (AgencyDetailFragment.this.Account_Name != null) {
              AgencyDetailFragment.this.Account_Name.setText(((Account)paramTransaction.member_1.accounts.get(0)).Account_Name);
            }
            if (AgencyDetailFragment.this.Account_No != null) {
              AgencyDetailFragment.this.Account_No.setText(((Account)paramTransaction.member_1.accounts.get(0)).Account_No);
            }
            label784:
            switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[AgencyDetailFragment.this.trans.transactiontype.ordinal()])
            {
            }
            break;
          }
          for (;;)
          {
            break;
            break label784;
            if (paramTransaction.account_2 == null)
            {
              AgencyDetailFragment.this.Account_Name.setText(((Account)paramTransaction.member_1.accounts.get(0)).Account_Name);
              AgencyDetailFragment.this.Account_No.setText(((Account)paramTransaction.member_1.accounts.get(0)).Account_No);
              break label784;
            }
            if (paramTransaction.account_2.Account_ok)
            {
              AgencyDetailFragment.this.Account_Name2.setText(paramTransaction.account_2.Account_Name);
              break label784;
            }
            AgencyDetailFragment.this.Account_Name2.setText(paramTransaction.account_2.Message);
            break label784;
            if (AgencyDetailFragment.this.trans.account_1 != null) {
              new AgencyDetailFragment.TransactionrequestTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
            }
          }
          break;
          SelectAcc(AgencyDetailFragment.this.trans.member_1);
          AgencyDetailFragment.this.pacc.setVisibility(8);
          break;
          if (AgencyDetailFragment.this.trans.account_2 == null)
          {
            SelectAcc(AgencyDetailFragment.this.trans.member_1);
            break;
          }
          if (AgencyDetailFragment.this.trans.account_2.Account_ok)
          {
            AgencyDetailFragment.this.Account_Name2.setText(paramTransaction.account_2.Account_Name);
            break;
          }
          AgencyDetailFragment.this.Account_Name2.setText(paramTransaction.account_2.Message);
          break;
          AgencyDetailFragment.this.trans.account_1 = ((Account)paramTransaction.member_1.accounts.get(0));
          if (AgencyDetailFragment.this.Account_No != null) {
            AgencyDetailFragment.this.Account_No.setText(AgencyDetailFragment.this.trans.account_1.Account_No);
          }
          if (AgencyDetailFragment.this.Account_Name != null) {
            AgencyDetailFragment.this.Account_Name.setText(AgencyDetailFragment.this.trans.account_1.Account_Name);
          }
          if (AgencyDetailFragment.this.trans.account_1 == null) {
            break;
          }
          new AgencyDetailFragment.TransactionrequestTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
          break;
          AgencyDetailFragment.this.id_no.setError("No Outstanding loans");
          AgencyDetailFragment.this.id_no.requestFocus();
          continue;
          AgencyDetailFragment.this.trans.loan_no = ((Loans)paramTransaction.member_1.loans.get(0));
          AgencyDetailFragment.this.loanNo.setText(((Loans)paramTransaction.member_1.loans.get(0)).Loan_No);
          AgencyDetailFragment.this.loan_Type.setText(((Loans)paramTransaction.member_1.loans.get(0)).Loan_Type);
          continue;
          if (paramTransaction.message != null) {
            AgencyDetailFragment.this.Info.setText(paramTransaction.message);
          }
          break;
        }
      }
    }
  }
  
  public class TransactionCompleteTask
    extends AsyncTask<Void, Void, Transaction>
  {
    private final ProgressDialog dialog = new ProgressDialog(AgencyDetailFragment.this.rootView.getContext());
    private Transaction tr;
    
    TransactionCompleteTask(Transaction paramTransaction)
    {
      this.tr = paramTransaction;
    }
    
    protected Transaction doInBackground(Void... paramVarArgs)
    {
      try
      {
        paramVarArgs = new Gson();
        this.tr.message = null;
        paramVarArgs = paramVarArgs.toJson(this.tr);
        paramVarArgs = JsonParser.SendHttpPost(AgencyDetailFragment.this.getActivity(), "Transactions", paramVarArgs, "data");
        Type localType = new TypeToken() {}.getType();
        this.tr = ((Transaction)new Gson().fromJson(paramVarArgs, localType));
        paramVarArgs = this.tr;
        return paramVarArgs;
      }
      catch (Exception paramVarArgs)
      {
        paramVarArgs.printStackTrace();
        if (!paramVarArgs.getMessage().contains("Connection to")) {}
      }
      for (this.tr.message = "No Connection, make sure that your mobile data is enabled, or you are on a wifi.";; this.tr.message = paramVarArgs.getMessage()) {
        return this.tr;
      }
    }
    
    protected void onCancelled() {}
    
    protected void onPostExecute(final Transaction paramTransaction)
    {
      if (this.dialog.isShowing()) {
        this.dialog.dismiss();
      }
      AgencyDetailFragment.this.trans = paramTransaction;
      paramTransaction = LayoutInflater.from(AgencyDetailFragment.this.rootView.getContext()).inflate(2130903076, null);
      Object localObject = (TextView)paramTransaction.findViewById(2131296336);
      TextView localTextView1 = (TextView)paramTransaction.findViewById(2131296363);
      TextView localTextView2 = (TextView)paramTransaction.findViewById(2131296333);
      TextView localTextView3 = (TextView)paramTransaction.findViewById(2131296326);
      TextView localTextView4 = (TextView)paramTransaction.findViewById(2131296335);
      TextView localTextView5 = (TextView)paramTransaction.findViewById(2131296370);
      TableRow localTableRow = (TableRow)paramTransaction.findViewById(2131296334);
      localTextView5.setText(AgencyDetailFragment.this.trans.reference);
      ((TextView)localObject).setText(AgencyDetailFragment.this.trans.status.toString());
      localTextView2.setText(AgencyDetailFragment.this.trans.transactiontype.toString());
      localTextView4.setText(String.valueOf(AgencyDetailFragment.this.trans.amount));
      switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[AgencyDetailFragment.this.trans.transactiontype.ordinal()])
      {
      }
      for (;;)
      {
        if (AgencyDetailFragment.this.trans.message != null) {
          localTextView1.setText(AgencyDetailFragment.this.trans.message);
        }
        localObject = new AlertDialog.Builder(AgencyDetailFragment.this.rootView.getContext());
        ((AlertDialog.Builder)localObject).setTitle("RESULTS");
        ((AlertDialog.Builder)localObject).setView(paramTransaction);
        ((AlertDialog.Builder)localObject).setPositiveButton("Ok", new DialogInterface.OnClickListener()
        {
          public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {}
        });
        paramTransaction = ((AlertDialog.Builder)localObject).create();
        paramTransaction.show();
        paramTransaction.getButton(-1).setOnClickListener(new View.OnClickListener()
        {
          public void onClick(View paramAnonymousView)
          {
            paramTransaction.dismiss();
            AgencyDetailFragment.this.trans = null;
            if (!AgencyDetailFragment.this.twopane)
            {
              AgencyDetailFragment.this.getActivity().finish();
              return;
            }
            AgencyDetailFragment.this.rootView = null;
          }
        });
        return;
        localTextView3.setText(AgencyDetailFragment.this.trans.account_1.Account_No);
        continue;
        localTableRow.setVisibility(8);
        localTextView3.setText(AgencyDetailFragment.this.trans.account_1.Account_No);
        continue;
        localTextView3.setText(AgencyDetailFragment.this.trans.loan_no.Loan_No);
        continue;
        localTextView3.setText(AgencyDetailFragment.this.trans.account_1.Account_No + " To " + AgencyDetailFragment.this.trans.account_2.Account_No);
        continue;
        localTextView3.setText(AgencyDetailFragment.this.trans.member_1.name + "\n" + AgencyDetailFragment.this.trans.member_1.id_no + "\n" + AgencyDetailFragment.this.trans.member_1.telephone);
        continue;
        localTextView3.setText(AgencyDetailFragment.this.trans.account_1.Account_No + "\n" + AgencyDetailFragment.this.trans.account_1.Account_Name + "\n" + AgencyDetailFragment.this.trans.account_1.Telephone);
      }
    }
    
    protected void onPreExecute()
    {
      this.dialog.setMessage("Processing request...");
      this.dialog.show();
    }
  }
  
  public class TransactionrequestTask
    extends AsyncTask<Void, Void, Transaction>
  {
    private final ProgressDialog dialog = new ProgressDialog(AgencyDetailFragment.this.rootView.getContext());
    private Transaction tr;
    
    TransactionrequestTask(Transaction paramTransaction)
    {
      this.tr = paramTransaction;
    }
    
    protected Transaction doInBackground(Void... paramVarArgs)
    {
      try
      {
        paramVarArgs = new Gson();
        this.tr.message = null;
        if ((this.tr.account_1 != null) && (this.tr.member_1 != null))
        {
          this.tr.member_1.name = this.tr.account_1.Account_Name;
          this.tr.member_1.telephone = this.tr.account_1.Telephone;
        }
        paramVarArgs = paramVarArgs.toJson(this.tr);
        paramVarArgs = JsonParser.SendHttpPost(AgencyDetailFragment.this.getActivity(), "Transactions", paramVarArgs, "data");
        Type localType = new TypeToken() {}.getType();
        this.tr = ((Transaction)new Gson().fromJson(paramVarArgs, localType));
        paramVarArgs = this.tr;
        return paramVarArgs;
      }
      catch (Exception paramVarArgs)
      {
        paramVarArgs.printStackTrace();
        if (!paramVarArgs.getMessage().contains("Connection to")) {}
      }
      for (this.tr.message = "No Connection, make sure that your mobile data is enabled, or you are on a wifi.";; this.tr.message = paramVarArgs.getMessage()) {
        return this.tr;
      }
    }
    
    protected void onCancelled() {}
    
    protected void onPostExecute(final Transaction paramTransaction)
    {
      if (this.dialog.isShowing()) {
        this.dialog.dismiss();
      }
      AgencyDetailFragment.this.trans = paramTransaction;
      int i = 1;
      int j = 1;
      if (AgencyDetailFragment.this.trans.status == Transaction.Status.Confirmation)
      {
        AgencyDetailFragment.this.trans.status = Transaction.Status.Pending;
        TableRow localTableRow2;
        switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[AgencyDetailFragment.this.trans.transactiontype.ordinal()])
        {
        default: 
          i = j;
          if (AgencyDetailFragment.this.trans.amount < AgencyDetailFragment.this.trans.Minimun_Amount)
          {
            i = j;
            if (AgencyDetailFragment.this.amount != null)
            {
              AgencyDetailFragment.this.amount.requestFocus();
              AgencyDetailFragment.this.amount.setError("Minimun Amount allowed is " + AgencyDetailFragment.this.trans.Minimun_Amount);
              AgencyDetailFragment.this.trans.status = Transaction.Status.Pending;
              i = 0;
            }
          }
          j = i;
          if (AgencyDetailFragment.this.trans.amount > AgencyDetailFragment.this.trans.Maximun_Amount)
          {
            j = i;
            if (AgencyDetailFragment.this.amount != null)
            {
              AgencyDetailFragment.this.amount.requestFocus();
              AgencyDetailFragment.this.amount.setError("Maximun Amount allowed is " + AgencyDetailFragment.this.trans.Maximun_Amount);
              j = 0;
              AgencyDetailFragment.this.trans.status = Transaction.Status.Pending;
            }
          }
          if (j == 1)
          {
            localObject2 = LayoutInflater.from(AgencyDetailFragment.this.rootView.getContext()).inflate(2130903069, null);
            localObject3 = (TextView)((View)localObject2).findViewById(2131296333);
            localTextView1 = (TextView)((View)localObject2).findViewById(2131296326);
            localObject4 = (TableRow)((View)localObject2).findViewById(2131296334);
            localTextView2 = (TextView)((View)localObject2).findViewById(2131296335);
            localTableRow1 = (TableRow)((View)localObject2).findViewById(2131296339);
            localTableRow2 = (TableRow)((View)localObject2).findViewById(2131296337);
            paramTransaction = (EditText)((View)localObject2).findViewById(2131296338);
            localObject1 = (EditText)((View)localObject2).findViewById(2131296340);
            ((TextView)localObject3).setText(AgencyDetailFragment.this.trans.transactiontype.toString());
            switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[AgencyDetailFragment.this.trans.transactiontype.ordinal()])
            {
            }
          }
          break;
        }
        for (;;)
        {
          localTextView2.setText(String.valueOf(AgencyDetailFragment.this.trans.amount));
          localObject3 = new AlertDialog.Builder(AgencyDetailFragment.this.rootView.getContext());
          ((AlertDialog.Builder)localObject3).setTitle("Client Confirmation");
          ((AlertDialog.Builder)localObject3).setView((View)localObject2);
          ((AlertDialog.Builder)localObject3).setPositiveButton("Ok", new DialogInterface.OnClickListener()
          {
            public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {}
          });
          ((AlertDialog.Builder)localObject3).setNegativeButton("Cancel", new DialogInterface.OnClickListener()
          {
            public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {}
          });
          localObject2 = ((AlertDialog.Builder)localObject3).create();
          ((AlertDialog)localObject2).show();
          ((AlertDialog)localObject2).getButton(-1).setOnClickListener(new View.OnClickListener()
          {
            public void onClick(View paramAnonymousView)
            {
              paramAnonymousView = paramTransaction.getText().toString();
              switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[AgencyDetailFragment.this.trans.transactiontype.ordinal()])
              {
              case 6: 
              default: 
                paramTransaction.setError(null);
                if (TextUtils.isEmpty(paramAnonymousView))
                {
                  paramTransaction.setError(AgencyDetailFragment.this.getString(2131492891));
                  paramTransaction.requestFocus();
                  return;
                }
                break;
              }
              do
              {
                do
                {
                  AgencyDetailFragment.this.trans.status = Transaction.Status.Confirmation;
                  new AgencyDetailFragment.TransactionCompleteTask(AgencyDetailFragment.this, AgencyDetailFragment.this.trans).execute(new Void[0]);
                  localObject2.dismiss();
                  return;
                  paramTransaction.setError(null);
                  if (TextUtils.isEmpty(paramAnonymousView))
                  {
                    paramTransaction.setError(AgencyDetailFragment.this.getString(2131492891));
                    paramTransaction.requestFocus();
                    return;
                  }
                } while (paramTransaction.getText().toString().equals(AgencyDetailFragment.this.trans.code));
                paramTransaction.setError(AgencyDetailFragment.this.getString(2131492888));
                paramTransaction.requestFocus();
                return;
                localObject1.setError(null);
                if (TextUtils.isEmpty(localObject1.getText().toString()))
                {
                  localObject1.setError(AgencyDetailFragment.this.getString(2131492891));
                  localObject1.requestFocus();
                  return;
                }
                if (!paramTransaction.getText().toString().equals(AgencyDetailFragment.this.trans.code))
                {
                  paramTransaction.setError(AgencyDetailFragment.this.getString(2131492888));
                  paramTransaction.requestFocus();
                  return;
                }
              } while (localObject1.getText().toString().equals(AgencyDetailFragment.this.trans.member_1.pin));
              localObject1.setError(AgencyDetailFragment.this.getString(2131492895));
              localObject1.requestFocus();
            }
          });
          ((AlertDialog)localObject2).getButton(-2).setOnClickListener(new View.OnClickListener()
          {
            public void onClick(View paramAnonymousView)
            {
              AgencyDetailFragment.this.trans.status = Transaction.Status.Pending;
              localObject2.dismiss();
            }
          });
          return;
          j = i;
          break;
          localTableRow1.setVisibility(8);
          localTableRow2.setVisibility(8);
          localTextView1.setText(AgencyDetailFragment.this.trans.account_1.Account_No + "\n" + AgencyDetailFragment.this.trans.account_1.Account_Name);
          continue;
          localTextView1.setText(AgencyDetailFragment.this.trans.account_1.Account_No);
          continue;
          ((TableRow)localObject4).setVisibility(8);
          localTextView1.setText(AgencyDetailFragment.this.trans.account_1.Account_No);
          continue;
          localTableRow1.setVisibility(8);
          localTableRow2.setVisibility(8);
          localTextView1.setText(AgencyDetailFragment.this.trans.loan_no.Loan_No);
          continue;
          localTextView1.setText(AgencyDetailFragment.this.trans.account_1.Account_No + " To " + AgencyDetailFragment.this.trans.account_2.Account_No);
          continue;
          localTableRow1.setVisibility(8);
          localTextView1.setText(AgencyDetailFragment.this.trans.member_1.name + "\n" + AgencyDetailFragment.this.trans.member_1.id_no + "\n" + AgencyDetailFragment.this.trans.member_1.telephone);
          continue;
          localTableRow1.setVisibility(8);
          ((TableRow)localObject4).setVisibility(8);
          localTextView1.setText(AgencyDetailFragment.this.trans.account_1.Account_No + "\n" + AgencyDetailFragment.this.trans.account_1.Account_Name + "\n" + AgencyDetailFragment.this.trans.account_1.Telephone);
          continue;
          localTableRow1.setVisibility(8);
          localTextView1.setText(AgencyDetailFragment.this.trans.member_1.name + "\n" + AgencyDetailFragment.this.trans.member_1.id_no + "\n" + AgencyDetailFragment.this.trans.member_1.telephone);
        }
      }
      paramTransaction = LayoutInflater.from(AgencyDetailFragment.this.rootView.getContext()).inflate(2130903076, null);
      final Object localObject1 = (TextView)paramTransaction.findViewById(2131296336);
      final Object localObject2 = (TextView)paramTransaction.findViewById(2131296363);
      Object localObject3 = (TextView)paramTransaction.findViewById(2131296333);
      TextView localTextView1 = (TextView)paramTransaction.findViewById(2131296326);
      Object localObject4 = (TextView)paramTransaction.findViewById(2131296335);
      TextView localTextView2 = (TextView)paramTransaction.findViewById(2131296370);
      TableRow localTableRow1 = (TableRow)paramTransaction.findViewById(2131296334);
      localTextView2.setText(AgencyDetailFragment.this.trans.reference);
      ((TextView)localObject1).setText(AgencyDetailFragment.this.trans.status.toString());
      ((TextView)localObject3).setText(AgencyDetailFragment.this.trans.transactiontype.toString());
      switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[AgencyDetailFragment.this.trans.transactiontype.ordinal()])
      {
      }
      for (;;)
      {
        ((TextView)localObject4).setText(String.valueOf(AgencyDetailFragment.this.trans.amount));
        if (AgencyDetailFragment.this.trans.message != null) {
          ((TextView)localObject2).setText(AgencyDetailFragment.this.trans.message);
        }
        localObject1 = new AlertDialog.Builder(AgencyDetailFragment.this.rootView.getContext());
        ((AlertDialog.Builder)localObject1).setTitle("RESULTS");
        ((AlertDialog.Builder)localObject1).setView(paramTransaction);
        ((AlertDialog.Builder)localObject1).setPositiveButton("Ok", new DialogInterface.OnClickListener()
        {
          public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt) {}
        });
        paramTransaction = ((AlertDialog.Builder)localObject1).create();
        paramTransaction.show();
        paramTransaction.getButton(-1).setOnClickListener(new View.OnClickListener()
        {
          public void onClick(View paramAnonymousView)
          {
            paramTransaction.dismiss();
            AgencyDetailFragment.this.trans = null;
            if (!AgencyDetailFragment.this.twopane)
            {
              AgencyDetailFragment.this.getActivity().finish();
              return;
            }
            AgencyDetailFragment.this.rootView = null;
          }
        });
        return;
        localTextView1.setText(AgencyDetailFragment.this.trans.account_1.Account_No);
        continue;
        localTextView1.setText(AgencyDetailFragment.this.trans.loan_no.Loan_No);
        continue;
        localTextView1.setText(AgencyDetailFragment.this.trans.account_1.Account_No + " To " + AgencyDetailFragment.this.trans.account_2.Account_No);
        continue;
        localTextView1.setText(AgencyDetailFragment.this.trans.member_1.name + "\n" + AgencyDetailFragment.this.trans.member_1.id_no + "\n" + AgencyDetailFragment.this.trans.member_1.telephone);
        continue;
        localTableRow1.setVisibility(8);
        localTextView1.setText(AgencyDetailFragment.this.trans.account_1.Account_No + "\n" + AgencyDetailFragment.this.trans.account_1.Account_Name + "\n" + AgencyDetailFragment.this.trans.account_1.Telephone);
      }
    }
    
    protected void onPreExecute()
    {
      this.dialog.setMessage("Processing request...");
      this.dialog.show();
    }
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\com\example\paul\a_sacco\AgencyDetailFragment.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */
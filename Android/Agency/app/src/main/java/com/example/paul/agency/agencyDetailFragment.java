package com.example.paul.agency;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;

import com.google.gson.Gson;
import com.google.gson.JsonParser;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;


/**
 * A fragment representing a single agency detail screen.
 * This fragment is either contained in a {@link agencyListActivity}
 * in two-pane mode (on tablets) or a {@link agencyDetailActivity}
 * on handsets.
 */
public class agencyDetailFragment extends Fragment {
    /**
     * The fragment argument representing the item ID that this fragment
     * represents.
     */
    public static final String ARG_ITEM_ID = "item_id";
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
    private com.example.paul.agency.dummy.Menu.DummyItem mItem;
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
        this.id_no = ((EditText)paramView.findViewById(R.id.NationalId));
        this.Account_No = ((TextView)paramView.findViewById(R.id.txtaccountno));
        this.Account_Name = ((TextView)paramView.findViewById(R.id.txtaccountname));
        this.confirm = ((Button)paramView.findViewById(R.id.Confirm));
        this.cancel = ((Button)paramView.findViewById(R.id.Cancel));
        this.pacc = ((ProgressBar)paramView.findViewById(R.id.paccno));
        this.trans.status = Transaction.Status.Pending;
        this.confirm.setOnClickListener(new View.OnClickListener()
        {
            public void onClick(View paramAnonymousView)
            {
                id_no.setError(null);
                String id  = id_no.getText().toString();

                if (TextUtils.isEmpty(id))
                {
                    id_no.setError(String.valueOf( R.string.error_field_required));
                 return;;
                }

                member = new Member();
                member.id_no = id_no.getText().toString();
                trans.member_1 = member;
                pacc.setVisibility(View.VISIBLE);
                new GetaccountTask(this, trans).execute(new Void[0]);
            }
        });
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
            AlertDialog.Builder localBuilder = new AlertDialog.Builder(rootView.getContext());
            localBuilder.setTitle("Accounts");
            localBuilder.setMessage("Select Account to use");
            ListView localListView = new ListView(rootView.getContext());
            localListView.setChoiceMode(1);
            localListView.setAdapter(new BindAccounts(getActivity(), paramMember.accounts));
            localBuilder.setView(localListView);
            localBuilder.setPositiveButton("Ok", new DialogInterface.OnClickListener()
            {
                public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt)
                {
                    trans.account_1 = BindAccounts.outdata;
                    if (trans.account_1 != null)
                    {
                      Account_No.setText(BindAccounts.outdata.Account_No);
                      Account_Name.setText(BindAccounts.outdata.Account_Name);
                        switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[.trans.transactiontype.ordinal()])
                        {
                        }
                    }
                    do
                    {
                        return;
                    } while (.trans.account_1 == null);
                    new AgencyDetailFragment.TransactionrequestTask(, .trans).execute(new Void[0]);
                }
            });
            localBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener()
            {
                public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt)
                {
                  trans.account_1 = null;
                  Account_No.setText("");
                  Account_Name.setText("");
                }
            });
            localBuilder.show();
        }

        private void changepin()
        {
            View localView = LayoutInflater.from(rootView.getContext()).inflate(2130903074, null);
            final EditText localEditText1 = (EditText)localView.findViewById(2131296360);
            final EditText localEditText2 = (EditText)localView.findViewById(2131296361);
            final EditText localEditText3 = (EditText)localView.findViewById(2131296362);
            AlertDialog.Builder localBuilder = new AlertDialog.Builder(rootView.getContext());
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
          pindialog = localBuilder.create();
          pindialog.show();
          pindialog.getButton(-1).setOnClickListener(new View.OnClickListener()
            {
                public void onClick(View paramAnonymousView)
                {
                    paramAnonymousView = localEditText1.getText().toString();
                    String str1 = localEditText2.getText().toString();
                    String str2 = localEditText3.getText().toString();
                    if (TextUtils.isEmpty(paramAnonymousView))
                    {
                        localEditText1.setError(.getString(2131492891));
                        localEditText1.requestFocus();
                        return;
                    }
                    if (TextUtils.isEmpty(str1))
                    {
                        localEditText2.setError(.getString(2131492891));
                        localEditText2.requestFocus();
                        return;
                    }
                    if (TextUtils.isEmpty(str2))
                    {
                        localEditText3.setError(.getString(2131492891));
                        localEditText3.requestFocus();
                        return;
                    }
                    if (!paramAnonymousView.equals(trans.member_1.pin))
                    {
                        localEditText1.setError(.getString(2131492890));
                        localEditText1.requestFocus();
                        return;
                    }
                    if (!str1.equals(str2))
                    {
                        localEditText3.setError(getString(2131492889));
                        localEditText3.requestFocus();
                        return;
                    }
                  trans.member_1.pin = str2;
                  trans.pinchanged = true;
                  trans.newpin = str2;
                  pindialog.dismiss();
                  pindialog = null;
                }
            });
          pindialog.getButton(-2).setOnClickListener(new View.OnClickListener()
            {
                public void onClick(View paramAnonymousView)
                {
                  pindialog.dismiss();
                  pindialog = null;
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
                paramVarArgs = JsonParser.SendHttpPost(getActivity(), "Accounts", paramVarArgs, "data");
                Type localType = new TypeToken() {}getType();
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
          trans = paramTransaction;
            if (paramTransaction.status != Transaction.Status.Failed) {
                switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[paramTransaction.transactiontype.ordinal()])
                {
                    default:
                        switch (paramTransaction.member_1.accounts.size())
                        {
                            default:
                                switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[.trans.transactiontype.ordinal()])
                            {
                                default:
                                  trans.account_1 = ((Account)paramTransaction.member_1.accounts.get(0));
                                    if (Account_No != null) {
                                      Account_No.setText(trans.account_1.Account_No);
                                    }
                                    if (Account_Name != null) {
                                      Account_Name.setText(trans.account_1.Account_Name);
                                    }
                                    if (trans.transactiontype == Transaction.Transtype.LoanRepayment) {
                                        switch (paramTransaction.member_1.loans.size())
                                        {
                                            default:
                                                AlertDialog.Builder localBuilder = new AlertDialog.Builder(rootView.getContext());
                                                localBuilder.setTitle("Loans");
                                                localBuilder.setMessage("Select Loan to pay");
                                                ListView localListView = new ListView(rootView.getContext());
                                                localListView.setChoiceMode(1);
                                                localListView.setAdapter(new BindLoans(getActivity(), paramTransaction.member_1.loans));
                                                localBuilder.setView(localListView);
                                                localBuilder.setPositiveButton("Ok", new DialogInterface.OnClickListener()
                                                {
                                                    public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt)
                                                    {
                                                        if (BindLoans.outdata != null)
                                                        {
                                                          loanNo.setText(BindLoans.outdata.Loan_No);
                                                          loan_Type.setText(BindLoans.outdata.Loan_Type);
                                                          trans.loan_no = BindLoans.outdata;
                                                            return;
                                                        }
                                                      loanNo.setText("");
                                                      loan_Type.setText("");
                                                    }
                                                });
                                                localBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener()
                                                {
                                                    public void onClick(DialogInterface paramAnonymousDialogInterface, int paramAnonymousInt)
                                                    {
                                                      Account_No.setText("");
                                                      Account_Name.setText("");
                                                    }
                                                });
                                                localBuilder.show();
                                              ploan.setVisibility(8);
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
                if (pacc != null) {
                  pacc.setVisibility(View.VISIBLE);
                }
                if (pacc2 != null) {
                  pacc2.setVisibility(View.VISIBLE);
                }
                return;
                if (trans.account_1.Account_ok)
                {
                  Account_Name.setText(paramTransaction.account_1.Account_Name);
                    break;
                }
              Account_Name.setText(paramTransaction.account_1.Message);
                break;
                switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[paramTransaction.transactiontype.ordinal()])
                {
                    default:
                      id_no.setError("No Active Account");
                      id_no.requestFocus();
                        break;
                    case 1:
                      id_no.setError("Invalid ID");
                      id_no.setText("");
                      id_no.requestFocus();
                        break;
                  trans.account_1 = ((Account)paramTransaction.member_1.accounts.get(0));
                    switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[.trans.transactiontype.ordinal()])
                    {
                        default:
                          trans.account_1 = ((Account)paramTransaction.member_1.accounts.get(0));
                            if (Account_Name != null) {
                              Account_Name.setText(((Account)paramTransaction.member_1.accounts.get(0)).Account_Name);
                            }
                            if (Account_No != null) {
                              Account_No.setText(((Account)paramTransaction.member_1.accounts.get(0)).Account_No);
                            }
                            label784:
                            switch (AgencyDetailFragment.19.$SwitchMap$com$example$paul$a_sacco$Transaction$Transtype[.trans.transactiontype.ordinal()])
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
                          Account_Name.setText(((Account)paramTransaction.member_1.accounts.get(0)).Account_Name);
                          Account_No.setText(((Account)paramTransaction.member_1.accounts.get(0)).Account_No);
                            break label784;
                        }
                        if (paramTransaction.account_2.Account_ok)
                        {
                          Account_Name2.setText(paramTransaction.account_2.Account_Name);
                            break label784;
                        }
                      Account_Name2.setText(paramTransaction.account_2.Message);
                        break label784;
                        if (trans.account_1 != null) {
                            new TransactionrequestTask( trans).execute(new Void[0]);
                        }
                    }
                    break;
                    SelectAcc(trans.member_1);
                  pacc.setVisibility(8);
                    break;
                    if (trans.account_2 == null)
                    {
                        SelectAcc(trans.member_1);
                        break;
                    }
                    if (trans.account_2.Account_ok)
                    {
                      Account_Name2.setText(paramTransaction.account_2.Account_Name);
                        break;
                    }
                  Account_Name2.setText(paramTransaction.account_2.Message);
                    break;
                  trans.account_1 = ((Account)paramTransaction.member_1.accounts.get(0));
                    if (Account_No != null) {
                      Account_No.setText(trans.account_1.Account_No);
                    }
                    if (Account_Name != null) {
                      Account_Name.setText(trans.account_1.Account_Name);
                    }
                    if (trans.account_1 == null) {
                        break;
                    }
                    new AgencyDetailFragment.TransactionrequestTask(, trans).execute(new Void[0]);
                    break;
                  id_no.setError("No Outstanding loans");
                  id_no.requestFocus();
                    continue;
                  trans.loan_no = ((Loans)paramTransaction.member_1.loans.get(0));
                  loanNo.setText(((Loans)paramTransaction.member_1.loans.get(0)).Loan_No);
                  loan_Type.setText(((Loans)paramTransaction.member_1.loans.get(0)).Loan_Type);
                    continue;
                    if (paramTransaction.message != null) {
                      Info.setText(paramTransaction.message);
                    }
                    break;
                }
            }
        }
    }
    /**
     * Mandatory empty constructor for the fragment manager to instantiate the
     * fragment (e.g. upon screen orientation changes).
     */
    public agencyDetailFragment() {
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        if (getArguments().containsKey(ARG_ITEM_ID)) {
            // Load the dummy content specified by the fragment
            // arguments. In a real-world scenario, use a Loader
            // to load content from a content provider.
            mItem =  com.example.paul.agency.dummy.Menu.ITEM_MAP.get(getArguments().getString(ARG_ITEM_ID));
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_agency_detail, container, false);

        // Show the dummy content as text in a TextView.
        if (mItem != null) {
            ((TextView) rootView.findViewById(R.id.agency_detail)).setText(mItem.content);
        }

        return rootView;
    }
}

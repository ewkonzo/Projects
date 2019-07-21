package com.example.paul.m_branch;

import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.HashMap;
import java.util.List;

public class Receipts extends BaseExpandableListAdapter {

    private Context _context;
    private DB db;
    private List<summaries.Receipts> _listDataHeader; // header titles
    private HashMap<summaries.Receipts, List<transaction>> _listDataChild;

    public Receipts(Context context, List<summaries.Receipts> listDataHeader,
                    HashMap<summaries.Receipts, List<transaction>> listChildData, DB d) {
        this._context = context;
        this._listDataHeader = listDataHeader;
        this._listDataChild = listChildData;
        this.db = d;
    }

    @Override
    public Object getChild(int groupPosition, int childPosititon) {
        return this._listDataChild.get(this._listDataHeader.get(groupPosition))
                .get(childPosititon);
    }

    @Override
    public long getChildId(int groupPosition, int childPosition) {
        return childPosition;
    }

    @Override
    public View getChildView(int groupPosition, final int childPosition,
                             boolean isLastChild, View convertView, ViewGroup parent) {

        final transaction t = (transaction) getChild(groupPosition, childPosition);

        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) this._context
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.reportreceiptlist, null);
        }
        TextView recno = convertView.findViewById(R.id.Receiptno);
        recno.setText(t.Document_No);

        TextView time = convertView.findViewById(R.id.time);
        time.setText(t.Time);

        TextView type = convertView.findViewById(R.id.type);
        type.setText(t.typename);
        TextView loanno = convertView.findViewById(R.id.loanno);
        if(t.Type.contains("LOAN"))
        loanno.setText(t.Loan_No +"("+ t.Ward +")");
        else
            loanno.setText(t.Loan_No);

        TextView txtamount = convertView.findViewById(R.id.Amount);
        txtamount.setText(String.format("%.2f", t.Amount));

        ImageView sent = convertView.findViewById(R.id.sent);
        if (!t.sent)
            sent.setVisibility(View.GONE);

        return convertView;
    }

    @Override
    public int getChildrenCount(int groupPosition) {
               try{
                      return this._listDataChild.get(this._listDataHeader.get(groupPosition))
                .size();}
                catch (Exception e){
                   return 0;
                }
    }
    @Override
    public Object getGroup(int groupPosition) {
        return this._listDataHeader.get(groupPosition);
    }

    @Override
    public int getGroupCount() {
        return this._listDataHeader.size();
    }
    @Override
    public long getGroupId(int groupPosition) {
        return groupPosition;
    }
    @Override
    public View getGroupView(int groupPosition, boolean isExpanded,
                             View convertView, ViewGroup parent) {
        final summaries.Receipts headerTitle = (summaries.Receipts) getGroup(groupPosition);
        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) this._context
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.receiptgroup, null);
        }
        ImageView im = convertView.findViewById(R.id.groupheadericon);

        TextView lblgroupname = convertView
                .findViewById(R.id.lblListHeader);
        lblgroupname.setText(headerTitle.date);

        TextView lblrec = convertView
                .findViewById(R.id.lblListreceipt);
        lblrec.setText(headerTitle.receipt + "(" + headerTitle.Count + ")");

        TextView lblmno = convertView
                .findViewById(R.id.memberno);
        lblmno.setText(headerTitle.No);

        TextView mname = convertView
                .findViewById(R.id.membername);
        mname.setText(headerTitle.Name);


        TextView lblcount = convertView
                .findViewById(R.id.groupcountvalue);
        lblcount.setText(String.valueOf(headerTitle.user));

        TextView lbltotal = convertView
                .findViewById(R.id.grouptotalvalue);
        lbltotal.setText(String.format("%.2f", headerTitle.Total));

        Calendar cdt;
        cdt = Calendar.getInstance();
        SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
        final String formattedDate = df.format(cdt.getTime());
        final ImageView reverse = convertView.findViewById(R.id.reverse);
        reverse.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                List<transaction> d = db.gettransbybatch(headerTitle.receipt + "R");
                if (d.size() == 0) {
                    List<transaction> t = db.gettransbybatch(headerTitle.receipt);
                    for (transaction tt : t
                            ) {
                        tt.Constituency = "1";
                        db.updatetrans(tt);
                        tt.sent = false;
                        tt.Document_No = tt.Document_No + "R";
                        tt.OTTN = tt.OTTN + "R";
                        tt.Amount = tt.Amount * -1;
                        db.inserttrans(tt);
                        reverse.setVisibility(View.GONE);
                    }
                    summaries.Receipts r = new summaries.Receipts();
                    r.date= t.get(0).Date;
                    r.No = t.get(0).Account_No  ;
                    r.Name = t.get(0).Account_Name  ;
                    r.Count = t.size();
                    r.user   = t.get(0).Agent_Code;
                    r.Total = headerTitle.Total;
                    _listDataHeader.add(r);
                    notifyDataSetChanged();
                }
            }
        });
        ImageView print = convertView.findViewById(R.id.printdaily);
        print.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                db.post(headerTitle.receipt);
                summaries.printer p = new summaries.printer();
                p.printcollection(null, db.gettransbybatch(headerTitle.receipt));
            }
        });
        reverse.setVisibility(View.VISIBLE);
        print.setVisibility(View.VISIBLE);
        List<transaction> d = db.gettransbybatch(headerTitle.receipt);
        if (d.size() > 0) {
               if (d.get(0).Constituency != null) {
                if ((d.get(0).Constituency.equals("1"))) {
                    reverse.setVisibility(View.GONE);
                    print.setVisibility(View.GONE);
                }
            }
            if (!d.get(0).Date.equals(formattedDate)) {
                   reverse.setVisibility(View.GONE);
                print.setVisibility(View.GONE);
            }
        }
        if (Myvariables.CurrentAgent.Account_type !=1) {
            if (reverse.getVisibility() == View.VISIBLE) {
                reverse.setVisibility(View.GONE);
            }
        }


        return convertView;
    }
    @Override
    public boolean hasStableIds() {
        return true;
    }
    @Override
    public boolean isChildSelectable(int groupPosition, int childPosition) {
        return true;
    }
}
package com.example.paul.m_branch;
import java.util.HashMap;
import java.util.List;

import android.content.Context;
import android.graphics.Typeface;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

public class ExpandableListAdapter extends BaseExpandableListAdapter {

    private Context _context;
    private DB db ;
    private List<summaries.collectiondates> _listDataHeader; // header titles
    private HashMap<summaries.collectiondates, List<transaction>> _listDataChild;
    public ExpandableListAdapter(Context context, List<summaries.collectiondates> listDataHeader,
                                 HashMap<summaries.collectiondates, List<transaction>> listChildData,DB d) {
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
            convertView = infalInflater.inflate(R.layout.reportlist, null);
        }

        TextView txtmemberno = (TextView) convertView.findViewById(R.id.memberno);
        txtmemberno.setText(t.Account_No);
        TextView txtmembername = (TextView) convertView.findViewById(R.id.membername);
        txtmembername.setText(t.Account_Name);
        TextView txtreference = (TextView) convertView.findViewById(R.id.reference);
        txtreference.setText(t.Document_No);
        TextView txtreceipt = (TextView) convertView.findViewById(R.id.receiptno);
        txtreceipt.setText(t.Date + " "+ t.Time);
        TextView txtttype = (TextView) convertView.findViewById(R.id.transtype);
        if(!t.Loan_No.equals("")) {
            if (t.Type.contains("LOAN"))
            txtttype.setText(t.typename + "(" + t.Ward +")");
            else
                txtttype.setText(t.typename + "(" + t.Loan_No+")" );
        }else
            txtttype.setText(t.typename);

        TextView txtamount = (TextView) convertView.findViewById(R.id.tamount);
        txtamount.setText(String.format("%.2f", t.Amount));
        ImageView sent = (ImageView)convertView.findViewById(R.id.sent);
        if(!t.sent)
            sent.setVisibility(View.GONE);

        return convertView;
    }

    @Override
    public int getChildrenCount(int groupPosition) {
        return this._listDataChild.get(this._listDataHeader.get(groupPosition))
                .size();
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
        final summaries.collectiondates headerTitle = (summaries.collectiondates) getGroup(groupPosition);

        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) this._context
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.reportgroup, null);
        }
        ImageView im = (ImageView) convertView.findViewById(R.id.groupheadericon);


        TextView lblgroupname = (TextView) convertView
                .findViewById(R.id.lblListHeader);
        lblgroupname.setText(headerTitle.date);

        TextView lblcount = (TextView) convertView
                .findViewById(R.id.groupcountvalue);
        lblcount.setText(String.valueOf(headerTitle.Count));

        TextView lbltotal = (TextView) convertView
                .findViewById(R.id.grouptotalvalue);
        lbltotal.setText(headerTitle.Total.toString());

        ImageView print = (ImageView)convertView.findViewById(R.id.printdaily);
        print.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

            }
        });
        ImageView refresh = (ImageView)convertView.findViewById(R.id.refresh);
refresh.setOnClickListener(new View.OnClickListener() {
    @Override
    public void onClick(View v) {
        db.refresh(headerTitle.date);
        Log.i("refresh",headerTitle.date );
    }
});


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
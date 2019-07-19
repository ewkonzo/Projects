package com.example.paul.m_branch;

import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.HashMap;
import java.util.List;

public class Vehicleadapter extends BaseExpandableListAdapter {
    private Context _context;
    private List<summaries.collectiondates> _listDataHeader; // header titles
    private HashMap<summaries.collectiondates, List<transaction>> _listDataChild;

    public Vehicleadapter(Context context, List<summaries.collectiondates> listDataHeader,
                          HashMap<summaries.collectiondates, List<transaction>> listChildData) {
        this._context = context;
        this._listDataHeader = listDataHeader;
        this._listDataChild = listChildData;
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
            convertView = infalInflater.inflate(R.layout.vehiclelist, null);
        }

        TextView date = (TextView) convertView.findViewById(R.id.Date);
        date.setText(t.Date);

        TextView time = (TextView) convertView.findViewById(R.id.Time );
        time.setText(t.Time);

        TextView type = (TextView) convertView.findViewById(R.id.type);
        type.setText(t.typename);

        TextView txtreceipt = (TextView) convertView.findViewById(R.id.receiptno);
        txtreceipt.setText(t.Document_No);

        TextView txtamount = (TextView) convertView.findViewById(R.id.Amount);
        txtamount.setText(String.format("%.2f", t.Amount));

//        TextView txtttype = (TextView) convertView.findViewById(R.id.transtype);
//
//        if(!t.Loan_No.equals("")) {
//            if (t.Type.contains("LOAN"))
//            txtttype.setText(t.typename + "(" + t.Ward +")");
//            else
//                txtttype.setText(t.typename + "(" + t.Loan_No+")" );
//        }else
//            txtttype.setText(t.typename);
//
//
//        ImageView sent = (ImageView)convertView.findViewById(R.id.sent);
//        if(!t.sent)
//            sent.setVisibility(View.GONE);

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
        summaries.collectiondates headerTitle = (summaries.collectiondates) getGroup(groupPosition);

        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) this._context
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.vehiclegroup, null);
        }

        TextView veh = (TextView) convertView
                .findViewById(R.id.vehicleno);
        veh.setText(headerTitle.date);

        TextView memberno = (TextView) convertView
                .findViewById(R.id.memberno);
        memberno.setText(String.valueOf(headerTitle.MemberNo));

        TextView memberName = (TextView) convertView
                .findViewById(R.id.membername);
        memberName.setText(headerTitle.MemberName);

        TextView c = (TextView) convertView
                .findViewById(R.id.vehiclecount);
        c.setText(String.valueOf(headerTitle.Count));

        TextView t = (TextView) convertView
                .findViewById(R.id.grouptotalvalue);
        t.setText(headerTitle.Total.toString());
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
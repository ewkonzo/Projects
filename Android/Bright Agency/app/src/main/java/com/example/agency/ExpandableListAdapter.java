package com.example.agency;

import android.content.Context;
import android.graphics.Typeface;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.HashMap;
import java.util.List;

public class ExpandableListAdapter extends BaseExpandableListAdapter {

    private Context _context;
    private List<Summaries.Bydate> _listDataHeader; // header titles
    // child data in format of header title, child title
    private HashMap<Summaries.Bydate, List<Transaction>> _listDataChild;

    public ExpandableListAdapter(Context context, List<Summaries.Bydate> listDataHeader,
                                 HashMap<Summaries.Bydate, List<Transaction>> listChildData) {
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

        final Transaction coll = (Transaction) getChild(groupPosition, childPosition);

        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) this._context
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.list_item, null);
        }

        TextView collid = (TextView) convertView
                .findViewById(R.id.Reference);
        collid.setText(coll.reference);

        TextView farmername = (TextView) convertView
                .findViewById(R.id.custname);
        farmername.setText(coll.Name);

        TextView collno = (TextView) convertView
                .findViewById(R.id.ttype);
        collno.setText(coll.transactiontype.toString());

        TextView amount = (TextView) convertView
                .findViewById(R.id.samount);
        amount.setText(String.valueOf(coll.amount));

        TextView status = (TextView) convertView
                .findViewById(R.id.status);
        status.setText( coll.status.toString());





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
        Summaries.Bydate headerTitle = (Summaries.Bydate) getGroup(groupPosition);
        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) this._context
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.list_group, null);
        }
        ImageView im = (ImageView)convertView.findViewById(R.id.groupheadericon);

        if (isExpanded) {
            im.setImageResource(R.drawable.arrow_sans_down_32);
        } else {
            im.setImageResource(R.drawable.arrow_sans_up_32);
        }
        TextView listdate = (TextView) convertView
                .findViewById(R.id.listdate);
        listdate.setTypeface(null, Typeface.BOLD);
        listdate.setText(headerTitle.Date);

        TextView listtotal = (TextView) convertView
                .findViewById(R.id.listtotal);
        listtotal.setTypeface(null, Typeface.BOLD);
        listtotal.setText(String.format("%.2f", headerTitle.Total));

        return convertView;
    }
    @Override
    public boolean hasStableIds() {
        return false;
    }
    @Override
    public boolean isChildSelectable(int groupPosition, int childPosition) {
        return true;
    }
}

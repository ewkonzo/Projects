package com.example.paul.datacollector;

        import java.util.HashMap;
        import java.util.List;

        import android.content.Context;
        import android.graphics.Typeface;
        import android.provider.ContactsContract;
        import android.view.LayoutInflater;
        import android.view.View;
        import android.view.ViewGroup;
        import android.widget.BaseExpandableListAdapter;
        import android.widget.CheckedTextView;
        import android.widget.ImageView;
        import android.widget.TextView;

public class ExpandableListAdapter extends BaseExpandableListAdapter {

    private Context _context;
    private List<Summaries.Bydate> _listDataHeader; // header titles
    // child data in format of header title, child title
    private HashMap<Summaries.Bydate, List<Collection>> _listDataChild;

    public ExpandableListAdapter(Context context, List<Summaries.Bydate> listDataHeader,
                                 HashMap<Summaries.Bydate, List<Collection>> listChildData) {
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

        final Collection coll = (Collection) getChild(groupPosition, childPosition);

        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) this._context
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.list_item, null);
        }

        TextView farmerno = (TextView) convertView
                .findViewById(R.id.farmerno);
        farmerno.setText(coll.Farmers_Number);

        TextView farmername = (TextView) convertView
                .findViewById(R.id.farmername);
        farmername.setText(coll.Farmers_Name);

        TextView collno = (TextView) convertView
                .findViewById(R.id.collectionid);
        collno.setText(coll.Collection_Number);

        TextView datecol = (TextView) convertView
                .findViewById(R.id.Datetime);
        datecol.setText( coll.Time);

        TextView kgcol = (TextView) convertView
                .findViewById(R.id.Kgcollected);
        kgcol.setText( coll.Kg_Collected.toString());

        ImageView status = (ImageView) convertView
                .findViewById(R.id.status);
        if (coll.sent )
            status.setVisibility(View.VISIBLE);

        else
        status.setVisibility(View.GONE);



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

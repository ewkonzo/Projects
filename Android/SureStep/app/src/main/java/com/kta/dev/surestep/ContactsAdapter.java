package com.kta.dev.surestep;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.List;

/**
 * Created by G on 4/19/2016.
 */
public class ContactsAdapter extends BaseAdapter {
    Activity mActivity;
    List<Contact> mList;

    public ContactsAdapter(Activity activity, List<Contact> list) {
        mActivity = activity;
        mList = list;
    }

    @Override
    public int getCount() {
        return mList.size();
    }

    @Override
    public Object getItem(int position) {
        return mList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View rowView = convertView;

        if (rowView == null){
            LayoutInflater inflater = (LayoutInflater) mActivity
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

            rowView = inflater.inflate(R.layout.contact_list_item, parent, false);

            ViewHolder viewHolder = new ViewHolder();

            viewHolder.contactName = (TextView) rowView.findViewById(R.id.contactName);
            viewHolder.contactNumber = (TextView) rowView.findViewById(R.id.contactNumber);
            viewHolder.contactIdNumber = (TextView) rowView.findViewById(R.id.contactIdNumber);

            rowView.setTag(viewHolder);

        }

        ViewHolder vHolder = (ViewHolder) rowView.getTag();
        Contact contact = mList.get(position);

        vHolder.contactName.setText(contact.getName());
        vHolder.contactNumber.setText(contact.getTelephoneNumber());
        vHolder.contactIdNumber.setText(contact.getNationalId());

        return rowView;

    }

    class ViewHolder{
        TextView contactName;
        TextView contactNumber;
        TextView contactIdNumber;
    }
}

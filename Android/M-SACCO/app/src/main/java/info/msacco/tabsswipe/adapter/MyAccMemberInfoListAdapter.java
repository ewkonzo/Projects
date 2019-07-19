package info.msacco.tabsswipe.adapter;

import info.msacco.actionbar.model.MyAccMemberInfoDataModel;

import java.util.ArrayList;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.msacco.safaricom_sacco.R;

public class MyAccMemberInfoListAdapter extends
		ArrayAdapter<MyAccMemberInfoDataModel> {
	private ArrayList<MyAccMemberInfoDataModel> data;
	private Context mContext;

	public MyAccMemberInfoListAdapter(Context ctx,
			ArrayList<MyAccMemberInfoDataModel> items) {
		super(ctx, android.R.layout.simple_list_item_1, items);
		data = items;
		mContext = ctx;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {

		View row = convertView;
		if (row == null) {
			LayoutInflater inflater = (LayoutInflater) mContext
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			row = inflater
					.inflate(R.layout.member_info_list_items, null);
		}
		TextView txtLabel = (TextView) row
				.findViewById(R.id.myAccMemberInfoLabel);
		TextView txtName = (TextView) row
				.findViewById(R.id.myAccMemberInfoName);
		MyAccMemberInfoDataModel memInfoDataModel = data.get(position);

		txtLabel.setText(memInfoDataModel.getLabel());
		txtName.setText(memInfoDataModel.getName());
		return row;

	}
}

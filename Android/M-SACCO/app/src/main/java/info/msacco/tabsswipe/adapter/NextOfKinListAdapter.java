package info.msacco.tabsswipe.adapter;

import info.msacco.actionbar.model.NextOfKinDataModel;

import java.util.ArrayList;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.msacco.safaricom_sacco.R;

public class NextOfKinListAdapter extends ArrayAdapter<NextOfKinDataModel> {
	private ArrayList<NextOfKinDataModel> data;
	private Context mContext;

	public NextOfKinListAdapter(Context ctx, ArrayList<NextOfKinDataModel> items) {
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
			row = inflater.inflate(R.layout.next_of_kin_list_items, null);
		}
		TextView txtKinName = (TextView) row.findViewById(R.id.n_kin_name);
		TextView txtKinRshipValue = (TextView) row
				.findViewById(R.id.n_kin_rship_value);
		TextView txtKinAllocValue = (TextView) row
				.findViewById(R.id.n_kin_allocation_value);

		NextOfKinDataModel DataModel = data.get(position);
		txtKinName.setText(DataModel.getNkin_name());
		txtKinRshipValue.setText(DataModel.getNkin_rship());
		txtKinAllocValue.setText(DataModel.getNkin_allocation());

		return row;

	}
}

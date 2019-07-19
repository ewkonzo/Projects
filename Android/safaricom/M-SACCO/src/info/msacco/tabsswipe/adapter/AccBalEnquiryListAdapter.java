package info.msacco.tabsswipe.adapter;

import info.msacco.actionbar.model.AccBalEnquiryDataModel;

import java.util.ArrayList;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.msacco.safaricom_sacco.R;

public class AccBalEnquiryListAdapter extends
		ArrayAdapter<AccBalEnquiryDataModel> {
	private ArrayList<AccBalEnquiryDataModel> data;
	private Context mContext;

	public AccBalEnquiryListAdapter(Context ctx,
			ArrayList<AccBalEnquiryDataModel> items) {
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
			row = inflater.inflate(R.layout.acc_bal_eq_list_items, null);
		}
		TextView txtAccountName = (TextView) row
				.findViewById(R.id.b_account_name);
		TextView txtBalanceName = (TextView) row
				.findViewById(R.id.b_account_balance_label);
		TextView txtBalanceValue = (TextView) row
				.findViewById(R.id.b_account_balance_value);

		AccBalEnquiryDataModel DataModel = data.get(position);
		if (DataModel.getAccount_name().trim().equals("Loan Type:")) {
			txtAccountName.setText("Loan Type: ADVANCE");
		} else {
			txtAccountName.setText(DataModel.getAccount_name());
		}
		txtBalanceName.setText(DataModel.getAccount_balance_label());
		txtBalanceValue.setText(DataModel.getAccount_balance_value());
		return row;

	}
}

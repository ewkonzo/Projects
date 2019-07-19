package info.msacco.tabsswipe.adapter;

import info.msacco.actionbar.model.MyAccMiniStatementDataModel;

import java.util.ArrayList;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.msacco.safaricom_sacco.R;

public class MyAccMiniStatementListAdapter extends
		ArrayAdapter<MyAccMiniStatementDataModel> {
	private ArrayList<MyAccMiniStatementDataModel> data;
	private Context mContext;

	public MyAccMiniStatementListAdapter(Context ctx,
			ArrayList<MyAccMiniStatementDataModel> items) {
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
			row = inflater.inflate(R.layout.mini_statement_list_items,
					null);
		}
		TextView txtDate = (TextView) row
				.findViewById(R.id.myAccMiniStatementDate);
		TextView txtDesc = (TextView) row
				.findViewById(R.id.myAccMiniStatementDescription);
		TextView txtAmt = (TextView) row
				.findViewById(R.id.myAccMiniStatementAmount);
		MyAccMiniStatementDataModel minStmtfoDataModel = data.get(position);

		txtDate.setText(minStmtfoDataModel.getDate());
		txtDesc.setText(minStmtfoDataModel.getDescription());
		txtAmt.setText(minStmtfoDataModel.getAmount());
		return row;

	}
}

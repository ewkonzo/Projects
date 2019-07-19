package info.msacco.tabsswipe.adapter;

import info.msacco.actionbar.model.MledgerReportsByTimeDataModel;

import java.util.ArrayList;

import android.content.Context;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.msacco.safaricom_sacco.R;

public class MledgerReportsByTimeListAdapter extends ArrayAdapter<MledgerReportsByTimeDataModel> {
	private ArrayList<MledgerReportsByTimeDataModel> data;
	private Context mContext;

	public MledgerReportsByTimeListAdapter(Context ctx, ArrayList<MledgerReportsByTimeDataModel> items) {
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
			row = inflater.inflate(R.layout.mledger_reports_by_time_list_items, null);
		}
		TextView txtMonth = (TextView) row.findViewById(R.id.label_month);
		TextView txtDeposits = (TextView) row.findViewById(R.id.label_deposits);
		TextView txtWithdrawals = (TextView) row
				.findViewById(R.id.label_withdrawals);
		MledgerReportsByTimeDataModel timeDataModel = data.get(position);

			txtMonth.setText(timeDataModel.get_month());

			txtDeposits.setText(timeDataModel.get_deposits().toString());

			txtWithdrawals.setText(timeDataModel.get_deposits().toString());

		return row;
	}
}

package info.msacco.tabsswipe.adapter;

import info.msacco.actionbar.model.MledgerDepWithdByTimeDailyTransactionsDrillDownModel;
import info.msacco.actionbar.model.MledgerDepWithdByTimeDateDrillDownModel;
import info.msacco.tabsswipe.MLedgerReportsByTimeDrillDown;

import java.util.HashMap;
import java.util.List;

import android.content.Context;
import android.graphics.Typeface;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.TextView;

import com.msacco.safaricom_sacco.R;

public class MledgerReportsByTimeDayOfMonthExpandableListAdapter extends
		BaseExpandableListAdapter {

	private MLedgerReportsByTimeDrillDown _context;
	private List<MledgerDepWithdByTimeDateDrillDownModel> _listDataHeader; // Header titles
	// child data in format of header title ,child title
	private HashMap<MledgerDepWithdByTimeDateDrillDownModel, List<MledgerDepWithdByTimeDailyTransactionsDrillDownModel>> _listDataChild;

	public MledgerReportsByTimeDayOfMonthExpandableListAdapter(
			MLedgerReportsByTimeDrillDown mLedgerReportByTimeDayOfMonth,
			List<MledgerDepWithdByTimeDateDrillDownModel> listDataHeader,
			HashMap<MledgerDepWithdByTimeDateDrillDownModel, List<MledgerDepWithdByTimeDailyTransactionsDrillDownModel>> listDataChild) {
		this._context = mLedgerReportByTimeDayOfMonth;
		this._listDataHeader = listDataHeader;
		this._listDataChild = listDataChild;
	}

	@Override
	public Object getChild(int groupPosition, int childPosition) {
		// TODO Auto-generated method stub
		return this._listDataChild.get(this._listDataHeader.get(groupPosition))
				.get(childPosition);
	}

	@Override
	public long getChildId(int groupPosition, int childPosition) {
		// TODO Auto-generated method stub
		return childPosition;
	}

	@Override
	public View getChildView(int groupPosition, final int childPosition,
			boolean isLastChild, View convertView, ViewGroup parent) {
		// TODO Auto-generated method stub
		final MledgerDepWithdByTimeDailyTransactionsDrillDownModel childText = (MledgerDepWithdByTimeDailyTransactionsDrillDownModel) getChild(
				groupPosition, childPosition);

		if (convertView == null) {
			LayoutInflater infalInflater = (LayoutInflater) this._context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = infalInflater.inflate(
					R.layout.mledger_reports_by_time_day_of_month_list_items, null);
		}
		TextView txtListTime = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTimelblMonth);
		TextView txtListDesc = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTimelblDeposit);
		TextView txtListAmount = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTimelblWithdrawal);

		if(childText.get_deposit()>0.0)
		{
			txtListTime.setText(childText.get_date());
			txtListDesc.setText(childText.get_description());
			txtListAmount.setText(String.valueOf(childText.get_deposit()));
			txtListAmount.setTextColor(_context.getResources().getColor(R.color.darkgreen));
			}
		else{
			txtListTime.setText(childText.get_date());
			txtListDesc.setText(childText.get_description());
			txtListAmount.setText(String.valueOf(childText.get_withdrawal()));
			txtListAmount.setTextColor(_context.getResources().getColor(R.color.red));
		}
		return convertView;
	}

	@Override
	public int getChildrenCount(int groupPosition) {
		// TODO Auto-generated method stub
		return this._listDataChild.get(this._listDataHeader.get(groupPosition))
				.size();
	}

	@Override
	public Object getGroup(int groupPosition) {
		// TODO Auto-generated method stub
		return this._listDataHeader.get(groupPosition);
	}

	@Override
	public int getGroupCount() {
		// TODO Auto-generated method stub
		return this._listDataHeader.size();
	}

	@Override
	public long getGroupId(int arg0) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public View getGroupView(int groupPosition, boolean isExpanded,
			View convertView, ViewGroup parent) {
		// TODO Auto-generated method stub

		final MledgerDepWithdByTimeDateDrillDownModel parentText = (MledgerDepWithdByTimeDateDrillDownModel) 
				getGroup(groupPosition);
		if (convertView == null) {
			LayoutInflater infalInflater = (LayoutInflater) this._context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = infalInflater.inflate(
					R.layout.mledger_reports_by_time_day_of_month_list_group, null);
		}		

		TextView lblDayListHeader = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTimeDrillDownDateListHeader);
		lblDayListHeader.setTypeface(null, Typeface.NORMAL);
		
		TextView lblDepListHeader = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTimeDrillDownDepListHeader);
		lblDepListHeader.setTypeface(null, Typeface.NORMAL);
		
		TextView lblWithdListHeader = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTimeDrillDownWithdListHeader);
		lblWithdListHeader.setTypeface(null, Typeface.NORMAL);
		
		
		lblDayListHeader.setText(parentText.get_date());
		lblDepListHeader.setText(String.valueOf(parentText.get_deposit()));
		lblWithdListHeader.setText(String.valueOf(parentText.get_withdrawal()));
		return convertView;
	}

	@Override
	public boolean hasStableIds() {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean isChildSelectable(int groupPosition, int childPosition) {
		// TODO Auto-generated method stub
		return true;
	}
}
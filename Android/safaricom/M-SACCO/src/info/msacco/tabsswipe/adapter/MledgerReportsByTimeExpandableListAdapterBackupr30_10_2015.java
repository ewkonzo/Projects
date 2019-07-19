package info.msacco.tabsswipe.adapter;

import info.msacco.actionbar.model.MledgerDepWithdByTimeMonthDrillDownModel;
import info.msacco.actionbar.model.MledgerDepWithdByTimeYearDataModel;
import info.msacco.tabsswipe.MLedgerReportsByTime_BC_30_10_2015;

import java.util.HashMap;
import java.util.List;

import android.content.Context;
import android.graphics.Color;
import android.graphics.Typeface;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.TextView;

import com.msacco.safaricom_sacco.R;

public class MledgerReportsByTimeExpandableListAdapterBackupr30_10_2015 extends
		BaseExpandableListAdapter {

	private MLedgerReportsByTime_BC_30_10_2015 _context;
	private List<MledgerDepWithdByTimeYearDataModel> _listDataHeader; // Header titles
	// child data in format of header title ,child title
	private HashMap<MledgerDepWithdByTimeYearDataModel, List<MledgerDepWithdByTimeMonthDrillDownModel>> _listDataChild;

	public MledgerReportsByTimeExpandableListAdapterBackupr30_10_2015(
			MLedgerReportsByTime_BC_30_10_2015 mLedgerReportByTime,
			List<MledgerDepWithdByTimeYearDataModel> listDataHeader,
			HashMap<MledgerDepWithdByTimeYearDataModel,List<MledgerDepWithdByTimeMonthDrillDownModel>> listDataChild) {
		this._context = mLedgerReportByTime;
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
		final MledgerDepWithdByTimeMonthDrillDownModel childText = (MledgerDepWithdByTimeMonthDrillDownModel) getChild(
				groupPosition, childPosition);

		if (convertView == null) {
			LayoutInflater infalInflater = (LayoutInflater) this._context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = infalInflater.inflate(
					R.layout.mledger_reports_by_time_list_items_bc_30_10_2015, null);
		}
		TextView txtListMonth = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTimelblMonth);
		TextView txtListDep = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTimelblDeposit);
		TextView txtListWithd = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTimelblWithdrawal);

		if (childPosition == 0) {
			txtListMonth.setText("Month");
			txtListMonth.setTextColor(Color.BLACK);
			txtListMonth.setTypeface(null, Typeface.BOLD);
			txtListMonth.setTextSize(11);
			txtListDep.setText("Deposit");
			txtListDep.setTextColor(Color.BLACK);
			txtListDep.setTypeface(null, Typeface.BOLD);
			txtListDep.setTextSize(11);
			txtListWithd.setText("Withdrawal");
			txtListWithd.setTextColor(Color.BLACK);
			txtListWithd.setTypeface(null, Typeface.BOLD);
			txtListWithd.setTextSize(11);
		}

		else{
			txtListMonth.setText(childText.get_month());
			txtListMonth.setTextColor(Color.BLACK);
			txtListMonth.setTypeface(null, Typeface.NORMAL);
			txtListMonth.setTextSize(9);
			txtListDep.setText(String.valueOf(childText.get_deposit()));
			txtListDep.setTextColor(_context.getResources().getColor(R.color.lightgreen));
			txtListDep.setTypeface(null, Typeface.NORMAL);
			txtListDep.setTextSize(9);
			txtListWithd.setText(String.valueOf(childText.get_withdrawal()));
			txtListWithd.setTextColor(Color.RED);
			txtListWithd.setTypeface(null, Typeface.NORMAL);
			txtListWithd.setTextSize(9);
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

		final MledgerDepWithdByTimeYearDataModel parentText = (MledgerDepWithdByTimeYearDataModel) 
				getGroup(groupPosition);
		
		if (convertView == null) {
			LayoutInflater infalInflater = (LayoutInflater) this._context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = infalInflater.inflate(
					R.layout.mledger_reports_by_time_list_groupbc_30_10_2015, null);
		}
		
		
		TextView lblYearListHeader = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTimelblYearListHeader);
		lblYearListHeader.setTypeface(null, Typeface.NORMAL);
		
		TextView lblDepListHeader = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTimelblDepListHeader);
		lblDepListHeader.setTypeface(null, Typeface.NORMAL);
		
		TextView lblWithdListHeader = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTimelblWithdListHeader);
		lblWithdListHeader.setTypeface(null, Typeface.NORMAL);
		
		
		lblYearListHeader.setText(parentText.get_year());
		lblDepListHeader.setText(String.valueOf(parentText.getDeposits()));
		lblWithdListHeader.setText(String.valueOf(parentText.getWithdrawals()));

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
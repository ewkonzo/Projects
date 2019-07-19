package info.msacco.tabsswipe.adapter;

import info.msacco.actionbar.model.MledgerDepWithdByAccTypeDataModel;
import info.msacco.actionbar.model.MledgerDepWithdByAccTypeDrillDownModel;
import info.msacco.tabsswipe.MLedgerReportsByAccType;

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

public class MledgerReportsByAccTypeExpandableListAdapter extends
		BaseExpandableListAdapter {

	private MLedgerReportsByAccType _context;
	private List<MledgerDepWithdByAccTypeDataModel> _listDataHeader; // Header
																		// titles
	// child data in format of header title ,child title
	private HashMap<MledgerDepWithdByAccTypeDataModel, List<MledgerDepWithdByAccTypeDrillDownModel>> _listDataChild;

	public MledgerReportsByAccTypeExpandableListAdapter(
			MLedgerReportsByAccType mLedgerDepositByType,
			List<MledgerDepWithdByAccTypeDataModel> listDataHeader,
			HashMap<MledgerDepWithdByAccTypeDataModel, List<MledgerDepWithdByAccTypeDrillDownModel>> listDataChild) {
		this._context = mLedgerDepositByType;
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
		final MledgerDepWithdByAccTypeDrillDownModel childText = (MledgerDepWithdByAccTypeDrillDownModel) getChild(
				groupPosition, childPosition);

		if (convertView == null) {
			LayoutInflater infalInflater = (LayoutInflater) this._context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = infalInflater.inflate(
					R.layout.mledger_reports_by_acc_type_list_items, null);
		}
		TextView txtListDate = (TextView) convertView
				.findViewById(R.id.mledgerReportsByByAccTypelblDate);
		TextView txtListDesc = (TextView) convertView
				.findViewById(R.id.mledgerReportsByByAccTypelblDescription);
		TextView txtListAmount = (TextView) convertView
				.findViewById(R.id.mledgerDepositByAccTypelblDeposit);


		if (childText.get_deposit() > 0.0) {
			txtListDate.setText(childText.get_posting_date());
			txtListDesc.setText(childText.get_description());
			txtListAmount.setText(String.valueOf(childText.get_deposit()));
			txtListAmount.setTextColor(_context.getResources().getColor(R.color.darkgreen));
		} else {
			txtListDate.setText(childText.get_posting_date());
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

		final MledgerDepWithdByAccTypeDataModel parentText = (MledgerDepWithdByAccTypeDataModel) getGroup(groupPosition);

		if (convertView == null) {
			LayoutInflater infalInflater = (LayoutInflater) this._context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = infalInflater.inflate(
					R.layout.mledger_reports_by_acc_type_list_group, null);
		}
		TextView lblAccListHeader = (TextView) convertView
				.findViewById(R.id.mledgerReportsByAccTypeAccListHeader);
		lblAccListHeader.setTypeface(null, Typeface.NORMAL);

		TextView lblDepListHeader = (TextView) convertView
				.findViewById(R.id.mledgerReportsByAccTypeDepListHeader);
		lblDepListHeader.setTypeface(null, Typeface.NORMAL);

		TextView lblWithdListHeader = (TextView) convertView
				.findViewById(R.id.mledgerReportsByAccTypeWithdListHeader);
		lblWithdListHeader.setTypeface(null, Typeface.NORMAL);

		lblAccListHeader.setText(parentText.getAcc_type());
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
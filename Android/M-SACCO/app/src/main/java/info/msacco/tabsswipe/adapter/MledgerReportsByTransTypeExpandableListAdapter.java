package info.msacco.tabsswipe.adapter;

import info.msacco.actionbar.model.MledgerDepWithdByTransTypeDataModel;
import info.msacco.actionbar.model.MledgerDepWithdByTransTypeDrillDownModel;
import info.msacco.tabsswipe.MLedgerReportsByTransType;

import java.util.HashMap;
import java.util.List;

import android.content.Context;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.TextView;

import com.msacco.safaricom_sacco.R;

public class MledgerReportsByTransTypeExpandableListAdapter extends
		BaseExpandableListAdapter {

	private MLedgerReportsByTransType _context;
	private List<MledgerDepWithdByTransTypeDataModel> _listDataHeader; // Header
																		// titles
	// child data in format of header title ,child title
	private HashMap<MledgerDepWithdByTransTypeDataModel, List<MledgerDepWithdByTransTypeDrillDownModel>> _listDataChild;

	public MledgerReportsByTransTypeExpandableListAdapter(
			MLedgerReportsByTransType mLedgerDepositByTransType,
			List<MledgerDepWithdByTransTypeDataModel> listDataHeader,
			HashMap<MledgerDepWithdByTransTypeDataModel, List<MledgerDepWithdByTransTypeDrillDownModel>> listDataChild) {
		this._context = mLedgerDepositByTransType;
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
		final MledgerDepWithdByTransTypeDrillDownModel childText = (MledgerDepWithdByTransTypeDrillDownModel) getChild(
				groupPosition, childPosition);

		if (convertView == null) {
			LayoutInflater infalInflater = (LayoutInflater) this._context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = infalInflater.inflate(
					R.layout.mledger_reports_by_trans_type_list_items, null);
		}
		TextView txtListDate = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTransTypelblDate);
		TextView txtListDesc = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTransTypelblDescription);
		TextView txtListAmount = (TextView) convertView
				.findViewById(R.id.mledgerDepositByTransTypelblAmount);

		if (childText.get_deposit() > 0.0) {
			txtListDate.setText(childText.get_posting_date());
			txtListDesc.setText(childText.get_description());
			txtListAmount.setText(String.valueOf(childText.get_deposit()));
			txtListAmount.setTextColor(_context.getResources().getColor(
					R.color.darkgreen));
		} else {
			txtListDate.setText(childText.get_posting_date());
			txtListDesc.setText(childText.get_description());
			txtListDesc.setTextColor(Color.BLACK);
			txtListAmount.setText(String.valueOf(childText.get_withdrawal()));
			txtListAmount.setTextColor(_context.getResources().getColor(
					R.color.red));
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

		final MledgerDepWithdByTransTypeDataModel parentText = (MledgerDepWithdByTransTypeDataModel) getGroup(groupPosition);

		if (convertView == null) {
			LayoutInflater infalInflater = (LayoutInflater) this._context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = infalInflater.inflate(
					R.layout.mledger_reports_by_trans_type_list_group, null);
		}
		TextView lblAccListHeader = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTransTypeListHeader);

		TextView lblDepListHeader = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTransTypeDepListHeader);

		TextView lblWithdListHeader = (TextView) convertView
				.findViewById(R.id.mledgerReportsByTransTypeWithdListHeader);

		lblAccListHeader.setText(parentText.get_trans_type());
		lblDepListHeader.setText(String.valueOf(parentText.get_deposits()));
		lblWithdListHeader
				.setText(String.valueOf(parentText.get_withdrawals()));
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
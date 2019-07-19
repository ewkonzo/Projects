package info.msacco.tabsswipe;

import info.msacco.actionbar.model.MledgerDepWithdByTransTypeDataModel;
import info.msacco.actionbar.model.MledgerDepWithdByTransTypeDrillDownModel;
import info.msacco.tabsswipe.adapter.MSACCOLocalDb;
import info.msacco.tabsswipe.adapter.MledgerReportsByTransTypeExpandableListAdapter;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.ExpandableListView;
import android.widget.ExpandableListView.OnGroupClickListener;
import android.widget.ExpandableListView.OnGroupCollapseListener;
import android.widget.ExpandableListView.OnGroupExpandListener;

import com.msacco.safaricom_sacco.R;

public class MLedgerReportsByTransType extends Activity {

	private double[] totalDeposits = null;
	private double[] totalWithdrawals = null;
	private String[] accountTypeTitles = null;

	MledgerReportsByTransTypeExpandableListAdapter listAdapter;
	ExpandableListView expListView;

	// Contains a list of headers for expandable lists.
	List<MledgerDepWithdByTransTypeDataModel> listDataHeader;

	// Contains the drill down data for each Account type
	List drillDownArrayList;

	// On object with header and drill down data for a single expandableList
	// element
	HashMap<MledgerDepWithdByTransTypeDataModel, List<MledgerDepWithdByTransTypeDrillDownModel>> listDataChild;

	// Store data for use in drawing charts.
	HashMap<String[], Double[]> reportsData;
	MSACCOLocalDb db;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.mledger_reports_by_trans_type);

		// Instantiate Local DB
		db = new MSACCOLocalDb(this);
		// Instantiate Lists.
		drillDownArrayList = new ArrayList<MledgerDepWithdByTransTypeDataModel>();
		InitializeExpandableList();
	}

	public void InitializeExpandableList() {
		// get the listview
		expListView = (ExpandableListView) findViewById(R.id.mledgerReportsByTransTypeExpLv);

		// preparing list data
		prepareListData();

		listAdapter = new MledgerReportsByTransTypeExpandableListAdapter(this,
				listDataHeader, listDataChild);

		// setting list adapter
		expListView.setAdapter(listAdapter);

		// Listview Group click listener
		expListView.setOnGroupClickListener(new OnGroupClickListener() {

			@Override
			public boolean onGroupClick(ExpandableListView parent, View v,
					int groupPosition, long id) {
				return false;
			}
		});

		// Listview Group expanded listener
		expListView.setOnGroupExpandListener(new OnGroupExpandListener() {

			@Override
			public void onGroupExpand(int groupPosition) {
			}
		});

		// Listview Group collasped listener
		expListView.setOnGroupCollapseListener(new OnGroupCollapseListener() {

			@Override
			public void onGroupCollapse(int groupPosition) {

			}
		});
	}

	// Preparing the list data
	private void prepareListData() {

		// Get data from local DB into a Custom List for withdrawals and
		// deposits.
		List<MledgerDepWithdByTransTypeDataModel> list = db
				.getDepositAndWithdByJBatch();

		// Instantiate the header and drill down elements
		listDataHeader = new ArrayList<MledgerDepWithdByTransTypeDataModel>();
		listDataChild = new HashMap<MledgerDepWithdByTransTypeDataModel, List<MledgerDepWithdByTransTypeDrillDownModel>>();

		totalDeposits = new double[list.size()];
		totalWithdrawals = new double[list.size()];
		accountTypeTitles = new String[list.size()];

		for (int i = 0; i < list.size(); i++) {

			// Create titles for the Expandable list drill down elements.
			MledgerDepWithdByTransTypeDrillDownModel titles = new MledgerDepWithdByTransTypeDrillDownModel();

			// Store drill down data into a Custom list
			List<MledgerDepWithdByTransTypeDrillDownModel> drillList = db
					.getDepositAndWithdDrillDownByJBatch(list.get(i)
							.get_trans_type());

			// Adding parent Data
			listDataHeader.add(list.get(i));

			List<MledgerDepWithdByTransTypeDrillDownModel> drillDownItems = new ArrayList<MledgerDepWithdByTransTypeDrillDownModel>();

			accountTypeTitles[i] = list.get(i).get_trans_type();

			for (int index = 0; index < drillList.size(); index++) {

				// Add drill down data elememts into parent List
				drillDownItems.add((drillList.get(index)));

				// Sum up all withdrawals and deposits for a particular account
				// type.
				totalWithdrawals[i] += drillList.get(index).get_withdrawal();
				totalDeposits[i] += drillList.get(index).get_deposit();
			}

			// Add Parent and child data into a List.
			listDataChild.put(listDataHeader.get(i), drillDownItems);
		}

	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.reports_by_trans_type_menu, menu);
		return super.onCreateOptionsMenu(menu);
	}

	/**
	 * On selecting action bar icons
	 * */
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Take appropriate action for each action item click
		switch (item.getItemId()) {
		case R.id.action_bar_chart:

			Intent in = new Intent(getApplicationContext(),
					MLedgerReportsByTransTypeBarChart.class);
			in.putExtra("titles", accountTypeTitles);
			in.putExtra("totalWithdrawals", totalWithdrawals);
			in.putExtra("totalDeposits", totalDeposits);
			startActivity(in);
			finish();

			return true;
		case R.id.action_pie_chart:
			Intent i = new Intent(getApplicationContext(),
					MLedgerReportsByTransTypePieChart.class);
			i.putExtra("titles", accountTypeTitles);
			i.putExtra("totalWithdrawals", totalWithdrawals);
			i.putExtra("totalDeposits", totalDeposits);
			startActivity(i);
			finish();
			return true;

		default:
			return super.onOptionsItemSelected(item);
		}
	}
}
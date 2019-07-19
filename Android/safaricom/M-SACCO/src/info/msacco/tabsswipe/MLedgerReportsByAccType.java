package info.msacco.tabsswipe;

import info.msacco.actionbar.model.MledgerDepWithdByAccTypeDataModel;
import info.msacco.actionbar.model.MledgerDepWithdByAccTypeDrillDownModel;
import info.msacco.tabsswipe.adapter.MSACCOLocalDb;
import info.msacco.tabsswipe.adapter.MledgerReportsByAccTypeExpandableListAdapter;

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
import android.widget.Button;
import android.widget.ExpandableListView;
import android.widget.ExpandableListView.OnGroupClickListener;
import android.widget.ExpandableListView.OnGroupCollapseListener;
import android.widget.ExpandableListView.OnGroupExpandListener;

import com.msacco.safaricom_sacco.R;

public class MLedgerReportsByAccType extends Activity {

	private double[] totalDeposits = null;
	private double[] totalWithdrawals = null;
	private String[] accountTypeTitles = null;
	private Button onBarGraphIconClicked, onPieChartIconClicked;

	MledgerReportsByAccTypeExpandableListAdapter listAdapter;
	ExpandableListView expListView;

	// Contains a list of headers for expandable lists.
	List<MledgerDepWithdByAccTypeDataModel> listDataHeader;

	// Contains the drill down data for each Account type
	List drillDownArrayList;

	// One object with header and drill down data for a single expandableList
	// element
	HashMap<MledgerDepWithdByAccTypeDataModel, List<MledgerDepWithdByAccTypeDrillDownModel>> listDataChild;

	// Store data for use in drawing charts.
	HashMap<String[], Double[]> reportsData;
	MSACCOLocalDb db;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.mledger_reports_by_acc_type);
		// Instantiate Local DB
		db = new MSACCOLocalDb(this);
		// Instantiate Lists.
		drillDownArrayList = new ArrayList<MledgerDepWithdByAccTypeDataModel>();
		InitializeExpandableList();
	}

	public void InitializeExpandableList() {
		// get the listview
		expListView = (ExpandableListView) findViewById(R.id.mledgerReportsByTypeExpLv);

		// preparing list data
		prepareListData();

		listAdapter = new MledgerReportsByAccTypeExpandableListAdapter(this,
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
		List<MledgerDepWithdByAccTypeDataModel> list = db
				.getDepositAndWithdByAccType();

		// Instantiate the header and drill down elements
		listDataHeader = new ArrayList<MledgerDepWithdByAccTypeDataModel>();
		listDataChild = new HashMap<MledgerDepWithdByAccTypeDataModel, List<MledgerDepWithdByAccTypeDrillDownModel>>();
		try {

		} catch (Exception e) {
			// TODO: handle exception
		}
		totalDeposits = new double[list.size()];
		totalWithdrawals = new double[list.size()];
		accountTypeTitles = new String[list.size()];

		for (int i = 0; i < list.size(); i++) {

			// Create titles for the Expandable list drill down elements.
			/*MledgerDepWithdByAccTypeDrillDownModel titles = new MledgerDepWithdByAccTypeDrillDownModel();
			titles.set_posting_date("");
			titles.set_description("");
			titles.set_withdrawal(22.2);*/

			// Store drill down data into a Custom list
			List<MledgerDepWithdByAccTypeDrillDownModel> drillList = db
					.getDepositAndWithdDrillDownData(list.get(i).getAcc_type());

			// Adding parent Data
			listDataHeader.add(list.get(i));

			List<MledgerDepWithdByAccTypeDrillDownModel> drillDownItems = new ArrayList<MledgerDepWithdByAccTypeDrillDownModel>();

			// Add title to a custom List
			//drillDownItems.add(titles);

			accountTypeTitles[i] = list.get(i).getAcc_type();

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
					MLedgerReportsByAccTypeBarChart.class);
			in.putExtra("titles", accountTypeTitles);
			in.putExtra("totalWithdrawals", totalWithdrawals);
			in.putExtra("totalDeposits", totalDeposits);
			// Close all views before launching Login
			in.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(in);
			finish();

			return true;
		case R.id.action_pie_chart:
			Intent inten = new Intent(getApplicationContext(),
					MLedgerReportsByAccTypePieChart.class);
			inten.putExtra("titles", accountTypeTitles);
			inten.putExtra("totalWithdrawals", totalWithdrawals);
			inten.putExtra("totalDeposits", totalDeposits);
			// Close all views before launching Login
			inten.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(inten);
			finish();
			return true;

		default:
			return super.onOptionsItemSelected(item);
		}
	}
}

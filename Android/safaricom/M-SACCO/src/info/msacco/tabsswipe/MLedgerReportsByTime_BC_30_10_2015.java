package info.msacco.tabsswipe;

import info.msacco.actionbar.model.MledgerDepWithdByTimeMonthDrillDownModel;
import info.msacco.actionbar.model.MledgerDepWithdByTimeYearDataModel;
import info.msacco.tabsswipe.adapter.MSACCOLocalDb;
import info.msacco.tabsswipe.adapter.MledgerReportsByTimeExpandableListAdapterBackupr30_10_2015;

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
import android.widget.ExpandableListView.OnChildClickListener;
import android.widget.ExpandableListView.OnGroupClickListener;
import android.widget.ExpandableListView.OnGroupCollapseListener;
import android.widget.ExpandableListView.OnGroupExpandListener;

import com.msacco.safaricom_sacco.R;

public class MLedgerReportsByTime_BC_30_10_2015 extends Activity {

	MledgerReportsByTimeExpandableListAdapterBackupr30_10_2015 listAdapter;
	ExpandableListView expListView;

	// Contains a list of headers for expandable lists.
	List<MledgerDepWithdByTimeYearDataModel> listDataHeader;

	// Contains the drill down data for each Account type
	List drillDownArrayList;
	List<MledgerDepWithdByTimeYearDataModel> list;
	List<MledgerDepWithdByTimeMonthDrillDownModel> listgraph;

	// On object with header and drill down data for a single epandableList
	// element
	HashMap<MledgerDepWithdByTimeYearDataModel, List<MledgerDepWithdByTimeMonthDrillDownModel>> listDataChild;

	private double[] totalDeposits = null;
	private double[] totalWithdrawals = null;
	private String[] yearTitles = null;

	// For holding a list of data elements from web service
	List<String> analysisByTimeList;

	// Reference to the local Database Class
	MSACCOLocalDb db;

	// Store data for use in drawing charts.
	HashMap<String[], Double[]> reportsData;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.mledger_reports_by_time_bc_30_10_2015);

		// Instantiate Lists.
		analysisByTimeList = new ArrayList<String>();
		// drillDownArrayList = new
		// ArrayList<MledgerDepWithdByTimeMonthDrillDownModel>();
		list = new ArrayList<MledgerDepWithdByTimeYearDataModel>();

		// Instantiate Local DB
		db = new MSACCOLocalDb(this);

		// Call to method that sets up the expandable List
		InitializeExpandableList();
	}

	public void InitializeExpandableList() {
		// get the listview
		expListView = (ExpandableListView) findViewById(R.id.mledgerReportsByTimeExpLv);

		// preparing list data
		prepareListData();

		listAdapter = new MledgerReportsByTimeExpandableListAdapterBackupr30_10_2015(this,
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

		// Listview on child click listener
		expListView.setOnChildClickListener(new OnChildClickListener() {

			@Override
			public boolean onChildClick(ExpandableListView parent, View v,
					int groupPosition, int childPosition, long id) {
				// TODO Auto-generated method stub
				if (childPosition > 0) {

					String year = listDataHeader.get(groupPosition).get_year();
					String month = listDataChild
							.get(listDataHeader.get(groupPosition))
							.get(childPosition).toString();

					Intent i = new Intent(getApplicationContext(),
							MLedgerReportsByTimeDrillDown.class);
					i.putExtra("month", month);
					i.putExtra("year", year);

					startActivity(i);
				}
				return false;
			}
		});
	}

	// Preparing the list data
	private void prepareListData() {

		// Get data from local DB into a Custom List for withdrawals and
		// deposits.
		try {
			list = db.getDepositAndWithdByYear();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		// Instantiate the header and drill down elements
		listDataHeader = new ArrayList<MledgerDepWithdByTimeYearDataModel>();
		listDataChild = new HashMap<MledgerDepWithdByTimeYearDataModel, List<MledgerDepWithdByTimeMonthDrillDownModel>>();

		totalDeposits = new double[list.size()];
		totalWithdrawals = new double[list.size()];
		yearTitles = new String[list.size()];

		for (int i = 0; i < list.size(); i++) {

			// Create titles for the Expandable list drill down elements.
			MledgerDepWithdByTimeMonthDrillDownModel titles = new MledgerDepWithdByTimeMonthDrillDownModel();
			titles.set_month("");
			titles.set_deposit(22.2);
			titles.set_withdrawal(22.2);

			// Store drill down data into a Custom list
			List<MledgerDepWithdByTimeMonthDrillDownModel> drillList = db
					.getDepAndWithdDrillDownDataByMonth(list.get(i).get_year());

			// Adding parent Data
			listDataHeader.add(list.get(i));

			List<MledgerDepWithdByTimeMonthDrillDownModel> drillDownItems = new ArrayList<MledgerDepWithdByTimeMonthDrillDownModel>();

			// Add title to a custom List
			drillDownItems.add(titles);

			yearTitles[i] = list.get(i).get_year();

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

			Intent i = new Intent(getApplicationContext(),
					MLedgerReportsByTimeBarChart.class);
			i.putExtra("titles", yearTitles);
			i.putExtra("totalWithdrawals", totalWithdrawals);
			i.putExtra("totalDeposits", totalDeposits);
			startActivity(i);
			finish();

			return true;
		case R.id.action_pie_chart:
			Intent intn = new Intent(getApplicationContext(),
					MLedgerReportsByTimePieChart.class);
			intn.putExtra("titles", yearTitles);
			intn.putExtra("totalWithdrawals", totalWithdrawals);
			intn.putExtra("totalDeposits", totalDeposits);
			startActivity(intn);
			finish();
			return true;

		default:
			return super.onOptionsItemSelected(item);
		}
	}
}

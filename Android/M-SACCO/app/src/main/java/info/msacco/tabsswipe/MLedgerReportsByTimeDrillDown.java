package info.msacco.tabsswipe;

import info.msacco.actionbar.model.MledgerDepWithdByTimeDailyTransactionsDrillDownModel;
import info.msacco.actionbar.model.MledgerDepWithdByTimeDateDrillDownModel;
import info.msacco.tabsswipe.adapter.MSACCOLocalDb;
import info.msacco.tabsswipe.adapter.MledgerReportsByTimeDayOfMonthExpandableListAdapter;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ExpandableListView;
import android.widget.ExpandableListView.OnChildClickListener;
import android.widget.ExpandableListView.OnGroupClickListener;
import android.widget.ExpandableListView.OnGroupCollapseListener;
import android.widget.ExpandableListView.OnGroupExpandListener;

import com.msacco.safaricom_sacco.R;

public class MLedgerReportsByTimeDrillDown extends Activity {

	MledgerReportsByTimeDayOfMonthExpandableListAdapter listAdapter;
	ExpandableListView expListView;

	// Contains a list of headers for expandable lists.
	List<MledgerDepWithdByTimeDateDrillDownModel> listDataHeader;

	List<MledgerDepWithdByTimeDateDrillDownModel> dateList;

	// One object with header and drill down data for a single epandableList
	// element
	HashMap<MledgerDepWithdByTimeDateDrillDownModel, List<MledgerDepWithdByTimeDailyTransactionsDrillDownModel>> listDataChild;

	// Reference to the local Database Class
	MSACCOLocalDb db;

	// Store data for use in drawing charts.
	HashMap<String[], Double[]> reportsData;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.mledger_reports_by_time_day_of_month);

		// Instantiate Lists.
		dateList = new ArrayList<MledgerDepWithdByTimeDateDrillDownModel>();
	
		// Instantiate Local DB
		db = new MSACCOLocalDb(this);
		

		// Call to method that sets up the expandable List
		InitializeExpandableList();
	}

	public void InitializeExpandableList() {
		// get the listview
		expListView = (ExpandableListView) findViewById(R.id.mledgerReportsByTimeMonthExpLv);

		// preparing list data
		prepareListData();

		listAdapter = new MledgerReportsByTimeDayOfMonthExpandableListAdapter(this,
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
				// TODO Auto-generated method stub;
				return false;
			}
		});
	}

	// Preparing the list data
	private void prepareListData() {

		// Get data from local DB into a Custom List
		Intent intent=getIntent();

		String month=intent.getStringExtra("month");
		
		dateList=db.getDepAndWithdDrillDownDataByTimeDayOfMonth(month);

		// Instantiate the header and drill down elements
		listDataHeader = new ArrayList<MledgerDepWithdByTimeDateDrillDownModel>();
		listDataChild = new HashMap<MledgerDepWithdByTimeDateDrillDownModel, List<MledgerDepWithdByTimeDailyTransactionsDrillDownModel>>();

		for (int i = 0; i < dateList.size(); i++) {

			//Store drill down data into a Custom list
			List<MledgerDepWithdByTimeDailyTransactionsDrillDownModel> drillList = db
					.getDepAndWithdDrillDownDataByTimeDailyTransactions(month, dateList.get(i).get_date());

			// Adding parent Data
			listDataHeader.add(dateList.get(i));

			List<MledgerDepWithdByTimeDailyTransactionsDrillDownModel> drillDownItems = new ArrayList<MledgerDepWithdByTimeDailyTransactionsDrillDownModel>();

			for (int index = 0; index < drillList.size(); index++) {

				// Add drill down data elememts into parent List
				drillDownItems.add((drillList.get(index)));
			}

			// Add Parent and child data into a List.
			listDataChild.put(listDataHeader.get(i), drillDownItems);
		}

	}
}

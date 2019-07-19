package info.msacco.tabsswipe;

import android.app.ActionBar;
import android.app.ActionBar.OnNavigationListener;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.widget.ArrayAdapter;

import com.msacco.safaricom_sacco.R;

public class MLedgerReportsByTransTypePieChart extends Activity
		implements
		MLedgerReportsByTransTypeDepositPieChartFragment.depositReportsDataListener,
		MLedgerReportsByTransTypeWithdrawalsPieChartFragment.withdrawalReportsDataListener {

	private String[] titlesArray;
	private double[] depositsArray;
	private double[] withdrawalArray;
	/** An array of strings to populate dropdown list */
	String[] actions = new String[] { "Deposits", "Withdrawals" };

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.mledger_reports_by_trans_type_pie_chart);

		Intent intent = getIntent();

		// Get the number of accounts
		int sizeOfArray = intent.getStringArrayExtra("titles").length;

		// Pie Chart Slice Names
		titlesArray = intent.getStringArrayExtra("titles");

		// Pie Chart Deposit Slice Values
		depositsArray = intent.getDoubleArrayExtra("totalDeposits");

		// Pie Chart Withdrawals Slice Values
		withdrawalArray = intent.getDoubleArrayExtra("totalWithdrawals");

		// Set the deposits pie chart fragment as the default when the activity
		// opens.
		android.app.FragmentManager fragmentManager = getFragmentManager();
		android.app.FragmentTransaction fragmentTransaction = fragmentManager
				.beginTransaction();

		MLedgerReportsByTransTypeDepositPieChartFragment depfragment = new MLedgerReportsByTransTypeDepositPieChartFragment();
		fragmentTransaction.replace(R.id.container, depfragment);
		fragmentTransaction.commit();
		/** Create an array adapter to populate dropdownlist */
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(
				getBaseContext(), R.layout.spinner_items_template_white,
				actions);

		/** Enabling dropdown list navigation for the action bar */
		getActionBar().setNavigationMode(ActionBar.NAVIGATION_MODE_LIST);

		/** Defining Navigation listener */
		ActionBar.OnNavigationListener navigationListener = new OnNavigationListener() {

			@Override
			public boolean onNavigationItemSelected(int itemPosition,
					long itemId) {
				android.app.FragmentManager fragmentManager = getFragmentManager();
				android.app.FragmentTransaction fragmentTransaction = fragmentManager
						.beginTransaction();
				switch (itemPosition) {
				case 0:
					if (totals(depositsArray) < 0.1) {
						noTransactionFoundFragment fragment = new noTransactionFoundFragment();
						fragmentTransaction.replace(R.id.container, fragment);
						fragmentTransaction.commit();
					} else {
						MLedgerReportsByTransTypeDepositPieChartFragment depfragment = new MLedgerReportsByTransTypeDepositPieChartFragment();
						fragmentTransaction
								.replace(R.id.container, depfragment);
					}
					return true;
				case 1:
					if (totals(withdrawalArray) < 0.1) {
						noTransactionFoundFragment fragment = new noTransactionFoundFragment();
						fragmentTransaction.replace(R.id.container, fragment);
						fragmentTransaction.commit();
					} else {
						MLedgerReportsByTransTypeWithdrawalsPieChartFragment withdfragment = new MLedgerReportsByTransTypeWithdrawalsPieChartFragment();
						fragmentTransaction.replace(R.id.container,
								withdfragment);
						fragmentTransaction.commit();
					}

					return true;
				default:
					MLedgerReportsByTransTypeDepositPieChartFragment depfragment = new MLedgerReportsByTransTypeDepositPieChartFragment();
					fragmentTransaction.replace(R.id.container, depfragment);
					return false;
				}
			}
		};

		/**
		 * Setting dropdown items and item navigation listener for the actionbar
		 */
		getActionBar().setListNavigationCallbacks(adapter, navigationListener);
	}

	public double totals(double[] arr) {
		double totals = 0.0;
		for (int i = 0; i < arr.length; i++) {
			totals += arr[i];
		}
		return totals;
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	// Implementation of the interface "depositReportsDataListener" method for
	// getting the deposit data.
	@Override
	public Bundle depositReportsData() {

		Bundle depositsbundle = new Bundle();
		depositsbundle.putStringArray("titles", titlesArray);
		depositsbundle.putDoubleArray("deposits", depositsArray);
		return depositsbundle;
	}

	// Implementation of the interface "depositReportsDataListener" method for
	// getting the withdrawal data.
	@Override
	public Bundle withdrawalReportsData() {

		Bundle withdrawalsbundle = new Bundle();
		withdrawalsbundle.putStringArray("titles", titlesArray);
		withdrawalsbundle.putDoubleArray("withdrawals", withdrawalArray);
		return withdrawalsbundle;
	}

}
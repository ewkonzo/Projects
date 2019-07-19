package info.msacco.tabsswipe;

import info.msacco.actionbar.model.MledgerReportsByTimeDataModel;
import info.msacco.tabsswipe.adapter.MSACCOLocalDb;
import info.msacco.tabsswipe.adapter.MledgerReportsByTimeListAdapter;

import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ListView;

import com.msacco.safaricom_sacco.R;

public class MLedgerReportsByTime extends Activity {

	private MSACCOLocalDb db;
	private ListView transactionByTimeListV;
	private List<MledgerReportsByTimeDataModel> monthList;

	private MledgerReportsByTimeListAdapter adapter;

	private double[] totalDeposits = null;
	private double[] totalWithdrawals = null;
	private String[] monthTitles = null;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.mledger_reports_by_time);

		db = new MSACCOLocalDb(getApplicationContext());
		monthList = new ArrayList<MledgerReportsByTimeDataModel>();
		setLists();
	}

	public void setLists() {
		monthList = db.getDepAndWithdByMonth();

		transactionByTimeListV = (ListView) findViewById(R.id.MledgerByTimeMAinList);

		ArrayList<MledgerReportsByTimeDataModel> entryListModel = new ArrayList<MledgerReportsByTimeDataModel>();

		totalDeposits = new double[monthList.size()];
		totalWithdrawals = new double[monthList.size()];
		monthTitles = new String[monthList.size()];

		for (int i = 0; i < monthList.size(); i++) {
			monthTitles[i] =monthList.get(i).get_month();
			totalDeposits[i] = monthList.get(i).get_deposits();
			totalWithdrawals[i] = monthList.get(i).get_withdrawals();

			MledgerReportsByTimeDataModel mdl = new MledgerReportsByTimeDataModel(
					monthList.get(i).get_month(), monthList.get(i)
							.get_deposits(), monthList.get(i).get_withdrawals());
			entryListModel.add(mdl);
		}
		adapter = new MledgerReportsByTimeListAdapter(this, entryListModel);
		transactionByTimeListV.setAdapter(adapter);

		transactionByTimeListV
				.setOnItemClickListener(new OnItemClickListener() {

					@Override
					public void onItemClick(AdapterView<?> parent, View arg1,
							int position, long id) {
						// When clicked, show a toast with the TextView text

						MledgerReportsByTimeDataModel model = (MledgerReportsByTimeDataModel) parent
								.getItemAtPosition(position);

						String month = model.get_month();

						Intent i = new Intent(getApplicationContext(),
								MLedgerReportsByTimeDrillDown.class);
						i.putExtra("month", month);
						startActivity(i);
					}
				});
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
			i.putExtra("titles", monthTitles);
			i.putExtra("totalWithdrawals", totalWithdrawals);
			i.putExtra("totalDeposits", totalDeposits);
			startActivity(i);
			finish();

			return true;
		case R.id.action_pie_chart:
			Intent intn = new Intent(getApplicationContext(),
					MLedgerReportsByTimePieChart.class);
			intn.putExtra("titles", monthTitles);
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

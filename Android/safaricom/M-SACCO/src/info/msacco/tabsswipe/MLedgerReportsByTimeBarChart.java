package info.msacco.tabsswipe;

import org.achartengine.ChartFactory;
import org.achartengine.chart.BarChart.Type;
import org.achartengine.model.XYMultipleSeriesDataset;
import org.achartengine.model.XYSeries;
import org.achartengine.renderer.XYMultipleSeriesRenderer;
import org.achartengine.renderer.XYSeriesRenderer;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;

import com.msacco.safaricom_sacco.R;

public class MLedgerReportsByTimeBarChart extends Activity {

	private String[] titlesArray;
	private static double[] depositsArray;
	private static double[] withdrawalArray;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.mledger_reports_by_time_bar_chart);

		// Ploting the chart
		openChart();
	}

	private void openChart() {

		Intent in = getIntent();

		try {
			// Get the number of accounts
			int sizeOfArray = in.getStringArrayExtra("titles").length;

			// Account Names.
			titlesArray = in.getStringArrayExtra("titles");

			// Deposits' amounts
			depositsArray = in.getDoubleArrayExtra("totalDeposits");

			// Withdrawal Amounts.
			withdrawalArray = in.getDoubleArrayExtra("totalWithdrawals");

			// Creating an XYSeries for Deposits and Withdrawals

			XYSeries depositsSeries = new XYSeries("Deposits");
			XYSeries withdrawalsSeries = new XYSeries("Withdrawals");

			// Adding data to Deposits and Withdrawals Series.
			for (int i = 0; i < titlesArray.length; i++) {

				depositsSeries.add(i, depositsArray[i]);
				withdrawalsSeries.add(i, withdrawalArray[i]);
			}

			// Creating a dataset to hold each series
			XYMultipleSeriesDataset dataset = new XYMultipleSeriesDataset();

			// Adding Deposits Series to the dataset
			dataset.addSeries(depositsSeries);

			// Adding Withdrawals Series to dataset
			dataset.addSeries(withdrawalsSeries);

			// Creating XYSeriesRenderer to customize DepositsSeries
			XYSeriesRenderer depositsRenderer = new XYSeriesRenderer();
			depositsRenderer.setColor(Color.GREEN);
			depositsRenderer.setFillPoints(true);
			depositsRenderer.setDisplayChartValues(true);

			// Creating XYSeriesRenderer to customize Withdrawalsseries
			XYSeriesRenderer withdrawalRenderer = new XYSeriesRenderer();
			withdrawalRenderer.setColor(Color.RED);
			withdrawalRenderer.setFillPoints(true);
			withdrawalRenderer.setDisplayChartValues(true);

			// Creating a XYMultipleSeriesRenderer to customize the whole chart
			XYMultipleSeriesRenderer multiRenderer = new XYMultipleSeriesRenderer();

			multiRenderer.setMargins(new int[] { 50, 50, 50, 0 });
			multiRenderer.setBackgroundColor(Color.WHITE);
			multiRenderer.setXLabels(0);
			multiRenderer.setMarginsColor(Color.WHITE);
			multiRenderer.setLegendTextSize(18);
			multiRenderer.setAxesColor(this.getResources().getColor(
					R.color.lightgreen));
			multiRenderer.setLabelsTextSize(15);
			multiRenderer.setBarSpacing(0.25);
			multiRenderer.setChartTitle("Deposits and Withdrals by month");

			multiRenderer.setXLabelsAngle(90);
			multiRenderer.setPanEnabled(true, false);
			multiRenderer.setLabelsColor(Color.BLACK);
			multiRenderer.setXLabelsColor(Color.BLACK);
			multiRenderer.setFitLegend(true);
			multiRenderer.setYLabelsPadding(30);
			multiRenderer.setApplyBackgroundColor(true);
			multiRenderer.setZoomButtonsVisible(true);
			multiRenderer.setXAxisMin(-0.5);
			multiRenderer.setYAxisMin(-1.0);
			multiRenderer.setXAxisMax((depositsArray.length)
					+ (withdrawalArray.length));
			multiRenderer.setYAxisMax(YSeriesMax()*1.15);

			for (int i = 0; i < titlesArray.length; i++) {
				multiRenderer.addXTextLabel(i, titlesArray[i]);
			}

			// Adding depositsRenderer and withdrawalsRenderer to
			// multipleRenderer
			// Note: The order of adding dataseries to dataset and renderers to
			// multipleRenderer
			// should be same
			multiRenderer.addSeriesRenderer(depositsRenderer);
			multiRenderer.addSeriesRenderer(withdrawalRenderer);

			// Creating an intent to plot bar chart using dataset and
			// multipleRenderer
			Intent intent = ChartFactory.getBarChartIntent(getBaseContext(),
					dataset, multiRenderer, Type.DEFAULT);

			// Start Activity
			startActivity(intent);
			finish();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public static double YseriesValuesMax(double[] array) {
		// Finds and returns max
		double max = array[0];
		for (int j = 1; j < array.length; j++) {
			if (array[j] > max) {
				max = array[j];
			}
		}

		return max;
	}

	public static double YSeriesMax() {
		double[] maxVal = new double[2];
		double maxdeposit = YseriesValuesMax(depositsArray);
		double maxwithdrawal = YseriesValuesMax(withdrawalArray);

		maxVal[0] = maxdeposit;
		maxVal[1] = maxwithdrawal;

		double finalMax = YseriesValuesMax(maxVal);
		return finalMax;
	}
}
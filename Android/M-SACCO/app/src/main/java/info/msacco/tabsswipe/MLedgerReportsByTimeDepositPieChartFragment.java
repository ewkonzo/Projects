package info.msacco.tabsswipe;

import java.text.DecimalFormat;
import java.util.ArrayList;

import org.achartengine.ChartFactory;
import org.achartengine.GraphicalView;
import org.achartengine.model.CategorySeries;
import org.achartengine.model.SeriesSelection;
import org.achartengine.renderer.DefaultRenderer;
import org.achartengine.renderer.SimpleSeriesRenderer;

import android.app.Activity;
import android.app.Fragment;
import android.graphics.Color;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewGroup.LayoutParams;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.msacco.safaricom_sacco.R;

public class MLedgerReportsByTimeDepositPieChartFragment extends Fragment {

	private String[] chartTitles;
	private double[] chartDeposits;
	/** Colors to be used for the pie slices. */
	private static int[] COLORS = new int[] { 
			Color.rgb(0, 255, 255), Color.rgb(255, 0, 255),
			Color.rgb(128, 0, 128), Color.rgb(255, 140, 0),
			Color.rgb(0, 100, 0), Color.rgb(255, 0, 0), Color.rgb(0, 255, 0),
			Color.rgb(139, 0, 139), Color.rgb(25, 25, 112),
			Color.rgb(95, 158, 160), Color.rgb(165, 42, 42) };
	/** The main series that will include all the data. */
	private CategorySeries mSeries = new CategorySeries("");
	/** The main renderer for the main dataset. */
	private DefaultRenderer mRenderer = new DefaultRenderer();
	/** The chart view that displays the data. */
	private GraphicalView mChartView;

	private depositReportsDataListener mListener;
	private LinearLayout layout;

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {

		View rootView = inflater.inflate(
				R.layout.mledger_reports_by_acc_type_pie_chart_dep_fragment,
				container, false);
		layout = (LinearLayout) rootView
				.findViewById(R.id.mledgerReportsByAccTypedepPiechart);
		return rootView;
	}

	protected void onRestoreInstanceState(Bundle savedState) {
		super.onSaveInstanceState(savedState);
		mSeries = (CategorySeries) savedState.getSerializable("current_series");
		mRenderer = (DefaultRenderer) savedState
				.getSerializable("current_renderer");
	}

	@Override
	public void onSaveInstanceState(Bundle outState) {
		super.onSaveInstanceState(outState);
		outState.putSerializable("current_series", mSeries);
		outState.putSerializable("current_renderer", mRenderer);
	}

	@Override
	public void onAttach(Activity activity) {
		super.onAttach(activity);
		try {
			mListener = (depositReportsDataListener) activity;
		} catch (ClassCastException e) {
			throw new ClassCastException(activity.toString()
					+ " must implement depositReportsDataListener");
		}
	}

	@Override
	public void onResume() {
		// TODO Auto-generated method stub
		super.onResume();

		Bundle dataBundle;
		dataBundle = mListener.depositReportsData();

		chartTitles = dataBundle.getStringArray("titles");
		chartDeposits = dataBundle.getDoubleArray("deposits");

		// Ploting the chart
		openChart();
	}

	@Override
	public void onDetach() {
		super.onDetach();
		mListener = null;
	}

	public interface depositReportsDataListener {
		public Bundle depositReportsData();
	}

	private void openChart() {

		ArrayList<Double> newChartdepositsArray = new ArrayList<Double>();
		final ArrayList<String> newChartTitles = new ArrayList<String>();
		for (int i = 0; i < chartDeposits.length; i++) {
			if (chartDeposits[i] > 0.0) {
				newChartdepositsArray.add(chartDeposits[i]);
				newChartTitles.add(chartTitles[i]);
			}
		}
		super.onResume();

		for (int i = 0; i < newChartdepositsArray.size(); i++) {
			mSeries.add(newChartTitles.get(i), newChartdepositsArray.get(i));
			SimpleSeriesRenderer renderer = new SimpleSeriesRenderer();
			renderer.setColor(COLORS[(mSeries.getItemCount() - 1)
					% COLORS.length]);
			mRenderer.addSeriesRenderer(renderer);
			mRenderer.setChartTitle("Deposits");
			mRenderer.setChartTitleTextSize(22);
			mRenderer.setLabelsColor(Color.BLACK);
			mRenderer.setLabelsTextSize(12);
			mRenderer.setZoomButtonsVisible(true);
		}
		if (mChartView == null) {

			mChartView = ChartFactory.getPieChartView(getActivity(), mSeries,
					mRenderer);
			mRenderer.setClickEnabled(true);
			mChartView.setOnClickListener(new View.OnClickListener() {
				@Override
				public void onClick(View v) {
					SeriesSelection seriesSelection = mChartView
							.getCurrentSeriesAndPoint();
					if (seriesSelection == null) {

					} else {
						for (int i = 0; i < mSeries.getItemCount(); i++) {
							mRenderer.getSeriesRendererAt(i).setHighlighted(
									i == seriesSelection.getPointIndex());
						}
						mChartView.repaint();

						// Getting the name of the clicked slice
						int seriesIndex = seriesSelection.getPointIndex();
						String selectedSeries = "";
						selectedSeries = newChartTitles.get(seriesIndex);

						// Getting the value of the clicked slice
						double value = seriesSelection.getXValue();
						DecimalFormat dFormat = new DecimalFormat("#.#");

						// Displaying the message
						Toast.makeText(
								getActivity().getBaseContext(),
								selectedSeries + " : "
										+ Double.valueOf(dFormat.format(value)),
								Toast.LENGTH_SHORT).show();
					}
				}
			});
			layout.addView(mChartView, new LayoutParams(
					LayoutParams.FILL_PARENT, LayoutParams.FILL_PARENT));
		} else {
			// mChartView.repaint();
		}
	}
}

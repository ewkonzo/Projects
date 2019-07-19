package info.msacco.tabsswipe;

import android.os.Bundle;

import com.msacco.safaricom_sacco.R;

public class FeedbackActivity extends DashBoardActivity {
	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.main);
		setHeader(getString(R.string.FeedbackActivityTitle), true, false);

	}
}

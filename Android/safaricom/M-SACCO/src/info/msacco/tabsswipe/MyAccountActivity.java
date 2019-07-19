package info.msacco.tabsswipe;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

import com.msacco.safaricom_sacco.R;

public class MyAccountActivity extends Activity implements OnClickListener {

	private Button onMemberInfoBtnClicked, nextOfKinBtn,onMiniGuarantorshipBtnClicked;

	// onMiniStmtBtnClicked;
	// private CheckInternetConnectivity cd;
	// flag for Internet connection status
	// Boolean isInternetPresent = false;

	@Override
	protected void onCreate(Bundle savedInstanceState) 
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.my_accounts_main);
				
		onMemberInfoBtnClicked = (Button) findViewById(R.id.myAccMemberInfoBtn);
		nextOfKinBtn = (Button) findViewById(R.id.myAccNextOfKinBtn);
		onMemberInfoBtnClicked.setOnClickListener(this);
		nextOfKinBtn.setOnClickListener(this);

	}

	@Override
	public void onClick(View v) {
		if (v == onMemberInfoBtnClicked) {
			Intent intent = new Intent(this, MyAccMemberInfoActivity.class);
			// Close all views before launching Dashboard
			intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(intent);
		} else if (v == nextOfKinBtn) {
			Intent intent = new Intent(this, MyAccNextOfKinActivity.class);
			// Close all views before launching Dashboard
			intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
			startActivity(intent);
		}
	}
}
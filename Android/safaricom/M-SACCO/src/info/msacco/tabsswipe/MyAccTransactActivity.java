package info.msacco.tabsswipe;


import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

import com.msacco.safaricom_sacco.R;

public class MyAccTransactActivity extends Activity implements OnClickListener{
	
	private Button onMyAccTransactDepositBtnClicked,onMyAccTransactWithdrawBtnClicked,
	onMyAccTransactAirtimeTopUpBtnClicked;
	
  @Override
  protected void onCreate(Bundle savedInstanceState) {
	        super.onCreate(savedInstanceState);
	        setContentView(R.layout.transact);
	        
	        onMyAccTransactDepositBtnClicked = (Button) findViewById(R.id.myAccTransactDepositBtn);
	        onMyAccTransactWithdrawBtnClicked = (Button) findViewById(R.id.myAccTransactWithdrawBtn);
	        onMyAccTransactAirtimeTopUpBtnClicked = (Button) findViewById(R.id.myAccTransactAirtimeTopUpBtn);
	        
	        onMyAccTransactDepositBtnClicked.setOnClickListener(this);
	        onMyAccTransactWithdrawBtnClicked.setOnClickListener(this);
	        onMyAccTransactAirtimeTopUpBtnClicked.setOnClickListener(this);	    	
	  }

	@Override
	public void onClick(View view) {
		if(view==onMyAccTransactDepositBtnClicked)
		{
			Intent intent = new Intent(this,MyAccTransactDepositActivity.class);
			startActivity(intent);
		}
		else if(view==onMyAccTransactWithdrawBtnClicked)
		{
			Intent intent = new Intent(this,MyAccTransactWithdrawActivity.class);
			startActivity(intent);
		}
		else if(view==onMyAccTransactAirtimeTopUpBtnClicked)
		{
			Intent intent = new Intent(this,MyAccTransactAirtimeTopUpActivity.class);
			startActivity(intent);
		}
		
	}
}

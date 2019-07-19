package info.msacco.tabsswipe;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.Button;

import com.msacco.safaricom_sacco.R;

public class EPayOnlinePaymentFragment extends Fragment implements OnClickListener{

	Button payPalBtn,pesaPalBtn;
	
	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {

		View rootView = inflater.inflate(R.layout.e_pay_online_pay_fragment, container, false);
		
		payPalBtn=(Button) rootView.findViewById(R.id.epayOnlineMasterCardBtn);
		pesaPalBtn=(Button) rootView.findViewById(R.id.epayOnlineVisaBtn);
		
		payPalBtn.setOnClickListener(this);
		pesaPalBtn.setOnClickListener(this);
		
	return rootView;	
	}

	@Override
	public void onClick(View view) {
		
		if(view==payPalBtn)
		{
			Intent i= new Intent(getActivity().getApplicationContext(),EPayOnlinePaymentMasterCardActivity.class);
			startActivity(i);
		}

		else if(view==pesaPalBtn)
		{
			Intent i= new Intent(getActivity().getApplicationContext(),EPayOnlinePaymentVISAActivity.class);
			startActivity(i);
		}
		
	}
}

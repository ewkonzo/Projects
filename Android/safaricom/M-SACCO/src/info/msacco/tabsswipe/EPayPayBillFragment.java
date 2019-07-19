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

public class EPayPayBillFragment extends Fragment implements OnClickListener{

	Button kplcBtn,nairobiWater,DSTV_btn,ZUKU_btn;
	
	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {

		View rootView = inflater.inflate(R.layout.e_pay_pay_bill_fragment, container, false);
		
		kplcBtn=(Button) rootView.findViewById(R.id.epayPayBillKPLCBtn);
		nairobiWater=(Button) rootView.findViewById(R.id.epayPayBillNairobiWaterBtn);
		DSTV_btn=(Button) rootView.findViewById(R.id.epayPayBillDSTVBtn);
		ZUKU_btn=(Button) rootView.findViewById(R.id.epayPayBillZUKUBtn);
		
		kplcBtn.setOnClickListener(this);
		nairobiWater.setOnClickListener(this);
		DSTV_btn.setOnClickListener(this);
		ZUKU_btn.setOnClickListener(this);
		
	return rootView;	
	}

	@Override
	public void onClick(View view) {
		
		if(view==kplcBtn)
		{
			Intent i= new Intent(getActivity().getApplicationContext(),EPayPayBillKPLCActivity.class);
			startActivity(i);
		}
		else if(view==ZUKU_btn)
		{
			Intent i= new Intent(getActivity().getApplicationContext(),EPayPayBillZUKUActivity.class);
			startActivity(i);
		}
		else if(view==nairobiWater)
		{
			Intent i= new Intent(getActivity().getApplicationContext(),EPayPayBillNairobiWaterActivity.class);
			startActivity(i);
		}
		else if(view==DSTV_btn)
		{
			Intent i= new Intent(getActivity().getApplicationContext(),EPayPayBillDSTVActivity.class);
			startActivity(i);
		}
		
	}
}

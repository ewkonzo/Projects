package info.msacco.tabsswipe.adapter;


import info.msacco.tabsswipe.MyLnsLoanRepaymentFragment;
import info.msacco.tabsswipe.MyLnsLoanRequestFragment;
import info.msacco.tabsswipe.MyLnsLoanStatusFragment;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

public class MyLoansTabsPagerAdapter extends FragmentPagerAdapter {
	
	private static final int NO_OF_TABS = 3;

    public MyLoansTabsPagerAdapter(FragmentManager fm) {
        super(fm);
    }
 
    @Override
    public Fragment getItem(int index) {
 
        switch (index) {
        case 0:
            // Deposit Fragment
            return new MyLnsLoanRequestFragment();
        case 1:
            // Account balance Fragment
            return new MyLnsLoanRepaymentFragment();
        case 2:
            // Deposit Fragment
            return new MyLnsLoanStatusFragment();
        }
 
        return null;
    }

	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return NO_OF_TABS;
	}
	
}

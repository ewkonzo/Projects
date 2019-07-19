package info.msacco.tabsswipe.adapter;


import info.msacco.tabsswipe.FTransFOSAtoBOSAFragment;
import info.msacco.tabsswipe.FTransFOSAtoFOSAFragment;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

public class FundsTransferTabsPagerAdapter extends FragmentPagerAdapter {
	
	private static final int NO_OF_TABS = 2;

    public FundsTransferTabsPagerAdapter(FragmentManager fm) {
        super(fm);
    }
 
    @Override
    public Fragment getItem(int index) {
 
        switch (index) {
        case 0:
            // Deposit Fragment
            return new FTransFOSAtoFOSAFragment();
        case 1:
            // Account balance Fragment
            return new FTransFOSAtoBOSAFragment();
        }
 
        return null;
    }

	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return NO_OF_TABS;
	}
	
}

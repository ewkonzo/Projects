package com.wizarpos.scanner.aidl;

import android.content.ServiceConnection;

public interface IAIDLListener {
    
    public static final int STATE_UNKNOW = -1;
//	onServiceConnected
	public  void  serviceConnected(Object objService, ServiceConnection connection);

}

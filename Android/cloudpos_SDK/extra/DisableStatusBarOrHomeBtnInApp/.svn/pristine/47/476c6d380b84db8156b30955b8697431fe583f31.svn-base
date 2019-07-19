package com.wizarpos.homebtn.demo;




import android.app.Activity;
import android.widget.Button;


/**对已有的activity中的控件进行总调度,方便资源的整体利用。
 * @author john.li
 */
public class ResourceManager {
	
	
	public static Object findObject(int id, Activity host){
		return host.findViewById(id);
	}
	
	
	public static Button getBtnReturnFromMainActivity(Activity host){
		Button exit = (Button)host.findViewById(R.id.btn2_return);//widget38
		return exit;
	}
	public static Button getBtnMenuFromMainActivity(Activity host){
		Button exit = (Button)host.findViewById(R.id.btn1_menu);//widget38
		return exit;
	}
	public static Button getBtnExitFromMainActivity(Activity host){
		Button exit = (Button)host.findViewById(R.id.btn3_back);//widget38
		return exit;
	}
	
}
package com.wizarpos.util;

public class SystemUtil {


	public static final String CUSTOM_SN = "wp.customer.serialno";
	
    public static String getCustomSn(){
    	return getProp("wp.customer.serialno", "null"); 
    }
    public static String getProp(String key, String defauleValue) {
        Object value = "";
        try {
           Class<?> systemProperties = Class.forName("android.os.SystemProperties");
           value = systemProperties.getMethod("get", new Class[] { String.class, String.class }).invoke(systemProperties, new Object[] { key, defauleValue });
        } catch (Exception e) {
           e.printStackTrace();
        }
        return value.toString();
     }
     
    

    
    

}

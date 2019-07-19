package info.msacco.utils;

public class Configuration 
{
	private static String URL = "http://41.72.203.234:35051/NewMsaccoApp/M-SaccoApp.asmx";
	
	private static String telephoneNo = "";
	private static String corporateNo = "505100";
	private static String pin = "";

	public static String getURL()
	{
		return URL;
	}

	public void setURL(String uRL) {
		URL = uRL;
	}

	public String getTelephoneNo() {
		return telephoneNo;
	}

	public void setTelephoneNo(String telephoneNo) {
		Configuration.telephoneNo = telephoneNo;
	}

	public static String getCorporateNo() {
		return corporateNo;
	}

	public void setCorporateNo(String corporateNo) {
		Configuration.corporateNo = corporateNo;
	}

	public String getPin() {
		return pin;
	}

	public void setPin(String pin) {
		Configuration.pin = pin;
	}

}
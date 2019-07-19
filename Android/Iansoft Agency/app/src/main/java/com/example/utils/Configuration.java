package com.example.utils;


public class Configuration {

	private static String URL = "http://192.168.43.72/CapitalClientService/AgencyClientService.asmx";
	
	// private static String URL ="http://41.72.203.234:35051/Agency/Agency.asmx";
	
	private static String URL_TWO = "http://41.72.203.234:35051/Agency/Agency.asmx";

	public static String telephoneNo = "";
	
	public static String AgentPin="";

	public static String getURL() {
		return URL;
	}
	public static String getURL_TWO() {
		return URL_TWO;
	}
	
	public String getAgentPin() {
		return AgentPin;
	}
	public void setAgentPin(String agentpin) {
		Configuration.AgentPin = agentpin;
	}
}

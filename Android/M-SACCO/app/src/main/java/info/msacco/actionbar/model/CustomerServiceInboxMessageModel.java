package info.msacco.actionbar.model;

public class CustomerServiceInboxMessageModel {
	
	// private variables
	int _entryNo;
	String _entryDate;
	String _messageHeading;
	String _message;

	
    public CustomerServiceInboxMessageModel(){}


	public CustomerServiceInboxMessageModel(int _entryNo, String _entryDate,
			String _messageHeading, String _message) {
		super();
		this._entryNo = _entryNo;
		this._entryDate = _entryDate;
		this._messageHeading = _messageHeading;
		this._message = _message;
	}


	public int get_entryNo() {
		return _entryNo;
	}


	public void set_entryNo(int _entryNo) {
		this._entryNo = _entryNo;
	}


	public String get_entryDate() {
		return _entryDate;
	}


	public void set_entryDate(String _entryDate) {
		this._entryDate = _entryDate;
	}


	public String get_messageHeading() {
		return _messageHeading;
	}


	public void set_messageHeading(String _messageHeading) {
		this._messageHeading = _messageHeading;
	}


	public String get_message() {
		return _message;
	}


	public void set_message(String _message) {
		this._message = _message;
	}

}
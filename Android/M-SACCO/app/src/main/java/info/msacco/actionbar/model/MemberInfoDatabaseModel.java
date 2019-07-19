package info.msacco.actionbar.model;

public class MemberInfoDatabaseModel {
	   //private variables
    int _id;
    String _name;
    String _gender;
    String _address;
    String _emailAddr;
    String _bankName;
    String _bankBrachName;
    String _bankAccNo;
    
    public MemberInfoDatabaseModel()
    {}
	public MemberInfoDatabaseModel(int _id, String _name, String _gender,
			String _address, String _emailAddr, String _bankName,
			String _bankBrachName, String _bankAccNo) {
		super();
		this._id = _id;
		this._name = _name;
		this._gender = _gender;
		this._address = _address;
		this._emailAddr = _emailAddr;
		this._bankName = _bankName;
		this._bankBrachName = _bankBrachName;
		this._bankAccNo = _bankAccNo;
	}
	public int get_id() {
		return _id;
	}
	public void set_id(int _id) {
		this._id = _id;
	}
	public String get_name() {
		return _name;
	}
	public void set_name(String _name) {
		this._name = _name;
	}
	public String get_gender() {
		return _gender;
	}
	public void set_gender(String _gender) {
		this._gender = _gender;
	}
	public String get_address() {
		return _address;
	}
	public void set_address(String _address) {
		this._address = _address;
	}
	public String get_emailAddr() {
		return _emailAddr;
	}
	public void set_emailAddr(String _emailAddr) {
		this._emailAddr = _emailAddr;
	}
	public String get_bankName() {
		return _bankName;
	}
	public void set_bankName(String _bankName) {
		this._bankName = _bankName;
	}
	public String get_bankBrachName() {
		return _bankBrachName;
	}
	public void set_bankBrachName(String _bankBrachName) {
		this._bankBrachName = _bankBrachName;
	}
	public String get_bankAccNo() {
		return _bankAccNo;
	}
	public void set_bankAccNo(String _bankAccNo) {
		this._bankAccNo = _bankAccNo;
	}
	

}

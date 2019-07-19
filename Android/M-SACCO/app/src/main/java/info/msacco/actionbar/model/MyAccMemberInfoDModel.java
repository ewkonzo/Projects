package info.msacco.actionbar.model;

public class MyAccMemberInfoDModel {
	private int _entry_number;
	private String _member_name;
	private String _member_gender;
	private String _member_address;
	private String _member_email;
	private String _member_bank;
	private String _member_branch;
	private String _member_account_number;

	public MyAccMemberInfoDModel() {
	}

	public MyAccMemberInfoDModel(int _entry_number, String _member_name,
			String _member_gender, String _member_address,
			String _member_email, String _member_bank, String _member_branch,
			String _member_account_number) {
		super();
		this._entry_number = _entry_number;
		this._member_name = _member_name;
		this._member_gender = _member_gender;
		this._member_address = _member_address;
		this._member_email = _member_email;
		this._member_bank = _member_bank;
		this._member_branch = _member_branch;
		this._member_account_number = _member_account_number;
	}

	public int get_entry_number() {
		return _entry_number;
	}

	public void set_entry_number(int _entry_number) {
		this._entry_number = _entry_number;
	}

	public String get_member_name() {
		return _member_name;
	}

	public void set_member_name(String _member_name) {
		this._member_name = _member_name;
	}

	public String get_member_gender() {
		return _member_gender;
	}

	public void set_member_gender(String _member_gender) {
		this._member_gender = _member_gender;
	}

	public String get_member_address() {
		return _member_address;
	}

	public void set_member_address(String _member_address) {
		this._member_address = _member_address;
	}

	public String get_member_email() {
		return _member_email;
	}

	public void set_member_email(String _member_email) {
		this._member_email = _member_email;
	}

	public String get_member_bank() {
		return _member_bank;
	}

	public void set_member_bank(String _member_bank) {
		this._member_bank = _member_bank;
	}

	public String get_member_branch() {
		return _member_branch;
	}

	public void set_member_branch(String _member_branch) {
		this._member_branch = _member_branch;
	}

	public String get_member_accoung_number() {
		return _member_account_number;
	}

	public void set_member_accoung_number(String _member_accoung_number) {
		this._member_account_number = _member_accoung_number;
	}

}
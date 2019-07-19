package info.msacco.actionbar.model;

public class MledgerDepWithdDatabaseModel {

	// private variables
	int _entry_no;
	String _account_type;
	String _date;
	String _month;
	String _year;
	double _credit_amount;
	double _debit_amount;
	double _amount;
	String _journal_batch_name;
	String _initial_entry_global_dim1;
	String _description;

	public MledgerDepWithdDatabaseModel(){}

	public MledgerDepWithdDatabaseModel(int _entry_no, String _account_type,
			String _date, String _month, String _year, double _credit_amount,
			double _debit_amount, double _amount, String _journal_batch_name,
			String _initial_entry_global_dim1, String _description) {
		super();
		this._entry_no = _entry_no;
		this._account_type = _account_type;
		this._date = _date;
		this._month = _month;
		this._year = _year;
		this._credit_amount = _credit_amount;
		this._debit_amount = _debit_amount;
		this._amount = _amount;
		this._journal_batch_name = _journal_batch_name;
		this._initial_entry_global_dim1 = _initial_entry_global_dim1;
		this._description = _description;
	}

	public int get_entry_no() {
		return _entry_no;
	}

	public void set_entry_no(int _entry_no) {
		this._entry_no = _entry_no;
	}

	public String get_account_type() {
		return _account_type;
	}

	public void set_account_type(String _account_type) {
		this._account_type = _account_type;
	}

	public String get_date() {
		return _date;
	}

	public void set_date(String _date) {
		this._date = _date;
	}

	public String get_month() {
		return _month;
	}

	public void set_month(String _month) {
		this._month = _month;
	}

	public String get_year() {
		return _year;
	}

	public void set_year(String _year) {
		this._year = _year;
	}

	public double get_credit_amount() {
		return _credit_amount;
	}

	public void set_credit_amount(double _credit_amount) {
		this._credit_amount = _credit_amount;
	}

	public double get_debit_amount() {
		return _debit_amount;
	}

	public void set_debit_amount(double _debit_amount) {
		this._debit_amount = _debit_amount;
	}

	public double get_amount() {
		return _amount;
	}

	public void set_amount(double _amount) {
		this._amount = _amount;
	}

	public String get_journal_batch_name() {
		return _journal_batch_name;
	}

	public void set_journal_batch_name(String _journal_batch_name) {
		this._journal_batch_name = _journal_batch_name;
	}

	public String get_initial_entry_global_dim1() {
		return _initial_entry_global_dim1;
	}

	public void set_initial_entry_global_dim1(String _initial_entry_global_dim1) {
		this._initial_entry_global_dim1 = _initial_entry_global_dim1;
	}

	public String get_description() {
		return _description;
	}

	public void set_description(String _description) {
		this._description = _description;
	}
	
}
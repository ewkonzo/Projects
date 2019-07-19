package info.msacco.tabsswipe.adapter;

import info.msacco.actionbar.model.CustomerServiceInboxMessageModel;
import info.msacco.actionbar.model.MledgerDepWithdByAccTypeDataModel;
import info.msacco.actionbar.model.MledgerDepWithdByAccTypeDrillDownModel;
import info.msacco.actionbar.model.MledgerDepWithdByTimeDailyTransactionsDrillDownModel;
import info.msacco.actionbar.model.MledgerDepWithdByTimeDateDrillDownModel;
import info.msacco.actionbar.model.MledgerDepWithdByTimeMonthDrillDownModel;
import info.msacco.actionbar.model.MledgerDepWithdByTimeYearDataModel;
import info.msacco.actionbar.model.MledgerDepWithdByTransTypeDataModel;
import info.msacco.actionbar.model.MledgerDepWithdByTransTypeDrillDownModel;
import info.msacco.actionbar.model.MledgerDepWithdDatabaseModel;
import info.msacco.actionbar.model.MledgerReportsByTimeDataModel;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class MSACCOLocalDb extends SQLiteOpenHelper {

	// All Static variables
	// Database Version
	private static final int DATABASE_VERSION = 1;

	// Database Name
	private static final String DATABASE_NAME = "MSACCOAnalyticsDatabase";

	// Deposits and Withdrawals dataset table name
	private static final String TABLE_MLEDGER_DATASET = "mledgerDepWithdDataSet";

	// inbox table name
	private static final String TABLE_INBOX_MESSAGES = "inboxMessages";

	// Shares and deposits table.
	private static final String TABLE_SHARES = "shares";

	// Shares and deposits table.
	private static final String TABLE_DEPOSITS = "deposits";

	// Shares and deposits table.
	private static final String TABLE_MEMBER_INFO = "member_info";

	// Inbox table Column names
	private static final String INBOX_ENTRY_NO = "inbox_entry_no";
	private static final String INBOX_ENTRY_DATE = "inbox_entry_date";
	private static final String INBOX_HEADING = "inbox_heading";
	private static final String INBOX_MESSAGE = "inbox_message";

	// Member Info table Column names
	private static final String MEMEBR_INFO_ENTRY_NO = "member_id";
	private static final String MEMEBR_NO = "member_no";
	private static final String MEMEBR_INFO_NAME = "name";
	private static final String MEMEBR_IDNO = "idno";
	private static final String MEMEBR_INFO_GENDER = "gender";
	private static final String MEMEBR_INFO_ADDRESS = "address";
	private static final String MEMEBR_DATEOFBIRTH = "date_of_birth";
	private static final String MEMEBR_INFO_EMAIL = "email";
	private static final String MEMEBR_REGDATE = "reg_date";
	private static final String MEMEBR_EMPLOYER = "employer";
	private static final String MEMEBR_MOTHLYCONT = "monthly_contribution";

	// deposits Column names
	private static final String Shares_ENTRY_NO = "Shares_ENTRY_NO";
	private static final String Shares_POSTING_DATE = "Shares_POSTING_DATE";
	private static final String Shares_YEAR = "Shares_YEAR";
	private static final String Shares_MONTH = "Shares_MONTH";
	private static final String Shares_DESCRIPTION = "Shares_DESCRIPTION";
	private static final String Shares_AMOUNT = "amount";

	// Deposits
	// Shares Column names
	private static final String Deposits_ENTRY_NO = "Deposits_ENTRY_NO";
	private static final String Deposits_POSTING_DATE = "Deposits_POSTING_DATE";
	private static final String Deposits_YEAR = "Deposits_YEAR";
	private static final String Deposits_MONTH = "Deposits_MONTH";
	private static final String Deposits_DESCRIPTION = "Deposits_DESCRIPTION";
	private static final String Deposits_AMOUNT = "amount";

	private static final String KEY_ENTRY_NO = "entry_no";
	private static final String KEY_ACCOUNT_TYPE = "account_type";
	private static final String KEY_DATE = "date";
	private static final String KEY_MONTH = "month";
	private static final String KEY_YEAR = "year";
	private static final String KEY_CREDIT_AMOUNT = "credit_amount";
	private static final String KEY_DEBIT_AMOUNT = "debit_amount";
	private static final String KEY_AMOUNT = "amount";
	private static final String KEY_JOURNAL_BATCH_NAME = "journal_batch_name";
	private static final String KEY_INITIAL_ENTRY_GLOBAL_DIM1 = "initial_entry_global_dim1";
	private static final String KEY_DESCRIPTION = "description";

	public MSACCOLocalDb(Context context) {
		super(context, DATABASE_NAME, null, DATABASE_VERSION);
	}

	// Creating Table
	@Override
	public void onCreate(SQLiteDatabase db) {
		String CREATE_MLEDGER_DATA_SET_TABLE = "CREATE TABLE "
				+ TABLE_MLEDGER_DATASET + "(" + KEY_ENTRY_NO
				+ " INTEGER PRIMARY KEY, " + KEY_ACCOUNT_TYPE + " TEXT, "
				+ KEY_DATE + " TEXT, " + KEY_YEAR + " TEXT, " + KEY_MONTH
				+ " TEXT, " + KEY_CREDIT_AMOUNT + " REAL, " + KEY_DEBIT_AMOUNT
				+ " REAL, " + KEY_AMOUNT + " REAL, " + KEY_JOURNAL_BATCH_NAME
				+ " TEXT, " + KEY_INITIAL_ENTRY_GLOBAL_DIM1 + " TEXT, "
				+ KEY_DESCRIPTION + " TEXT" + ")";

		String CREATE_INBOX_MESSAGES_TABLE = "CREATE TABLE "
				+ TABLE_INBOX_MESSAGES + "(" + INBOX_ENTRY_NO
				+ " INTEGER PRIMARY KEY, " + INBOX_ENTRY_DATE + " TEXT, "
				+ INBOX_HEADING + " TEXT, " + INBOX_MESSAGE + " TEXT" + ")";

		String CREATE_SHARES_TABLE = "CREATE TABLE " + TABLE_SHARES + "("
				+ Shares_ENTRY_NO + " INTEGER PRIMARY KEY, "
				+ Shares_POSTING_DATE + " TEXT, " + Shares_YEAR + " TEXT, "
				+ Shares_MONTH + " TEXT, " + Shares_DESCRIPTION + " TEXT, "
				+ Shares_AMOUNT + " REAL" + ")";

		String CREATE_DEPOSITS_TABLE = "CREATE TABLE " + TABLE_DEPOSITS + "("
				+ Deposits_ENTRY_NO + " INTEGER PRIMARY KEY, "
				+ Deposits_POSTING_DATE + " TEXT, " + Deposits_YEAR + " TEXT, "
				+ Deposits_MONTH + " TEXT, " + Deposits_DESCRIPTION + " TEXT, "
				+ Deposits_AMOUNT + " REAL" + ")";

		String CREATE_MEMBER_INFO_TABLE = "CREATE TABLE " + TABLE_MEMBER_INFO
				+ "(" + MEMEBR_INFO_ENTRY_NO + " TEXT PRIMARY KEY, "
				+ MEMEBR_NO + " TEXT, " + MEMEBR_INFO_NAME + " TEXT, "
				+ MEMEBR_IDNO + " TEXT, " + MEMEBR_INFO_GENDER + " TEXT, "
				+ MEMEBR_INFO_ADDRESS + " TEXT, " + MEMEBR_DATEOFBIRTH
				+ " TEXT, " + MEMEBR_INFO_EMAIL + " TEXT, " + MEMEBR_REGDATE
				+ " TEXT, " + MEMEBR_EMPLOYER + " TEXT," + MEMEBR_MOTHLYCONT
				+ " TEXT" + ")";

		// Execute Query
		db.execSQL(CREATE_SHARES_TABLE);
		db.execSQL(CREATE_INBOX_MESSAGES_TABLE);
		db.execSQL(CREATE_MLEDGER_DATA_SET_TABLE);
		db.execSQL(CREATE_DEPOSITS_TABLE);
		db.execSQL(CREATE_MEMBER_INFO_TABLE);
	}

	// Upgrading database
	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
		// Drop older table if existed
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_MLEDGER_DATASET);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_INBOX_MESSAGES);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_SHARES);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_DEPOSITS);
		db.execSQL("DROP TABLE IF EXISTS " + TABLE_MEMBER_INFO);

		// Create tables again
		onCreate(db);
	}

	/**
	 * All CRUD(Create, Read, Update, Delete) Operations
	 */

	// Insert member Info.
	public void addMemberInfoFromServer(List<String> meminfo) {
		SQLiteDatabase db = this.getWritableDatabase();

		ContentValues values = new ContentValues();

		values.put(MEMEBR_INFO_ENTRY_NO, meminfo.get(0));
		values.put(MEMEBR_NO, meminfo.get(0));
		values.put(MEMEBR_INFO_NAME, meminfo.get(1));
		values.put(MEMEBR_IDNO, meminfo.get(2));
		values.put(MEMEBR_INFO_GENDER, meminfo.get(3));
		values.put(MEMEBR_INFO_ADDRESS, meminfo.get(4));
		values.put(MEMEBR_DATEOFBIRTH, meminfo.get(5));
		values.put(MEMEBR_INFO_EMAIL, meminfo.get(6));
		values.put(MEMEBR_REGDATE, meminfo.get(7));
		values.put(MEMEBR_EMPLOYER, meminfo.get(8));
		values.put(MEMEBR_MOTHLYCONT, meminfo.get(9));

		// Inserting Row
		db.insertWithOnConflict(TABLE_MEMBER_INFO, null, values,
				SQLiteDatabase.CONFLICT_REPLACE);
		db.close(); // Closing database connection
	}

	// Insert messages from Server
	public void addMessagesFromServer(CustomerServiceInboxMessageModel dataModel) {
		SQLiteDatabase db = this.getWritableDatabase();

		ContentValues values = new ContentValues();

		values.put(INBOX_ENTRY_NO, dataModel.get_entryNo());
		values.put(INBOX_ENTRY_DATE, dataModel.get_entryDate());
		values.put(INBOX_HEADING, dataModel.get_messageHeading());
		values.put(INBOX_MESSAGE, dataModel.get_message());

		// Inserting Row
		db.insertWithOnConflict(TABLE_INBOX_MESSAGES, null, values,
				SQLiteDatabase.CONFLICT_REPLACE);
		db.close(); // Closing database connection
	}

	// Get member information.
	public List<String> getMemberInfo() {
		List<String> memInfoList = new ArrayList<String>();

		// query for info
		String memInfoQuery = "SELECT " + MEMEBR_NO + ", " + MEMEBR_INFO_NAME
				+ ", " + MEMEBR_IDNO + ", " + MEMEBR_INFO_GENDER + ", "
				+ MEMEBR_INFO_ADDRESS + ", " + MEMEBR_DATEOFBIRTH + ", "
				+ MEMEBR_INFO_EMAIL + "," + MEMEBR_REGDATE + ","
				+ MEMEBR_EMPLOYER + "," + MEMEBR_MOTHLYCONT + " FROM "
				+ TABLE_MEMBER_INFO;

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(memInfoQuery, null);

		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				for (int i = 0; i < cursor.getColumnCount(); i++) {
					// Adding item to list
					memInfoList.add(cursor.getString(i));
				}

			} while (cursor.moveToNext());
		}
		cursor.close();
		db.close();
		// return row
		return memInfoList;
	}

	// RETRIEVE INBOX MESSAGES
	public List<CustomerServiceInboxMessageModel> retrieveInboxMessages() {
		List<CustomerServiceInboxMessageModel> messagesList = new ArrayList<CustomerServiceInboxMessageModel>();

		// query for messages.
		String messagesQuery = "SELECT " + INBOX_ENTRY_NO + ", "
				+ INBOX_ENTRY_DATE + " ," + INBOX_HEADING + ", "
				+ INBOX_MESSAGE + " FROM " + TABLE_INBOX_MESSAGES
				+ " ORDER BY " + INBOX_ENTRY_NO;

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(messagesQuery, null);

		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				CustomerServiceInboxMessageModel dModel = new CustomerServiceInboxMessageModel();
				dModel.set_entryDate(cursor.getString(1));
				dModel.set_messageHeading(cursor.getString(2));
				dModel.set_message(cursor.getString(3));

				// Adding row to list
				messagesList.add(dModel);
			} while (cursor.moveToNext());
		}
		cursor.close();
		db.close();
		// return row
		return messagesList;
	}

	/*
	 * // Insert Shares from Server public void
	 * insertShares(MyAccSharesDepositsModel dataModel) { SQLiteDatabase db =
	 * this.getWritableDatabase();
	 * 
	 * ContentValues values = new ContentValues();
	 * 
	 * values.put(Shares_ENTRY_NO, dataModel.get_entry_no());
	 * values.put(Shares_POSTING_DATE, dataModel.get_posting_date());
	 * values.put(Shares_YEAR, dataModel.get_year()); values.put(Shares_MONTH,
	 * dataModel.get_month()); values.put(Shares_DESCRIPTION,
	 * dataModel.get_description()); values.put(Shares_AMOUNT,
	 * dataModel.get_amount());
	 * 
	 * // Inserting Row db.insertWithOnConflict(TABLE_SHARES, null, values,
	 * SQLiteDatabase.CONFLICT_REPLACE); db.close(); // Closing database
	 * connection }
	 * 
	 * // Insert Shares and deposits from Server public void
	 * insertDeposits(MyAccSharesDepositsModel dataModel) {
	 *//*
		 * SQLiteDatabase db = this.getWritableDatabase();
		 * 
		 * ContentValues values = new ContentValues();
		 * 
		 * values.put(Deposits_ENTRY_NO, dataModel.get_entry_no());
		 * values.put(Deposits_POSTING_DATE, dataModel.get_posting_date());
		 * values.put(Deposits_YEAR, dataModel.get_year());
		 * values.put(Deposits_MONTH, dataModel.get_month());
		 * values.put(Deposits_DESCRIPTION, dataModel.get_description());
		 * values.put(Deposits_AMOUNT, dataModel.get_amount());
		 * 
		 * // Inserting Row db.insertWithOnConflict(TABLE_DEPOSITS, null,
		 * values, SQLiteDatabase.CONFLICT_REPLACE); db.close(); // Closing
		 * database connection }
		 */

	public void deleteOldData() {
		SQLiteDatabase db = this.getWritableDatabase();
		SimpleDateFormat dateformat = new SimpleDateFormat("MM/dd/yy");

		Calendar cal = Calendar.getInstance();
		cal.add(Calendar.MONTH, -3);
		String query = "SELECT " + KEY_DATE + ", " + KEY_ENTRY_NO + " FROM "
				+ TABLE_MLEDGER_DATASET;
		Cursor cursor = db.rawQuery(query, null);

		Date datestored = new Date();
		Date datetoCompare = new Date();
		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				try {

					datestored = dateformat.parse((cursor.getString(0)));
					datetoCompare = dateformat.parse(dateformat.format(cal
							.getTime()));
					if (datestored.before(datetoCompare)) {
						db.delete(TABLE_MLEDGER_DATASET, KEY_ENTRY_NO + " = ?",
								new String[] { cursor.getString(1) });
					}
				} catch (Exception e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			} while (cursor.moveToNext());
		}
		String querafter = "SELECT " + KEY_DATE + " FROM "
				+ TABLE_MLEDGER_DATASET;
		Cursor cur = db.rawQuery(querafter, null);
		cursor.close();
		db.close();
	}

	public void deleteOldMessages() {
		SQLiteDatabase db = this.getWritableDatabase();
		SimpleDateFormat dateformat = new SimpleDateFormat("MM/dd/yy");

		Calendar cal = Calendar.getInstance();
		cal.add(Calendar.MONTH, -6);
		String query = "SELECT " + INBOX_ENTRY_DATE + ", " + INBOX_ENTRY_NO
				+ " FROM " + TABLE_INBOX_MESSAGES;
		Cursor cursor = db.rawQuery(query, null);

		Date datestored = new Date();
		Date datetoCompare = new Date();
		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				try {

					datestored = dateformat.parse((cursor.getString(0)));
					datetoCompare = dateformat.parse(dateformat.format(cal
							.getTime()));

					if (datestored.before(datetoCompare)) {
						db.delete(TABLE_INBOX_MESSAGES,
								INBOX_ENTRY_NO + " = ?",
								new String[] { cursor.getString(1) });
					}
				} catch (Exception e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			} while (cursor.moveToNext());
		}
		String querafter = "SELECT " + INBOX_ENTRY_DATE + " FROM "
				+ TABLE_INBOX_MESSAGES;
		Cursor cur = db.rawQuery(querafter, null);
		cursor.close();
		db.close();
	}

	// Insert dashBoard data from Server
	public void addDashBoardDataFromWebService(
			MledgerDepWithdDatabaseModel dataModel) {
		SQLiteDatabase db = this.getWritableDatabase();

		ContentValues values = new ContentValues();
		values.put(KEY_ENTRY_NO, dataModel.get_entry_no());
		values.put(KEY_ACCOUNT_TYPE, dataModel.get_account_type());
		values.put(KEY_DATE, dataModel.get_date());
		values.put(KEY_YEAR, dataModel.get_year());
		values.put(KEY_MONTH, dataModel.get_month());
		values.put(KEY_CREDIT_AMOUNT, dataModel.get_credit_amount());
		values.put(KEY_DEBIT_AMOUNT, dataModel.get_debit_amount());
		values.put(KEY_AMOUNT, dataModel.get_amount());
		values.put(KEY_JOURNAL_BATCH_NAME, dataModel.get_journal_batch_name());
		values.put(KEY_INITIAL_ENTRY_GLOBAL_DIM1,
				dataModel.get_initial_entry_global_dim1());
		values.put(KEY_DESCRIPTION, dataModel.get_description());

		// Inserting Row
		db.insertWithOnConflict(TABLE_MLEDGER_DATASET, null, values,
				SQLiteDatabase.CONFLICT_REPLACE);
		db.close(); // Closing database connection
	}

	// GET DEPOSITS AND WITHDRAWAL DATA ACCORDING TO ACCOUNT TYPE
	public List<MledgerDepWithdByAccTypeDataModel> getDepositAndWithdByAccType() {
		List<MledgerDepWithdByAccTypeDataModel> depwithdByAccTypeList = new ArrayList<MledgerDepWithdByAccTypeDataModel>();

		// Select deposits and withdrawals by account type Query
		String selectbyAccTypeQuery = "SELECT  " + KEY_ACCOUNT_TYPE + " , SUM("
				+ KEY_CREDIT_AMOUNT + ") AS Deposits," + " SUM("
				+ KEY_DEBIT_AMOUNT + ") AS Withdrawals FROM "
				+ TABLE_MLEDGER_DATASET + " GROUP BY " + KEY_ACCOUNT_TYPE
				+ " ORDER BY " + KEY_ACCOUNT_TYPE;

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(selectbyAccTypeQuery, null);

		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				MledgerDepWithdByAccTypeDataModel depWithdDmodel = new MledgerDepWithdByAccTypeDataModel();

				depWithdDmodel.setAcc_type(cursor.getString(0));
				depWithdDmodel.setDeposits(Double.parseDouble(cursor
						.getString(1)));
				depWithdDmodel.setWithdrawals(Double.parseDouble(cursor
						.getString(2)));

				// Adding row to list
				depwithdByAccTypeList.add(depWithdDmodel);
			} while (cursor.moveToNext());
		}
		cursor.close();
		db.close();
		// return row
		return depwithdByAccTypeList;
	}

	// DRILL DOWN ACCORDING TO ACCOUNT TYPE
	public List<MledgerDepWithdByAccTypeDrillDownModel> getDepositAndWithdDrillDownData(
			String account_type) {
		List<MledgerDepWithdByAccTypeDrillDownModel> depwithdByAccTypeDrillDownList = new ArrayList<MledgerDepWithdByAccTypeDrillDownModel>();

		// Select deposits and withdrawals by account type Query
		String selectdrillDownQuery = "SELECT " + KEY_DATE + ", " + ""
				+ KEY_CREDIT_AMOUNT + " AS Deposit, " + KEY_DEBIT_AMOUNT + ""
				+ " AS Withdrawal, " + KEY_DESCRIPTION + " FROM "
				+ TABLE_MLEDGER_DATASET + " WHERE " + KEY_ACCOUNT_TYPE + "= '"
				+ account_type + "' ORDER BY " + KEY_DATE + " DESC";

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(selectdrillDownQuery, null);

		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				MledgerDepWithdByAccTypeDrillDownModel drillDmodel = new MledgerDepWithdByAccTypeDrillDownModel();

				drillDmodel.set_posting_date(cursor.getString(0));
				drillDmodel
						.set_deposit(Double.parseDouble(cursor.getString(1)));
				drillDmodel.set_withdrawal(Double.parseDouble(cursor
						.getString(2)));
				drillDmodel.set_description(cursor.getString(3));

				// Adding row to list
				depwithdByAccTypeDrillDownList.add(drillDmodel);
			} while (cursor.moveToNext());
		}
		cursor.close();
		db.close();
		// return row
		return depwithdByAccTypeDrillDownList;
	}

	// Updated 29/10/2015-return transaction months
	public List<MledgerReportsByTimeDataModel> getDepAndWithdByMonth() {
		List<MledgerReportsByTimeDataModel> depwithdByTimeDrillDownList = new ArrayList<MledgerReportsByTimeDataModel>();

		// Select deposits and withdrawals by account time Query
		String selectdrillDownQuery = "SELECT " + KEY_MONTH + " , SUM("
				+ KEY_CREDIT_AMOUNT + " ) AS Deposits, SUM(" + KEY_DEBIT_AMOUNT
				+ ") AS Withdrawals FROM " + TABLE_MLEDGER_DATASET
				+ " GROUP BY " + KEY_MONTH + " ORDER BY " + KEY_MONTH + " ASC";

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(selectdrillDownQuery, null);

		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				MledgerReportsByTimeDataModel drillDmodel = new MledgerReportsByTimeDataModel();

				drillDmodel.set_month(cursor.getString(0));
				drillDmodel
						.set_deposits(Double.parseDouble(cursor.getString(1)));
				drillDmodel.set_withdrawals(Double.parseDouble(cursor
						.getString(2)));

				// Adding row to list
				depwithdByTimeDrillDownList.add(drillDmodel);
			} while (cursor.moveToNext());
		}
		cursor.close();
		db.close();
		// return row
		return depwithdByTimeDrillDownList;
	}

	// DEPOSITS AND WITHDRAWALS ACCORDING TO YEAR
	public List<MledgerDepWithdByTimeYearDataModel> getDepositAndWithdByYear() {
		List<MledgerDepWithdByTimeYearDataModel> depwithdByYearList = new ArrayList<MledgerDepWithdByTimeYearDataModel>();

		// Select deposits and withdrawals by account type Query

		String selectbyYearQuery = "SELECT " + KEY_YEAR + ", SUM("
				+ KEY_CREDIT_AMOUNT + ") AS Deposits," + " SUM("
				+ KEY_DEBIT_AMOUNT + ") AS Withdrawals FROM "
				+ TABLE_MLEDGER_DATASET + " GROUP BY " + KEY_YEAR
				+ " ORDER BY " + KEY_YEAR + " DESC";

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(selectbyYearQuery, null);

		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				MledgerDepWithdByTimeYearDataModel depWithdDmodel = new MledgerDepWithdByTimeYearDataModel();

				depWithdDmodel.set_year(cursor.getString(0));
				depWithdDmodel.setDeposits(Double.parseDouble(cursor
						.getString(1)));
				depWithdDmodel.setWithdrawals(Double.parseDouble(cursor
						.getString(2)));

				// Adding row to list
				depwithdByYearList.add(depWithdDmodel);
			} while (cursor.moveToNext());
		}
		cursor.close();
		db.close();
		// return row
		return depwithdByYearList;
	}

	// DRILL DOWN DEPOSITS AND WITHDRAWALS ON YEAR TO SHOW MONTHS
	public List<MledgerDepWithdByTimeMonthDrillDownModel> getDepAndWithdDrillDownDataByMonth(
			String _year) {
		List<MledgerDepWithdByTimeMonthDrillDownModel> depwithdByTimeDrillDownList = new ArrayList<MledgerDepWithdByTimeMonthDrillDownModel>();

		// Select deposits and withdrawals by account time Query
		String selectdrillDownQuery = "SELECT " + KEY_MONTH + " , SUM( " + ""
				+ KEY_CREDIT_AMOUNT + " ) AS Deposits, SUM(" + KEY_DEBIT_AMOUNT
				+ ") AS Withdrawals FROM " + TABLE_MLEDGER_DATASET + " WHERE "
				+ KEY_YEAR + " = '" + _year
				+ "' GROUP BY Month ORDER BY Month DESC";

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(selectdrillDownQuery, null);

		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				MledgerDepWithdByTimeMonthDrillDownModel drillDmodel = new MledgerDepWithdByTimeMonthDrillDownModel();

				drillDmodel.set_month(cursor.getString(0));
				drillDmodel
						.set_deposit(Double.parseDouble(cursor.getString(1)));
				drillDmodel.set_withdrawal(Double.parseDouble(cursor
						.getString(2)));

				// Adding row to list
				depwithdByTimeDrillDownList.add(drillDmodel);
			} while (cursor.moveToNext());
		}
		cursor.close();
		db.close();
		// return row
		return depwithdByTimeDrillDownList;
	}

	// DRILL DOWN DEPOSITS AND WITHDRAWALS ON YEAR TO SHOW MONTHS FOR GRAPH
	public List<MledgerDepWithdByTimeMonthDrillDownModel> getDepAndWithdDrillDownByMonthGraphData() {
		List<MledgerDepWithdByTimeMonthDrillDownModel> depwithdByTimeDrillDownList = new ArrayList<MledgerDepWithdByTimeMonthDrillDownModel>();

		// Select deposits and withdrawals by account time Query
		String selectdrillDownQuery = "SELECT " + KEY_MONTH + " , SUM( " + ""
				+ KEY_CREDIT_AMOUNT + " ) AS Deposits, SUM(" + KEY_DEBIT_AMOUNT
				+ ") AS Withdrawals FROM " + TABLE_MLEDGER_DATASET;

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(selectdrillDownQuery, null);

		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				MledgerDepWithdByTimeMonthDrillDownModel drillDmodel = new MledgerDepWithdByTimeMonthDrillDownModel();

				try {
					drillDmodel.set_month(cursor.getString(0));
					drillDmodel.set_deposit(Double.parseDouble(cursor
							.getString(1)));
					drillDmodel.set_withdrawal(Double.parseDouble(cursor
							.getString(2)));
				} catch (NumberFormatException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}

				// Adding row to list
				depwithdByTimeDrillDownList.add(drillDmodel);
			} while (cursor.moveToNext());
		}
		cursor.close();
		db.close();
		// return row
		return depwithdByTimeDrillDownList;
	}

	// DRILL DOWN DEPOSITS AND WITHDRAWALS ON MONTH TO SHOW DATES
	public List<MledgerDepWithdByTimeDateDrillDownModel> getDepAndWithdDrillDownDataByTimeDayOfMonth(
			String _month) {
		List<MledgerDepWithdByTimeDateDrillDownModel> depwithdByTimeDrillDownList = new ArrayList<MledgerDepWithdByTimeDateDrillDownModel>();

		// Select deposits and withdrawals by account time Query
		String selectdrillDownQuery = "SELECT " + KEY_DATE + ", SUM("
				+ KEY_CREDIT_AMOUNT + ")" + " AS Deposits, SUM("
				+ KEY_DEBIT_AMOUNT + ") AS Withdrawals " + "FROM "
				+ TABLE_MLEDGER_DATASET + " WHERE "
				+ KEY_MONTH + " = '" + _month + "' GROUP BY "
				+ KEY_DATE + " ," + KEY_DATE + " ORDER BY " + KEY_DATE
				+ " DESC";

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(selectdrillDownQuery, null);

		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				MledgerDepWithdByTimeDateDrillDownModel drillDmodel = new MledgerDepWithdByTimeDateDrillDownModel();

				drillDmodel.set_date(cursor.getString(0));
				drillDmodel
						.set_deposit(Double.parseDouble(cursor.getString(1)));
				drillDmodel.set_withdrawal(Double.parseDouble(cursor
						.getString(2)));

				// Adding row to list
				depwithdByTimeDrillDownList.add(drillDmodel);
			} while (cursor.moveToNext());
		}
		cursor.close();
		db.close();
		// return row
		return depwithdByTimeDrillDownList;
	}

	// DRILL DOWN DEPOSITS AND WITHDRAWALS ON DATE TO SHOW INDIVIDUAL
	// TRANSACTIONS FOR THAT DATE
	public List<MledgerDepWithdByTimeDailyTransactionsDrillDownModel> getDepAndWithdDrillDownDataByTimeDailyTransactions(
			String _month, String _day) {
		List<MledgerDepWithdByTimeDailyTransactionsDrillDownModel> depwithdByTimeDrillDownList = new ArrayList<MledgerDepWithdByTimeDailyTransactionsDrillDownModel>();

		// Select deposits and withdrawals by account time Query
		String selectdrillDownQuery = "SELECT " + KEY_DATE + " , "
				+ KEY_CREDIT_AMOUNT + " AS Deposits," + " " + KEY_DEBIT_AMOUNT
				+ " AS Withdrawals, " + KEY_DESCRIPTION + "  FROM  "
				+ TABLE_MLEDGER_DATASET + "  WHERE "
				+ KEY_MONTH + " = '" + _month + "' AND "
				+ KEY_DATE + "  = '" + _day + "' ORDER BY " + KEY_DATE
				+ " DESC";

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(selectdrillDownQuery, null);

		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				MledgerDepWithdByTimeDailyTransactionsDrillDownModel drillDmodel = new MledgerDepWithdByTimeDailyTransactionsDrillDownModel();

				drillDmodel.set_date(cursor.getString(0));
				drillDmodel
						.set_deposit(Double.parseDouble(cursor.getString(1)));
				drillDmodel.set_withdrawal(Double.parseDouble(cursor
						.getString(2)));
				drillDmodel.set_description(cursor.getString(3));

				// Adding row to list
				depwithdByTimeDrillDownList.add(drillDmodel);
			} while (cursor.moveToNext());
		}
		cursor.close();
		db.close();
		// return row
		return depwithdByTimeDrillDownList;
	}

	// DEPOSITS AND WITHDRAWALS ACCORDING TO JOURNAL BATCH
	public List<MledgerDepWithdByTransTypeDataModel> getDepositAndWithdByJBatch() {
		List<MledgerDepWithdByTransTypeDataModel> depwithdByJBatchList = new ArrayList<MledgerDepWithdByTransTypeDataModel>();

		// Select deposits and withdrawals by account type Query

		String selectbyJbatchQuery = "SELECT " + KEY_JOURNAL_BATCH_NAME
				+ ", SUM(" + KEY_CREDIT_AMOUNT + ") AS Deposits," + " SUM("
				+ KEY_DEBIT_AMOUNT + ") AS Withdrawals FROM "
				+ TABLE_MLEDGER_DATASET + " GROUP BY " + KEY_JOURNAL_BATCH_NAME
				+ " ORDER BY " + KEY_JOURNAL_BATCH_NAME + "";

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(selectbyJbatchQuery, null);

		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				MledgerDepWithdByTransTypeDataModel depWithdDmodel = new MledgerDepWithdByTransTypeDataModel();

				depWithdDmodel.set_trans_type(cursor.getString(0));
				depWithdDmodel.set_deposits(Double.parseDouble(cursor
						.getString(1)));
				depWithdDmodel.set_withdrawals(Double.parseDouble(cursor
						.getString(2)));

				// Adding row to list
				depwithdByJBatchList.add(depWithdDmodel);
			} while (cursor.moveToNext());
		}
		cursor.close();
		db.close();
		// return row
		return depwithdByJBatchList;
	}

	// DRILL DOWN ACCORDING TO JOURNAL BATCH
	public List<MledgerDepWithdByTransTypeDrillDownModel> getDepositAndWithdDrillDownByJBatch(
			String batchName) {
		List<MledgerDepWithdByTransTypeDrillDownModel> depwithdDrillDownByJBatchList = new ArrayList<MledgerDepWithdByTransTypeDrillDownModel>();

		// Select deposits and withdrawals by account type Query

		String selectDrillDownbyJbatchQuery = "SELECT " + KEY_DATE + ", "
				+ KEY_CREDIT_AMOUNT + " AS Deposits," + " " + KEY_DEBIT_AMOUNT
				+ " AS Withdrawals , " + KEY_DESCRIPTION + " FROM "
				+ TABLE_MLEDGER_DATASET + " WHERE " + KEY_JOURNAL_BATCH_NAME
				+ " = '" + batchName + "' " + " ORDER BY " + KEY_DATE + " DESC";

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(selectDrillDownbyJbatchQuery, null);

		// adding row to list
		if (cursor.moveToFirst()) {
			do {
				MledgerDepWithdByTransTypeDrillDownModel depWithdDmodel = new MledgerDepWithdByTransTypeDrillDownModel();

				depWithdDmodel.set_posting_date(cursor.getString(0));
				depWithdDmodel.set_deposit(Double.parseDouble(cursor
						.getString(1)));
				depWithdDmodel.set_withdrawal(Double.parseDouble(cursor
						.getString(2)));
				depWithdDmodel.set_description(cursor.getString(3));

				// Adding row to list
				depwithdDrillDownByJBatchList.add(depWithdDmodel);
			} while (cursor.moveToNext());
		}

		cursor.close();
		db.close();
		// return row
		return depwithdDrillDownByJBatchList;
	}

	// Get Mledger Last Entry.
	public int getMledgerLastEntry() {
		int latest_transaction = 0;

		// query for info
		String lastEntryQuery = "SELECT MAX(" + KEY_ENTRY_NO + ") FROM "
				+ TABLE_MLEDGER_DATASET + ";";

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(lastEntryQuery, null);
		if (cursor != null) {
			cursor.moveToFirst();
			if (cursor.getString(0) != null) {
				latest_transaction = Integer.parseInt(cursor.getString(0));
			}
		}

		cursor.close();
		db.close();
		// return row
		return latest_transaction;
	}

	// Get Inbox Last Entry.
	public int getInboxLastEntry() {
		int last_entry = 0;

		// query for info
		String lastEntryQuery = "SELECT MAX(" + INBOX_ENTRY_NO + ") FROM "
				+ TABLE_INBOX_MESSAGES + ";";

		SQLiteDatabase db = this.getWritableDatabase();
		Cursor cursor = db.rawQuery(lastEntryQuery, null);

		if (cursor != null) {
			cursor.moveToFirst();
			if (cursor.getString(0) != null) {
				last_entry = Integer.parseInt(cursor.getString(0));
			}
		}

		cursor.close();
		db.close();
		// return row
		return last_entry;
	}
}

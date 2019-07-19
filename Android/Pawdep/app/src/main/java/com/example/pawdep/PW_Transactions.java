package com.example.pawdep;

import java.util.List;

import androidx.annotation.NonNull;
import androidx.lifecycle.LiveData;
import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Entity;
import androidx.room.Insert;
import androidx.room.OnConflictStrategy;
import androidx.room.PrimaryKey;
import androidx.room.Query;
import androidx.room.Update;

@Entity
public class PW_Transactions {
    @PrimaryKey(autoGenerate = true)
    @NonNull
    public int No;
    public String Key;
    public String Transaction_No;
    public String Group_Code;
    public String Member_No;
    public String Member_Name;
    public static Transaction_Type Transaction_Type;
    public boolean Transaction_TypeSpecified;
    public Double Amount;
    public boolean AmountSpecified;
    public String Description;
    public String G_L_Account;
    public String Bank_Account;
    public String Comments;
    public boolean NoSpecified;
    public String Branch_Code;
    public String Pawdep_No;


    public enum Transaction_Type {

        /// <remarks/>
        _blank_(0),

        /// <remarks/>
        Loan(1),

        /// <remarks/>
        Repayment(2),

        /// <remarks/>
        Member_Deposit(3),

        /// <remarks/>
        Share_Capital(4),

        /// <remarks/>
        Benevolent_Fund(5),

        /// <remarks/>
        Application_Fee(6),

        /// <remarks/>
        Interest_Due(7),

        /// <remarks/>
        Interest_Paid(8),

        /// <remarks/>
        Chattel(9),

        /// <remarks/>
        Assessment_Fee(10),

        /// <remarks/>
        Pass_Book(11),

        /// <remarks/>
        Fines(12),

        /// <remarks/>
        Processing_Fee(13),

        /// <remarks/>
        Registration_Fee(14),
        /// <remarks/>
        Risk_Fund(15),

        /// <remarks/>
        Penalty(16),

        /// <remarks/>
        Group_Savings(17),

        /// <remarks/>
        Transfer_Fee(18),

        /// <remarks/>
        Forms(19),

        /// <remarks/>
        Hall_Fee(20);
        private int code;

        Transaction_Type(int code) {
            this.code = code;
        }

        public int getCode() {
            return code;
        }

        }

    @Dao
    public interface dao extends Basedao {
        @Insert(onConflict = OnConflictStrategy.REPLACE)
        long Insert(PW_Transactions t);
        @Update
        void Update(PW_Transactions t);
        @Delete
        void delete(PW_Transactions t);
        @Query("SELECT * FROM PW_Transactions")
        LiveData<List<PW_Transactions>> getAll();
    }
}

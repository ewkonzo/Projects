package com.example.pawdep;

import java.sql.Date;
import java.util.List;

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
public  class  Advance_issue
{

    public String Key;
    @PrimaryKey(autoGenerate = true)
    public int No ;
    public String Transaction_No;
    public String Adv_Loan_No;
    public String Member_No;
    public String Member_Name;
    public Double Amount;
    public boolean AmountSpecified;
    public Double Instalments;
    public boolean InstalmentsSpecified;
    public String Group_Code;
    public String Group_Name;

    public boolean NoSpecified;
    public Double Advance_Fees;
    public boolean Advance_FeesSpecified;
    public Double Loan_Aplication_Fee;
    public boolean Loan_Aplication_FeeSpecified;
    public String Loan_Code;
    public String Member_ID;
    public Date Loan_Disbursement_Date;
    public boolean Loan_Disbursement_DateSpecified;
    public Double Interest;
    public boolean InterestSpecified;
    public Double Advance_Balance;
    public boolean Advance_BalanceSpecified;
    public String Loan_Type;
    public String Pawdep_No;
    public String Branch_Code;
    @Dao
    public interface dao extends Basedao {
        @Insert(onConflict = OnConflictStrategy.REPLACE)
        long Insert(Advance_issue t);
        @Update
        void Update(Advance_issue t);
        @Delete
        void delete(Advance_issue t);
        @Query("SELECT * FROM advance_issue")
        LiveData<List<Advance_issue>> getAll();
    }
}

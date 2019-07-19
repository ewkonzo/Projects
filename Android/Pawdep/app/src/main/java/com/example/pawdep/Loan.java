package com.example.pawdep;

import java.util.List;

import androidx.annotation.NonNull;
import androidx.lifecycle.LiveData;
import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Entity;
import androidx.room.Ignore;
import androidx.room.Insert;
import androidx.room.OnConflictStrategy;
import androidx.room.PrimaryKey;
import androidx.room.Query;
import androidx.room.Update;

@Entity
public class Loan {
  @Ignore
    public String Key;
    @PrimaryKey
    @NonNull
    public String Loan_No;
    public String Member_No;
    public String Member_Name;
    public String ID_No;
    public int Loan_Status;
    public int Installments;
    public String Date_Approved;
    public String Disbursement_Date;
    public int Mode_of_Disbursement;
    public float Repayment;
    public float Outstanding_Balance;
    public String Group_No;
    public String Loan_Type;
    public double PAWDEP_Schedule_Repayment;
    public double PAWDEP_Schedule_Interest;
    public double Interest_Paid;
    public double Current_Repayments;
    @Dao
    public interface dao {
        @Insert(onConflict = OnConflictStrategy.REPLACE)
        long  Insert(Loan t) ;
        @Update
        void Update(Loan t);
        @Delete
        void delete(Loan t);
        @Query("SELECT * FROM `Loan`")
        List<Loan> getAll();
        @Query("SELECT * FROM `Loan` where Member_No =:No and Loan_Type <> 'HARAKA'")
        List<Loan> memberloansnonharaka(String No);
        @Query("SELECT * FROM `Loan` where Member_No =:No and Loan_Type = 'HARAKA'")
        List<Loan> memberloansharaka(String No);
    }

}

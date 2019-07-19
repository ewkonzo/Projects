package com.example.pawdep;

import java.io.Serializable;
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
    public class Advance implements Serializable {
    @NonNull
    @PrimaryKey(autoGenerate = true)
    public int No;
    public String Key;
    public String Transaction_No;
    public String Date;
    public boolean DateSpecified;
    public String Member_No;
    public String Member_Name;
    public Double Amount_Total;
    public boolean Amount_TotalSpecified;
    public Double Expected_Interest;
    public boolean Expected_InterestSpecified;
    public String Loan_No;
    public Double Expected_Repayment;
    public boolean Expected_RepaymentSpecified;
    public String Group_Code;
    public boolean NoSpecified;
    public Double Principle_Paid;
    public boolean Principle_PaidSpecified;
    public Double Interest_Paid;
    public boolean Interest_PaidSpecified;
    public String Branch_Code;
    public String Pawdep_No;

    @Dao
    public interface dao extends Basedao {
        @Insert(onConflict = OnConflictStrategy.REPLACE)
        long Insert(Advance t);
        @Update
        void Update(Advance t);
        @Delete
        void delete(Advance t);
        @Query("SELECT * FROM Advance")
        LiveData<List<Advance>> getAll();
    }
}

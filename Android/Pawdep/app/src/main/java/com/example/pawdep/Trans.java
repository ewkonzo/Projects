package com.example.pawdep;


import android.app.Application;
import android.os.AsyncTask;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.pawdep.databinding.Grouplist;
import com.google.android.material.floatingactionbutton.FloatingActionButton;


import androidx.databinding.DataBindingUtil;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.LiveData;
import androidx.recyclerview.widget.RecyclerView;
import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Entity;
import androidx.room.Ignore;
import androidx.room.Insert;
import androidx.room.OnConflictStrategy;
import androidx.room.PrimaryKey;
import androidx.annotation.NonNull;
import androidx.room.Query;
import androidx.room.Update;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Paul on 09-Dec-16.
 */


@Entity(tableName = "Trans Header")
public class Trans implements Serializable {
    public void setDescription(String description) {
        Description = description;
    }

    public void setGroup_Code(String group_Code) {
        Group_Code = group_Code;
    }

    public void setGroup_Name(String group_Name) {
        Group_Name = group_Name;
    }

    public void setProject(String project) {
        Project = project;
    }

    public void setDate(String date) {
        Date = date;
    }

    public void setDateSpecified(boolean dateSpecified) {
        DateSpecified = dateSpecified;
    }

    public void setReceipt_No(String receipt_No) {
        Receipt_No = receipt_No;
    }

    public void setBranch_Code(String branch_Code) {
        Branch_Code = branch_Code;
    }

    public void setBranch_Name(String branch_Name) {
        Branch_Name = branch_Name;
    }

    public void setGroup_Officer_Code(String group_Officer_Code) {
        Group_Officer_Code = group_Officer_Code;
    }

    public void setGroup_Officer_Name(String group_Officer_Name) {
        Group_Officer_Name = group_Officer_Name;
    }

    public void setLoan_Principle_Paid(float loan_Principle_Paid) {
        Loan_Principle_Paid = loan_Principle_Paid;
    }

    public void setLoan_Interest_Paid(float loan_Interest_Paid) {
        Loan_Interest_Paid = loan_Interest_Paid;
    }

    public void setSavings_Received(float savings_Received) {
        Savings_Received = savings_Received;
    }

    public void setAdvance_Principle_Paid(float advance_Principle_Paid) {
        Advance_Principle_Paid = advance_Principle_Paid;
    }

    public void setAdvance_Interest_Paid(float advance_Interest_Paid) {
        Advance_Interest_Paid = advance_Interest_Paid;
    }

    public void setAdvances_Issued(float advances_Issued) {
        Advances_Issued = advances_Issued;
    }

    public void setOther_Transactions_Paid(float other_Transactions_Paid) {
        Other_Transactions_Paid = other_Transactions_Paid;
    }
    public void setCredit_Officer_Totals(float credit_Officer_Totals) {
        Credit_Officer_Totals = credit_Officer_Totals;
    }
    public void setBank_Account(String bank_Account) {
        Bank_Account = bank_Account;
    }

    public static void setStatus(Trans.Status status) {
        Status = status;
    }

    public void setHall_Received(float hall_Received) {
        Hall_Received = hall_Received;
    }

    public void setHall_Paid(float hall_Paid) {
        Hall_Paid = hall_Paid;
    }

    public void setGroup_Fines(float group_Fines) {
        Group_Fines = group_Fines;
    }

    public void setPenalty(float penalty) {
        Penalty = penalty;
    }

    public void setAdvance_Fine(float advance_Fine) {
        Advance_Fine = advance_Fine;
    }

    public void setPosted(boolean posted) {
        Posted = posted;
    }

    public void setPosted_Advance(float posted_Advance) {
        Posted_Advance = posted_Advance;
    }

    @PrimaryKey(autoGenerate = true )
    public Integer Id;
    public String Transaction_No;
    public String Description;
    public String Group_Code;
    public String Group_Name;
    public String Project;
    public String Date;
    @Ignore
    public boolean DateSpecified;
    public String Receipt_No;
    public String Branch_Code;
    public String Branch_Name;
    public String Group_Officer_Code;
    public String Group_Officer_Name;
    @Ignore
    public float Loan_Principle_Paid;
    @Ignore
    public float Loan_Interest_Paid;
    @Ignore
    public float Savings_Received;
    @Ignore
    public float Advance_Principle_Paid;
    @Ignore
    public float Advance_Interest_Paid;
    @Ignore
    public float Advances_Issued;
    @Ignore
    public float Other_Transactions_Paid;
    @Ignore
    public float Credit_Officer_Totals;
    @Ignore
    public String Bank_Account;

    public static Status Status;
    @Ignore
    public float Hall_Received;
    @Ignore
    public float Hall_Paid;

    public float Group_Fines;
    @Ignore
    public float Penalty;
    @Ignore
    public float Advance_Fine;

    public boolean Posted;
public  boolean sent;
    @Ignore
    public float Posted_Advance;


    @Override
    public String toString() {
        return Description;
    }

    public enum Status {
        /// <remarks/>
        Pending,
        /// <remarks/>
        Approved,
    }

    @Dao
    public interface dao extends Basedao {
        @Insert(onConflict = OnConflictStrategy.REPLACE)
       long  Insert(Trans t) ;
        @Update
       void Update(Trans t);
        @Delete
        void delete(Trans t);
        @Query("SELECT * FROM `trans header` order by Transaction_No desc")
        LiveData<List<Trans>> getAll();

        @Query("Select * from `trans header` where sent =0")
        List<Trans> unsent();

        @Query("update `trans header` set sent = 1 where Id =:id")
        int updatesent(int id);

    }
    public static class adapter extends RecyclerView.Adapter<adapter.NoteHolder> {
        private List<Trans> notes = new ArrayList<>();
        Grouplist binding;
      boolean  isFABOpen = false;
        private OnItemClickListener listener;
        @NonNull
        @Override
        public NoteHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

            this. binding = DataBindingUtil.inflate(
                    LayoutInflater.from(parent.getContext()),
                    R.layout.grouplistitem, parent, false);

            return new NoteHolder(binding);
        }

        @Override
        public void onBindViewHolder(@NonNull NoteHolder holder, int position) {

            Trans currentNote = notes.get(position);
            holder.bind(currentNote);




        }


        @Override
        public int getItemCount() {
            return notes.size();
        }
        public Trans getTransAt(int position) {
            return notes.get(position);
        }
        public void setTrans(List<Trans> notes) {
            this.notes = notes;
            notifyDataSetChanged();
        }

        class NoteHolder extends RecyclerView.ViewHolder {
            private Grouplist binding;

            public NoteHolder(Grouplist itemView) {
                super(itemView.getRoot());
                this.binding=itemView;

                itemView.getRoot().setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        int position = getAdapterPosition();
                        if (listener != null && position != RecyclerView.NO_POSITION) {
                            listener.onItemClick(notes.get(position));
                        }
                    }
                });

            }
            public void bind(Trans object){

                binding.setTransaction(object);
                binding.executePendingBindings();
            }

        }

        public interface OnItemClickListener {
            void onItemClick(Trans note);
        }

        public void setOnItemClickListener(OnItemClickListener listener) {
            this.listener = listener;
        }
    }

}


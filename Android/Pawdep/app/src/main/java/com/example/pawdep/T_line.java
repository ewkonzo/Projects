package com.example.pawdep;


import android.content.Context;
import android.os.AsyncTask;
import android.os.Parcelable;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.Toast;


import com.example.pawdep.databinding.Tline;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import androidx.annotation.NonNull;
import androidx.databinding.DataBindingUtil;
import androidx.lifecycle.LiveData;
import androidx.recyclerview.widget.RecyclerView;
import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Entity;
import androidx.room.Insert;
import androidx.room.OnConflictStrategy;
import androidx.room.PrimaryKey;
import androidx.room.Query;
import androidx.room.Update;
import androidx.work.Worker;
import androidx.work.WorkerParameters;

@Entity(tableName = "t_line")
public  class T_line implements Serializable {
    @PrimaryKey()
    @NonNull
    public String No;
    public String PAWDEP_No;
    public String Transaction_No;
    public String Member_Name;
    public String Loan_No;
    public String Group_Code;
    public float Savings_B_F;
    public float Loan_Balance_B_F;
    public float Expected_Interest;
    public float Total_Paid;
    public float Principle_Paid;
    public float Interest_Paid;
    public float Monthly_Savings;
    public float Savings__Shares_C_F;
    public float Loan_Balance_C_F;
    public float Interest_Balance_C_F;
    public float Fines;
    public String t_lineaction_No;
    public float Unpaid_Penalty;
    public float Penalty_Charged;
    public boolean Non_Cash;
    public float Expected_Principal;
    public String Member_No;
    public float Principle_Recovered;
    public float Intrerest_Recovered;
    public float Hall;
    public String Branch_Code;
    public boolean sent = false;

    @NonNull
    public String getNo() {
        return No;
    }

    public String getPAWDEP_No() {
        return PAWDEP_No;
    }

    public String getTransaction_No() {
        return Transaction_No;
    }

    public String getMember_Name() {
        return Member_Name;
    }

    public String getLoan_No() {
        return Loan_No;
    }

    public String getGroup_Code() {
        return Group_Code;
    }

    public float getSavings_B_F() {
        return Savings_B_F;
    }

    public float getExpected_Interest() {
        return Expected_Interest;
    }

    public float getTotal_Paid() {
        return Total_Paid;
    }

    public float getPrinciple_Paid() {
        return Principle_Paid;
    }

    public float getInterest_Paid() {
        return Interest_Paid;
    }

    public float getMonthly_Savings() {
        return Monthly_Savings;
    }

    public float getSavings__Shares_C_F() {
        return Savings__Shares_C_F;
    }

    public float getLoan_Balance_C_F() {
        return Loan_Balance_C_F;
    }

    public float getInterest_Balance_C_F() {
        return Interest_Balance_C_F;
    }

    public float getFines() {
        return Fines;
    }

    public String getT_lineaction_No() {
        return t_lineaction_No;
    }

    public float getUnpaid_Penalty() {
        return Unpaid_Penalty;
    }

    public float getPenalty_Charged() {
        return Penalty_Charged;
    }

    public boolean isNon_Cash() {
        return Non_Cash;
    }

    public float getExpected_Principal() {
        return Expected_Principal;
    }

    public String getMember_No() {
        return Member_No;
    }

    public float getPrinciple_Recovered() {
        return Principle_Recovered;
    }

    public float getIntrerest_Recovered() {
        return Intrerest_Recovered;
    }

    public float getHall() {
        return Hall;
    }

    public String getBranch_Code() {
        return Branch_Code;
    }

    public boolean isSent() {
        return sent;
    }

    public String getT_line_Header() {
        return t_line_Header;
    }

    public float getLoan_Balance_B_F() {
        return Loan_Balance_B_F;
    }


    public void setNo(String no) {
        No = no;
    }

    public void setPAWDEP_No(String PAWDEP_No) {
        this.PAWDEP_No = PAWDEP_No;
    }

    public void setMember_Name(String member_Name) {
        Member_Name = member_Name;
    }

    public void setLoan_No(String loan_No) {
        Loan_No = loan_No;
    }

    public void setSavings_B_F(float savings_B_F) {
        Savings_B_F = savings_B_F;
    }

    public void setLoan_Balance_B_F(float loan_Balance_B_F) {
        Loan_Balance_B_F = loan_Balance_B_F;
    }

    public void setExpected_Interest(float expected_Interest) {
        Expected_Interest = expected_Interest;
    }

    public void setTotal_Paid(float total_Paid) {
        Total_Paid = total_Paid;
    }

    public void setPrinciple_Paid(float principle_Paid) {
        Principle_Paid = principle_Paid;
    }

    public void setInterest_Paid(float interest_Paid) {
        Interest_Paid = interest_Paid;
    }

    public void setMonthly_Savings(float monthly_Savings) {
        Monthly_Savings = monthly_Savings;
    }

    public void setSavings__Shares_C_F(float savings__Shares_C_F) {
        Savings__Shares_C_F = savings__Shares_C_F;
    }

    public void setLoan_Balance_C_F(float loan_Balance_C_F) {
        Loan_Balance_C_F = loan_Balance_C_F;
    }

    public void setInterest_Balance_C_F(float interest_Balance_C_F) {
        Interest_Balance_C_F = interest_Balance_C_F;
    }

    public void setFines(float fines) {
        Fines = fines;
    }

    public void setT_lineaction_No(String t_lineaction_No) {
        this.t_lineaction_No = t_lineaction_No;
    }

    public void setUnpaid_Penalty(float unpaid_Penalty) {
        Unpaid_Penalty = unpaid_Penalty;
    }

    public void setPenalty_Charged(float penalty_Charged) {
        Penalty_Charged = penalty_Charged;
    }

    public void setNon_Cash(boolean non_Cash) {
        Non_Cash = non_Cash;
    }

    public void setExpected_Principal(float expected_Principal) {
        Expected_Principal = expected_Principal;
    }

    public void setMember_No(String member_No) {
        Member_No = member_No;
    }

    public void setPrinciple_Recovered(float principle_Recovered) {
        Principle_Recovered = principle_Recovered;
    }

    public void setIntrerest_Recovered(float intrerest_Recovered) {
        Intrerest_Recovered = intrerest_Recovered;
    }

    public void setHall(float hall) {
        Hall = hall;
    }

    public void setBranch_Code(String branch_Code) {
        Branch_Code = branch_Code;
    }

    public void setT_line_Header(String t_line_Header) {
        this.t_line_Header = t_line_Header;
    }

    public String t_line_Header;

    @Dao
    public interface dao {
        @Insert(onConflict = OnConflictStrategy.REPLACE)
        long Insert(T_line t);

        @Update
        int  Update(T_line t);

        @Delete
        void delete(T_line t);

        @Query("SELECT * FROM `T_line`")
        List<T_line> getAll();

        @Query("Select * from `T_line` where sent =0")
        List<T_line> unsent();

        @Query("update `t_line` set sent = 1 where `No` =:id")
        int updatesent(String id);

        @Query("SELECT * FROM `t_line` where Group_Code =:Group and PAWDEP_No =:No and Transaction_No =:t")
        List<T_line> Transctionline(String Group, String t, String No);
        @Query("SELECT * FROM `t_line` where Transaction_No =:t")
        List<T_line> Transctionline(String t);

    }

    public static class adapter extends RecyclerView.Adapter<adapter.Holder> {
        private List<T_line> notes = new ArrayList<>();
        private T_line.adapter.OnItemClickListener listener;

        @NonNull
        @Override
        public Holder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
            Tline binding = DataBindingUtil.inflate(
                    LayoutInflater.from(parent.getContext()),
                    R.layout.t_lineitem, parent, false);


            return new Holder(parent, binding);
        }

        @Override
        public void onBindViewHolder(@NonNull Holder holder, int position) {

            T_line current = notes.get(position);
            holder.bind(current);
        }

        @Override
        public int getItemCount() {
            return notes.size();
        }

        public void sett_line(List<T_line> notes) {
            this.notes = notes;
            notifyDataSetChanged();
        }
        class Holder extends RecyclerView.ViewHolder {
            private Tline binding;
            DB db;
            dao d;

            public Holder(@NonNull ViewGroup parent, Tline itemView) {
                super(itemView.getRoot());
                db = DB.getInstance(parent.getContext());
                d = db.t_linedao();

                this.binding = itemView;

                itemView.getRoot().setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        int position = getAdapterPosition();
                        if (listener != null && position != RecyclerView.NO_POSITION) {
                            listener.onItemClick(notes.get(position));
                        }
                    }
                });

                TextWatcher textWatcher = new TextWatcher() {
                    @Override
                    public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                    }

                    @Override
                    public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                    }

                    @Override
                    public void afterTextChanged(Editable editable) {
                        T_line t = binding.getTransaction();
                        t.setTotal_Paid((t.Interest_Paid+t.Principle_Paid+t.Interest_Paid+t.Penalty_Charged+t.Fines+t.Monthly_Savings+t.Hall));
                        new Holder.saveAsyncTask().execute(t);
                    }
                };
                View.OnFocusChangeListener focusChangeListener = new View.OnFocusChangeListener() {
                    @Override
                    public void onFocusChange(View view, boolean b) {
                        if (b==false)notifyDataSetChanged();
                    }
                };

                binding.savings  .addTextChangedListener(textWatcher);
                binding.Penaltycharged.addTextChangedListener(textWatcher);
                binding.interestpaid.addTextChangedListener(textWatcher);
                binding.LoanPrinciplePaid.addTextChangedListener(textWatcher);
                binding.fines.addTextChangedListener(textWatcher);
                binding.hall.addTextChangedListener(textWatcher);

                binding.savings.setSelectAllOnFocus(true);
                binding.Penaltycharged.setSelectAllOnFocus(true);
                binding.interestpaid.setSelectAllOnFocus(true);
                binding.LoanPrinciplePaid.setSelectAllOnFocus(true);
                binding.fines.setSelectAllOnFocus(true);
                binding.hall.setSelectAllOnFocus(true);
                binding.savings.setOnFocusChangeListener(focusChangeListener);
            }

            public void bind(T_line object) {
                binding.setTransaction(object);
                binding.executePendingBindings();
            }

            public Tline getdata() {
                return binding;
            }

            private class saveAsyncTask extends AsyncTask<T_line, Void, Void> {
                @Override
                protected Void doInBackground(T_line... notes) {
                    try {

              Log.i("Saved",String.valueOf(d.Update(notes[0])));
                       // notifyDataSetChanged();
                    }
                    catch (Exception e)
                    {e.printStackTrace();}
                    return null;
                }
            }
        }

        public interface OnItemClickListener {
            void onItemClick(T_line note);
        }

        public void setOnItemClickListener(T_line.adapter.OnItemClickListener listener) {
            this.listener = listener;
        }

    }
}

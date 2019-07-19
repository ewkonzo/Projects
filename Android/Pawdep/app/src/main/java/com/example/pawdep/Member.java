package com.example.pawdep;


import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.pawdep.databinding.Grouplist;

import java.util.ArrayList;
import java.util.List;

import androidx.databinding.DataBindingUtil;
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
import androidx.room.TypeConverter;
import androidx.room.TypeConverters;
import androidx.room.Update;

/**
 * Created by Paul on 11-Dec-16.
 */

@Entity(tableName = "Members")

public class Member {
    @Ignore
    public String Key;
    @PrimaryKey
   @NonNull
    public String No;
    public String Name ;
    public String Phone_No;
    public String Group_No;
    public String DOB;
    public String ID_No;
    public  int Status;
    public  int Account_Category ;
    public double Member_Deposits;
    public double Group_Savings;
    public enum status {
        /// <remarks/>
        Active(0),

        /// <remarks/>
        Non_Active(1),

        /// <remarks/>
        Blocked(2),

        /// <remarks/>
        Dormant(3),

        /// <remarks/>
        Re_instated(4),

        /// <remarks/>
        Deceased(5),

        /// <remarks/>
        Withdrawal(6),

        /// <remarks/>
        Retired(7),

        /// <remarks/>
        Termination(8),

        /// <remarks/>
        Resigned(9),

        /// <remarks/>
        Ex_Company(10),

        /// <remarks/>
        Casuals(11),

        /// <remarks/>
        Family_Member(12),

        /// <remarks/>
        Defaulter(13),

        /// <remarks/>
        Closed(14),

        /// <remarks/>
        Suspended(15);
        private int code;

        status(int code) {
            this.code = code;
        }

        public int getCode() {
            return code;
        }

        }
    public enum account_Category {

        /// <remarks/>
        Group,

        /// <remarks/>
        Individual,

        /// <remarks/>
        Non_Member,
    }


    @Dao
    public interface dao extends Basedao {
        @Insert(onConflict = OnConflictStrategy.REPLACE)
        long  Insert(Member t) ;
        @Update
        void Update(Member t);
        @Delete
        void delete(Member t);
        @Query("SELECT * FROM members")
        LiveData<List<Member>> getAll();
        @Query("SELECT * FROM members")
        List<Member> All();
        @Query("SELECT * FROM members where Group_No =:group and Account_Category ='1'")
        List<Member> getbygroupmembers(String group);

        @Query("select distinct Group_No from members")
        List<String> groups();
    }
    public static class adapter extends RecyclerView.Adapter<adapter.NoteHolder> {
        private List<Member> notes = new ArrayList<>();
        private Member.adapter.OnItemClickListener listener;
        @NonNull
        @Override
        public NoteHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

            Grouplist binding = DataBindingUtil.inflate(
                    LayoutInflater.from(parent.getContext()),
                    R.layout.grouplistitem, parent, false);

            return new NoteHolder(binding);
        }

        @Override
        public void onBindViewHolder(@NonNull NoteHolder holder, int position) {

            Member currentNote = notes.get(position);
            holder.bind(currentNote);
        }

        @Override
        public int getItemCount() {
            return notes.size();
        }

        public void setmember(List<Member> notes) {
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
            public void bind(Member object){

                //binding.setTransaction(object);
              //  binding.executePendingBindings();
            }

        }

        public interface OnItemClickListener {
            void onItemClick(Member note);
        }

        public void setOnItemClickListener(Member.adapter.OnItemClickListener listener) {
            this.listener = listener;
        }
    }

}

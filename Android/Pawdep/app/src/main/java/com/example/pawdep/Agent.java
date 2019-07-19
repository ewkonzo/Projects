package com.example.pawdep;


import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.pawdep.databinding.Grouplist;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import androidx.databinding.DataBindingUtil;
import androidx.lifecycle.LiveData;
import androidx.recyclerview.widget.RecyclerView;
import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Entity;
import androidx.room.Insert;
import androidx.room.OnConflictStrategy;
import androidx.room.PrimaryKey;
import androidx.annotation.NonNull;
import androidx.room.Query;
import androidx.room.Update;

/**
 * Created by Paul on 11-Dec-16.
 */

@Entity
public class Agent {
    @PrimaryKey
    @NonNull
    public String Agent_Code;
    public String Name;
    public String Mobile_No;
    public  int status;
    public String Password;

    public enum Status {
        /// <remarks/>
        Pending,
        /// <remarks/>
        first_Approval,
        /// <remarks/>
        Approved,
        /// <remarks/>
        Rejected,
    }
    @Dao
    public interface dao extends Basedao {
        @Insert(onConflict = OnConflictStrategy.REPLACE)
        long  Insert(Agent t) ;
        @Update
        void Update(Agent t);
        @Delete
        void delete(Agent t);
        @Query("SELECT * FROM Agent")
        LiveData<List<Agent>> getAll();
    }
    public static class adapter extends RecyclerView.Adapter<adapter.NoteHolder> {
        private List<Agent> notes = new ArrayList<>();
        private OnItemClickListener listener;
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

            Agent currentNote = notes.get(position);
            holder.bind(currentNote);
        }

        @Override
        public int getItemCount() {
            return notes.size();
        }

        public void setmember(List<Agent> notes) {
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
            public void bind(Agent object){

                //binding.setTransaction(object);
                //  binding.executePendingBindings();
            }

        }

        public interface OnItemClickListener {
            void onItemClick(Agent note);
        }

        public void setOnItemClickListener(OnItemClickListener listener) {
            this.listener = listener;
        }
    }
}

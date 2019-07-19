package com.trimline.padweps;


import android.databinding.DataBindingUtil;
import android.databinding.ViewDataBinding;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import java.util.ArrayList;
import java.util.List;

import io.reactivex.annotations.NonNull;

public class NoteAdapter extends RecyclerView.Adapter<NoteAdapter.NoteHolder> {
    private List<Trans> notes = new ArrayList<>();

    @NonNull
    @Override
    public NoteHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.addedittran, parent, false);
        ViewDataBinding binding = DataBindingUtil.inflate(
                LayoutInflater.from(parent.getContext()),
                R.layout.addedittran, parent, false);

        return new NoteHolder(binding);
    }

    @Override
    public void onBindViewHolder(@NonNull NoteHolder holder, int position) {
        Trans currentNote = notes.get(position);
//        holder.textViewTitle.setText(currentNote.getTitle());
//        holder.textViewDescription.setText(currentNote.getDescription());
//        holder.textViewPriority.setText(String.valueOf(currentNote.getPriority()));
    }

    @Override
    public int getItemCount() {
        return notes.size();
    }

    public void setNotes(List<Trans> notes) {
        this.notes = notes;
        notifyDataSetChanged();
    }

    class NoteHolder extends RecyclerView.ViewHolder {
        private  ViewDataBinding    binding;

        public NoteHolder(ViewDataBinding itemView) {
            super(itemView.getRoot());
            this.binding=itemView;

        }
        public void bind(Object object){

           // binding.setVariable(BR.transaction,object);
            binding.executePendingBindings();
        }
    }
}

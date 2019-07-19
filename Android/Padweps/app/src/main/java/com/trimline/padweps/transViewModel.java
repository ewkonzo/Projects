package com.trimline.padweps;

import android.app.Application;
import android.arch.lifecycle.AndroidViewModel;
import android.arch.lifecycle.LiveData;

import java.util.List;

import io.reactivex.annotations.NonNull;


public class transViewModel extends AndroidViewModel {
    private Repository repository;
    private LiveData<List<Trans>> allNotes;
   private transDao tdao  ;
    public transViewModel(@NonNull Application application) {
        super(application);
        //repository = new Repository(application,tdao );

    }
    public LiveData<List<Trans>> getAllNotes() {
        return allNotes;
    }
public void insert(Trans t)
{

    //repository.insert(t);
}
}

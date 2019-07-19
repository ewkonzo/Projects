package com.example.pawdep;

import android.content.Context;
import android.util.Log;

import androidx.annotation.NonNull;
import androidx.work.Worker;
import androidx.work.WorkerParameters;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.util.List;

public class worker extends Worker {

    public worker(
            @NonNull Context context,
            @NonNull WorkerParameters params) {
        super(context, params);
    }

    @Override
    public Result doWork() {
        // Do the work here--in this case, upload the images.
        getlogins();
        getloans();
        getgroups();
        getmembers();


        return Result.success();
    }
    private void getlogins() {
        Agent.dao Dao ;
        DB db = DB.getInstance(getApplicationContext());
        Dao = db.agentdao();
        try {
            Gson g = new Gson();
            String  result = JsonParser.postjson("logins", null, null);
            Type localType = new TypeToken<List<Agent>>() {
            }.getType();
            List<Agent> results = new Gson().fromJson(result, localType);
            if (results != null) {
                try {
                    for (Agent f : results
                    ) {
                        Dao.Insert(f);
                    }
                } catch (Exception ex) {

                    ex.printStackTrace();
                }
            } else {
                Log.i("members", "Empty");
            }
        } catch (Exception e) {

            e.printStackTrace();
        }
    }

    private void getmembers() {
        Member.dao Dao ;
        DB db = DB.getInstance(getApplicationContext());
        Dao = db.memberDao();
        try {
          List<Member> results;
            String key ="";
            Boolean all = false;
            while (all == false){
          String  result = JsonParser.postjson("allmembers", "bookmarkkey", key);
            Type localType = new TypeToken<List<Member>>() {
            }.getType();
            results = new Gson().fromJson(result, localType);
            if (results != null) {
                try {
                    all = true;
                   for (Member f : results
                    ) {
                       if (f.No!=null)
                           Dao.Insert(f);
                       key = f.Key;
                       all = false;
                    }
                } catch (Exception ex) {

                    ex.printStackTrace();
                }
            } else {
                Log.i("members", "Empty");
            }}
        } catch (Exception e) {

            e.printStackTrace();
        }
    }
    private void getgroups() {
        Group.dao Dao ;
        DB db = DB.getInstance(getApplicationContext());
        Dao = db.groupDao();
        try {
            List<Group> results ;
            String key ="";
            Boolean all = false;
            while (all == false){
            String  result = JsonParser.postjson("allgroups", "bookmarkkey", key);
            Type localType = new TypeToken<List<Group>>() {
            }.getType();
           results = new Gson().fromJson(result, localType);
            if (results != null) {
                try {
                    all = true;
                    for (Group f : results
                    ) {
                        if (f.Group_No !=null)
                        Dao.Insert(f);
                        key = f.Key;
                    }
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
            } else {
                Log.i("Groups", "Empty");
            }}
        } catch (Exception e) {

            e.printStackTrace();
        }
    }
    private void getloans() {
        Loan.dao Dao ;
        DB db = DB.getInstance(getApplicationContext());
        Dao = db.loandao();
        try {
            List<Loan> results ;
            String key ="";
            Boolean all = false;
            while (all == false){
            String  result = JsonParser.postjson("loans", "bookmarkkey", key);
            Type localType = new TypeToken<List<Loan>>() {
            }.getType();
           results = new Gson().fromJson(result, localType);
            if (results != null) {
                try {
                    all = true;
                    for (Loan f : results
                    ) {
                        if (f.Loan_No !=null)
                        Dao.Insert(f);
                        key = f.Key;
                    }
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
            } else {
                Log.i("Groups", "Empty");
            }}
        } catch (Exception e) {

            e.printStackTrace();
        }
    }
    private void sendtrans() {
        Trans.dao Dao ;
        DB db = DB.getInstance(getApplicationContext());
        Dao = db.transactiondao();
        try {
            for (Trans cc : Dao.unsent()
            ) {
                Trans res = null;
                Gson g = new Gson();
               String result = g.toJson(cc);
                result = JsonParser.postjson("Collections", "data", result);
                Type localType = new TypeToken<Trans>() {
                }.getType();
                res = new Gson().fromJson(result, localType);
                if (res != null) {
                   Dao.updatesent (res.Id);
                }
            }
        } catch (Exception e) {
            e.printStackTrace();

        }
    }
    private void sendtline() {
        T_line.dao Dao ;
        DB db = DB.getInstance(getApplicationContext());
        Dao = db.t_linedao();
        try {
            for (T_line cc : Dao.unsent()
            ) {
                T_line res = null;
                Gson g = new Gson();
                String result = g.toJson(cc);
                result = JsonParser.postjson("Collections", "data", result);
                Type localType = new TypeToken<T_line>() {
                }.getType();
                res = new Gson().fromJson(result, localType);
                if (res != null) {
                    Dao.updatesent (res.No);
                }
            }
        } catch (Exception e) {
            e.printStackTrace();

        }
    }
}




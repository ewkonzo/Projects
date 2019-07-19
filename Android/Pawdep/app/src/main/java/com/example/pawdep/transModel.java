package com.example.pawdep;

import android.app.Application;
import android.os.AsyncTask;
import android.util.Log;


import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.LiveData;

public class transModel extends AndroidViewModel {
    Trans.dao Dao;
    T_line.dao tdao;
    Member.dao mdao;
    Loan.dao ldao;
    Advance.dao adao;
    PW_Transactions.dao ptdao;
    private LiveData<List<Trans>> allNotes;

    public transModel(@NonNull Application application) {
        super(application);
        DB db = DB.getInstance(application);

        Dao = db.transactiondao();
        tdao = db.t_linedao();
        mdao = db.memberDao();
        ldao = db.loandao();
        adao = db.adao();
        ptdao = db.ptadao();
        allNotes = Dao.getAll();
    }

    public LiveData<List<Trans>> getAll() {
        return allNotes;
    }

    public void insert(Trans t) {
        new InsertAsyncTask(Dao).execute(t);

    }

    private class InsertAsyncTask extends AsyncTask<Trans, Void, Void> {
        private Trans.dao Dao;

        private InsertAsyncTask(Trans.dao Dao) {
            this.Dao = Dao;
        }

        @Override
        protected Void doInBackground(Trans... notes) {
            Trans tr = notes[0];
            long l = Dao.Insert(notes[0]);

            List<Member> members = mdao.getbygroupmembers(notes[0].Group_Code);
            Integer i = 1;
            for (Member m : members
            ) {
                T_line t;
                t = new T_line();
                Date c = Calendar.getInstance().getTime();
                SimpleDateFormat df = new SimpleDateFormat("ddMMyyHHmmss");
                t.No = df.format(c) + i.toString();
                t.Transaction_No = tr.Transaction_No;
                t.Member_No = m.No;
                t.PAWDEP_No = m.No;
                t.Member_Name = m.Name;
                t.Savings_B_F = (float) m.Group_Savings;
                t.Group_Code = tr.Group_Code;
                List<Loan> ll = ldao.memberloansnonharaka(m.No);
                if (ll.size() != 0) {
                    t.Loan_Balance_B_F = (float) ll.get(0).Outstanding_Balance;//  ll.stream().mapToDouble(n -> n.Outstanding_Balance).sum();
                    t.Loan_No = ll.get(0).Loan_No;
                    t.Expected_Interest = (float) (ll.get(0).PAWDEP_Schedule_Interest + ll.get(0).Interest_Paid);
                    t.Expected_Principal = (float) (ll.get(0).PAWDEP_Schedule_Repayment + ll.get(0).Current_Repayments);
                }

                List<T_line> t_lines = tdao.Transctionline(tr.Group_Code, tr.Transaction_No, m.No);
                if (t_lines.size() > 0) {
                    Log.i("Rec", t_lines.get(0).No);
                    t.No = t_lines.get(0).No;
                   // tdao.Update(t);
                } else {
                    tdao.Insert(t);
                    i++;
                }
                List<Loan> harakaloans = ldao.memberloansharaka(m.No);
                if (harakaloans.size() > 0) {
                    Advance adv = new Advance();
                    adv.Transaction_No = tr.Transaction_No;
                    adv.Group_Code = tr.Group_Code;
                    adv.Member_No = m.No;
                    adv.Member_Name = m.Name;
                    adv.Expected_Repayment = Double.valueOf(harakaloans.get(0).Outstanding_Balance);
                    adv.Expected_Interest = Double.valueOf(harakaloans.get(0).Outstanding_Balance * (5 / 100));
                    adv.Loan_No = harakaloans.get(0).Loan_No;
                    adao.Insert(adv);
                }
            }
            return null;
        }
    }

}

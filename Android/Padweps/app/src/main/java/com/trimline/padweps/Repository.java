package com.trimline.padweps;

public class Repository<T>{

//    private D tDao;
//    private LiveData<List<T>> alltransactions;
//
//    public Repository(Application application, D Dao) {
//        DB database = DB.getInstance(application);
//        tDao = Dao;
//
//    }
//
//    public void insert(T transaction) {
//        new InsertAsyncTask(tDao).execute(transaction);
//    }
//
//    public void update(T transaction) {
//        new UpdateAsyncTask(tDao).execute(transaction);
//    }
//
//    public void delete(T transaction) {
//        new DeleteAsyncTask(tDao).execute(transaction);
//    }
//
//    public LiveData<List<T>> getAll() {
//        return alltransactions;
//    }
//    private  class InsertAsyncTask extends AsyncTask<T, Void, Void> {
//        private D transDao;
//
//        private InsertAsyncTask(D Dao) {
//            this.transDao = transDao;
//        }
//
//        @Override
//        protected Void doInBackground(T... transactions) {
//
//            transDao.insert(transactions[0]);
//            return null;
//        }
//    }
//
//    private  class UpdateAsyncTask extends AsyncTask<T, Void, Void> {
//        private D Dao;
//
//        private UpdateAsyncTask(D dao) {
//            this.Dao = dao;
//        }
//
//        @Override
//        protected Void doInBackground(T... transactions) {
//            Dao.insert(transactions[0]);
//            return null;
//        }
//    }
//
//    private  class DeleteAsyncTask extends AsyncTask<T, Void, Void> {
//        private D Dao;
//
//        private DeleteAsyncTask(D dao) {
//            this.Dao = dao;
//        }
//
//        @Override
//        protected Void doInBackground(T... transactions) {
//           Dao.delete(transactions[0]);
//            return null;
//        }
//    }




}
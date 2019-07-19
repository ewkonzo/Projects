package com.example.pawdep;

import android.app.Application;
import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.Filter;
import android.widget.TextView;



import java.sql.Date;
import java.util.ArrayList;
import java.util.List;

import androidx.annotation.NonNull;
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
import androidx.room.Query;
import androidx.room.Update;

@Entity(tableName = "Groups")
public  class  Group{

    @Ignore
    public String Key;

    public void setGroup_No(@NonNull String group_No) {
        Group_No = group_No;
    }

    public void setGroup_Name(String group_Name) {
        Group_Name = group_Name;
    }

    public void setBranch_Code(String branch_Code) {
        Branch_Code = branch_Code;
    }

    public void setBranch_Name(String branch_Name) {
        Branch_Name = branch_Name;
    }

    @NonNull
    public String getGroup_No() {
        return Group_No;
    }

    public String getGroup_Name() {
        return Group_Name;
    }

    public String getBranch_Code() {
        return Branch_Code;
    }

    public String getBranch_Name() {
        return Branch_Name;
    }

    @PrimaryKey
    @NonNull
    public String Group_No;

    public String Group_Name;
    public String Branch_Code;
    public String Branch_Name;


    @Dao
    public interface dao {
        @Insert(onConflict = OnConflictStrategy.REPLACE)
        long Insert(Group t);

        @Update
        void Update(Group t);

        @Delete
        void delete(Group t);

        @Query("SELECT * FROM groups")
        LiveData<List<Group>> getAll();

        @Query("select distinct * from Groups")
        List<Group> Groups();
        @Query("select Group_Name from Groups where Group_No =:groupno")
        String groupname(String groupno);
    }

        public static class Groupsadapter extends ArrayAdapter
        {
            private Context context;
            private int          resource;
            private List<Group> groups;
            private List<Group> tempItems;
            private List<Group> suggestions;

            public Groupsadapter(Context context, int resource, List<Group> items)
            {
                super(context, resource, 0, items);

                this.context = context;
                this.resource = resource;
                this.groups = items;
                tempItems = new ArrayList<Group>(items);
                suggestions = new ArrayList<Group>();
            }

            @Override
            public View getView(int position, View convertView, ViewGroup parent)
            {
                View view = convertView;
                if (convertView == null)
                {
                    LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
                    view = inflater.inflate(resource, parent, false);
                }
                TextView groupno = (TextView)view.findViewById(R.id.groupno);
                TextView groupname = view.findViewById(R.id.groupname);
                TextView branchname = view.findViewById(R.id.branchname);
                Group  item= groups.get(position);

//                if (item != null && view instanceof TextView)
//                {
                  //  ((TextView) view).setText(item);
                    groupno.setText(item.getGroup_No());
                    groupname.setText(item.getGroup_Name());
                    branchname.setText(item.getBranch_Name());
              // }

                return view;
            }

            @Override
            public Filter getFilter()
            {
                return nameFilter;
            }

            Filter nameFilter = new Filter()
            {
                @Override
                public CharSequence convertResultToString(Object resultValue)
                {
                    Group str = (Group) resultValue;
                    return str.Group_No;
                }

                @Override
                protected FilterResults performFiltering(CharSequence constraint)
                {
                    if (constraint != null)
                    {
                        suggestions.clear();
                        for (Group names : tempItems) {
                            if (names.Group_Name.toLowerCase().contains(constraint.toString().toLowerCase())) {
                                suggestions.add(names);
                            } else if (names.Group_No.toLowerCase().contains(constraint.toString().toLowerCase())) {
                                suggestions.add(names);
                            }
//                            else if (names.Branch_Name.toLowerCase().contains(constraint.toString().toLowerCase())) {
//                                suggestions.add(names);
//                            }
                        }
                        FilterResults filterResults = new FilterResults();
                        filterResults.values = suggestions;
                        filterResults.count = suggestions.size();
                        return filterResults;
                    }
                    else
                    {
                        return new FilterResults();
                    }
                }

                @Override
                protected void publishResults(CharSequence constraint, FilterResults results)
                {try{
                    List<Group> filterList = (ArrayList<Group>) results.values;
                    if (results != null && results.count > 0)
                    {
                        clear();
                        for (Group item : filterList)
                        {
                            add(item);
                            notifyDataSetChanged();
                        }
                    }
                }catch (Exception ex){ex.printStackTrace();}}
            };
        }

    }

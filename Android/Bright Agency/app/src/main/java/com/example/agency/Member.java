package com.example.agency;

import java.util.List;

public class Member
{
    public String id_no = null;
    public String name = null;
    public String telephone = null;
    public List<Account> accounts = null;
    public String pin;
    public Boolean pin_changed = false;
    public List<Loans> loans = null;
    public Boolean requestsuccessful = true;
    public String message = null;
}

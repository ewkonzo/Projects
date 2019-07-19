package com.example.paul.datacollector;

/**
 * Created by Paul on 02-Dec-16.
 */

public class user {
    public String User;
    public String Password;
    public Boolean Password_Changed;
    public Boolean Active;
    public String Factory;
    public String Transporter;
    @Override
    public String toString() {
        return this.User;
    }
}

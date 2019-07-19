package com.example.paul.datacollector;

public  class Routes
{
    public String Code ;
    public String Description;
    @Override
    public String toString() {
        return this.Description;
    }
    public  static Routes currentroute;
}

package elegance.hasoft.com.elegance;


public class TimeCalculator {
 public String getDuration(String postedTime){
     long now = System.currentTimeMillis()/1000;
     long posted = new Long(postedTime);
     long secs = (now -posted);
     long diff = Math.round(secs/60);

     String show = "";
     if (diff < 1){
         show = "Just now";
     }else{
         if (diff == 1){
         show = "1 min";
     }else {
         if (diff>1 && diff < 60){
         show = diff + " min";
         }else{
            if (diff>=60){
            long hours = Math.round(diff/60);
            if(hours==1){
            show = hours + " h";
            }else {
                if (hours <24){
                show = hours + " h";
                }else{
                    if (hours>=24){
                        long days = Math.round(hours/24);
                        if(days == 1){
                            show = days + " d";
                        }else{
                            if(days > 1 && days < 7){
                                show = days + " d";
                            }else{
                                if(days>=7 && days < 28){
                                long weeks = Math.round(days/7);
                                if(weeks==1){
                                	show = weeks + " w";
                                }else{
                                	show = weeks + " w";
                                }
                                }else{
                                    if (days>=28){
                                        long months = Math.round(days/28);
                                        show = months + " months";
                                    }else{

                                    }
                                }
                            }
                            }}}}}}}}
     return show;
 }}


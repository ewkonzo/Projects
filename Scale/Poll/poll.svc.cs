using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Poll
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class poll : polls
    {
        string newline = "\n";
        delegate string asp(string i);
        delegate string consti(string id, string sess);
        public string ussd(string sessionId, string phoneNumber, string serviceCode, string text)
        {
            string res = "END Thank you";
            string[] hops = text.Split(new char[] { '*' });
            string lastoption = hops[hops.GetUpperBound(0)];
            string shortcode = hops[0];
            using (var db = new MobileEntities())
            {
                try
                {
                    switch (hops.Length)
                    {
                        case 1:
                            res = "CON Please select your constituency." + newline;
                            var c = db.constituencies.Where(o => o.shortcode == lastoption);
                            int i = 1;
                            foreach (var cc in c)
                            {
                                session_variable s = new session_variable();
                                s.session = sessionId;
                                s.var_id = i;
                                s.type = "C";
                                s.var_key = cc.Id.ToString();
                                s.var_value = cc.constituency1;
                              
                                db.session_variables.Add(s);
                                res += string.Format("{0}. {1}{2}", i, s.var_value, newline);
                                s = null;
  i++;
                            }
                            break;
                        case 2:
                            res = "CON Select position." + newline;
                            res += "1. Governor" + newline;
                            res += "2. Senator" + newline;
                            res += "3. Women Rep" + newline;
                            res += "4. MP";
                            break;

                        case 3:
                            switch (lastoption)
                            {
                                case "4":
                                    long id =Convert.ToInt64(getvariable(sessionId, Convert.ToInt16(hops[1]), "C"));
                                    var m = db.Aspirants.Where(o => o.Constituency == id && o.position == lastoption);

                                    res = "CON Vote your preffered MP";
                                    int jj = 1;
                                    foreach (var cc in m)
                                    {
                                        session_variable s = new session_variable();
                                        s.session = sessionId;
                                        s.var_id = jj;
                                        s.var_key = cc.id.ToString();
                                        s.var_value = cc.Name;
                                        s.type = "A";
                                       
                                        db.session_variables.Add(s);
                                        res += string.Format("{0}. {1}{2}", jj, s.var_value, newline);
                                        s = null; jj++;
                                    }
                                    break;

                                default:

                                    asp sp = x =>
                                    {
                                        string ps = "";
                                        switch (x)
                                        {
                                            case "1": ps = "Governor"; break;
                                            case "2": ps = "Senator"; break;
                                            case "3": ps = "Women rep"; break;
                                        }

                                        return ps;
                                    };

                                    var g = db.Aspirants.Where(o => o.Code == shortcode && o.position == lastoption);
                                    res = "CON Vote your preffered " + sp(lastoption)+ newline;
                                    int j = 1;
                                    foreach (var cc in g)
                                    {
                                        session_variable s = new session_variable();
                                        s.session = sessionId;
                                        s.var_id = j;
                                        s.type = "A";
                                        s.var_key = cc.id.ToString();
                                        s.var_value = cc.Name;
                                        db.session_variables.Add(s);
                                        res += string.Format("{0}. {1}{2}", j, s.var_value, newline);
                                        s = null; j++;
                                    }
                                    break;
                            }
                            break;
                        case 4:
                            res = "END Thank you for your vote.";
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {


                }
                finally
                {

                    db.SaveChanges();
                }
            }
            return res;
        }
        private string getvariable(string sess, int n,string type) {
            string v = "";
            using (var db = new MobileEntities())
            {
                var d = db.session_variables.FirstOrDefault(o => o.session == sess && o.var_id == n && o.type == type);
                v = d.var_key;
            
            }
            return v;
        }
    
    }
}

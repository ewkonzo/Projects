using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Polls
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class polls
        : poll
    {
        string newline = "\n";
    
        public string ussd(string sessionId, string phoneNumber, string serviceCode, string text) {
            string res ="END Thank you" ;
            string[] hops = text.Split(new char[]{'*'});
           
            using (var db = new MobileEntities()) { 
            try
            {
                switch (hops.Length) { 
                    case 1:
                        res = "CON Please select your constituency." + newline;
                        var c = db.constituencies.Where(o => o.shortcode == text);
                        int i =1;
                        foreach (var cc in c)
                        {
                            session_variable s = new session_variable();
                            s.session = sessionId;
                            s.var_id=i;
                            s.var_key = cc.Id.ToString();
                            s.var_value = cc.constituency1;
                            i++;
                            db.session_variables.Add(s);
                            res += string.Format("{0}. {1}{2}", i, s.var_value,newline);
                            s = null;

                        }
                        break;
                    case 2:
                        res = "CON Select position." + newline;
                         res += "1. Governor"+newline;
                         res += "2. Senator"+newline;
                         res += "3. Women Rep"+newline;
                         res += "4. MP";
                         break;

                    case 3:
                        switch (text)
                        { 
                            case "1":
                                var g = db.Aspirants.Where(o => o.Code == hops[0]);
                                res = "CON Vote your preffered Governor";
                                int j = 1;
                                foreach (var cc in g)
                                {
                                    session_variable s = new session_variable();
                                    s.session = sessionId;
                                    s.var_id = j;
                                    s.var_key = cc.id.ToString();
                                    s.var_value = cc.Name;
                                    j++;
                                    db.session_variables.Add(s);
                                    res += string.Format("{0}. {1}{2}", j, s.var_value, newline);
                                    s = null;
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
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
namespace PData
{
}

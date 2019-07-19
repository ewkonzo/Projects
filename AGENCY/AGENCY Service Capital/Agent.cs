using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
namespace AGENCY
{
    public class Agent
    {
        public String agent_code = null;
        public String agent_Name = null;
        public String agent_Account = null;
        public double account_balance = 0;
        public String Telephone = null;
        public String pin = null;
        public Boolean logged_in = false;
        public String message = null;
        public String new_pin = null;
        public Boolean Pin_changed = false;
        public Boolean Branch = false;

        public static string GetAccount(ref Agent Agentcode)
        {
            string acc = string.Empty;
            try
            {
                using (var db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    if (db.mDB.State == ConnectionState.Open)
                    {
                        DataTable dt = db.Getdatatable(String.Format("SELECT top(1) * FROM [Capital SACCO Society Ltd$Agent Applications] WHERE [Agent Code] ='{0}'", Agentcode.agent_code));
                        if (dt.Rows.Count > 0)
                        {
                            acc = dt.Rows[0]["Account"].ToString();
  Agentcode.Branch = Convert.ToBoolean( dt.Rows[0]["Branch"]);
                        }
                    }
                    db.close();
                }
            }
            catch (Exception ex)
            {               
                CUtilities.LogEntryOnFile(ex.Message);
            }
   
            CUtilities.LogEntryOnFile(acc);
            return acc;
        }
    }
}

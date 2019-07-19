using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
namespace AGENCY
{
    public class Agent
    {
        public static Agents.AgentApplications_Service agentservice = new Agents.AgentApplications_Service();
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
                acc = agentservice.Read(Agentcode.agent_code).Account;
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

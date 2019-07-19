using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace RunCodunits
{
    public partial class Service1 : ServiceBase
    {
        private System.Net.NetworkCredential cd; private ServerSetting ss = new ServerSetting();
        public static Run.RunThem run = new Run.RunThem();
        public Service1()
        {
            InitializeComponent();
            string path ="Settings.txt";
            ss.getsettings(path);
            cd = new System.Net.NetworkCredential(ss.user, ss.pass, ss.domain);
            run.Url = String.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/RunThem", ss.server, ss.Companyname,
                ss.Instance, ss.Port);
            run.PreAuthenticate = true;
            run.Credentials = cd;
        }

        protected override void OnStart(string[] args)
        {
            RunThem rn = new RunThem();
            rn.onstart();
        }

        protected override void OnStop()
        {
            RunThem.stop = true;
        }
    }
}

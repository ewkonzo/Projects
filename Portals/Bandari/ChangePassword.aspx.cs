using System;
using System.Data.SqlClient;
using System.Text;
using Bandari_Sacco.controller;

namespace Bandari_Sacco
{
    public partial class ChangePassword : System.Web.UI.Page
    {

        public string body = "", recepient = "", subject = "", Personal_No = "", Password = "", Msg = "", attachment = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member_No"] == null || string.IsNullOrEmpty(Session["Member_No"].ToString()))
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            else
            {
                var user = MyClass.user(Session["user_id"].ToString());
                string changedPassword = "";
                //changedPassword = MyClass.CheckIfChangedPassword(Session["Member_No"].ToString());
                string trimmedchangedpassword = changedPassword.Trim();
                Session["CHANGED"] = Convert.ToInt16( user.Changed_Password);

                if (user.Changed_Password == false)
                {

                    string msg = "please change the default password to continue.";
                    lblDisplay.Text = String.Format("<div class='alert alert-info'>{0}</div>", msg);


                }
            }
            if (!IsPostBack)
            {
                lblDisplay2.Text = "Please use a combination of uppercase, lowercase and number for your password";
            }
 
        }
        protected void ResetButton_Click(object sender, EventArgs e)
        {

            string enteredPassword = txtOldPass.Text.Trim();
            string storedPassword = "";
            string newpassword = txtNewPass.Text.Trim();
            string confirmednewpassword = txtConfirmNewPass.Text.Trim();
            string memberNo = Session["Member_No"].ToString();
            string changed = Session["CHANGED"].ToString();




          
                        
                     var user =   Global.user_Service.Read(memberNo);
                    if (user != null  )
                    {
                    storedPassword = user.Password.ToString();
                        if (changed == "0")
                        {
                            if (storedPassword ==MyClass.GetMd5Hash( enteredPassword) && newpassword == confirmednewpassword)
                            {
                                 bool results = ValidatePassword();
                                 if (results == true)
                                 {

                                user.Password = MyClass.GetMd5Hash(newpassword);
                            user.Changed_Password = true;
                            user.Changed_PasswordSpecified = true;
                            Global.user_Service.Update(ref user);
                                     Session.Abandon();
                                     Response.Redirect("PasswordChangeSuccess.aspx");
                                     //string msg = "Password successfully changed";

                                    // lblDisplay.Text = String.Format("<div class='alert alert-success'>{0}</div>", msg);
                                 }
                            }
                            else
                            {
                                string msg = "You have entered the wrong old password. Please try again";

                                lblDisplay.Text = String.Format("<div class='alert alert-warning'>{0}</div>", msg);


                            }

                        }


                        else if (changed == "1")
                        {
                            if (storedPassword == MyClass.GetMd5Hash(enteredPassword) && newpassword == confirmednewpassword)
                            {
                                 bool results = ValidatePassword();
                                 if (results == true)
                                 {
                                     user.Password  =MyClass.GetMd5Hash(newpassword);
                            user.Changed_Password = true;
                            user.Changed_PasswordSpecified = true;
                            Global.user_Service.Update(ref user);
                            Session.Abandon();
                                     Response.Redirect("PasswordChangeSuccess.aspx");
                                     //string msg = "Password successfully changed";

                                     //lblDisplay.Text = String.Format("<div class='alert alert-success'>{0}</div>", msg);

                                 }
                            }
                            else
                            {

                                string msg = "You have entered the wrong password. Please try again";

                                lblDisplay.Text = String.Format("<div class='alert alert-warning'>{0}</div>", msg);

                            }
                        }
                //    }
                //}
            }
        }

        protected bool ValidatePassword()
        {
            bool passed = true;
            try
            {
                cSite.WriteLog("Tried to change password");
                if (true)
                {
                    if (cPasswordAdvisor.CheckStrength(txtConfirmNewPass.Text.Trim()) == enPasswordScore.psBlank)
                    {
                        string msg = "Your new password is blank." +
                        " Please enter a password consisting of atleast an uppercase and lowercase letter," +
                        " a number and an alpha numeric character.";
                        lblDisplay.Text = String.Format("<div class='alert alert-info'>{0}</div>", msg);

                        passed = false;

                    }
                    else if (cPasswordAdvisor.CheckStrength(txtConfirmNewPass.Text.Trim()) == enPasswordScore.psVeryWeak)
                    {
                        string msg = "Your new password is very weak." +
                       " Please enter a password consisting of atleast an uppercase and lowercase letter," +
                       " a number and an alpha numeric character.";
                        lblDisplay.Text = String.Format("<div class='alert alert-info'>{0}</div>", msg);

                        passed = false;
                    }
                    else if (cPasswordAdvisor.CheckStrength(txtConfirmNewPass.Text.Trim()) == enPasswordScore.psWeak)
                    {
                        string msg = "Your new password is weak." +
                       " Please enter a password consisting of atleast an uppercase and lowercase letter," +
                       " a number and an alpha numeric character.";
                        lblDisplay.Text = String.Format("<div class='alert alert-info'>{0}</div>", msg);

                        passed = false;
                    }


                    else if (cPasswordAdvisor.CheckStrength(txtConfirmNewPass.Text.Trim()) == enPasswordScore.psMedium)
                    {
                        string msg = "Your new password is medium." +
                          " Please enter a password consisting of atleast an uppercase and lowercase letter," +
                          " a number and an alpha numeric character.";
                        lblDisplay.Text = String.Format("<div class='alert alert-info'>{0}</div>", msg);

                        passed = false;
                    }

                    //else if (cPasswordAdvisor.CheckStrength(this.txtPassword1.Text) == enPasswordScore.psStrong)
                    //{
                    // this.lblErrorX.Text = "Your new password is a bit stronger." +
                    // " Enter a password consisting of uppercase and lowercase letters," +
                    // " numbers and an alpha numeric characters.";
                    // RegisterStartupScript("Validation", "<script>alert('" + this.lblErrorX.Text + "')</script>");
                    // return;
                    //}

                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return passed;
        }

        #region Javascript Message

        public void Message(string strMsg)
        {
            var sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(strMsg);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
        }

        #endregion
    }
}
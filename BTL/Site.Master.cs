using System;

namespace BTL
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "user")
            {
                LinkButtonHome.Visible = true;
                LinkButtonRead.Visible = true;
                LinkButtonUpload.Visible = false;
                LinkButtonProfile.Visible = true;
                LinkButtonSignup.Visible = false;
                LinkButtonLogin.Visible = false;
                LinkButtonLogout.Visible = true;
            }
            else if (Session["UserRole"] != null && Session["UserRole"].ToString() == "contributor")
            {
                LinkButtonHome.Visible = true;
                LinkButtonRead.Visible = true;
                LinkButtonUpload.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonSignup.Visible = false;
                LinkButtonLogin.Visible = false;
                LinkButtonLogout.Visible = true;
            } else if (Session["UserRole"] != null && Session["UserRole"].ToString() == "admin")
            {
                LinkButtonHome.Visible = true;
                LinkButtonRead.Visible = true;
                LinkButtonUpload.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonSignup.Visible = false;
                LinkButtonLogin.Visible = false;
                LinkButtonLogout.Visible = true;
            } else
            {
                LinkButtonHome.Visible = true;
                LinkButtonRead.Visible = true;
                LinkButtonUpload.Visible = false;
                LinkButtonProfile.Visible = false;
                LinkButtonSignup.Visible = true;
                LinkButtonLogin.Visible = true;
                LinkButtonLogout.Visible = false;
            }
        }

        protected void LinkButtonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void LinkButtonRead_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButtonUpload_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButtonProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void LinkButtonSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        protected void LinkButtonLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }
    }
}
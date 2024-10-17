using BTL.dao;
using BTL.model;
using System;
using System.Configuration;

namespace BTL
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBoxEmail.Text) || string.IsNullOrEmpty(TextBoxPassword.Text))
                {
                    Notify("Please fill in all the empty fields!");
                    return;
                }
                UserDAO userDAO = new UserDAO();
                if (userDAO.Verify(TextBoxEmail.Text.Trim(),TextBoxPassword.Text.Trim()))
                {
                    User user = userDAO.Read(TextBoxEmail.Text.Trim());
                    Session["UserEmail"] = user.Email;
                    Session["UserName"] = user.Name;
                    Session["UserRole"] = user.Role;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Notify("Invalid email or password.");
                }
            }
            catch (Exception ex)
            {
                Notify("An error occurred. Please try again later!\n" + ex.Message);
            }
        }
        private void Notify(string message)
        {
            LabelNotify.Text = message;
            LabelNotify.Visible = true;
        }
    }
}
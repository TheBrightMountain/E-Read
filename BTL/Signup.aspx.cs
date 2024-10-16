using BTL.dao;
using BTL.model;
using System;
using System.Configuration;

namespace BTL
{
    public partial class Signup : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSignup_Click(object sender, EventArgs e)
        {
            try
            {
                UserDAO userDAO = new UserDAO();
                if (string.IsNullOrEmpty(TextBoxEmail.Text) || string.IsNullOrEmpty(TextBoxName.Text) || string.IsNullOrEmpty(TextBoxBirthdate.Text) || string.IsNullOrEmpty(TextBoxPhone.Text) || string.IsNullOrEmpty(TextBoxCity.Text))
                {
                    Notify("Please fill in all the empty fields!");
                    return;
                }
                if (string.IsNullOrEmpty(TextBoxPassword.Text) || string.IsNullOrEmpty(TextBoxConfPassword.Text))
                {
                    Notify("Please fill in both password fields!");
                    return;
                }
                if (TextBoxPassword.Text.Trim() != TextBoxConfPassword.Text.Trim())
                {
                    Notify("Passwords don't match. Please re-enter!");
                    return;
                }
                if (userDAO.EmailExists(TextBoxEmail.Text.Trim()))
                {
                    Notify("Email already exists. Please use a different email!");
                    return;
                }

                User newUser = new User
                {
                    Email = TextBoxEmail.Text.Trim(),
                    Password = TextBoxPassword.Text.Trim(),
                    Name = TextBoxName.Text.Trim(),
                    DateOfBirth = DateTime.Parse(TextBoxBirthdate.Text),
                    Phone = TextBoxPhone.Text.Trim(),
                    City = TextBoxCity.Text.Trim()
                };

                userDAO.Create(newUser);

                Response.Redirect("Login.aspx");
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
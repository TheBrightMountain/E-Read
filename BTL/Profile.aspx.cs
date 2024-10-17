using BTL.dao;
using BTL.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL
{
    public partial class Profile : System.Web.UI.Page
    {
        UserDAO UserDAO = new UserDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["UserEmail"] != null)
            {
                User user = UserDAO.Read(Session["UserEmail"].ToString());
                TextBoxEmail.Text = user.Email;
                TextBoxName.Text = user.Name;
                TextBoxBirthdate.Text = user.DateOfBirth.ToString("yyyy-MM-dd");
                TextBoxPhone.Text = user.Phone;
                TextBoxCity.Text = user.City;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            UserDAO.Delete(Session["UserEmail"].ToString());
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UserDAO userDAO = new UserDAO();
                if (string.IsNullOrEmpty(TextBoxEmail.Text) || string.IsNullOrEmpty(TextBoxName.Text) || string.IsNullOrEmpty(TextBoxBirthdate.Text) || string.IsNullOrEmpty(TextBoxPhone.Text) || string.IsNullOrEmpty(TextBoxCity.Text))
                {
                    Notify("Please fill in all the empty fields!");
                    return;
                }
                User user = userDAO.Read(Session["UserEmail"].ToString());
                User updatedUser = new User
                {
                    Email = TextBoxEmail.Text.Trim(),
                    Password = user.Password,
                    Name = TextBoxName.Text.Trim(),
                    DateOfBirth = DateTime.Parse(TextBoxBirthdate.Text),
                    Phone = TextBoxPhone.Text.Trim(),
                    City = TextBoxCity.Text.Trim(),
                    Role = user.Role
                };
                userDAO.Update(updatedUser);
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
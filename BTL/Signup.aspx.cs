using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email = @Email", con))
                    {
                        cmd.Parameters.AddWithValue("@Email", TextBoxEmail.Text.Trim());
                        con.Open();
                        int emailCount = (int)cmd.ExecuteScalar();
                        con.Close();
                        if (emailCount > 0)
                        {
                            Notify("Email already exists. Please use a different email!");
                            return;
                        }
                    }
                }
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (Email, PasswordHash, Name, DateOfBirth, Phone, City) VALUES (@Email, @PasswordHash, @Name, @DateOfBirth, @Phone, @City)", con))
                    {
                        var passwordHasher = new PasswordHasher<object>();
                        string passwordHash = passwordHasher.HashPassword(null, TextBoxPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", TextBoxEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        cmd.Parameters.AddWithValue("@Name", TextBoxName.Text.Trim());
                        cmd.Parameters.AddWithValue("@DateOfBirth", DateTime.Parse(TextBoxBirthdate.Text));
                        cmd.Parameters.AddWithValue("@Phone", TextBoxPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@City", TextBoxCity.Text.Trim());
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("Login.aspx");
                    }
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
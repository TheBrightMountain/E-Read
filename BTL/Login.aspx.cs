using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL
{
    public partial class Login : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBoxEmail.Text) || string.IsNullOrEmpty(TextBoxPassword.Text))
                {
                    Notify("Please fill in both email and password fields!");
                    return;
                }

                string email = TextBoxEmail.Text.Trim();
                string enteredPassword = TextBoxPassword.Text.Trim();
                string storedPasswordHash = null;
                string name = null;

                // Retrieve the stored password hash from the database
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT PasswordHash, Name FROM Users WHERE Email = @Email", con))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            storedPasswordHash = reader["PasswordHash"].ToString();
                            name = reader["Name"].ToString();
                        }
                        else
                        {
                            Notify("Invalid email or password.");
                            return;
                        }
                    }
                }

                // Create a PasswordHasher instance
                var passwordHasher = new PasswordHasher<object>();

                // Verify the entered password against the stored hash
                var verificationResult = passwordHasher.VerifyHashedPassword(null, storedPasswordHash, enteredPassword);

                if (verificationResult == PasswordVerificationResult.Success)
                {
                    // Password match, login successful
                    Session["UserEmail"] = email; // Store user info in session
                    Session["UserName"] = name;
                    Response.Redirect("Home.aspx"); // Redirect to dashboard or home page
                }
                else
                {
                    // Password does not match
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
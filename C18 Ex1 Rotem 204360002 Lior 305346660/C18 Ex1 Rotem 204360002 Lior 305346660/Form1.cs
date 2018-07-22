using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;


namespace C18_Ex1_Rotem_204360002_Lior_305346660
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        User m_LoggedInUser;

        private void loginAndInit()
        {
            /// Owner: design.patterns

            /// Use the FacebookService.Login method to display the login form to any user who wish to use this application.
            /// You can then save the result.AccessToken for future auto-connect to this user:
            LoginResult result = FacebookService.Login("229517584351841", /// (desig patter's "Design Patterns Course App 2.4" app)
                "public_profile"
                );
               
            // These are NOT the complete list of permissions. Other permissions for example:
            // "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            // The documentation regarding facebook login and permissions can be found here: 
            // https://developers.facebook.com/docs/facebook-login/permissions#reference


            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_LoggedInUser = result.LoggedInUser;
                fetchUserInfo();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }

        private void fetchUserInfo()
        {
            pictureBox1.LoadAsync(m_LoggedInUser.PictureNormalURL);
            //if (m_LoggedInUser.Posts.Count > 0)
            //{
            //    textBoxStatus.Text = m_LoggedInUser.Posts[0].Message;
            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

       
    }
}

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
    public partial class FormApp : Form
    {
        public FormApp()
        {


               InitializeComponent();
               m_Appsettings = Appsettings.LoadFromFile();
               this.StartPosition = FormStartPosition.Manual;
               this.Size = m_Appsettings.LastWindowSize; 
               this.Location = m_Appsettings.LastwindowLocation;
               this.rememberMecheckBox.Checked = m_Appsettings.RememberMe;          
        }

          private readonly Appsettings m_Appsettings;
          private User m_LoggedInUser;
          private LoginResult m_loginResult;

          protected override void OnShown(EventArgs e)
          {
               if (m_Appsettings.RememberMe && !string.IsNullOrEmpty(m_Appsettings.lastAccesToken))
               {
                    m_loginResult = FacebookService.Connect(m_Appsettings.lastAccesToken);
                    m_LoggedInUser = m_loginResult.LoggedInUser;
                    fetchUserInfo();
               }
          }

          protected override void OnFormClosing(FormClosingEventArgs e)
          {              
               m_Appsettings.LastwindowLocation = this.Location;
               m_Appsettings.LastWindowSize = this.Size;
               m_Appsettings.RememberMe = this.rememberMecheckBox.Checked;
               if (this.rememberMecheckBox.Checked)
               {
                    m_Appsettings.lastAccesToken = m_loginResult.AccessToken;
               }
               else
               {
                    m_Appsettings.lastAccesToken = null;
               }

               m_Appsettings.SavetoFile();
          }

          private void loginAndInit()
        {
               /// Owner: design.patterns

               /// Use the FacebookService.Login method to display the login form to any user who wish to use this application.
               /// You can then save the result.AccessToken for future auto-connect to this user:
               m_loginResult = FacebookService.Login("229517584351841", /// (desig patter's "Design Patterns Course App 2.4" app)
                "public_profile");
            // These are NOT the complete list of permissions. Other permissions for example:
            // "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            // The documentation regarding facebook login and permissions can be found here: 
            // https://developers.facebook.com/docs/facebook-login/permissions#reference


            if (!string.IsNullOrEmpty(m_loginResult.AccessToken))
            {
                m_LoggedInUser = m_loginResult.LoggedInUser;
                fetchUserInfo();
            }
            else
            {
                MessageBox.Show(m_loginResult.ErrorMessage);
            }
        }

        private void fetchUserInfo()
        {
            profilePicture.LoadAsync(m_LoggedInUser.PictureNormalURL);
            //if (m_LoggedInUser.Posts.Count > 0)
            //{
            //    textBoxStatus.Text = m_LoggedInUser.Posts[0].Message;
            //}
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }        
    }
}

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
using System.Runtime.InteropServices;
using System.Web;
using Facebook;

namespace C18_Ex1_Rotem_204360002_Lior_305346660
{
    public partial class FormApp : Form
    {
        public FormApp()
        {
            InitializeComponent();
           
            //m_Appsettings = Appsettings.LoadFromFile();
            //this.StartPosition = FormStartPosition.Manual;
            //this.Size = m_Appsettings.LastWindowSize; 
            //this.Location = m_Appsettings.LastwindowLocation;
            //this.rememberMecheckBox.Checked = m_Appsettings.RememberMe; 

        }

        //  private readonly Appsettings m_Appsettings;
        private User m_LoggedInUser;
        private LoginResult m_loginResult;


        //  protected override void OnShown(EventArgs e)
        //  {
        //    if (m_Appsettings.RememberMe && !string.IsNullOrEmpty(m_Appsettings.lastAccesToken))
        //    {
        //        m_loginResult = FacebookService.Connect(m_Appsettings.lastAccesToken);
        //        m_LoggedInUser = m_loginResult.LoggedInUser;
        //        fetchUserInfo();
        //    }
        //}

        //  protected override void OnFormClosing(FormClosingEventArgs e)
        //  {              
        //       m_Appsettings.LastwindowLocation = this.Location;
        //       m_Appsettings.LastWindowSize = this.Size;
        //       m_Appsettings.RememberMe = this.rememberMecheckBox.Checked;
        //       if (this.rememberMecheckBox.Checked)
        //       {
        //            m_Appsettings.lastAccesToken = m_loginResult.AccessToken;
        //       }
        //       else
        //       {
        //            m_Appsettings.lastAccesToken = null;
        //       }

        //       m_Appsettings.SavetoFile();
        //  }

        private void loginAndInit()
        {
            /// Owner: design.patterns

            /// Use the FacebookService.Login method to display the login form to any user who wish to use this application.
            /// You can then save the result.AccessToken for future auto-connect to this user:
            m_loginResult = FacebookService.Login("229517584351841", /// (desig patter's "Design Patterns Course App 2.4" app)
             "public_profile",
             "user_birthday",
             "user_friends",
             "user_events",
             //"user_groups" (This permission is only available for apps using Graph API version v2.3 or older.)
             "user_hometown",
             "user_likes",
             "user_location",
             "user_photos",
             "user_posts",

             //"user_status" (This permission is only available for apps using Graph API version v2.3 or older.)
             "user_tagged_places",
             "user_videos",
             // "read_mailbox", (This permission is only available for apps using Graph API version v2.3 or older.)
             "read_page_mailboxes",
             // "read_stream", (This permission is only available for apps using Graph API version v2.3 or older.)
             // "manage_notifications", (This permission is only available for apps using Graph API version v2.3 or older.)
             "manage_pages",
             "publish_pages",
             //---JUST FOR TESTING---//
             "user_education_history",
             "user_actions.video",
             "user_actions.news",
             "user_actions.music",
             "user_about_me",
             "publish_actions",
             "user_games_activity",
             "user_managed_groups",
             "user_relationships",
             "user_relationship_details",
             "user_religion_politics",
             "user_website",
             "user_work_history",
             "read_custom_friendlists",
             "rsvp_event"
             //------------------//
             );
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

       

        private void button1_Click(object sender, EventArgs e)
        {

            fetchFriends();
            fetchPosts();

        }

        private void fetchFriends()
        {
            listBox1.Items.Clear();
            listBox1.DisplayMember = "Name";
            foreach (User friend in m_LoggedInUser.Friends)
            {
                listBox1.Items.Add(friend);
                friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
            }

            if (m_LoggedInUser.Friends.Count == 0)
            {
                MessageBox.Show("No Friends to retrieve :(");
            }
        }

        private void fetchPosts()
        {
            foreach (Post post in m_LoggedInUser.Posts)
            {
                if (post.Message != null)
                {
                    listBox1.Items.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                    listBox1.Items.Add(post.Caption);
                }
                else
                {
                    listBox1.Items.Add(string.Format("[{0}]", post.Type));
                }
            }

            if (m_LoggedInUser.Posts.Count == 0)
            {
                MessageBox.Show("No Posts to retrieve :(");
            }
        }

        private void fetchFrienInfo(int i_RandomFriend)
        {
            string birthDayUser = m_LoggedInUser.Friends[i_RandomFriend].Birthday;
            string genderUser = m_LoggedInUser.Friends[i_RandomFriend].Gender.ToString();
            string IDUser = m_LoggedInUser.Friends[i_RandomFriend].Id;
            friendsInfoTextBox.Text = string.Format("{0} BirthDay {1}\n{0} Gender: {2}\n{0} ID: {3}", m_LoggedInUser.Friends[i_RandomFriend].FirstName,
                birthDayUser, genderUser, IDUser);
        }

      

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    fetchPages();
        //}



        private void buttonSetStatus_Click_1(object sender, EventArgs e)
        {
            Status postedStatus = m_LoggedInUser.PostStatus(textBoxStatus.Text);
            MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            FacebookService.Logout(cleanProfilePic);
        }


        private void cleanProfilePic()
        {
            profilePicture.Image = null;
            profilePicture.Image = m_LoggedInUser.Friends[0].ImageNormal;
        }

        private void showInfoButton_Click(object sender, EventArgs e)
        {
            string birthDayUser = m_LoggedInUser.Birthday;
            string genderUser = m_LoggedInUser.Gender.ToString();
            string IDUser = m_LoggedInUser.Id;
            User.eRelationshipStatus? relationshipStatusUser = m_LoggedInUser.RelationshipStatus;
            UserInfoTextBox.Text = string.Format("{0} BirthDay {1}\n{0} Gender: {2}\n{0} ID: {3}\n{0} Relationship: {4}", m_LoggedInUser.FirstName,
                birthDayUser, genderUser, IDUser, relationshipStatusUser);           
        }

        private void pictureBoxRandomFriendProfilePic_Click(object sender, EventArgs e)
        {
             Random randomPic = new Random();
            int ran = randomPic.Next(0, m_LoggedInUser.Friends.Count);
            if (m_LoggedInUser.Friends.Count > 0)
            {
                pictureBoxRandomFriendProfilePic.Image = m_LoggedInUser.Friends[ran].ImageNormal;
                fetchFrienInfo(ran);
            }
            else
            {
                MessageBox.Show("No Friends to retrieve :(");
            }
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    albumlistBox.Items.Clear();
        //    albumlistBox.DisplayMember = "Name";
        //    foreach (Album album in m_LoggedInUser.Albums)
        //    {
        //        albumlistBox.Items.Add(album);
        //        //album.ReFetch(DynamicWrapper.eLoadOptions.Full);
        //    }

        //    if (m_LoggedInUser.Albums.Count == 0)
        //    {
        //        MessageBox.Show("No Album to retrieve :(");
        //    }
        //}

        //private void albumlistBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int i = 0;
        //    foreach(Album photo in m_LoggedInUser.Albums)
        //    {
               
        //        PictureBox pic = new PictureBox();
        //        pic.Image = photo.Photos.ImageNormal;
        //        pic.Location = new Point(1440 + i, 805);
        //        pic.Size = new Size(100,100);
        //        i += 110;
        //    }
        //}

       
    }
}

using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using Facebook;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace C18_Ex1_Rotem_204360002_Lior_305346660
{
    public partial class FaceApp : Form
    {
        private readonly Appsettings r_Appsettings;
        private List<string> m_FriendsFromFile;
        private User m_LoggedInUser;
        private LoginResult m_loginResult;
        private List<Image> m_friendImeges = new List<Image>();
        private string m_welcomLabelMassage;

        public FaceApp()
        {
            int h = Screen.PrimaryScreen.WorkingArea.Height;
            int w = Screen.PrimaryScreen.WorkingArea.Width;
            this.ClientSize = new Size(w, h);
            InitializeComponent();
            r_Appsettings = Appsettings.LoadFromFile();
            setFormSize();
        }

        private void setFormSize()
        {
            this.rememberMecheckBox.Checked = r_Appsettings.RememberMe;
            if (this.rememberMecheckBox.Checked)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Size = r_Appsettings.LastWindowSize;
                this.Location = r_Appsettings.LastwindowLocation;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            if (r_Appsettings.RememberMe && !string.IsNullOrEmpty(r_Appsettings.LastAccesToken))
            {
                m_loginResult = FacebookService.Connect(r_Appsettings.LastAccesToken);
                m_LoggedInUser = m_loginResult.LoggedInUser;
                fetchUserInfo();
                m_welcomLabelMassage = string.Format("Welcome back\n{0}", m_LoggedInUser.Name);
                welcomLabel.Text = m_welcomLabelMassage;
            }
        }
      
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            r_Appsettings.LastwindowLocation = this.Location;
            r_Appsettings.LastWindowSize = this.Size;
            r_Appsettings.RememberMe = this.rememberMecheckBox.Checked;
            if (this.rememberMecheckBox.Checked && m_LoggedInUser != null)
            {
                r_Appsettings.LastAccesToken = m_loginResult.AccessToken;
            }
            else
            {
                r_Appsettings.LastAccesToken = null;
            }

            r_Appsettings.SavetoFile();
        }

        private void loginAndInit()
        {
            m_loginResult = FacebookService.Login(
             "229517584351841",
             "public_profile",
             "user_birthday",
             "user_friends",
             "user_events",
             "user_hometown",
             "user_likes",
             "user_location",
             "user_photos",
             "user_posts",
             "user_tagged_places",
             "user_videos",
             "read_page_mailboxes",
             "manage_pages",
             "publish_pages",
             "user_education_history", //---JUST FOR TESTING---//
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
             "rsvp_event");
             
            if (!string.IsNullOrEmpty(m_loginResult.AccessToken))
            {
                m_LoggedInUser = m_loginResult.LoggedInUser;
                fetchUserInfo();
            }
            else
            {
                try
                {
                    MessageBox.Show(m_loginResult.ErrorMessage);
                }
                catch (Exception)
                {
                    MessageBox.Show("User without permition... :-(\n Please Login again");
                    logout();
                }
            }
        }

        private void fetchUserInfo()
        {
            profilePicture.LoadAsync(m_LoggedInUser.PictureLargeURL);
            saveFriendsProfilePics();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            loginAndInit();
            if (m_LoggedInUser != null)
            {
                saveFriendsToFile();
                m_welcomLabelMassage = string.Format("Welcome\n{0}", m_LoggedInUser.Name);
                welcomLabel.Text = m_welcomLabelMassage;
            }
        }

        private void buttonFetchPosts_Click(object sender, EventArgs e)
        {
            if (m_LoggedInUser != null)
            {
                fetchPosts();
            }
        }
  
        private void fetchPosts()
        {
            foreach (Post post in m_LoggedInUser.Posts)
            {
                if (post.Message != null)
                {
                    lastPostsListBox.Items.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                    lastPostsListBox.Items.Add(post.Caption);
                }
                else
                {
                    lastPostsListBox.Items.Add(string.Format("[{0}]", post.Type));
                }
            }

            if (m_LoggedInUser.Posts.Count == 0)
            {
                MessageBox.Show("No Posts to retrieve :(");
            }
        }
     
        private void buttonSetStatus_Click(object sender, EventArgs e)
        {
            if (m_LoggedInUser != null)
            {
                Status postedStatus = m_LoggedInUser.PostStatus(textBoxStatus.Text);
                MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void logout()
        {
            if (m_LoggedInUser != null || m_loginResult != null)
            {
                FacebookService.Logout(cleanProfilePic);
            }
        }

        private void cleanProfilePic()
        {
            profilePicture.Image = null;
            m_LoggedInUser = null;
            this.rememberMecheckBox.Checked = false;
            UserInfoTextBox.Clear();
            friendsInfoTextBox.Clear();
            lastPostsListBox.Items.Clear();
            pictureBoxRandomFriendProfilePic.Image = null;
            welcomLabel.Text = string.Empty;
        }

        private void showInfoButton_Click(object sender, EventArgs e)
        {
            if (m_LoggedInUser != null)
            {
                string birthDayUser = m_LoggedInUser.Birthday;
                string genderUser = m_LoggedInUser.Gender.ToString();
                string IDUser = m_LoggedInUser.Id;
                UserInfoTextBox.Text = string.Format("{0} BirthDay {1}\n{0} Gender: {2}\n{0} ID: {3}", m_LoggedInUser.FirstName, birthDayUser, genderUser, IDUser);                 
            }
        }

        // --- Lottery friens fetcher
        private void pictureBoxRandomFriendProfilePic_Click(object sender, EventArgs e)
        {
            pictureRandom();
        }

        private void pictureRandom()
        {
            friendsInfoTextBox.Clear();
            timerForLotteryFriends.Enabled = false;
            Random randomPic = new Random();
            if (m_LoggedInUser == null)
            {
                MessageBox.Show("Connect with your FACEBOOK user first!");
            }
            else
            {
                timerForLotteryFriends.Enabled = true;
                if (m_LoggedInUser.Friends.Count > 0)
                {
                    timerHelper.Enabled = true;
                    pictureBoxRandomFriendProfilePic.Enabled = false;
                    timerForLotteryFriends.Interval = 10;
                    timerForLotteryFriends.Start();
                    timerHelper.Start();
                }
                else
                {
                    MessageBox.Show("No Friends to retrieve :(");
                }
            }
        }

        private void timerForLotteryFriends_Tick(object sender, EventArgs e)
        {
            Random randomPic = new Random();
            int ran = 0;
            ran = randomPic.Next(0, m_LoggedInUser.Friends.Count);
            pictureBoxRandomFriendProfilePic.Image = m_friendImeges[ran];
            if (timerForLotteryFriends.Interval >= 500)
            {
                timerForLotteryFriends.Stop();
                timerHelper.Stop();
                timerHelper.Enabled = false;
                pictureBoxRandomFriendProfilePic.Enabled = true;
                fetchFriendInfo(ran);
            }
        }

        private void timerHelper_Tick(object sender, EventArgs e)
        {
            timerForLotteryFriends.Interval += 100;
        }

        private void fetchFriendInfo(int i_RandomFriend)
        {
            if (m_LoggedInUser != null)
            {
                string birthDayUser = m_LoggedInUser.Friends[i_RandomFriend].Birthday;
                string genderUser = m_LoggedInUser.Friends[i_RandomFriend].Gender.ToString();
                string IDUser = m_LoggedInUser.Friends[i_RandomFriend].Id;
                friendsInfoTextBox.Text = string.Format("{4}\n{0} Birthday: {1}\n{0} Gender: {2}\n{0} ID: {3}", m_LoggedInUser.Friends[i_RandomFriend].FirstName, birthDayUser, genderUser, IDUser, m_LoggedInUser.Friends[i_RandomFriend].Name);
            }
        }
        // -------------------------------------//

        // --Unfiend fetcher
        private void saveFriendsProfilePics()
        {
            foreach (User friend in m_LoggedInUser.Friends)
            {
                m_friendImeges.Add(friend.ImageNormal);
            }
        }

        private void buttonCheckLeftFriends_Click(object sender, EventArgs e)
        {
            if (m_LoggedInUser != null)
            {
                loadfriendfromfile();
                List<string> AllfriendsNames = new List<string>();

                foreach (User friend in m_LoggedInUser.Friends)
                {
                    AllfriendsNames.Add(friend.Name);
                }

                var missingFriends = m_FriendsFromFile.Except(AllfriendsNames);
                if (missingFriends.Count<string>() > 0)
                {
                    //////////someone in the friendlist had left
                    MessageBox.Show("someone in the friend list had left :(");
                }
                else
                {
                    MessageBox.Show("no one has left your friend list :)");
                }
            }
        }

        private void loadfriendfromfile()
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            using (Stream stram = new FileStream(path + string.Format(@"\Friends of {0}.xml", m_LoggedInUser.Name), FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                m_FriendsFromFile = serializer.Deserialize(stram) as List<string>;
            }

            saveFriendsProfilePics();
        }

        private void saveFriendsToFile()
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (!File.Exists(string.Format(path + string.Format(@"Friends of {0}.xml", m_LoggedInUser.Name))))
            {
                using (Stream stram = new FileStream(path + string.Format(@"\Friends of {0}.xml", m_LoggedInUser.Name), FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                    List<string> friends = new List<string>();

                    foreach (User friend in m_LoggedInUser.Friends)
                    {
                        friends.Add(friend.Name);
                    }

                    serializer.Serialize(stram, friends);
                }
            }
        }

        //---------------------------------//
    }
}
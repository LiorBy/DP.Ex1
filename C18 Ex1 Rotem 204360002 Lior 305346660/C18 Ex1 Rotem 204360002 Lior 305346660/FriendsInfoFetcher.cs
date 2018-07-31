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
using Facebook;
using System.Xml.Serialization;

namespace C18_Ex1_Rotem_204360002_Lior_305346660
{
    public class FriendsInfoFetcher
    {
        private User m_LoggedInUser { get; set; }
        private LoginResult m_loginResult { get; set; }
        private string m_FriendData { get; set; }

        //public FriendsInfoFetcher(User i_LoggedInUser)
        //{
        //    if(i_LoggedInUser == null)
        //    {
        //        m_LoggedInUser = null;
        //    }
        //    else
        //    {
        //        m_LoggedInUser = i_LoggedInUser;
        //    }
        //    createUserDateStr
        //}

        //private void fetchFriendInfo(int i_RandomFriend)
        //{
        //    if (m_LoggedInUser != null)
        //    {
        //        string birthDayUser = m_LoggedInUser.Friends[i_RandomFriend].Birthday;
        //        string genderUser = m_LoggedInUser.Friends[i_RandomFriend].Gender.ToString();
        //        string IDUser = m_LoggedInUser.Friends[i_RandomFriend].Id;
        //        m_FriendData = string.Format("{0} BirthDay {1}\n{0} Gender: {2}\n{0} ID: {3}", m_LoggedInUser.Friends[i_RandomFriend].FirstName,
        //            birthDayUser, genderUser, IDUser);
        //    }
        //}

        //private void pictureBoxRandomFriendProfilePic_Click(object sender, EventArgs e)
        //{
        //        Random randomFriendlo = new Random();
        //        int ran = randomPic.Next(0, m_LoggedInUser.Friends.Count);
        //        if (m_LoggedInUser.Friends.Count > 0)
        //        {

        //            pictureBoxRandomFriendProfilePic.Image = m_LoggedInUser.Friends[ran].ImageNormal;
        //            fetchFriendInfo(ran);
        //        }
        //        else
        //        {
        //            MessageBox.Show("No Friends to retrieve :(");
        //        }
        //    }
        //}
    }
}

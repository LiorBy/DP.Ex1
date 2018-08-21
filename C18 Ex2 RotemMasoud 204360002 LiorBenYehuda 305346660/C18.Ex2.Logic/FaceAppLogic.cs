using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace C18.Ex2.Logic
{
     public class FaceAppLogic
     {      
          public User loggedInUser { get; set; }   
          
          public FaceAppLogic()
          {

          }

          internal IEnumerable<string> compareFriends(List<string> i_FriendsFromFile)
          {
               List<string> AllfriendsNames = new List<string>();

               foreach (User friend in loggedInUser.Friends)
               {
                    AllfriendsNames.Add(friend.Name);
               }

              IEnumerable<string> missingFriends = i_FriendsFromFile.Except(AllfriendsNames);

               return missingFriends;
          }    
     }
}

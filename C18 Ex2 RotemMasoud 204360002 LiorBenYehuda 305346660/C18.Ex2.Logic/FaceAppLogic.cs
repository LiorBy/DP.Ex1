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

          private readonly string r_Path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
          private List<string> m_FriendsFromFile;
          public User loggedInUser { get; set; }   
          
          public FaceAppLogic()
          {

          }

          internal IEnumerable<string> compareFriends()
          {
               List<string> AllfriendsNames = new List<string>();

               foreach (User friend in loggedInUser.Friends)
               {
                    AllfriendsNames.Add(friend.Name);
               }

              IEnumerable<string> missingFriends = m_FriendsFromFile.Except(AllfriendsNames);

               return missingFriends;
          }

          internal void updateFriendsToFile()
          {
               using (Stream stram = new FileStream(r_Path + string.Format(@"\Friends of {0}.xml", loggedInUser.Name), FileMode.Create))
               {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                    List<string> friends = new List<string>();

                    foreach (User friend in loggedInUser.Friends)
                    {
                         friends.Add(friend.Name);
                    }

                    serializer.Serialize(stram, friends);
               }
          }

          internal void loadfriendfromfile()
          {
               using (Stream stram = new FileStream(r_Path + string.Format(@"\Friends of {0}.xml", loggedInUser.Name), FileMode.Open))
               {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                    m_FriendsFromFile = serializer.Deserialize(stram) as List<string>;
               }

               //SaveFriendsProfilePics();
          }

          public void SaveFriendsToFile()
          {
               if (!File.Exists(string.Format(r_Path + string.Format(@"\Friends of {0}.xml", loggedInUser.Name))))
               {
                    updateFriendsToFile();
               }
          }
         
     }
}

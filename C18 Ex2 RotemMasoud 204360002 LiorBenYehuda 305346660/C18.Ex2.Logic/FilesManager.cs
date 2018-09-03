using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace C18.Ex2.Logic
{
     public sealed class FilesManager
     { 
          private static readonly object sr_padlock = new object();
          private static FilesManager s_FilesManager = null;
          private readonly string r_Path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

          private FilesManager()
          {
          }

          public static FilesManager GetInstance()
          {
               string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

               if (s_FilesManager == null)
               {
                    lock (sr_padlock)
                    {
                         if (s_FilesManager == null)
                         {
                                   s_FilesManager = new FilesManager();                         
                         }
                    }
               }

               return s_FilesManager;
          }

          internal void updateFriendsToFile(User i_LoggedInUser)
          {
               using (Stream stram = new FileStream(r_Path + string.Format(@"\Friends of {0}.xml", i_LoggedInUser.Name), FileMode.Create))
               {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                    List<string> friends = new List<string>();

                    foreach (User friend in i_LoggedInUser.Friends)
                    {
                         friends.Add(friend.Name);
                    }

                    serializer.Serialize(stram, friends);
               }
          }

          internal List<string> loadfriendfromfile(User i_LoggedInUser)
          {
               using (Stream stram = new FileStream(r_Path + string.Format(@"\Friends of {0}.xml", i_LoggedInUser.Name), FileMode.Open))
               {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                    List<string> m_FriendsFromFile = serializer.Deserialize(stram) as List<string>;

                    return m_FriendsFromFile;
               }

               ///SaveFriendsProfilePics();
          }

          public void SaveFriendsToFile(User i_LoggedInUser)
          {
               if (!File.Exists(string.Format(r_Path + string.Format(@"\Friends of {0}.xml", i_LoggedInUser.Name))))
               {
                    updateFriendsToFile(i_LoggedInUser);
               }
          }
     }
}

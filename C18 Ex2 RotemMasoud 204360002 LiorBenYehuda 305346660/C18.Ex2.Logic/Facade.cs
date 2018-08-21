using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C18.Ex2.Logic
{
     public class Facade
     {
          private readonly FaceAppLogic logic;

          public Facade(FaceAppLogic i_FaceAppLogic)
          {
               logic = i_FaceAppLogic;
          }
          private List<string> m_FriendsFromFile;

          public bool CheckLeftFriends()
          {
               bool isFriendLeft = false;

               if (logic.loggedInUser != null)
               {
                    m_FriendsFromFile = FilesManager.GetInstance().loadfriendfromfile(logic.loggedInUser);
                    IEnumerable<string> missingFriends = logic.compareFriends(m_FriendsFromFile);

                    if (missingFriends.Count<string>() > 0)
                    {
                         //////////someone in the friendlist had left
                         isFriendLeft = true;
                         FilesManager.GetInstance().updateFriendsToFile(logic.loggedInUser);
                    }

               }

                    return isFriendLeft;
            }

     }
}

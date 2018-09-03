using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

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

          public MissingFriends CheckLeftFriends()
          {
               MissingFriends currentFriends = new MissingFriends();

               if (logic.loggedInUser != null)
               {
                    m_FriendsFromFile = FilesManager.GetInstance().loadfriendfromfile(logic.loggedInUser);
                    currentFriends.missingFriends = logic.compareFriends(m_FriendsFromFile);

                    if (currentFriends.missingFriends.Count<string>() > 0)
                    {
                         //////////someone in the friendlist had left
                         FilesManager.GetInstance().updateFriendsToFile(logic.loggedInUser);
                    }                 
               }

                    return currentFriends;
            }
     }
}

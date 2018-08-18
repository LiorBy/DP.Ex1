using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C18.Ex2.Logic
{
     public class Facade
     {
          FaceAppLogic logic = new FaceAppLogic();

          public bool CheckLeftFriends()
          {
               bool isFriendLeft = false;

               if (logic.loggedInUser != null)
               {
                    logic.loadfriendfromfile();
                    IEnumerable<string> missingFriends = logic.compareFriends();

                    if (missingFriends.Count<string>() > 0)
                    {
                         //////////someone in the friendlist had left
                         isFriendLeft = true;
                         logic.updateFriendsToFile();
                    }

               }

                    return isFriendLeft;
            }

     }
}

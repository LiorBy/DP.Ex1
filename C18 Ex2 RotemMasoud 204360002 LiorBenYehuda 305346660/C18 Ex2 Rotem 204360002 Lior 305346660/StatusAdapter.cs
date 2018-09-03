using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace C18_Ex1_Rotem_204360002_Lior_305346660
{
     public class StatusAdapter : IStatus
     {
          public User user { get; set; }

          public List<Status> PostStatuses(List<string> i_StatusText)
          {
               List<Status> statuses = new List<Status>();
               foreach(string statusText in i_StatusText)
               {
                   statuses.Add(user.PostStatus(statusText));
               }

               return statuses;
          }
     }
}

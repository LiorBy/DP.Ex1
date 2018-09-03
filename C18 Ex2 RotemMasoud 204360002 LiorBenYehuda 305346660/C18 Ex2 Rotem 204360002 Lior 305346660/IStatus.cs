using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace C18_Ex1_Rotem_204360002_Lior_305346660
{
     internal interface IStatus
     {
          List<Status> PostStatuses(List<string> i_StatusText);
     }
}
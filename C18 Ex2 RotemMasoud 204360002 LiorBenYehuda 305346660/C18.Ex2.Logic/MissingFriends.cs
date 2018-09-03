using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C18.Ex2.Logic
{
     public class MissingFriends : IEnumerable<string>
     {       
          public IEnumerable<string> missingFriends { get; set; }

          public IEnumerator<string> GetEnumerator()
          {
               return missingFriends.GetEnumerator();
          }

          IEnumerator IEnumerable.GetEnumerator()
          {
              return GetEnumerator();
          }
     }
}

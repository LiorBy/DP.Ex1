using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace C18_Ex1_Rotem_204360002_Lior_305346660
{
     public sealed class Appsettings
     {

          private static Appsettings s_Appsettings = null;
          private static readonly object padlock = new object();
          public Point LastwindowLocation { get; set; }
          public Size LastWindowSize { get; set; }
          public bool RememberMe { get; set; }
          public string lastAccesToken { get; set; }

          private Appsettings()
          {
               LastwindowLocation = new Point(50, 50);
               LastWindowSize = new Size(1000, 500);
               RememberMe = false;
               lastAccesToken = null;
          }

          public void SavetoFile()
          {
               using (Stream stram = new FileStream(@"E:\Appsetting.xml", FileMode.Truncate))
               {
                    XmlSerializer serializer = new XmlSerializer(this.GetType());
                    serializer.Serialize(stram, this);
               }
          }

          public static Appsettings LoadFromFile()
          {
             
               if (s_Appsettings==null)
               {

                    lock (padlock)
                    {
                         if (s_Appsettings == null)
                         {
                              using (Stream stram = new FileStream(@"E:\Appsetting.xml", FileMode.Open))
                              {
                                   XmlSerializer serializer = new XmlSerializer(typeof(Appsettings));
                                   s_Appsettings = serializer.Deserialize(stram) as Appsettings;
                              }
                         }
                    }
               }
               
               return s_Appsettings;
          }
     }
}

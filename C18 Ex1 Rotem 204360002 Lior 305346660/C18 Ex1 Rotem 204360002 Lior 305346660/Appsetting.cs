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
          private static readonly object sr_padlock = new object();    
          private static Appsettings s_Appsettings = null;

          public Point m_LastwindowLocation { get; set; }

          public Size m_LastWindowSize { get; set; }

          public bool m_RememberMe { get; set; }

          public string m_LastAccesToken { get; set; }

          private Appsettings()
          {
               m_LastwindowLocation = new Point(50, 50);
               m_LastWindowSize = new Size(1000, 500);
               m_RememberMe = false;
               m_LastAccesToken = null;
          }

          public static Appsettings LoadFromFile()
          {
               string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

               if (s_Appsettings == null)
               {
                    lock (sr_padlock)
                    {
                         if (s_Appsettings == null)
                         {
                              if (File.Exists(path + @"\Appsetting.xml"))
                              {
                                   using (Stream stram = new FileStream(path + @"\Appsetting.xml", FileMode.Open))
                                   {
                                        XmlSerializer serializer = new XmlSerializer(typeof(Appsettings));
                                        s_Appsettings = serializer.Deserialize(stram) as Appsettings;
                                   }
                              }
                              else
                              {
                                   s_Appsettings = new Appsettings();
                              }                         
                         }
                    }
               }
               
               return s_Appsettings;
          }

          public void SavetoFile()
          {
              string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

               using (Stream stram = new FileStream(path + @"\Appsetting.xml", FileMode.Create))
               {
                    XmlSerializer serializer = new XmlSerializer(this.GetType());
                    serializer.Serialize(stram, this);
               }
          }         
     }
}

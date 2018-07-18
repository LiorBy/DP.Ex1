using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Facebook;
using FacebookWrapper;

using System.Windows.Forms;

namespace C18_Ex1_Rotem_204360002_Lior_305346660
{
    public partial class FormApp : Form
    {
        public FormApp()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 200;
            FacebookWrapper.FacebookService.s_FbApiVersion = 2.8f;
        }
    }
}

using System;

namespace C18_Ex1_Rotem_204360002_Lior_305346660
{
    partial class FaceApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {   
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceApp));
            this.connectButton = new System.Windows.Forms.Button();
            this.lastPostsListBox = new System.Windows.Forms.ListBox();
            this.pictureBoxRandomFriendProfilePic = new System.Windows.Forms.PictureBox();
            this.showInfoButton = new System.Windows.Forms.Button();
            this.friendsInfoTextBox = new System.Windows.Forms.RichTextBox();
            this.UserInfoTextBox = new System.Windows.Forms.RichTextBox();
            this.LastPostsButtom = new System.Windows.Forms.Button();
            this.buttonSetStatus = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.profilePicture = new System.Windows.Forms.PictureBox();
            this.checkFriendsbutton = new System.Windows.Forms.Button();
            this.rememberMecheckBox = new System.Windows.Forms.CheckBox();
            this.timerForLotteryFriends = new System.Windows.Forms.Timer(this.components);
            this.timerHelper = new System.Windows.Forms.Timer(this.components);
            this.ClickOnTheImageLabel = new System.Windows.Forms.Label();
            this.welcomLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRandomFriendProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.PaleVioletRed;
            this.connectButton.BackgroundImage = global::C18_Ex1_Rotem_204360002_Lior_305346660.Properties.Resources._1504126420_conn;
            resources.ApplyResources(this.connectButton, "connectButton");
            this.connectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connectButton.FlatAppearance.BorderSize = 0;
            this.connectButton.Name = "connectButton";
            this.connectButton.TabStop = false;
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // lastPostsListBox
            // 
            resources.ApplyResources(this.lastPostsListBox, "lastPostsListBox");
            this.lastPostsListBox.BackColor = System.Drawing.Color.PaleVioletRed;
            this.lastPostsListBox.FormattingEnabled = true;
            this.lastPostsListBox.Name = "lastPostsListBox";
            // 
            // pictureBoxRandomFriendProfilePic
            // 
            resources.ApplyResources(this.pictureBoxRandomFriendProfilePic, "pictureBoxRandomFriendProfilePic");
            this.pictureBoxRandomFriendProfilePic.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxRandomFriendProfilePic.BackgroundImage = global::C18_Ex1_Rotem_204360002_Lior_305346660.Properties.Resources._636536002_170x170;
            this.pictureBoxRandomFriendProfilePic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRandomFriendProfilePic.Name = "pictureBoxRandomFriendProfilePic";
            this.pictureBoxRandomFriendProfilePic.TabStop = false;
            this.pictureBoxRandomFriendProfilePic.Click += new System.EventHandler(this.pictureBoxRandomFriendProfilePic_Click);
            // 
            // showInfoButton
            // 
            resources.ApplyResources(this.showInfoButton, "showInfoButton");
            this.showInfoButton.Name = "showInfoButton";
            this.showInfoButton.UseVisualStyleBackColor = true;
            this.showInfoButton.Click += new System.EventHandler(this.showInfoButton_Click);
            // 
            // friendsInfoTextBox
            // 
            resources.ApplyResources(this.friendsInfoTextBox, "friendsInfoTextBox");
            this.friendsInfoTextBox.Name = "friendsInfoTextBox";
            // 
            // UserInfoTextBox
            // 
            resources.ApplyResources(this.UserInfoTextBox, "UserInfoTextBox");
            this.UserInfoTextBox.BackColor = System.Drawing.Color.PaleVioletRed;
            this.UserInfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserInfoTextBox.Name = "UserInfoTextBox";
            // 
            // LastPostsButtom
            // 
            resources.ApplyResources(this.LastPostsButtom, "LastPostsButtom");
            this.LastPostsButtom.Name = "LastPostsButtom";
            this.LastPostsButtom.UseVisualStyleBackColor = true;
            this.LastPostsButtom.Click += new System.EventHandler(this.buttonFetchPosts_Click);
            // 
            // buttonSetStatus
            // 
            resources.ApplyResources(this.buttonSetStatus, "buttonSetStatus");
            this.buttonSetStatus.Name = "buttonSetStatus";
            this.buttonSetStatus.UseVisualStyleBackColor = true;
            this.buttonSetStatus.Click += new System.EventHandler(this.buttonSetStatus_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.PaleVioletRed;
            this.logOutButton.BackgroundImage = global::C18_Ex1_Rotem_204360002_Lior_305346660.Properties.Resources.lior_logout;
            resources.ApplyResources(this.logOutButton, "logOutButton");
            this.logOutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logOutButton.FlatAppearance.BorderSize = 0;
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.TabStop = false;
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // textBoxStatus
            // 
            resources.ApplyResources(this.textBoxStatus, "textBoxStatus");
            this.textBoxStatus.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxStatus.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxStatus.Name = "textBoxStatus";
            // 
            // profilePicture
            // 
            resources.ApplyResources(this.profilePicture, "profilePicture");
            this.profilePicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.TabStop = false;
            // 
            // checkFriendsbutton
            // 
            resources.ApplyResources(this.checkFriendsbutton, "checkFriendsbutton");
            this.checkFriendsbutton.Name = "checkFriendsbutton";
            this.checkFriendsbutton.UseVisualStyleBackColor = true;
            this.checkFriendsbutton.Click += new System.EventHandler(this.buttonCheckLeftFriends_Click);
            // 
            // rememberMecheckBox
            // 
            resources.ApplyResources(this.rememberMecheckBox, "rememberMecheckBox");
            this.rememberMecheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rememberMecheckBox.Name = "rememberMecheckBox";
            this.rememberMecheckBox.UseVisualStyleBackColor = true;
            // 
            // timerForLotteryFriends
            // 
            this.timerForLotteryFriends.Interval = 1000;
            this.timerForLotteryFriends.Tick += new System.EventHandler(this.timerForLotteryFriends_Tick);
            // 
            // timerHelper
            // 
            this.timerHelper.Interval = 1000;
            this.timerHelper.Tick += new System.EventHandler(this.timerHelper_Tick);
            // 
            // ClickOnTheImageLabel
            // 
            resources.ApplyResources(this.ClickOnTheImageLabel, "ClickOnTheImageLabel");
            this.ClickOnTheImageLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClickOnTheImageLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClickOnTheImageLabel.Name = "ClickOnTheImageLabel";
            // 
            // welcomLabel
            // 
            resources.ApplyResources(this.welcomLabel, "welcomLabel");
            this.welcomLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.welcomLabel.Name = "welcomLabel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleVioletRed;
            this.panel1.Controls.Add(this.welcomLabel);
            this.panel1.Controls.Add(this.connectButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // FaceApp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.ClickOnTheImageLabel);
            this.Controls.Add(this.profilePicture);
            this.Controls.Add(this.rememberMecheckBox);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.lastPostsListBox);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.checkFriendsbutton);
            this.Controls.Add(this.buttonSetStatus);
            this.Controls.Add(this.friendsInfoTextBox);
            this.Controls.Add(this.UserInfoTextBox);
            this.Controls.Add(this.showInfoButton);
            this.Controls.Add(this.pictureBoxRandomFriendProfilePic);
            this.Controls.Add(this.LastPostsButtom);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MinimizeBox = false;
            this.Name = "FaceApp";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRandomFriendProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        #endregion


        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ListBox lastPostsListBox;
        private System.Windows.Forms.PictureBox pictureBoxRandomFriendProfilePic;
        private System.Windows.Forms.Button showInfoButton;
        private System.Windows.Forms.RichTextBox friendsInfoTextBox;
        private System.Windows.Forms.RichTextBox UserInfoTextBox;
        private System.Windows.Forms.Button LastPostsButtom;
        private System.Windows.Forms.Button buttonSetStatus;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.PictureBox profilePicture;
        private System.Windows.Forms.Button checkFriendsbutton;
        private System.Windows.Forms.CheckBox rememberMecheckBox;
        private System.Windows.Forms.Timer timerForLotteryFriends;
        private System.Windows.Forms.Timer timerHelper;
        private System.Windows.Forms.Label ClickOnTheImageLabel;
        private System.Windows.Forms.Label welcomLabel;
        private System.Windows.Forms.Panel panel1;
    }
}


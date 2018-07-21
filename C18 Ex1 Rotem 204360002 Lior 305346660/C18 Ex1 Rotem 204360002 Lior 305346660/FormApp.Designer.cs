namespace C18_Ex1_Rotem_204360002_Lior_305346660
{
    partial class FormApp
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
               this.connectButton = new System.Windows.Forms.Button();
               this.profilePicture = new System.Windows.Forms.PictureBox();
               this.rememberMecheckBox = new System.Windows.Forms.CheckBox();
               ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
               this.SuspendLayout();
               // 
               // button1
               // 
               this.connectButton.Location = new System.Drawing.Point(5, 13);
               this.connectButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
               this.connectButton.Name = "connectButton";
               this.connectButton.Size = new System.Drawing.Size(192, 131);
               this.connectButton.TabIndex = 0;
               this.connectButton.Text = "connect";
               this.connectButton.UseVisualStyleBackColor = true;
               this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
               // 
               // pictureBox1
               // 
               this.profilePicture.Location = new System.Drawing.Point(321, 130);
               this.profilePicture.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
               this.profilePicture.Name = "profilePicture";
               this.profilePicture.Size = new System.Drawing.Size(160, 157);
               this.profilePicture.TabIndex = 1;
               this.profilePicture.TabStop = false;
               // 
               // checkBox1
               // 
               this.rememberMecheckBox.AutoSize = true;
               this.rememberMecheckBox.Location = new System.Drawing.Point(13, 166);
               this.rememberMecheckBox.Name = "rememberMecheckBox";
               this.rememberMecheckBox.Size = new System.Drawing.Size(89, 17);
               this.rememberMecheckBox.TabIndex = 2;
               this.rememberMecheckBox.Text = "remember me";
               this.rememberMecheckBox.UseVisualStyleBackColor = true;
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(521, 448);
               this.Controls.Add(this.rememberMecheckBox);
               this.Controls.Add(this.profilePicture);
               this.Controls.Add(this.connectButton);
               this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
               this.Name = "FormApp";
               this.Text = "FormApp";
               ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.PictureBox profilePicture;
          private System.Windows.Forms.CheckBox rememberMecheckBox;
     }
}


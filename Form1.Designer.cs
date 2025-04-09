namespace TutorLab
{
    partial class tutorCheckIn
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
            this.studentIdTextBox = new System.Windows.Forms.TextBox();
            this.studentIdLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.supportButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.extraLabel = new System.Windows.Forms.Label();
            this.nameResultLabel = new System.Windows.Forms.Label();
            this.extraCreditLabel = new System.Windows.Forms.Label();
            this.studentNumLabel = new System.Windows.Forms.Label();
            this.studentLabel = new System.Windows.Forms.Label();
            this.databaseButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studentIdTextBox
            // 
            this.studentIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.studentIdTextBox.Location = new System.Drawing.Point(149, 56);
            this.studentIdTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.studentIdTextBox.Name = "studentIdTextBox";
            this.studentIdTextBox.Size = new System.Drawing.Size(298, 20);
            this.studentIdTextBox.TabIndex = 0;
            // 
            // studentIdLabel
            // 
            this.studentIdLabel.AutoSize = true;
            this.studentIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentIdLabel.Location = new System.Drawing.Point(53, 56);
            this.studentIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.studentIdLabel.Name = "studentIdLabel";
            this.studentIdLabel.Size = new System.Drawing.Size(88, 18);
            this.studentIdLabel.TabIndex = 1;
            this.studentIdLabel.Text = "Student Id:";
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(94, 232);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(146, 33);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // supportButton
            // 
            this.supportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supportButton.Location = new System.Drawing.Point(399, 232);
            this.supportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.supportButton.Name = "supportButton";
            this.supportButton.Size = new System.Drawing.Size(146, 33);
            this.supportButton.TabIndex = 3;
            this.supportButton.Text = "Contact Support";
            this.supportButton.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(91, 118);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(52, 16);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name:";
            // 
            // extraLabel
            // 
            this.extraLabel.AutoSize = true;
            this.extraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extraLabel.Location = new System.Drawing.Point(44, 157);
            this.extraLabel.Name = "extraLabel";
            this.extraLabel.Size = new System.Drawing.Size(99, 16);
            this.extraLabel.TabIndex = 5;
            this.extraLabel.Text = "Extra Credit?:";
            // 
            // nameResultLabel
            // 
            this.nameResultLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameResultLabel.Location = new System.Drawing.Point(149, 114);
            this.nameResultLabel.Name = "nameResultLabel";
            this.nameResultLabel.Size = new System.Drawing.Size(95, 25);
            this.nameResultLabel.TabIndex = 6;
            this.nameResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // extraCreditLabel
            // 
            this.extraCreditLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extraCreditLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extraCreditLabel.Location = new System.Drawing.Point(149, 153);
            this.extraCreditLabel.Name = "extraCreditLabel";
            this.extraCreditLabel.Size = new System.Drawing.Size(95, 25);
            this.extraCreditLabel.TabIndex = 7;
            this.extraCreditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // studentNumLabel
            // 
            this.studentNumLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.studentNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentNumLabel.Location = new System.Drawing.Point(462, 109);
            this.studentNumLabel.Name = "studentNumLabel";
            this.studentNumLabel.Size = new System.Drawing.Size(95, 25);
            this.studentNumLabel.TabIndex = 8;
            this.studentNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // studentLabel
            // 
            this.studentLabel.AutoSize = true;
            this.studentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentLabel.Location = new System.Drawing.Point(376, 113);
            this.studentLabel.Name = "studentLabel";
            this.studentLabel.Size = new System.Drawing.Size(80, 16);
            this.studentLabel.TabIndex = 9;
            this.studentLabel.Text = "Student Id:";
            // 
            // databaseButton
            // 
            this.databaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseButton.Location = new System.Drawing.Point(249, 217);
            this.databaseButton.Name = "databaseButton";
            this.databaseButton.Size = new System.Drawing.Size(143, 63);
            this.databaseButton.TabIndex = 10;
            this.databaseButton.Text = "School Database";
            this.databaseButton.UseVisualStyleBackColor = true;
            this.databaseButton.Click += new System.EventHandler(this.databaseButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(485, 287);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 11;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // tutorCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 322);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.databaseButton);
            this.Controls.Add(this.studentLabel);
            this.Controls.Add(this.studentNumLabel);
            this.Controls.Add(this.extraCreditLabel);
            this.Controls.Add(this.nameResultLabel);
            this.Controls.Add(this.extraLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.supportButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.studentIdLabel);
            this.Controls.Add(this.studentIdTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "tutorCheckIn";
            this.Text = "Tutoring Check In";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox studentIdTextBox;
        private System.Windows.Forms.Label studentIdLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button supportButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label extraLabel;
        private System.Windows.Forms.Label nameResultLabel;
        private System.Windows.Forms.Label extraCreditLabel;
        private System.Windows.Forms.Label studentNumLabel;
        private System.Windows.Forms.Label studentLabel;
        private System.Windows.Forms.Button databaseButton;
        private System.Windows.Forms.Button exitButton;
    }
}


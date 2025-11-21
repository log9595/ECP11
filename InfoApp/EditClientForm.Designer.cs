namespace InfoApp
{
    partial class EditClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditClientForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddCenter = new System.Windows.Forms.Button();
            this.btnAddOrg = new System.Windows.Forms.Button();
            this.btnAddPost = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCenter = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbOrgStruct = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPost = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFIO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnAddCenter);
            this.groupBox1.Controls.Add(this.btnAddOrg);
            this.groupBox1.Controls.Add(this.btnAddPost);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbCenter);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtRoom);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbOrgStruct);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbPost);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFIO);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 354);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пользовательские данные";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(108, 322);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(262, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить изменения";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(116, 128);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(100, 20);
            this.txtBox.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "№ носителя:";
            // 
            // btnAddCenter
            // 
            this.btnAddCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddCenter.Location = new System.Drawing.Point(317, 205);
            this.btnAddCenter.Name = "btnAddCenter";
            this.btnAddCenter.Size = new System.Drawing.Size(25, 21);
            this.btnAddCenter.TabIndex = 31;
            this.btnAddCenter.Text = "+";
            this.btnAddCenter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddCenter.UseVisualStyleBackColor = true;
            this.btnAddCenter.Click += new System.EventHandler(this.btnAddCenter_Click);
            // 
            // btnAddOrg
            // 
            this.btnAddOrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddOrg.Location = new System.Drawing.Point(317, 76);
            this.btnAddOrg.Name = "btnAddOrg";
            this.btnAddOrg.Size = new System.Drawing.Size(25, 21);
            this.btnAddOrg.TabIndex = 30;
            this.btnAddOrg.Text = "+";
            this.btnAddOrg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddOrg.UseVisualStyleBackColor = true;
            this.btnAddOrg.Click += new System.EventHandler(this.BtnAddOrg_Click);
            // 
            // btnAddPost
            // 
            this.btnAddPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddPost.Location = new System.Drawing.Point(317, 49);
            this.btnAddPost.Name = "btnAddPost";
            this.btnAddPost.Size = new System.Drawing.Size(25, 21);
            this.btnAddPost.TabIndex = 29;
            this.btnAddPost.Text = "+";
            this.btnAddPost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddPost.UseVisualStyleBackColor = true;
            this.btnAddPost.Click += new System.EventHandler(this.BtnAddPost_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(116, 232);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComment.Size = new System.Drawing.Size(244, 82);
            this.txtComment.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Комментарий:";
            // 
            // cbCenter
            // 
            this.cbCenter.FormattingEnabled = true;
            this.cbCenter.Location = new System.Drawing.Point(116, 205);
            this.cbCenter.Name = "cbCenter";
            this.cbCenter.Size = new System.Drawing.Size(195, 21);
            this.cbCenter.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Удостов. центр:";
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(116, 103);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(100, 20);
            this.txtRoom.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Кабинет:";
            // 
            // cbOrgStruct
            // 
            this.cbOrgStruct.FormattingEnabled = true;
            this.cbOrgStruct.Location = new System.Drawing.Point(116, 77);
            this.cbOrgStruct.Name = "cbOrgStruct";
            this.cbOrgStruct.Size = new System.Drawing.Size(195, 21);
            this.cbOrgStruct.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Отдел/отделение:";
            // 
            // cbPost
            // 
            this.cbPost.FormattingEnabled = true;
            this.cbPost.Location = new System.Drawing.Point(116, 49);
            this.cbPost.Name = "cbPost";
            this.cbPost.Size = new System.Drawing.Size(195, 21);
            this.cbPost.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Должность:";
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(116, 179);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(122, 20);
            this.dateTo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Дата окончания:";
            // 
            // dateFrom
            // 
            this.dateFrom.Location = new System.Drawing.Point(116, 153);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(122, 20);
            this.dateFrom.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Дата начала:";
            // 
            // txtFIO
            // 
            this.txtFIO.Location = new System.Drawing.Point(116, 23);
            this.txtFIO.Name = "txtFIO";
            this.txtFIO.Size = new System.Drawing.Size(356, 20);
            this.txtFIO.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ф.И.О.:";
            // 
            // EditClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 378);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование данных пользователя";
            this.Load += new System.EventHandler(this.AddClientForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCenter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbOrgStruct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbPost;
        private System.Windows.Forms.Button btnAddCenter;
        private System.Windows.Forms.Button btnAddOrg;
        private System.Windows.Forms.Button btnAddPost;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSave;
    }
}
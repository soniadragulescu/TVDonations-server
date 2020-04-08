using System.ComponentModel;

namespace MPP_TeledonClientServer
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.buttonLogout = new System.Windows.Forms.Button();
            this.dataGridViewCase = new System.Windows.Forms.DataGridView();
            this.CaseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseTotalSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewDonor = new System.Windows.Forms.DataGridView();
            this.DonorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxDonor = new System.Windows.Forms.TextBox();
            this.labelDonor = new System.Windows.Forms.Label();
            this.labelDonorId = new System.Windows.Forms.Label();
            this.labelDonorName = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelTelephone = new System.Windows.Forms.Label();
            this.textBoxDonorId = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxTelephone = new System.Windows.Forms.TextBox();
            this.textBoxCaseId = new System.Windows.Forms.TextBox();
            this.labelCaseId = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.buttonAddDonation = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelCases = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewCase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewDonor)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(986, 11);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(159, 48);
            this.buttonLogout.TabIndex = 0;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click_1);
            // 
            // dataGridViewCase
            // 
            this.dataGridViewCase.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                {this.CaseId, this.CaseName, this.CaseTotalSum});
            this.dataGridViewCase.Location = new System.Drawing.Point(797, 135);
            this.dataGridViewCase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewCase.Name = "dataGridViewCase";
            this.dataGridViewCase.RowTemplate.Height = 28;
            this.dataGridViewCase.Size = new System.Drawing.Size(500, 388);
            this.dataGridViewCase.TabIndex = 1;
            this.dataGridViewCase.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCase_CellContentClick);
            this.dataGridViewCase.CellContentClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCase_CellContentClick);
            this.dataGridViewCase.CellContentDoubleClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCase_CellContentClick);
            this.dataGridViewCase.CellDoubleClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCase_CellContentClick);
            // 
            // CaseId
            // 
            this.CaseId.HeaderText = "CaseId";
            this.CaseId.Name = "CaseId";
            // 
            // CaseName
            // 
            this.CaseName.HeaderText = "CaseName";
            this.CaseName.Name = "CaseName";
            // 
            // CaseTotalSum
            // 
            this.CaseTotalSum.HeaderText = "CaseTotalSum";
            this.CaseTotalSum.Name = "CaseTotalSum";
            // 
            // dataGridViewDonor
            // 
            this.dataGridViewDonor.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDonor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                {this.DonorId, this.DonorName, this.Address, this.Telephone});
            this.dataGridViewDonor.Location = new System.Drawing.Point(30, 135);
            this.dataGridViewDonor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewDonor.Name = "dataGridViewDonor";
            this.dataGridViewDonor.RowTemplate.Height = 28;
            this.dataGridViewDonor.Size = new System.Drawing.Size(394, 388);
            this.dataGridViewDonor.TabIndex = 2;
            this.dataGridViewDonor.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDonor_CellContentClick);
            this.dataGridViewDonor.CellContentClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDonor_CellContentClick);
            this.dataGridViewDonor.CellContentDoubleClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDonor_CellContentClick);
            this.dataGridViewDonor.CellDoubleClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDonor_CellContentClick);
            // 
            // DonorId
            // 
            this.DonorId.HeaderText = "DonorId";
            this.DonorId.Name = "DonorId";
            // 
            // DonorName
            // 
            this.DonorName.HeaderText = "DonorName";
            this.DonorName.Name = "DonorName";
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // Telephone
            // 
            this.Telephone.HeaderText = "Telephone";
            this.Telephone.Name = "Telephone";
            // 
            // textBoxDonor
            // 
            this.textBoxDonor.Location = new System.Drawing.Point(142, 86);
            this.textBoxDonor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDonor.Name = "textBoxDonor";
            this.textBoxDonor.Size = new System.Drawing.Size(138, 31);
            this.textBoxDonor.TabIndex = 3;
            // 
            // labelDonor
            // 
            this.labelDonor.Location = new System.Drawing.Point(43, 86);
            this.labelDonor.Name = "labelDonor";
            this.labelDonor.Size = new System.Drawing.Size(84, 31);
            this.labelDonor.TabIndex = 4;
            this.labelDonor.Text = "Name:";
            // 
            // labelDonorId
            // 
            this.labelDonorId.Location = new System.Drawing.Point(451, 231);
            this.labelDonorId.Name = "labelDonorId";
            this.labelDonorId.Size = new System.Drawing.Size(97, 28);
            this.labelDonorId.TabIndex = 5;
            this.labelDonorId.Text = "Donor id:";
            // 
            // labelDonorName
            // 
            this.labelDonorName.Location = new System.Drawing.Point(451, 259);
            this.labelDonorName.Name = "labelDonorName";
            this.labelDonorName.Size = new System.Drawing.Size(97, 42);
            this.labelDonorName.TabIndex = 6;
            this.labelDonorName.Text = "Name:";
            // 
            // labelAddress
            // 
            this.labelAddress.Location = new System.Drawing.Point(448, 298);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(100, 31);
            this.labelAddress.TabIndex = 7;
            this.labelAddress.Text = "Address:";
            // 
            // labelTelephone
            // 
            this.labelTelephone.Location = new System.Drawing.Point(444, 335);
            this.labelTelephone.Name = "labelTelephone";
            this.labelTelephone.Size = new System.Drawing.Size(97, 30);
            this.labelTelephone.TabIndex = 8;
            this.labelTelephone.Text = "Telephone:";
            // 
            // textBoxDonorId
            // 
            this.textBoxDonorId.Location = new System.Drawing.Point(551, 228);
            this.textBoxDonorId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDonorId.Name = "textBoxDonorId";
            this.textBoxDonorId.Size = new System.Drawing.Size(135, 31);
            this.textBoxDonorId.TabIndex = 9;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(551, 262);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(135, 31);
            this.textBoxName.TabIndex = 10;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(551, 298);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(135, 31);
            this.textBoxAddress.TabIndex = 11;
            // 
            // textBoxTelephone
            // 
            this.textBoxTelephone.Location = new System.Drawing.Point(551, 332);
            this.textBoxTelephone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTelephone.Name = "textBoxTelephone";
            this.textBoxTelephone.Size = new System.Drawing.Size(135, 31);
            this.textBoxTelephone.TabIndex = 12;
            // 
            // textBoxCaseId
            // 
            this.textBoxCaseId.Location = new System.Drawing.Point(551, 412);
            this.textBoxCaseId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCaseId.Name = "textBoxCaseId";
            this.textBoxCaseId.Size = new System.Drawing.Size(135, 31);
            this.textBoxCaseId.TabIndex = 13;
            // 
            // labelCaseId
            // 
            this.labelCaseId.Location = new System.Drawing.Point(448, 412);
            this.labelCaseId.Name = "labelCaseId";
            this.labelCaseId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelCaseId.Size = new System.Drawing.Size(97, 31);
            this.labelCaseId.TabIndex = 14;
            this.labelCaseId.Text = "Case id:\r\n";
            // 
            // labelSum
            // 
            this.labelSum.Location = new System.Drawing.Point(444, 442);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(100, 29);
            this.labelSum.TabIndex = 15;
            this.labelSum.Text = "Sum:";
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(551, 448);
            this.textBoxSum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(135, 31);
            this.textBoxSum.TabIndex = 16;
            // 
            // buttonAddDonation
            // 
            this.buttonAddDonation.Location = new System.Drawing.Point(451, 502);
            this.buttonAddDonation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddDonation.Name = "buttonAddDonation";
            this.buttonAddDonation.Size = new System.Drawing.Size(114, 38);
            this.buttonAddDonation.TabIndex = 17;
            this.buttonAddDonation.Text = "Donate!";
            this.buttonAddDonation.UseVisualStyleBackColor = true;
            this.buttonAddDonation.Click += new System.EventHandler(this.buttonAddDonation_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(311, 71);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(100, 46);
            this.buttonSearch.TabIndex = 18;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelCases
            // 
            this.labelCases.Location = new System.Drawing.Point(862, 82);
            this.labelCases.Name = "labelCases";
            this.labelCases.Size = new System.Drawing.Size(104, 31);
            this.labelCases.TabIndex = 19;
            this.labelCases.Text = "Cases:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.labelCases);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonAddDonation);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelCaseId);
            this.Controls.Add(this.textBoxCaseId);
            this.Controls.Add(this.textBoxTelephone);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxDonorId);
            this.Controls.Add(this.labelTelephone);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelDonorName);
            this.Controls.Add(this.labelDonorId);
            this.Controls.Add(this.labelDonor);
            this.Controls.Add(this.textBoxDonor);
            this.Controls.Add(this.dataGridViewDonor);
            this.Controls.Add(this.dataGridViewCase);
            this.Controls.Add(this.buttonLogout);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewCase)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewDonor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.DataGridView dataGridViewCase;
        private System.Windows.Forms.DataGridView dataGridViewDonor;
        private System.Windows.Forms.TextBox textBoxDonor;
        private System.Windows.Forms.Label labelDonor;
        private System.Windows.Forms.Label labelDonorId;
        private System.Windows.Forms.Label labelDonorName;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelTelephone;
        private System.Windows.Forms.TextBox textBoxDonorId;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxTelephone;
        private System.Windows.Forms.TextBox textBoxCaseId;
        private System.Windows.Forms.Label labelCaseId;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Button buttonAddDonation;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelCases;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseTotalSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    }
}
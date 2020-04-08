using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MPP_TeledonClientServer.model;
using MPP_TeledonClientServer.services;
using networking;

namespace MPP_TeledonClientServer
{
    public partial class FormMain : Form
    {
        // private DonationService _donationService;
        private Controller controller;
        public FormMain(Controller controller)
        {
            InitializeComponent();
            //this._donationService = donationService;
            this.controller = controller;
            dataGridViewCase.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDonor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewCase.MultiSelect = false;
            dataGridViewDonor.MultiSelect = false;
            controller.updateEvent += donationUpdate;
            initData();
        }

        public void initData()
        {
            dataGridViewCase.Rows.Clear();
            IEnumerable<Case> cases = this.controller.getAllCases();
            foreach (Case caz in cases)
            {
                var index = dataGridViewCase.Rows.Add();
                dataGridViewCase.Rows[index].Cells["CaseId"].Value = caz.Id;
                dataGridViewCase.Rows[index].Cells["CaseName"].Value = caz.Name;
                dataGridViewCase.Rows[index].Cells["CaseTotalSum"].Value = caz.TotalSum;
            }
            
            dataGridViewDonor.Rows.Clear();
            IEnumerable<Donor> donors = this.controller.searchDonorByName("");
            foreach (Donor donor in donors)
            {
                var index = dataGridViewDonor.Rows.Add();
                dataGridViewDonor.Rows[index].Cells["DonorId"].Value = donor.Id;
                dataGridViewDonor.Rows[index].Cells["DonorName"].Value = donor.Name;
                dataGridViewDonor.Rows[index].Cells["Address"].Value = donor.Address;
                dataGridViewDonor.Rows[index].Cells["Telephone"].Value = donor.Telephone;
            }
        }

        public delegate void upgradeDonorsDelegate(IEnumerable<Donor> donors);

        public delegate void upgradeCasesDelegate(IEnumerable<Case> cases);

        public void upgradeDonors(IEnumerable<Donor> donors)
        {
            dataGridViewDonor.Rows.Clear();
            foreach (Donor donor in donors)
            {
                var index = dataGridViewDonor.Rows.Add();
                dataGridViewDonor.Rows[index].Cells["DonorId"].Value = donor.Id;
                dataGridViewDonor.Rows[index].Cells["DonorName"].Value = donor.Name;
                dataGridViewDonor.Rows[index].Cells["Address"].Value = donor.Address;
                dataGridViewDonor.Rows[index].Cells["Telephone"].Value = donor.Telephone;
            }
        }

        public void upgradeCases(IEnumerable<Case> cases)
        {
            dataGridViewCase.Rows.Clear();
            foreach (Case caz in cases)
            {
                var index = dataGridViewCase.Rows.Add();
                dataGridViewCase.Rows[index].Cells["CaseId"].Value = caz.Id;
                dataGridViewCase.Rows[index].Cells["CaseName"].Value = caz.Name;
                dataGridViewCase.Rows[index].Cells["CaseTotalSum"].Value = caz.TotalSum;
            }
        }

        public void donationUpdate(object sender, NewDonationResponse response)
        {
            IEnumerable<Donor> donors = response.Donors;
            IEnumerable<Case> cases = response.Cases;

            dataGridViewDonor.BeginInvoke(new upgradeDonorsDelegate(upgradeDonors), donors);
            dataGridViewCase.BeginInvoke(new upgradeCasesDelegate(upgradeCases), cases);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            IEnumerable<Donor> donors = this.controller.searchDonorByName(textBoxDonor.Text);
            /*if (donors.Count() == 0)
            {
                MessageBox.Show("No donors found!");
                return;
            }*/
            dataGridViewDonor.Rows.Clear();
            foreach (Donor donor in donors)
            {
                var index = dataGridViewDonor.Rows.Add();
                dataGridViewDonor.Rows[index].Cells["DonorId"].Value = donor.Id;
                dataGridViewDonor.Rows[index].Cells["DonorName"].Value = donor.Name;
                dataGridViewDonor.Rows[index].Cells["Address"].Value = donor.Address;
                dataGridViewDonor.Rows[index].Cells["Telephone"].Value = donor.Telephone;
            }
        }

        private void buttonLogout_Click_1(object sender, EventArgs e)
        {
            controller.logout();
            this.Hide(); 
            Application.Exit();
        }

        private void buttonAddDonation_Click(object sender, EventArgs e)
        {
            try
            {
                int donorId = Int32.Parse(textBoxDonorId.Text);
                int caseId = Int32.Parse(textBoxCaseId.Text);
                string name = textBoxName.Text;
                string address = textBoxAddress.Text;
                string telephone = textBoxTelephone.Text;
                double sum = Double.Parse(textBoxSum.Text);
                this.controller.saveDonation(donorId,name,address,telephone,sum,caseId);
               // initData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewDonor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDonor.SelectedRows.Count != 0)
            {
                string donorId = dataGridViewDonor.SelectedRows[0].Cells["DonorId"].Value.ToString();
                string name = dataGridViewDonor.SelectedRows[0].Cells["DonorName"].Value.ToString();
                string address=dataGridViewDonor.SelectedRows[0].Cells["Address"].Value.ToString();
                string telephone=dataGridViewDonor.SelectedRows[0].Cells["Telephone"].Value.ToString();
                
                textBoxDonorId.Text = donorId;
                textBoxName.Text = name;
                textBoxAddress.Text = address;
                textBoxTelephone.Text = telephone;
            }
        }

        private void dataGridViewCase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCase.SelectedRows.Count != 0)
            {
                string caseId = dataGridViewCase.SelectedRows[0].Cells[0].Value.ToString();
                textBoxCaseId.Text = caseId;
            }
        }
    }
    
}
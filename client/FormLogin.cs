using System;
using System.Windows.Forms;
using MPP_TeledonClientServer.model;
using MPP_TeledonClientServer.services;

namespace MPP_TeledonClientServer
{
    public partial class FormLogin : Form
    {
        //  private VolunteerService _volunteerService;
        // private DonationService _donationService;
        private Controller controller;
        public FormLogin(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(textBoxUsername.Text=="" || textBoxPassword.Text=="")
            {
                MessageBox.Show("Please provide Username and Password");
                return;
            }

            string user = textBoxUsername.Text;
            string pass = textBoxPassword.Text;
            Volunteer volunteer = this.controller.login(user,pass );
            if (volunteer!=null)
            {
                MessageBox.Show("Login Successful!");
                this.Hide();
                FormMain fm = new FormMain(controller);
                fm.Show();
            }
            else
            {
                MessageBox.Show("Login Failed!");
            }
        }
    }
}
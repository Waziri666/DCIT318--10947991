using System;
using System.Windows.Forms;

namespace AddressBookApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string phoneNumber = txtPhoneNumber.Text;

            // You can save this information to a database, file, or display it in a message box for now
            MessageBox.Show($"Name: {name}\nEmail: {email}\nPhone Number: {phoneNumber}", "Contact Information Saved");
        }
    }
}

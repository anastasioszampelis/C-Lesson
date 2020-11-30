using MyApp.Enums;
using MyApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
    public partial class AddEditDisplayPerson : Form
    {
        public AddEditDisplayPerson()
        {
            InitializeComponent();
            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }
        public PersonModificationType ModificationType { get; set; }
        public Person Person { get; set; }
        public string FormTitle { get; set; }
        private void AddEditDisplayPerson_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = Person.FirstName;
            txtLastName.Text = Person.LastName;
            if(ModificationType == PersonModificationType.IsDisplay)
            {
                txtFirstName.ReadOnly = true;
                txtLastName.ReadOnly = true;
                btnOk.Enabled = false;
            }
            this.Text = FormTitle;
        }
    }
}

using MyApp.Enums;
using MyApp.Model;
using MyApp.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			peopleDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			peopleDataGridView.MultiSelect = false;
			displayPersonToolStripMenuItem.Tag = PersonModificationType.IsDisplay;
			addPersonToolStripMenuItem.Tag = PersonModificationType.IsAdd;
			editPersonToolStripMenuItem.Tag = PersonModificationType.IsEdit;
			displayPersonToolStripMenuItem.Click += new EventHandler(MenuClicked);
			addPersonToolStripMenuItem.Click += new EventHandler(MenuClicked);
			editPersonToolStripMenuItem.Click += new EventHandler(MenuClicked);
		}
		private void peopleDataGridView_SelectionChanged(object sender, EventArgs e)
		{
			SelectedPerson = (Person)peopleDataGridView.CurrentRow.DataBoundItem;
			ToggleMenuItems(SelectedPerson != null);
		}

		private void ToggleMenuItems(bool personIsSelected)
		{
			displayPersonToolStripMenuItem.Enabled = personIsSelected;
			addPersonToolStripMenuItem.Enabled = personIsSelected;
			deletePersonToolStripMenuItem.Enabled = personIsSelected;
		}
		private void MenuClicked(object sender, EventArgs e)
        {
			AddEditDisplayPerson form = new AddEditDisplayPerson();
			var item = sender as ToolStripMenuItem;
			form.ModificationType = (PersonModificationType)item.Tag;
			form.Person = (form.ModificationType == PersonModificationType.IsEdit || form.ModificationType == PersonModificationType.IsDisplay) ? SelectedPerson : new Person();
			form.FormTitle = item.Text;
			form.ShowDialog();
        }

        public BindingList<Person> People { get; set; }
		public Person SelectedPerson { get; set; }

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			People = PersonRepository.Instance.People;
			peopleDataGridView.DataSource = People;
		}

        private void closeAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }
    }

	
}

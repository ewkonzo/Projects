﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;

namespace Coffee
{
    public partial class Users : Form
    { private AutoweighEntities db = new AutoweighEntities(coffee.ConnectionString());
        public Users()
        {           
            InitializeComponent();
            if (coffee.user.Type != "Admin")
            {
                gridView1.OptionsBehavior.ReadOnly = true;
            }
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext

            // Call the Load method to get the data for the given DbSet from the database.
            db.Users.Load();
            // This line of code is generated by Data Source Configuration Wizard
            usersBindingSource.DataSource = db.Users.Local.ToBindingList();

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            gridView1.EndDataUpdate();
           db.SaveChanges(true);
        }

        private void repositoryItemTextEdit1_Leave(object sender, EventArgs e)
        {
            // gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.FocusedColumn, AutoweighEntities.GetMd5Hash(gridView1.GetFocusedDisplayText()));
        }

    }
}



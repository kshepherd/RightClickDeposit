using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using org.swordapp.client.windows.libraries;

namespace org.swordapp.client.windows
{
    public partial class frmDeposits : Form
    {
        Dictionary<int, Deposit> deposits;
        private ListViewColumnSorter lvwColumnSorter;
        private int selectedDeposit;
        private string action;

        public frmDeposits()
        {
            InitializeComponent();
            
        }

        public frmDeposits(Dictionary<int, Deposit> deposits)
        {
            InitializeComponent();
            this.deposits = deposits;
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
            drawList();
        }

        public void drawList()
        {

            if (deposits != null)
            {
                foreach (KeyValuePair<int, Deposit> kvp in deposits)
                {
                    
                    ListViewItem item = new ListViewItem();
                    item.Text = kvp.Value.GetFile();
                    item.Tag = kvp.Value.GetId();
                    item.SubItems.Add(kvp.Value.GetUpdated().ToString());
                    item.SubItems.Add(kvp.Value.GetContentLength().ToString());
                    item.SubItems.Add(kvp.Value.GetInProgress().ToString());
                    listView1.Items.Add(item);
                }
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                selectedDeposit = (int)listView1.SelectedItems[0].Tag;
                action = "update";
                if (deposits[selectedDeposit].GetInProgress())
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("You have selected a deposit that is not 'in progress'. Completed deposits cannot be managed directly by this application, please contact your repository team for more assistance.", "Can not alter a completed deposit");
                }
            }
            
        }

        public int GetSelectedDeposit()
        {
            return selectedDeposit;
        }

        public string GetAction()
        {
            return action;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                selectedDeposit = (int)listView1.SelectedItems[0].Tag;
                action = "delete";
                if (deposits[selectedDeposit].GetInProgress())
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("You have selected a deposit that is not 'in progress'. Completed deposits cannot be managed directly by this application, please contact your repository team for more assistance.", "Can not alter a completed deposit");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                selectedDeposit = (int)listView1.SelectedItems[0].Tag;
                action = "complete";
                if (deposits[selectedDeposit].GetInProgress())
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("You have selected a deposit that is not 'in progress'. Completed deposits cannot be managed directly by this application, please contact your repository team for more assistance.", "Can not alter a completed deposit");
                }
            }
        }


    }
}

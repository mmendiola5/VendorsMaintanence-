using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Michael Mendiola 10/9/22
namespace VendorMaintenance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void vendorsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vendorsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.payablesDataSet);

        }

        private void vendorsBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            try
            {
                this.vendorsBindingSource.EndEdit();
                this.vendorsTableAdapter.Fill(this.payablesDataSet.Vendors);
            }
            catch (DBConcurrencyException)
            {
                MessageBox.Show("A concurrency error occured." +
                    "The row was not updated.", "Concurrency Exception");
            }
            catch (DataException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                this.vendorsBindingSource.CancelEdit();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Server error #" + ex.Number + ": " + ex.Message, ex.GetType().ToString());
            }
            this.tableAdapterManager.UpdateAll(this.payablesDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payablesDataSet.Vendors' table. You can move, or remove it, as needed.
            try
            {
                this.vendorsBindingSource.EndEdit();
                this.vendorsTableAdapter.Fill(this.payablesDataSet.Vendors);
            }
            catch (DBConcurrencyException)
            {
                MessageBox.Show("A concurrency error occured." +
                    "The row was not updated.", "Concurrency Exception");
            }
            catch(DataException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                this.vendorsBindingSource.CancelEdit();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("SQL Server error #" + ex.Number + ": " + ex.Message, ex.GetType().ToString());
            }

        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class SalesHistory : Form
    {
        FrichProbnicDemoContext context;

        Partner selectedPartner;
        List<Partner> partners;



        public SalesHistory()
        {
            context = FrichProbnicDemoContext.Instance();
            partners = context.Partners.ToList();

            InitializeComponent();
            dataGridView1.ReadOnly = true;
            LoadData();
        }

        private void LoadData()
        {
            comboBox1.DataSource = partners;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

        }

        private void LoadSalesHistory()
        {
            if (selectedPartner == null)
            {
                MessageBox.Show("Необходимо выбрать партнера для просмотра истории реализации", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            label2.Text = $"История партнера {selectedPartner.Name}";
            label2.Visible = true;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Наименование продукции", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Количество", typeof(long)));
            dataTable.Columns.Add(new DataColumn("Дата продажи", typeof(DateTime)));

            List<PartnerProduct> sales = context.PartnerProducts.Include(x => x.Product).Where(x => x.PartnerId == selectedPartner.Id).ToList();

            foreach (PartnerProduct sale in sales)
            {
                dataTable.Rows.Add(sale.Product.Name, sale.Count, sale.SaleDate);
            }

            dataGridView1.DataSource = dataTable;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPartner = partners.Find(x => x.Id == (int)comboBox1.SelectedValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedPartner = partners.Find(x => x.Id == (int)comboBox1.SelectedValue);
            
            LoadSalesHistory();
        }
    }
}

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
using WinFormsApp3.Models;

namespace WinFormsApp3.View
{
    public partial class SalesHistory : Form
    {
        Partner partner;

        Partners03Context context;
        public SalesHistory(Partner partner)
        {
            context = Partners03Context.Instance();

            this.partner = partner;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            label1.Text = $"Реализация продукции партнером '{partner.Name}'";


            DataTable dt = new DataTable();
            dt.Columns.Add("Наименование продукции", typeof(string));
            dt.Columns.Add("Количество", typeof(int));
            dt.Columns.Add("Дата продажи", typeof(DateTime));

            // Загрузка продаж с включенными данными о продуктах
            var sales = context.Sales
                .Include(s => s.Product)  // загружаем связанные продукты
                .Where(s => s.PartnerId == partner.Id)
                .ToList();

            foreach (var sale in sales)
            {
                dt.Rows.Add(
                    sale.Product?.НаименованиеПродукции,  // Наименование продукции
                    sale.Count,                        // Количество
                    sale.SalesDate                         // Дата продажи
                );
            }

            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

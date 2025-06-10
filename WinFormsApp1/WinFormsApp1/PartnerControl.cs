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
    public partial class PartnerControl : UserControl
    {
        Partner partner;

        public Form1 mainForm {  get; set; }

        public PartnerControl(Partner partner)
        {
            this.partner = partner;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            label1.Text = $"{partner.PartnerType.Name} | {partner.Name}";
            label2.Text = $"{partner.Director}";
            maskedTextBox1.Text = partner.Phone;
            label3.Text = $"Рейтинг: {partner.Rating}";

            long productCount = partner.PartnerProducts.Sum(x => x.Count);
            int discount = 0;

            if (productCount > 300000)
                discount = 15;
            else if (productCount >= 50000)
                discount = 10;
            else if (productCount >= 10000)
                discount = 5;


            label4.Text = $"{discount}%";
        }

        private void PartnerControl_Click(object sender, EventArgs e)
        {
            AddEditPartnerForm form = new AddEditPartnerForm();
            form.Init(partner);
            if (form.ShowDialog() == DialogResult.OK)
                mainForm.LoadData();
        }
    }
}

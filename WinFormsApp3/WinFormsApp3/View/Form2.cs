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
    public partial class Form2 : Form
    {
        private Partner partner;

        private Partners03Context context;

        private BindingSource bindingSource;

        public Form2()
        {
            context = Partners03Context.Instance();
            InitializeComponent();
            
        }

        public void InitPartner(Partner partner)
        {
            this.partner = partner;
            LoadData();
        }

        public void InitPartner()
        {
            
            LoadData();
        }

        private void LoadData()
        {
            if (partner == null)
            {
                partner = new Partner();
            }
            List<PartnerType> types = context.PartnerTypes.ToList();

            comboBox1.DataSource = types;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            SetupBinding();
        }

        void SetupBinding()
        {
            bindingSource = new BindingSource();
            bindingSource.DataSource = typeof(Partner);
            bindingSource.Add(partner);

            comboBox1.DataBindings.Add("SelectedValue", bindingSource, nameof(Partner.PartnerTypeId));

            textBox1.DataBindings.Add("Text", bindingSource, nameof(Partner.Name));
            maskedTextBox1.Text = partner.Rating.ToString();
            textBox3.DataBindings.Add("Text", bindingSource, nameof(Partner.Address));
            textBox4.DataBindings.Add("Text", bindingSource, nameof(Partner.Director));
            if (partner.Id != 0)
                maskedTextBox2.Text = partner.Phone.Replace(" ", "");
            textBox6.DataBindings.Add("Text", bindingSource, nameof(Partner.Email));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                partner.Rating = int.Parse(maskedTextBox1.Text);
                partner.Phone = maskedTextBox2.Text;

                if (partner.Id == 0)
                    context.Partners.Add(partner);
                else
                    context.Partners.Update(partner);
                context.SaveChanges();

                DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения, проверьте данные");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            
        }
    }
}

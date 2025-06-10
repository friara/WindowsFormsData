using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class AddEditForm2 : Form
    {
        Partner partner;
        FrichProbnicDemoContext context;


        public AddEditForm2()
        {
            context = FrichProbnicDemoContext.Instance();

            InitializeComponent();
        }

        public void Init()
        {
            partner = new Partner();
            LoadData();
        }

        public void Init(Partner partner)
        {
            this.partner = partner;
            LoadData();
        }

        private void LoadData()
        {
            List<PartnerType> partnerTypes = context.PartnerTypes.ToList();
            comboBox1.DataSource = partnerTypes;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            BindingData();
        }

        private void BindingData()
        {
            textBox1.DataBindings.Add("Text", partner, nameof(Partner.Name));
            textBox3.DataBindings.Add("Text", partner, nameof(Partner.Rating));
            textBox4.DataBindings.Add("Text", partner, nameof(Partner.Address));
            textBox5.DataBindings.Add("Text", partner, nameof(Partner.Director));
            textBox7.DataBindings.Add("Text", partner, nameof(Partner.Email));

            comboBox1.DataBindings.Add("SelectedValue", partner, nameof(Partner.PartnerTypeId));

            if (partner.Id != 0)
            {
                maskedTextBox1.Text = partner.Phone.Replace(" ", "");

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{


            //    partner.Phone = maskedTextBox1.Text.Substring(3);

            //    bool hasErrors;


            //    ValidateProperty(textBox1, nameof(Partner.Name), textBox1.Text);
            //    if (!int.TryParse(textBox3.Text, out int ratingValue))
            //    {
            //        errorProvider1.SetError(textBox3, "Требуется целое число");
            //        hasErrors = true;
            //    }
            //    else
            //    {
            //        ValidateProperty(textBox3, nameof(Partner.Rating), ratingValue);
            //    }
            //    ValidateProperty(textBox4, nameof(Partner.Address), textBox4.Text);
            //    ValidateProperty(textBox5, nameof(Partner.Director), textBox5.Text);
            //    ValidateProperty(textBox7, nameof(Partner.Email), textBox7.Text);
            //    if (comboBox1.SelectedValue == null)
            //        errorProvider1.SetError(comboBox1, "Тип партнера обязателен для заполнения");
            //    ValidateProperty(maskedTextBox1, nameof(Partner.Phone), maskedTextBox1.Text.Substring(3));

            //    hasErrors = this.Controls.OfType<Control>()
            //        .Any(control => !string.IsNullOrEmpty(errorProvider1.GetError(control)));

            //    if(hasErrors)
            //    {
            //        MessageBox.Show("Неверно введены данные. Проверьте поля ввода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    if(partner.Id == 0)
            //    {
            //        context.Partners.Add(partner);
            //    }
            //    else
            //    {
            //        context.Partners.Update(partner);
            //    }
            //    context.SaveChanges();
            //    DialogResult = DialogResult.OK;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}











            try
            {


                partner.Phone = maskedTextBox1.Text.Substring(3);

                var validContext = new ValidationContext(partner);
                var errors = new List<ValidationResult>();
                bool hasErrors = !Validator.TryValidateObject(partner, validContext, errors, validateAllProperties: true);

                string message = "";

                foreach (var error in errors)
                {
                    message += error.ErrorMessage + '\n';
                }

                if (hasErrors)
                {
                    MessageBox.Show($"Неверно введены данные. Проверьте поля ввода. \n{message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (partner.Id == 0)
                {
                    context.Partners.Add(partner);
                }
                else
                {
                    context.Partners.Update(partner);
                }
                context.SaveChanges();
                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void ValidateProperty(Control control, string propertyName, object value)
        {
            var context = new ValidationContext(partner)
            { MemberName = propertyName };

            List<ValidationResult> errors = new List<ValidationResult>();
            bool isValid = Validator.TryValidateProperty(value, context, validationResults: errors);
            if (isValid)
            {
                errorProvider1.SetError(control, null);
            }
            else
                errorProvider1.SetError(control, errors.First().ErrorMessage);

        }
    }
}

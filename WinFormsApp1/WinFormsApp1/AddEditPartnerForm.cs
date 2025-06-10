using Microsoft.IdentityModel.Tokens;
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
using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp1
{
    public partial class AddEditPartnerForm : Form
    {
        FrichProbnicDemoContext context;

        BindingSource bindingSource;

        Partner partner;

        public AddEditPartnerForm()
        {
            context = FrichProbnicDemoContext.Instance();

            InitializeComponent();

            // Добавьте эту строку для автоматической валидации
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        public void Init(Partner partner)
        {
            this.partner = partner;
            LoadData();
        }
        public void Init()
        {
            partner = new Partner();
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
            bindingSource = new BindingSource();
            //bindingSource.DataSource = typeof(Partner);
            //bindingSource.Add(partner);
            bindingSource.DataSource = partner;

            //textBox1.DataBindings.Add("Text", bindingSource, nameof(Partner.Name));
            //textBox3.DataBindings.Add("Text", bindingSource, nameof(Partner.Rating));
            //textBox4.DataBindings.Add("Text", bindingSource, nameof(Partner.Address));
            //textBox5.DataBindings.Add("Text", bindingSource, nameof(Partner.Director));
            //textBox7.DataBindings.Add("Text", bindingSource, nameof(Partner.Email));
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



            // Подпишите все поля на валидацию
            textBox1.Validating += TextBox_Validating;
            textBox3.Validating += TextBox_Validating;
            textBox4.Validating += TextBox_Validating;
            textBox5.Validating += TextBox_Validating;
            textBox7.Validating += TextBox_Validating;
            comboBox1.Validating += ComboBox_Validating;
            maskedTextBox1.Validating += MaskedTextBox_Validating;

            
        }

        // Общий обработчик для TextBox
        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            var textBox = (TextBox)sender;
            string propertyName = GetPropertyName(textBox);

            if(textBox.Name == "textBox3")
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    ValidateProperty(textBox, nameof(Partner.Rating), 0); // 0 будет невалидным по Range
                    return;
                }
                if (int.TryParse(textBox.Text, out int rating))
                {
                    ValidateProperty(textBox, nameof(Partner.Rating), rating);
                }
                else
                {
                    errorProvider1.SetError(textBox, "Рейтинг должен быть целым числом");
                    e.Cancel = true;
                }
            }
            else
                ValidateProperty(textBox, propertyName, textBox.Text);
        }

        private void ComboBox_Validating(object sender, CancelEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            string propertyName = GetPropertyName(comboBox);


            if (comboBox.SelectedValue == null)
            {
                errorProvider1.SetError(comboBox, "Тип партнера обязателен");
                e.Cancel = true;
                return;
            }
            ValidateProperty(comboBox, propertyName, comboBox.SelectedValue);
        }

        // Обработчик для MaskedTextBox
        private void MaskedTextBox_Validating(object sender, CancelEventArgs e)
        {
            var maskedBox = (MaskedTextBox)sender;
            string propertyName = GetPropertyName(maskedBox);
            string phoneValue = maskedBox.Text.Substring(3).Trim();
            ValidateProperty(maskedBox, propertyName, phoneValue);
        }

        // Метод для сопоставления контролов и свойств
        private string GetPropertyName(Control control)
        {
            return control switch
            {
                _ when control == textBox1 => nameof(Partner.Name),
                _ when control == textBox3 => nameof(Partner.Rating),
                _ when control == textBox4 => nameof(Partner.Address),
                _ when control == textBox5 => nameof(Partner.Director),
                _ when control == textBox7 => nameof(Partner.Email),
                _ when control == comboBox1 => nameof(Partner.PartnerTypeId),
                _ when control == maskedTextBox1 => nameof(Partner.Phone),
                _ => throw new ArgumentException("Unknown control")
            };
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                partner.Phone = maskedTextBox1.Text.Substring(3).Trim();

                // Принудительно вызываем валидацию всех полей
                this.ValidateChildren();

                // Проверяем наличие ошибок
                bool hasErrors = Controls.OfType<Control>()
                    .Any(control => !string.IsNullOrEmpty(errorProvider1.GetError(control)));

                if (hasErrors)
                {
                    MessageBox.Show("Исправьте ошибки в полях!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (partner.Id == 0)
                    context.Partners.Add(partner);
                else
                    context.Partners.Update(partner);
                context.SaveChanges();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ValidateProperty(Control control, string propertyName, object value)
        {
            var context = new ValidationContext(partner)
            {
                MemberName = propertyName
            };

            var errors = new List<ValidationResult>();
            bool isValid = Validator.TryValidateProperty(value, context, errors);

            if (!isValid && errors.Count > 0)
            {
                errorProvider1.SetError(control, errors.First().ErrorMessage);
            }
            else
            {
                errorProvider1.SetError(control, null);
            }
        }
    }
}

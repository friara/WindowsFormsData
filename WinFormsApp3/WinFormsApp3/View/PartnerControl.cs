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
    public partial class PartnerControl : UserControl
    {
        public Partner partner {  get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                UpdateAppearance();
            }
        }


        public event EventHandler Selected;


        public PartnerControl(Partner partner)
        {
            this.partner = partner;

            InitializeComponent();
            LoadData();

            // Обработка клика на самом контроле
            this.Click += (s, e) => OnSelected();

            // Обработка кликов на всех дочерних элементах
            foreach (Control child in this.Controls)
            {
                child.Click += (s, e) => OnSelected();
            }
        }

        // Обновляем внешний вид при выделении
        private void UpdateAppearance()
        {
            BackColor = _isSelected ? Color.LightBlue : SystemColors.Control;
            BorderStyle = _isSelected ? BorderStyle.FixedSingle : BorderStyle.None;
        }

        private void LoadData()
        {
            label1.Text = $"{partner.PartnerType.Name} | {partner.Name}";
            label2.Text = $"{partner.Director}";
            maskedTextBox1.Text = $"{partner.Phone}";
            label4.Text = $"Рейтинг: {partner.Rating}";

            int discount = 0;
            long sales = partner.Sales.Sum(p => p.Count);
            if (sales > 300000)
                discount = 15;
            else if (sales >= 50000)
                discount = 10;
            else if (sales >= 10000)
                discount = 15;


            label5.Text = $"{discount}%";
        }

        private void OnSelected()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }

        private void PartnerControl_Click(object sender, EventArgs e)
        {
            IsSelected = true;
        }
    }
}

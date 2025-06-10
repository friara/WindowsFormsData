using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using WinFormsApp3.Models;
using WinFormsApp3.View;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        Partners03Context context;

        List<Partner> partners;

        PartnerControl currentSelectedControl;
        public Form1()
        {
            context = Partners03Context.Instance();

            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            partners = context.Partners.Include(p => p.PartnerType)
                                        .Include(p => p.Sales).ToList();

            flowLayoutPanel1.Controls.Clear();

            foreach (var partner in partners)
            {
                PartnerControl newControl = new PartnerControl(partner);
                newControl.Selected += UserControl_Selected;
                flowLayoutPanel1.Controls.Add(newControl);
            }
        }

        private void UserControl_Selected(object sender, EventArgs e)
        {
            // Снимаем выделение с предыдущего элемента
            if (currentSelectedControl != null)
            {
                currentSelectedControl.IsSelected = false;
            }

            // Выделяем новый элемент
            currentSelectedControl = (PartnerControl)sender;
            currentSelectedControl.IsSelected = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.InitPartner();
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentSelectedControl !=null)
            {
                Form2 form = new Form2();
                form.InitPartner(currentSelectedControl.partner);

                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
            else
                MessageBox.Show("Выберите партнера");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentSelectedControl != null)
            {
                try
                {
                    context.Partners.Remove(currentSelectedControl.partner);
                    context.SaveChanges();
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else
                MessageBox.Show("Выберите партнера");
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentSelectedControl != null)
            {
                SalesHistory history = new SalesHistory(currentSelectedControl.partner);
                history.ShowDialog();
            }
            else
                MessageBox.Show("Выберите партнера");
        }
    }
}

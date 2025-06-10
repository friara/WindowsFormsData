using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        FrichProbnicDemoContext context;

        List<Partner> partners;

        public Form1()
        {
            context = FrichProbnicDemoContext.Instance();
            InitializeComponent();

            LoadData();
        }

        public void LoadData()
        {
            partners = context.Partners.Include(x => x.PartnerType).Include(x => x.PartnerProducts).ToList();

            flowLayoutPanel1.Controls.Clear();

            foreach (var partner in partners)
            {
                PartnerControl control = new PartnerControl(partner);
                control.mainForm = this;
                flowLayoutPanel1.Controls.Add(control);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditForm2 form = new AddEditForm2();
            form.Init();
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SalesHistory form = new SalesHistory();
            form.ShowDialog();
        }
    }
}

namespace Intership
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var products = new Products.Products();
            Hide();
            products.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Orders.OrdersForm ordersForm = new();
            Hide();
            ordersForm.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Cars.CarsForm carsForm = new();
            Hide();
            carsForm.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Drivers.DriversForm driversForm = new();
            Hide();
            driversForm.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            var markets = new Markets.Markets();
            Hide();
            markets.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            EmployeessForms.RegistrationEmployeess registrationEmployeess = new();
            Hide();
            registrationEmployeess.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            EmployeessForms.EmployeessForm employeessForm = new();
            Hide();
            employeessForm.Show();
        }
    }
}

using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.EmployeessForms
{
    public partial class EmployeessForm : Form
    {
        private readonly IEmployeessRepository<Employeess> _employeessRepository;

        public EmployeessForm()
        {
            _employeessRepository = new EmployeessRepository();
            InitializeComponent();
        }
        private async void EmployeessForm_Load(object sender, EventArgs e)
        {
            SettingDataGridView();
            await LoadFullData();
        }
        private async Task LoadFullData()
        {
            var employeessesList = await _employeessRepository.GetAll();
            LoadDataGridView(employeessesList);
        }
        private void LoadDataGridView(IEnumerable<Employeess> employeessesList)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in employeessesList)
            {
                var row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = item.Name;
                row.Cells[1].Value = item.Surname;
                row.Cells[2].Value = item.MiddleName;
                row.Cells[3].Value = item.NumberPhobne;
                row.Cells[4].Value = item.Role.Name;
                dataGridView1.Rows.Add(row);
            }
        }
        private void SettingDataGridView()
        {
            dataGridView1.Columns.Add("Name", "Имя");
            dataGridView1.Columns.Add("Family", "Фамилия");
            dataGridView1.Columns.Add("MiddleName", "Отчество");
            dataGridView1.Columns.Add("NumberPhone", "Номер телефона");
            dataGridView1.Columns.Add("Role", "Должность");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = new();
            Hide();
            main.Show();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            await LoadFullData();
        }

        #region  Фильтрация
        private async void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                await SearchBySurname();
                textBox1.Clear();
            }
            else
                MessageBox.Show("Заполните поле ввода");
        }
        private async Task SearchBySurname()
        {
            var employeessesList = await _employeessRepository.FindBySurname(textBox1.Text);

            LoadDataGridView(employeessesList);
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                await SearchByNumberPhone();
                textBox2.Clear();
            }
            else
                MessageBox.Show("Заполните поле ввода");
        }
        private async Task SearchByNumberPhone()
        {
            var employeessesList = await _employeessRepository.FindByNumberPhone(textBox2.Text);

            LoadDataGridView(employeessesList);
        }
        #endregion

    }
}

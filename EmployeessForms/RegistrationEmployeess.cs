using Intership.Models;
using Intership.Repository.Interfaces;
using Intership.Repository.Class;

namespace Intership.EmployeessForms
{
    public partial class RegistrationEmployeess : Form
    {
        private int _roleId = default;
        private int _registrationId = default;

        private readonly ValidationService _validationService;
        private readonly IRoleRepository<Role> _roleRepository;
        private readonly IRegistrationDataRepository<RegistrationData> _registrationDataRepository;
        private readonly IEmployeessRepository<Employeess> _employeessRepository;
        public RegistrationEmployeess()
        {
            _validationService = new ValidationService();
            _roleRepository = new RoleRepository();
            _registrationDataRepository = new RegistrationDataRepository();
            _employeessRepository = new EmployeessRepository();
            InitializeComponent();
        }
        private async void RegistrationEmployeess_Load(object sender, EventArgs e)
        {
            await LoadRoles();
        }
        #region Roles
        private async Task LoadRoles()
        {
            var roleList = await _roleRepository.GetAll();
            foreach (var item in roleList)
            {
                comboBox1.Items.Add(item.Name);
            }
        }
        private async Task LoadRoleId()
        {
            if (comboBox1.SelectedItem != null)
            {
                var result = await _roleRepository.GetByName(comboBox1.Text);
                _roleId = result.Id;
            }
            else
                MessageBox.Show("Выберите должность");
        }
        #endregion
        #region RegistrationData
        private async Task CreateRegistrationData()
        {
            RegistrationData registrationData = new()
            {
                Login = textBox5.Text,
                Password = textBox6.Text
            };
            if (_validationService.IsValid(registrationData))
                await _registrationDataRepository.Create(registrationData);
            else
                MessageBox.Show("Валидация не пройдена, логин и пароли должны содержать минимум 5 символов");
        }
        private async Task SelectRegistrationId()
        {
            var result = await _registrationDataRepository.GetByLoginAndPassword(textBox5.Text, textBox6.Text);
            _registrationId = result.Id;
        }
        #endregion
        #region  Employee
        private async Task CreateEmployee()
        {
            Employeess employeess = new()
            {
                Surname = textBox1.Text,
                Name = textBox2.Text,
                MiddleName = textBox3.Text,
                NumberPhobne = textBox4.Text,
                RegistrationDataId = _registrationId,
                RoleId = _roleId
            };
            if (_validationService.IsValid(employeess))
            {
                await _employeessRepository.Create(employeess);
                MessageBox.Show("Вы успешно зарегестрировали пользователя");
            }
            else
            {
                MessageBox.Show("Валидация не пройдена, проверьте введеные данные");
                await _registrationDataRepository.Delete(_registrationId);
            }
        }
        #endregion
        private async void button1_Click(object sender, EventArgs e)
        {
            await LoadRoleId();
            if (textBox5.Text != "" & textBox6.Text == textBox7.Text & textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "")
            { 
                await CreateRegistrationData();
                await SelectRegistrationId();
                await CreateEmployee();

            }
            else
                MessageBox.Show("Проверьте введный логин и пароль");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MainForm main = new();
            Hide();
            main.Show();
        }
    }
}

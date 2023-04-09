using Intership.Models;
using Intership.Repository.Class;
using Intership.Repository.Interfaces;

namespace Intership.EmployeessForms
{
    public partial class Authorize : Form
    {
        private readonly IEmployeessRepository<Employeess> _employeessRepository;
        private readonly IRegistrationDataRepository<RegistrationData> _registrationDataRepository;
        public Authorize()
        {
            _employeessRepository = new EmployeessRepository();
            _registrationDataRepository = new RegistrationDataRepository();

            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "")
            {
                int registrationDataId = await SelectRegistrationDataId();
                if (registrationDataId != 0)
                {
                    await LoadRoleId(registrationDataId);

                    MainForm main = new();
                    Hide();
                    main.ShowDialog();
                }
            }
            else
                MessageBox.Show("Заполните поля ввода");
        }
        private async Task<int> SelectRegistrationDataId()
        {
            try
            {
                var registrationData =
                    await _registrationDataRepository.GetByLoginAndPassword(textBox1.Text, textBox2.Text);
                return registrationData.Id;
            }
            catch
            {
                MessageBox.Show("Пользователя с таким логином или паролем не сущесвтует");
                return 0;
            }
        }
        private async Task LoadRoleId(int registrationDataId)
        {
            var employee = await _employeessRepository.FindByRegistrationId(registrationDataId);
            WC.RoleId = employee.RoleId;
        }
        private void Authorize_Load(object sender, EventArgs e)
        {

        }
    }
}

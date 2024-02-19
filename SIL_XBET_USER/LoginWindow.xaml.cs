using SIL_XBET_USER;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using SIL_XBET_BANK;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SIL_XBET_USER
{


    public partial class LoginWindow : Window
    {
        XBETContext db = new XBETContext();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ButtonLog(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Password;

            User authUser = null;
            XBETContext db = new XBETContext();


            authUser = db.User.Where(s => s.Login == login && s.Password == password).FirstOrDefault();

            if (authUser != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();

                //TopUpBalance topUpBalance = new TopUpBalance();
                //topUpBalance.Show();
                //Close();

            }
            else
            {
                MessageBox.Show("Ты что-то сделал не так :(");
            }

        }
    }
}
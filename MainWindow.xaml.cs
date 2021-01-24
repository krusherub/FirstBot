using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram.Bot;

namespace FirstBot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TelegramBotClient bot;
        ObservableCollection<TelegramUser> Users;
        string text;
       // long? id = null;
        public MainWindow()
        {
            InitializeComponent();
            Users = new ObservableCollection<TelegramUser>();
            usersList.ItemsSource = Users;
            
            string token = "1449690225:AAHiXgfIV6lfSb0HQgtW4EPTuUIO6Kp-Nhg";
            bot = new TelegramBotClient(token);

            bot.OnMessage += delegate (object sender, Telegram.Bot.Args.MessageEventArgs e)
            {
                //   id = e.Message.Chat.Id;
                
                //  Debug.WriteLine(person.Id);
                string msg = $"{e.Message.Chat.FirstName}: {e.Message.Text}";
                this.Dispatcher.Invoke(() => {
                    var person = new TelegramUser(e.Message.Chat.FirstName, e.Message.Chat.Id);

                    if (!Users.Contains(person)) Users.Add(person);
                   // person.AddMessage("ss");
                    Users[Users.IndexOf(person)].AddMessage(msg);

                    //list1.ItemsSource = Users[Users.IndexOf(person)].Messages;


                });
                
            };
           bot.StartReceiving();

            textBox.KeyDown += (s, e) =>
            {
                if (e.Key == Key.Enter)
                    btnAction_Click(s, e);
            };
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("sadasdad");
          //  list1.Background = Brushes.Black;
            text = textBox.Text;
            if(usersList.SelectedItem != null)
            {
                var currUser = Users[Users.IndexOf(usersList.SelectedItem as TelegramUser)];
                // bot.StartReceiving();
                currUser.Messages.Add("Support: " + text);
                bot.SendTextMessageAsync(currUser.Id, text);

                textBox.Text = String.Empty;
            }
               
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

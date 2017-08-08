using ChattingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace ChattingClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public static IChattingService Server;
        private static DuplexChannelFactory<IChattingService> _channelFactory;
        public MainWindow()
        {
            InitializeComponent();
            _channelFactory = new DuplexChannelFactory<IChattingService>(new ClientCallback(), "ChattingServiceEndPoint");
            Server = _channelFactory.CreateChannel();
        }

       public void TakeMessage(string message, string userName)
        {
            ChatDisplayTextBox.Text += userName + ": " + message + "\n";
            //Scrolls automatically to text at the bottom of the message box
            ChatDisplayTextBox.ScrollToEnd();
        }

        //Sends the message in the chat textbox when send is clicked
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if(ChatTextBox.Text.Length == 0 )
            {
                return;
            }
            Server.SendMessageToAll(ChatTextBox.Text, UserNameTextBox.Text);
            TakeMessage(ChatTextBox.Text, "You");
            ChatTextBox.Text = "";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int returnValue = Server.Login(UserNameTextBox.Text);
            if(returnValue == 1)
            {
                MessageBox.Show("You are already logged in. Try again");
            }
            else if (returnValue == 0)
            {
                //Displays the name of the user who logged on
                MessageBox.Show("You successfully logged in!");
                WelcomeUserLbl.Content = "Welcome " + UserNameTextBox.Text + "!";
                UserNameTextBox.IsEnabled = false;
                LoginButton.IsEnabled = false;

                //loads users
                LoadUserList(Server.GetCurrentUsers());
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Server.Logout();
        }
        //Adds online users to show there online
        public void AddUserToList(string userName)
        {
            if(OnlineUserListBox.Items.Contains(userName))
            {
                return;
            }
            OnlineUserListBox.Items.Add(userName);
        }

        public void RemoveUserFromList(string userName)
        {
            if (OnlineUserListBox.Items.Contains(userName))
            {
                OnlineUserListBox.Items.Remove(userName);
            }

        }

        private void LoadUserList(List<string>users)
        {
            foreach(var user in users)
            {
                AddUserToList(user);
            }
        }

        
    }
}

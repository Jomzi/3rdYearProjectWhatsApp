using ChattingInterfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChattingServer
{

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]

    public class ChattingService : IChattingService
    {
        public ConcurrentDictionary<string, ConnectedClient> _connectedClients = new ConcurrentDictionary<string,
            ConnectedClient>();

        public int Login(string userName)
        {
            //is anyone else logged in with my name?
            { foreach (var client in _connectedClients) 
                {
                    if(client.Key.ToLower()==userName.ToLower())
                    {
                        //if yes 
                        return 1;
                    }
                }
            }
            var establishedUserConnection = OperationContext.Current.GetCallbackChannel<IClient>();

            //username is unqiue...so cannot log in with the same username.
            ConnectedClient newClient = new ConnectedClient();
            newClient.connection = establishedUserConnection;
            newClient.UserName = userName;

            _connectedClients.TryAdd(userName, newClient);

            updateHelper(0, userName);

            //shows information on the console window of the user login 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Client Logged In: {0} at {1}", newClient.UserName, System.DateTime.Now);
            Console.ResetColor();

            return 0;
        }

        public void Logout()
        {
            ConnectedClient client = GetMyClient();
            if(client != null)
            {
                ConnectedClient removedClient;
                _connectedClients.TryRemove(client.UserName, out removedClient);

                updateHelper(1, removedClient.UserName);
                //shows information on the console window of the user logged out 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Client Logged Off: {0} at {1}", removedClient.UserName, System.DateTime.Now);
                Console.ResetColor();
            }
            
        }


        public ConnectedClient GetMyClient()
        {
            var establishedUserConnection = OperationContext.Current.GetCallbackChannel<IClient>();
            foreach(var client in _connectedClients)
            {
                if(client.Value.connection == establishedUserConnection)
                {
                    return client.Value;
                }
            }
            return null;
        }
        //Sends message to all users
        public void SendMessageToAll(string message, string userName)
        {
            foreach(var client in _connectedClients)
            {
                if(client.Key.ToLower() != userName.ToLower())
                    {
                     client.Value.connection.GetMessage(message, userName);
                    }
            }
            
        }

        private void updateHelper(int Value, string userName)
        {
            foreach (var client in _connectedClients)
            {
                if (client.Value.UserName.ToLower() != userName.ToLower())
                {
                    client.Value.connection.GetUpdate(Value, userName);
                }
            }
        }

        public List<string> GetCurrentUsers()
        {
            List<string> listOfClients = new List<string>();
            foreach (var client in _connectedClients)
            {
                listOfClients.Add(client.Value.UserName);
            }
            {
                return listOfClients;
            }
        }
    }
}

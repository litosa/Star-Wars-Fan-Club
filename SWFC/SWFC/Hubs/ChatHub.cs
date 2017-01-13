using System;
using System.Collections.Generic;
using System.Linq;

using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using SWFC.ChatServiceReference;

namespace SWFC
{
    public class ChatHub : Hub
    {
        ChatServiceClient client = new ChatServiceClient();
        
        static ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();


        public void Get(string name)
        {

            List<Chat> listMessages = client.GetMessages().ToList();
            List<Chat> filteredListMessagesByName = listMessages.Where(lm => lm.SendTo == name || 
                                                      lm.Name == name ||
                                                      lm.SendTo == null).Take(15).ToList();
                        
            Clients.All.getBroadcastMessage(filteredListMessagesByName);
        }        

        public void Send(string name, string message)
        {
            string createdAt = DateTime.Now.ToString();

            Chat newMessage = new Chat();
            newMessage.Name = name;
            newMessage.Message = message;
            newMessage.MessagePosted = createdAt;

            client.CreateMessage(newMessage);
            
            Clients.All.broadcastMessage(name, message, createdAt);
        }        

        public void SendToSpecific(string name, string message, string to)
        {
            string createdAt = DateTime.Now.ToString();

            Chat newMessage = new Chat();
            newMessage.Name = name;
            newMessage.Message = message;
            newMessage.MessagePosted = createdAt;
            newMessage.SendTo = to;

            client.CreateMessage(newMessage);
            
            Clients.Caller.broadcastMessage(name, message, createdAt);
            Clients.Client(dic[to]).broadcastMessage(name, message, createdAt);
        }

        public void Notify(string name, string id)
        {
            if (dic.ContainsKey(name))
            {
                Clients.Caller.differentName();
            }
            else
            {
                dic.TryAdd(name, id);
                foreach (KeyValuePair<String, String> entry in dic)
                {
                    Clients.Caller.online(entry.Key);
                }
                Clients.Others.enters(name);
            }
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var name = dic.FirstOrDefault(x => x.Value == Context.ConnectionId.ToString());

            if (name.Key != null)
            {
                string s;
                dic.TryRemove(name.Key, out s);
                Clients.All.disconnected(name.Key);
            }            

            return base.OnDisconnected(stopCalled);
        }
    }
}
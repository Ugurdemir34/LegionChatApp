using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace WebAPI.Hubs
{
    public class BroadcastHub : Hub
    {
        private IMessageService _messageService;
        public  ConcurrentDictionary<int, string> Connections = new ConcurrentDictionary<int, string>();      
        //private TimerManager _timer;
        public BroadcastHub(IMessageService messageService /*TimerManager timer*/)
        {
            _messageService = messageService;
            // _timer = timer;
        }
        public async void SendMessage(LastMessageDto newMessage)
        {                
            _messageService.Add(new Entities.Concrete.Message
            {
                DeliveredDate = newMessage.DeliveredDate,
                MessageContent = newMessage.MessageContent,
                MessageFrom = newMessage.MessageFrom,
                MessageTo = newMessage.MessageTo
            });
            var To = Connections.FirstOrDefault(i => i.Key == newMessage.MessageTo).Value;
            if(To !=null)
            {              
                await Clients.Client(To).SendAsync("messagetransfer", newMessage);
            }         
        }
        public async void Texting(int userid,int friendId,int message)
        {
            var To = Connections.FirstOrDefault(i => i.Key == friendId).Value;
            if (To != null)
            {
                await Clients.Client(To).SendAsync("textingtransfer",userid,friendId,message);
            }
        }
     
        public void Connect(int userid,string connectionId)
        {
            Connections.AddOrUpdate(userid, connectionId, (a, b) => connectionId);
            Console.WriteLine(Connections.ToString());
        }       
       
    }
}

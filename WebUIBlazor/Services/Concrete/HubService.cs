using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIBlazor.Services.Concrete
{
    public sealed class HubService
    {
        private static HubConnection hubConnection = null;
        private static readonly object padlock = new object();
        public HubService()
        {
        }
        public static HubConnection Hub
        {
            get
            {
                if(hubConnection==null)
                {                  
                    lock(padlock)
                    {
                        if(hubConnection==null)
                        {
                            hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:44399/broadcast").Build();
                        }
                    }
                }
                return hubConnection;
            }
        }
    }
}

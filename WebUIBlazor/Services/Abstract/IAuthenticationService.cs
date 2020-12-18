using Core.Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUIBlazor.Models;

namespace WebUIBlazor.Services.Abstract
{
    public interface IAuthenticationService
    {
        TokenModel User { get; }
        Task Initialize();
        Task Login(LoginModel loginModel);       
        Task Logout();
    }
}

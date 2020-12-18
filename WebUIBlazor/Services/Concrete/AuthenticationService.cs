using Blazored.LocalStorage;
using Core.Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebUIBlazor.Models;
using WebUIBlazor.Services.Abstract;
using Microsoft.AspNetCore.SignalR.Client;
namespace WebUIBlazor.Services.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {


        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private HttpClient _httpClient;
        // private HubConnection _hub;

        public AuthenticationService(NavigationManager navigationManager, ILocalStorageService localStorageService, HttpClient httpClient)
        {
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }

        public TokenModel User { get; private set; }


        // public HubConnection Hub { get; set; } =

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<TokenModel>("tokenModel");
           // Hub = await _localStorageService.GetItem<HubConnection>("connectionModel");
        }

        public async Task Login(LoginModel loginModel)
        {
            var r = await _httpClient.PostAsJsonAsync("https://localhost:44399/api/auth/login", loginModel);
            var response = r.Content.ReadFromJsonAsync<TokenModel>();


            if (!String.IsNullOrEmpty(response.ToString()))
            {
                User = new TokenModel
                {
                    Token = response.Result.Token,
                    UserId = response.Result.UserId,
                    UserName = response.Result.UserName,
                  

                };
               
                await _localStorageService.SetItem("tokenModel", User);
              



            }
        }
        public async Task Logout()
        {
            User = null;
            
            await _localStorageService.RemoveItem("tokenModel");
            
            _navigationManager.NavigateTo("login");
        }


    }
}

using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserHobbyDto
    {
        public UserHobbyDto()
        {
           
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string About { get; set; }
        public string NativeLanguage { get; set; }
        public byte[] Photo { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime ProfileCreatedDate { get; set; }
        public string Sex { get; set; }
        public int Age
        {
            get 
            {
                TimeSpan ts = DateTime.Now - Birthday;
                return DateTime.MinValue.AddDays(ts.Days).Year-1; 
            }         
        }
        public bool isFriend { get; set; }
        public List<Hobby> Hobbies { get; set; }
        public List<Language> Languages { get; set; }    
      //  public List<Request> Requests { get; set; }
        
    }
}

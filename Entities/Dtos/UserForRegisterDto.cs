using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Dtos
{
    public class UserForRegisterDto : IDto
    {

        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]      
        public string About { get; set; }
        public string NativeLanguage { get; set; }
        public byte[] Photo { get; set; }      
        [Column(TypeName = "datetime2")]
        public DateTime Birthday { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ProfileCreatedDate { get; set; } = DateTime.Now;
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Sex { get; set; }
        public List<Language> Languages { get; set; } = new List<Language>();
        public List<Hobby> Hobbies { get; set; } = new List<Hobby>();
    }
}

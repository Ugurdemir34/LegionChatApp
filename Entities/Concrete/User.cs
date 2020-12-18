using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
       
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
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
        public virtual ICollection<UserHobby> UserHobbies { get; set; }

        public virtual ICollection<UserLanguage> UserLanguages { get; set; }

       
        

    }
}

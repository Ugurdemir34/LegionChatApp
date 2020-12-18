using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Dtos
{
    public class UserForCommunityDetailDto:IDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string About { get; set; }
        public string NativeLanguage { get; set; }
        public byte[] Photo { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Birthday { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ProfileCreatedDate { get; set; } = DateTime.Now;
        public string Country { get; set; }
        public string City { get; set; }
        public string Sex { get; set; }
        public bool Friendship { get; set; }
        public List<Language> Languages { get; set; } = new List<Language>();
        public List<Hobby> Hobbies { get; set; } = new List<Hobby>();
    }
}

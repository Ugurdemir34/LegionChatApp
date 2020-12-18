using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{

    public class Language : IEntity
    {
        public Language()
        {

        }       
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string CountryCode { get; set; }
        public virtual ICollection<UserLanguage> UserLanguages { get; set; }

    }
}

using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class UserLanguage:IEntity
    {

        public int UserId { get; set; }
       
        public int LanguageId { get; set; }
        // --------------------------------------------
        public virtual User User { get; set; }



    
        public virtual  Language Language { get; set; }

    }
}

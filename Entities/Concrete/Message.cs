using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Message :IEntity
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public DateTime DeliveredDate { get; set; }
        public  int MessageFrom { get; set; }
        public  int MessageTo { get; set; }
        // --------------------------------------------       
       
    }
}

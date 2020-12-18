using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class LastMessageDto:IDto
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public DateTime DeliveredDate { get; set; }
        public int MessageFrom { get; set; }
        public int MessageTo { get; set; }
        public string connectionId { get; set; }
    }
}

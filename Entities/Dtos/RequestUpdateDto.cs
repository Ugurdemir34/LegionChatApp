using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RequestUpdateDto
    {
        public int Id { get; set; }
        public int RequestFrom { get; set; }
        public bool Accepted { get; set; }
        public int RequestTo { get; set; }
    }
}

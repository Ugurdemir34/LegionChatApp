using Core.Entities;
using Entities.Concrete;
using Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RequestStateDto :IDto
    {
        public Request Request { get; set; }
        public RequestStates RequestStates { get; set; }
    }
}

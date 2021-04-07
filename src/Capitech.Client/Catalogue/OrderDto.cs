using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Catalogue
{
    public class OrderDto
    {
        public int ClientId { get; set; }

        public int OrderId { get; set;}

        public string Description { get; set; }

        public bool IsActive { get; set; }

    }
}

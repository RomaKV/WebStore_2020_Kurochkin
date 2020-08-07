using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.WebStore.ViewModels
{
    public class OrderDetailsViewModel
    {
        public CartViewModel CartViewModel { get; set; }
        public OrderViewModel OrderViewModel { get; set; }
    }
}

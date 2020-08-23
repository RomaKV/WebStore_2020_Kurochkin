using System;
using System.Collections.Generic;
using System.Text;
using Common.WebStore.ViewModels;

namespace Common.WebStore.ViewModels
{
    public class BrandCompleteViewModel
    {
        public IEnumerable<BrandViewModel> Brands { get; set; }

        public int? CurrentBrandId { get; set; }
    }
}

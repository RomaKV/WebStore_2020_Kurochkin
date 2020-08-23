using System;
using System.Collections.Generic;
using System.Text;
using Common.WebStore.ViewModels;

namespace Common.WebStore.DomainNew.ViewModels
{
    public class CategoryCompleteViewModel
    {
        public  IEnumerable<CategoryViewModel> Category { get; set; }

        public int? CurrentParentCategoryId { get; set; }

        public int? CurrentCategoryId { get; set; }

    }
}

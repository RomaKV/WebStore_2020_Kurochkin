﻿using Common.WebStore.Domain.Entities.Base.Interfaces;
using Common.WebStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.WebStore.DomainNew.Dto
{
    public class CreateOrderDto
    {
      public string UserName { get; set; }

      public  OrderViewModel Order { get; set; } 
     
      public  CartViewModel Cart { get; set; }
        
    }
}
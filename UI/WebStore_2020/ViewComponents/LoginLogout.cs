﻿
using Microsoft.AspNetCore.Mvc;

namespace UI.WebStore.ViewComponents
{
    public class LoginLogout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

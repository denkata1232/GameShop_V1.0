﻿
using Data.Models;
using GameShop_V1._0.ViewModels;
using System.Collections.Generic;

namespace GameShop_V1._0
{
    public static class GlobalInfo
    {
        public const string SecretAdminPassword = "admin123";
        public static User CurrentUser = null;
        public static List<CartProductViewModel> Cart = new List<CartProductViewModel>();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Library
{
    public interface ICheckout
    {
        IEnumerable<BasketItem> Scan(string item);
        int GetTotalPrice();
    }
}

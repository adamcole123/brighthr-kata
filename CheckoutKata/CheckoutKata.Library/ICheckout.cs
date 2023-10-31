using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Library
{
    internal interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}

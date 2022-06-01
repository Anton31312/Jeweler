using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeweler.EF
{
    public partial class Product
    {
        public string GetCost
        {
            get => $"Стоимость: {ProductCost}";
        }

        public string GetManufacture
        {
            get => $"Производитель: {ProductManufature.NameManufacture}";
        }

        public string GetCount
        {
            get => $"Наличие на складе: {ProductQuantityInStock}";
        }

        public string GetColor
        {
            get
            {
                if (ProductQuantityInStock == 0)
                {
                    return "#808080";
                }
                else
                {
                    return "#FFFFFF";
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.ProductSpec
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
    {
        public ProductWithBrandAndCategorySpecifications() : base()
        {
            Include.Add(P => P.Brand);
            Include.Add(P => P.Category);
        }
        
        //public ProductWithBrandAndCategorySpecifications() : base()
        //{
        //    Include.Add(P => P.Brand);
        //    Include.Add(P => P.Category);
        //}
    }
}

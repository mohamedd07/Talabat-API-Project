using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.ProductSpec
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
    {
        public ProductWithBrandAndCategorySpecifications(string? sort, int? brandId, int? categoryId) 
            : base(P=>
                        (!brandId.HasValue    || P.BrandId == brandId.Value) &&
                        (!categoryId.HasValue || P.CategoryId == categoryId.Value)
            )
        {
            Include.Add(P => P.Brand);
            Include.Add(P => P.Category);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(P => P.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDesc(P => P.Price);
                        break;

                    default: AddOrderBy(P => P.Name);
                        break;
                }  
            }
            else 
                AddOrderBy(P => P.Name);
        }

        public ProductWithBrandAndCategorySpecifications(int id) : base(P => P.Id == id)
        {
            Include.Add(P=> P.Brand);
            Include.Add(P => P.Category);
        }
    }
}

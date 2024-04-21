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
        public ProductWithBrandAndCategorySpecifications(ProductSpecParams specParams) 
            : base(P=>
                        (string.IsNullOrEmpty(specParams.Search) || P.Name.ToLower().Contains(specParams.Search)) &&
                        (!specParams.brandId.HasValue    || P.BrandId == specParams.brandId.Value) &&
                        (!specParams.categoryId.HasValue || P.CategoryId == specParams.categoryId.Value)
            )
        {
            Include.Add(P => P.Brand);
            Include.Add(P => P.Category);

            if (!string.IsNullOrEmpty(specParams.sort))
            {
                switch (specParams.sort)
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

            ApplyPagination((specParams.PageIndex - 1) * specParams.PageSize , specParams.PageSize);
        }

        public ProductWithBrandAndCategorySpecifications(int id) : base(P => P.Id == id)
        {
            Include.Add(P=> P.Brand);
            Include.Add(P => P.Category);
        }
    }
}

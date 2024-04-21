﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Specifications.ProductSpec
{
    public class ProductSpecParams
    {
        private int pageSize = 5;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > 10 ? 10 : value; } 
        }

        public int PageIndex { get; set; } = 1;

        private string? search;
        public string? Search
        {
            get { return search; }
            set { search = value?.ToLower(); }
        }
        public string? sort {  get; set; }
        public int? categoryId { get; set; }
        public int? brandId { get; set;}

        

    }
}
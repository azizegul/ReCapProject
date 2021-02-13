using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandService brandService;

        public BrandManager(IBrandService brandService)
        {
            this.brandService = brandService;
        }
    }
}

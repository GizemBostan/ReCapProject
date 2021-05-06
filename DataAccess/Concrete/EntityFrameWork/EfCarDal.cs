using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ProjectDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ProjectDbContext context=new ProjectDbContext())
            {
                var result = from cars in context.Cars
                             join color in context.Colors
                             on cars.ColorId equals color.ColorId
                             join brands in context.Brands 
                             on cars.BrandId equals brands.BrandId
                             select new CarDetailDto
                             {
                                 CarName = cars.CarName,
                                 ColorName = color.ColorName,
                                 DailyPrice = cars.DailyPrice,
                                 BrandName=brands.BrandName
                             };
                return result.ToList();
            }
        }
    }
}

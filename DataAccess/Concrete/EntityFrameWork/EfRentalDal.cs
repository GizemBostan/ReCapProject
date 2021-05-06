using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ProjectDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ProjectDbContext context = new ProjectDbContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers on r.CustomerId equals c.UserId
                             join car in context.Cars on r.CarId equals car.CarId
                             join u in context.Users on c.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId=car.CarId,
                                 CustomerId=c.UserId,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate
                                 
                             };
                return result.ToList();
            }
        }
    }
}

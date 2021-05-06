using Business.Abstract;
using Business.Concrete;
using Core.DataAccess;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //CarDetail();
            //AddTest();
            //DeleteTest();
            //UserTest();

        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { Id = 3, FirstName = "arzu", LastName = "bostan", Email = "arzu@a.com", Password = "12345" });
            foreach (var u in userManager.GetAll().Data)
            {
                Console.WriteLine(u.FirstName);
            }
        }

        private static void DeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { CarId = 4, BrandId = 3, CarName = "spor", ColorId = 2, DailyPrice = 134, Description = "manuel", ModelYear = 2010 });
            foreach (var c in carManager.GetAll().Data)
            {
                Console.WriteLine(c.CarName);
            }
        }

        private static void AddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { CarId = 4, BrandId = 3, CarName = "spor", ColorId = 2, DailyPrice = 134, Description = "manuel", ModelYear = 2010 });
            foreach (var c in carManager.GetAll().Data)
            {
                Console.WriteLine(c.CarName);
            }
        }

        private static void CarDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarName);
                }
            }
        }

    }
}

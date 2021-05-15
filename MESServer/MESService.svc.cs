using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MESModel;

namespace MESServer
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class MESService : IMESService
    {
        public string GetData(int value)
        {
            //return string.Format("You entered: {0}", value);
            using (AppContext db = new AppContext())
            {
                foreach (ProductAvailability pa in db.ProductAvailabilities)
                {
                    return pa.Product.Name;
                }
                return "empty";
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int GetDiff(int a, int b)
        {
            return a - b;
        }

        public List<Department> GetDepartments()
        {
            List<Department> result = new List<Department>();
            using (AppContext db = new AppContext())
            {
                var departments = db.Departments.Where(d => d.Parent == null);
                foreach (Department department in departments)
                {
                    result.Add(department);
                }
            }
            return result;
        }

        public string InitDb()
        {
            using (AppContext db = new AppContext())
            {
                // Clear all tables
                db.Departments.RemoveRange(db.Departments);
                db.Employees.RemoveRange(db.Employees);
                db.EmployeeCategories.RemoveRange(db.EmployeeCategories);
                db.Movements.RemoveRange(db.Movements);
                db.Products.RemoveRange(db.Products);
                db.ProductAvailabilities.RemoveRange(db.ProductAvailabilities);
                db.Teams.RemoveRange(db.Teams);
                db.TeamMembers.RemoveRange(db.TeamMembers);
                db.SaveChanges();

                Department department1  = new Department { Name = "Склад сырьевой", Parent = null };
                Department department2  = new Department { Name = "Цех 1 (сборка основных деталей)", Parent = null };
                Department department3  = new Department { Name = "Участок 1 (сборка фюзеляжа)", Parent = department2 };
                Department department4  = new Department { Name = "Участок 2 (сборка крыльев)", Parent = department2 };
                Department department5  = new Department { Name = "Участок 3 (сборка шасси)", Parent = department2 };
                Department department6  = new Department { Name = "Цех 2 (финальная сборка)", Parent = null };
                Department department7  = new Department { Name = "Участок 1 (механосборка)", Parent = department6 };
                Department department8  = new Department { Name = "Участок 2 (монтаж электрооборудования)", Parent = department6 };
                Department department9  = new Department { Name = "Цех 3 (покраска и салон)", Parent = null };
                Department department10 = new Department { Name = "Участок 1 (покраска)", Parent = department9 };
                Department department11 = new Department { Name = "Участок 2 (салон)", Parent = department9 };
                Department department12 = new Department { Name = "Склад готовой продукции", Parent = null };

                db.Departments.Add(department1);
                db.Departments.Add(department2);
                db.Departments.Add(department3);
                db.Departments.Add(department4);
                db.Departments.Add(department5);
                db.Departments.Add(department6);
                db.Departments.Add(department7);
                db.Departments.Add(department8);
                db.Departments.Add(department9);
                db.Departments.Add(department10);
                db.Departments.Add(department11);
                db.Departments.Add(department12);

                Product product1  = new Product { Name = "Лист металла" };
                Product product2  = new Product { Name = "Крепеж" };
                Product product3  = new Product { Name = "Двигатель" };
                Product product4  = new Product { Name = "Крыло" };
                Product product5  = new Product { Name = "Хвостовая секция фюзеляжа" };
                Product product6  = new Product { Name = "Средняя секция фюзеляжа" };
                Product product7  = new Product { Name = "Передняя секция фюзеляжа" };
                Product product8  = new Product { Name = "Шасси" };
                Product product9  = new Product { Name = "Шасси в сборе" };
                Product product10 = new Product { Name = "Кабель электрический" };
                Product product11 = new Product { Name = "Краска по металлу" };
                Product product12 = new Product { Name = "Самолет под покраску" };
                Product product13 = new Product { Name = "Самолет к продаже" };

                db.Products.Add(product1);
                db.Products.Add(product2);
                db.Products.Add(product3);
                db.Products.Add(product4);
                db.Products.Add(product5);
                db.Products.Add(product6);
                db.Products.Add(product7);
                db.Products.Add(product8);
                db.Products.Add(product9);
                db.Products.Add(product10);
                db.Products.Add(product11);
                db.Products.Add(product12);
                db.Products.Add(product13);

                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product1 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product1 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product1 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product1 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product1 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product2 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product2 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product2 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product2 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product2 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product3 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product3 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product8 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product10 });
                db.ProductAvailabilities.Add(new ProductAvailability { Department = department1, Product = product11 });

                EmployeeCategory employeeCategory1 = new EmployeeCategory { Name = "Рабочие" };
                db.EmployeeCategories.Add(employeeCategory1);

                Employee emloyee1  = new Employee { Name = "Иванов И.И.", EmployeeCategory = employeeCategory1 };
                Employee emloyee2  = new Employee { Name = "Петров П.С.", EmployeeCategory = employeeCategory1 };
                Employee emloyee3  = new Employee { Name = "Васильев В.В.", EmployeeCategory = employeeCategory1 };
                Employee emloyee4  = new Employee { Name = "Алексеев И.А.", EmployeeCategory = employeeCategory1 };
                Employee emloyee5  = new Employee { Name = "Иванов А.И.", EmployeeCategory = employeeCategory1 };
                Employee emloyee6  = new Employee { Name = "Андреев Г.П.", EmployeeCategory = employeeCategory1 };
                Employee emloyee7  = new Employee { Name = "Петров С.В.", EmployeeCategory = employeeCategory1 };

                db.Employees.Add(emloyee1);
                db.Employees.Add(emloyee2);
                db.Employees.Add(emloyee3);
                db.Employees.Add(emloyee4);
                db.Employees.Add(emloyee5);
                db.Employees.Add(emloyee6);
                db.Employees.Add(emloyee7);

                db.Teams.Add(new Team { Name = "Бригада 1", Department = department3, Leader = emloyee1 });
                db.Teams.Add(new Team { Name = "Бригада 2", Department = department4, Leader = emloyee2 });
                db.Teams.Add(new Team { Name = "Бригада 3", Department = department5, Leader = emloyee3 });
                db.Teams.Add(new Team { Name = "Бригада 4", Department = department7, Leader = emloyee4 });
                db.Teams.Add(new Team { Name = "Бригада 5", Department = department8, Leader = emloyee5 });
                db.Teams.Add(new Team { Name = "Бригада 6", Department = department10, Leader = emloyee6 });
                db.Teams.Add(new Team { Name = "Бригада 7", Department = department11, Leader = emloyee7 });
                db.SaveChanges();
            }
            return "Success";
        }

        public List<ProductAvailability> GetDepartmentAvailability(Department department)
        {
            List<ProductAvailability> result = new List<ProductAvailability>();
            using (AppContext db = new AppContext())
            {
                var products = from d in db.Departments
                               join pa in db.ProductAvailabilities on d.Id equals pa.Department.Id
                               join p in db.Products on pa.Product.Id equals p.Id
                               where d.Parent.Id == department.Id || d.Id == department.Id
                               select new
                               {
                                   Id = pa.Id,
                                   Product = p,
                                   Department = d
                               };
                foreach (var product in products)
                {
                    result.Add(new ProductAvailability { Id = product.Id, Product = product.Product, Department = product.Department });
                }
            }
            return result;
        }

        public List<Product> GetProducts()
        {
            List<Product> result = new List<Product>();
            using (AppContext db = new AppContext())
            {
                foreach (Product product in db.Products)
                {
                    result.Add(product);
                }
            }
            return result;
        }

        public List<Team> GetTeams()
        {
            List<Team> result = new List<Team>();
            using (AppContext db = new AppContext())
            {
                foreach (Team team in db.Teams)
                {
                    result.Add(team);
                }
            }
            return result;
        }

        public int AddProduct(int productId, int departmentId)
        {
            using (AppContext db = new AppContext())
            {
                Product product = db.Products.Where(p => p.Id == productId).First();
                Department department = (Department)db.Departments.Where(d => d.Id == departmentId).First();
                db.ProductAvailabilities.Add(new ProductAvailability { Product = product, Department = department });
                db.SaveChanges();
            }
            return 1;
        }

        public int DeleteProduct(int productAvailabilityId)
        {
            using (AppContext db = new AppContext())
            {
                ProductAvailability productAvailability = db.ProductAvailabilities.Where(pa => pa.Id == productAvailabilityId).First();
                db.ProductAvailabilities.Remove(productAvailability);
                db.SaveChanges();
            }
            return 1;
        }

        public int DeleteProducts(List<int> productIds)
        {
            foreach (int productId in productIds)
            {
                DeleteProduct(productId);
            }
            return 1;
        }

        public int TakeProduct(int productAvailabilityId, int teamId)
        {
            using (AppContext db = new AppContext())
            {
                Department source = (from pa in db.ProductAvailabilities
                                     join d in db.Departments on pa.Department.Id equals d.Id
                                     where pa.Id == productAvailabilityId
                                     select d).First();
                ProductAvailability productAvailability = db.ProductAvailabilities.Where(pa => pa.Id == productAvailabilityId).First();
                var department = (from d in db.Departments
                                 join t in db.Teams on d.Id equals t.Department.Id
                                 where t.Id == teamId
                                 select d).First();
                productAvailability.Department = department;
                db.SaveChanges();
                Product product = (from pa in db.ProductAvailabilities
                                   join p in db.Products on pa.Product.Id equals p.Id
                                   where pa.Id == productAvailabilityId
                                   select p).First();
                Department destination = department;
                DateTime movementDate = DateTime.Now;
                Team team = db.Teams.Where(t => t.Id == teamId).First();
                Movement movement = new Movement { Product = product, Source = source, Destination = destination, MovementDate = movementDate, Team = team };
                db.Movements.Add(movement);
                db.SaveChanges();
            }
            return 1;
        }

        public int TakeProducts(List<int> productIds, int teamId)
        {
            foreach (int productId in productIds)
            {
                TakeProduct(productId, teamId);
            }
            return 1;
        }

        public List<Movement> GetInputMovements(Department department)
        {
            List<Movement> result = new List<Movement>();
            using (AppContext db = new AppContext())
            {
                var movements = from m in db.Movements
                                join dd in db.Departments on m.Destination.Id equals dd.Id
                                join ds in db.Departments on m.Source.Id equals ds.Id
                                join p in db.Products on m.Product.Id equals p.Id
                                join t in db.Teams on m.Team.Id equals t.Id
                                where (dd.Parent.Id == department.Id || dd.Id == department.Id) &&
                                  !(ds.Parent.Id == department.Id || ds.Id == department.Id)
                                select new
                                {
                                    Id = m.Id,
                                    Product = p,
                                    Source = ds,
                                    Destination = dd,
                                    MovementDate = m.MovementDate,
                                    Team = t
                                };
                foreach (var movement in movements)
                {
                    result.Add(new Movement {
                        Id = movement.Id,
                        Product = movement.Product,
                        Source = movement.Source,
                        Destination = movement.Destination,
                        MovementDate = movement.MovementDate,
                        Team = movement.Team
                    });
                }
            }
            return result;
        }

        public List<Movement> GetOutputMovements(Department department)
        {
            List<Movement> result = new List<Movement>();
            using (AppContext db = new AppContext())
            {
                var movements = from m in db.Movements
                                join dd in db.Departments on m.Destination.Id equals dd.Id
                                join ds in db.Departments on m.Source.Id equals ds.Id
                                join p in db.Products on m.Product.Id equals p.Id
                                join t in db.Teams on m.Team.Id equals t.Id
                                where ds.Parent.Id == department.Id || ds.Id == department.Id
                                select new
                                {
                                    Id = m.Id,
                                    Product = p,
                                    Source = ds,
                                    Destination = dd,
                                    MovementDate = m.MovementDate,
                                    Team = t
                                };
                foreach (var movement in movements)
                {
                    result.Add(new Movement
                    {
                        Id = movement.Id,
                        Product = movement.Product,
                        Source = movement.Source,
                        Destination = movement.Destination,
                        MovementDate = movement.MovementDate,
                        Team = movement.Team
                    });
                }
            }
            return result;
        }

        public int GiveProduct(List<int> productAvailabilityIds, int teamId, int newProductId)
        {
            using (AppContext db = new AppContext())
            {
                foreach (int productAvailabilityId in productAvailabilityIds)
                {
                    ProductAvailability productAvailability = db.ProductAvailabilities.Where(pa => pa.Id == productAvailabilityId).First();
                    db.ProductAvailabilities.Remove(productAvailability);
                    db.SaveChanges();
                }
                Product product = db.Products.Where(p => p.Id == newProductId).First();
                Department department = (from d in db.Departments
                                         join t in db.Teams on d.Id equals t.Department.Id
                                         where t.Id == teamId
                                         select d).First();
                db.ProductAvailabilities.Add(new ProductAvailability { Product = product, Department = department });
                db.SaveChanges();
                Department source = department;
                Department destination = department;
                DateTime movementDate = DateTime.Now;
                Team team = db.Teams.Where(t => t.Id == teamId).First();
                Movement movement = new Movement { Product = product, Source = source, Destination = destination, MovementDate = movementDate, Team = team };
                db.Movements.Add(movement);
                db.SaveChanges();
            }
            return 1;
        }
    }
}

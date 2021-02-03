using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);// Referansı yakalama
                addedEntity.State = EntityState.Added;//Bu eklenecek bir nesnedir
                context.SaveChanges();//Tüm işlemleri gerçekleştir
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);// Referansı yakalama
                deletedEntity.State = EntityState.Deleted;//Bu silinecek bir nesnedir
                context.SaveChanges();//Tüm işlemleri gerçekleştir
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);// Referansı yakalama
                updatedEntity.State = EntityState.Modified;//Bu güncellenecek bir nesnedir
                context.SaveChanges();//Tüm işlemleri gerçekleştir
            }
        }
    }
}

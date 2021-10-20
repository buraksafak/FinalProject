using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{

    //where sozcugu ile kisitlama yapiyoruz.
    //class = referans tip olabilir demek.
    //T, ya IEntity ya da IEntity'den implemente edilmis bir nesne olabilir.
    //new'lenebilir olmali.
    //tum bunlari, sistemimizin yalnizca veritabani nesneleri ile calisan bir repository olmasi icin yaptik.
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity>
        where TEntity:class,IEntity, new()
        where TContext: DbContext, new()

    {

        public void Add(TEntity entity)
        {
            /*context, bellek acisindan yuklu bir islem. using yapisi, context ile isimiz bittiginde, otomatik olarak garbagecollector calistirarak
            bellekten siler.  (IDisposable pattern implementation of c#) */
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {

            //Select * from calistirir.
            using (TContext context = new TContext())
            {

                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            // Arkaplanda, Select * from Product islemini yapar.
            using (TContext context = new TContext())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }


    }
}

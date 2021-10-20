using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //where sozcugu ile kisitlama yapiyoruz. 
    //class = referans tip olabilir demek.
    //T, ya IEntity ya da IEntity'den implemente edilmis bir nesne olabilir.
    //new' lenebilir olmali.
    //tum bunlari, sistemimizin yalnizca veritabani nesneleri ile calisan bir repository olmasi icin gerceklestirdik.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Expression, dinamik filtreleme yapmamıza yarıyor.(Delegate) 
        
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        T Get(Expression<Func<T, bool>> filter = null);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

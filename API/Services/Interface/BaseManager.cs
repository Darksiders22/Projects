using Data;
using Models.Interfaces;

namespace Services.Interface
{

    public abstract class BaseManager<T> where T : IBaseModel
    {
        protected StoreDbContext context;
        public BaseManager(StoreDbContext db)
        {
            this.context = db;
        }
        public abstract string Add(T model);
        public abstract string Update(T model);
        public abstract string Delete(T model);
        public abstract T Get(int id);
    }


}



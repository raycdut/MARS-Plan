namespace MeetingRoomReservation.Data.SqlServer.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using MeetingRoomReservation.Data.SqlServer.IRepository;

    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        public RepositoryBase()
        {
            this.Db = new ReservationContext();
        }

        public RepositoryBase(ReservationContext dbCtx)
        {
            this.Db = dbCtx;
        }

        public ReservationContext Db { get; set; }

        public void Delete(T obj)
        {
            this.Db.Entry(obj).State = EntityState.Deleted;
            this.Db.SaveChanges();
        }

        public IEnumerable<T> Get()
        {
            return this.Db.Set<T>();
        }

        public void Insert(T obj)
        {
            this.Db.Entry(obj).State = EntityState.Added;
            this.Db.SaveChanges();
        }

        public void Update(T obj)
        {
            this.Db.Entry(obj).State = EntityState.Modified;
            this.Db.SaveChanges();
        }

        public T Single(Expression<Func<T, bool>> selector)
        {
            return this.Db.Set<T>().FirstOrDefault(selector);
        }
    }
}
namespace MeetingRoomReservation.Data.SqlServer.IRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepositoryBase<T>
        where T : class
    {
        IEnumerable<T> Get();

        T Single(Expression<Func<T, bool>> selector);

        void Update(T obj);

        void Delete(T obj);

        void Insert(T obj);
    }
}
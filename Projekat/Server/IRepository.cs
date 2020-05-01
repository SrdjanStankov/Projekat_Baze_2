using System.Collections.Generic;

namespace Server
{
    public interface IRepository
    {
        void Add<T>(T item); // C

        IEnumerable<T2> Get<T1, T2>(T1 id); // R

        void Update<T>(T item); // U

        void Remove<T>(T id); // D
    }
}
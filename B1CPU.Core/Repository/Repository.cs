using System.Collections.Generic;

namespace B1CPU.Core.Repository
{
    public class Repository<T> : List<T>, IRepository<T>
    {
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IRepositoryWrapper
    {
        IBookRepository Book { get; }
        void Save();
    }
}

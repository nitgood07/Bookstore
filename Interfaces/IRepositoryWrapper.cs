using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    interface IRepositoryWrapper
    {
        IBookRepository Book { get; }
        void Save();
    }
}

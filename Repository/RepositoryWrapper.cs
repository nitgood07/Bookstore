using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IBookRepository _book;

       
        public IBookRepository Book 
        {
            get
            {
                if(_book == null)
                {
                    _book = new BookRepository(_repoContext);
                }
                return _book;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}

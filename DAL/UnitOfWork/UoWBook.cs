﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEventManager.DAL;
using DAL.Domain;
using DAL.Repositories;
using DAL.Repository;
using Shared_Library.Interface;

namespace DAL.UnitOfWork
{
      public class UoWBook : IUnitofWork
    {
        private DatabaseContext context;
        private IRepository<BookReadingEvent> bookRepository;

        public UoWBook(DatabaseContext context)
        {
            this.context = context;
        }

        public IRepository<BookReadingEvent> BookRepository
        {
            get
            {
                if (this.bookRepository == null)
                {
                    this.bookRepository = new BaseRepository<BookReadingEvent>(context);
                }
                return bookRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UoWBook() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion



    }
}
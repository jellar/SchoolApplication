using System;

namespace SchoolApplication.Data.Infrastructure
{
    public class Disposable : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
        }

        ~Disposable()
        {
            Dispose(false);
        }

        private bool isDisposed;
        private void Dispose(bool disposing)
        {
            if(!isDisposed && disposing)
            {
                DisposeCore();
            }
            isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
            
        }
    }
}

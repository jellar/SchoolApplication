namespace SchoolApplication.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private SchoolEntities1 dataContext;

        protected override void DisposeCore()
        {
            if(dataContext != null)
            {
                dataContext.Dispose();
            }
        }
        public SchoolEntities1 Get()
        {
            return dataContext ?? (dataContext = new SchoolEntities1());
        }
    }
}

namespace SchoolApplication.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;

        private SchoolEntities1 dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected SchoolEntities1 DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }
       

        public void Commit()
        {
            DataContext.Commit();
        }
    }
}

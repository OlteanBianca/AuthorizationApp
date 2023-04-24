using AuthorizationApp.DBContext;

namespace AuthorizationApp.Repositories
{
    public class UnitOfWork
    {
        #region Private Fields
        private readonly AppDbContext _dbContext;
        #endregion

        #region Properties
        public StudentRepository Students { get; }
        public ClassRepository Classes { get; }
        public RoleRepository Roles { get; }
        public UserRepository Users { get; }
        #endregion

        #region Constructors
        public UnitOfWork(AppDbContext dbContext, StudentRepository students, ClassRepository classes, RoleRepository roles, UserRepository users)
        {
            _dbContext = dbContext;
            Students = students;
            Classes = classes;
            Roles = roles;
            Users = users;
        }
        #endregion

        #region Public Methods
        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }
        #endregion
    }
}

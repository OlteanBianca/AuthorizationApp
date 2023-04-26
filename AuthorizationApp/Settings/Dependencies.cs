using AuthorizationApp.DBContext;
using AuthorizationApp.Repositories;
using AuthorizationApp.Services;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationApp.Settings
{
    public static class Dependencies
    {
        #region Private Methods
        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<IClassService, ClassService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<StudentRepository>();
            services.AddScoped<RoleRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<ClassRepository>();
            services.AddScoped<GradeRepository>();
            services.AddScoped<UnitOfWork>();
        }
        #endregion

        #region Public Methods
        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            applicationBuilder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(applicationBuilder.Configuration.GetConnectionString("DefaultConnection"));
            });

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }
        #endregion
    }
}

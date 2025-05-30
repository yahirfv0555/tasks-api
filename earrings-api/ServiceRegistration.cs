using earrings_api.Features.Notes;
using earrings_api.Features.Tasks;
using EarringsApi.Features.Users;

namespace earrings_api
{
    public static class ServiceRegistrations
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<NotesController>();
            services.AddScoped<NotesRepository>();

            services.AddScoped<TasksController>();
            services.AddScoped<TasksRepository>();

            services.AddScoped<UsersController>();
            services.AddScoped<UsersRepository>();
        }
    }
}

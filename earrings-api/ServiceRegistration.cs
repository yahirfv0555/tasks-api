using earrings_api.Features.Notes;

namespace earrings_api
{
    public static class ServiceRegistrations
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<NotesController>();
            services.AddScoped<NotesRepository>();
        }
    }
}

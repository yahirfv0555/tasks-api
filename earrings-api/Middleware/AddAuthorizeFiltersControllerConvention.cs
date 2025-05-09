using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace earrings_api.Middleware
{
    public class AddAuthorizeFiltersControllerConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (
                !(
                    controller.ControllerName.Contains("Autenticacion") 
                    || controller.ControllerName.Contains("Correos")
                )
                && JsonConfiguration.GetEnvironment() != "QA"
            )
            {
                controller.Filters.Add(new AuthorizeFilter());
            }
        }
    }
}

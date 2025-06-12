#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AlertasEnviadosEndpoints
{
    public static IEndpointRouteBuilder MapAlertasEnviadosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AlertasEnviados").WithTags("AlertasEnviados").RequireAuthorization();
        MapAlertasEnviadosRoutes(group);
        return app;
    }

    private static void MapAlertasEnviadosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAlertasEnviadosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AlertasEnviados_GetAll").WithDisplayName("Get All AlertasEnviados");
        group.MapPost("/Filter", async (Filters.FilterAlertasEnviados filtro, string uri, IAlertasEnviadosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AlertasEnviados_Filter").WithDisplayName("Filter AlertasEnviados");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAlertasEnviadosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AlertasEnviados found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AlertasEnviados_GetById").WithDisplayName("Get AlertasEnviados By Id");
        group.MapPost("/AddAndUpdate", async (Models.AlertasEnviados regAlertasEnviados, string uri, IAlertasEnviadosValidation validation, IAlertasEnviadosWriter writer, IOperadorReader operadorReader, IAlertasReader alertasReader, IAlertasEnviadosService service) =>
        {
            var result = await service.AddAndUpdate(regAlertasEnviados, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AlertasEnviados_AddAndUpdate").WithDisplayName("Add or Update AlertasEnviados");
        group.MapDelete("/Delete", async (int id, string uri, IAlertasEnviadosValidation validation, IAlertasEnviadosWriter writer, IOperadorReader operadorReader, IAlertasReader alertasReader, IAlertasEnviadosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AlertasEnviados_Delete").WithDisplayName("Delete AlertasEnviados");
    }
}
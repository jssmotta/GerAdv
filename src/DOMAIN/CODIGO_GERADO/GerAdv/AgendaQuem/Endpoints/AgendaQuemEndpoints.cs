#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AgendaQuemEndpoints
{
    public static IEndpointRouteBuilder MapAgendaQuemEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AgendaQuem").WithTags("AgendaQuem").RequireAuthorization();
        MapAgendaQuemRoutes(group);
        return app;
    }

    private static void MapAgendaQuemRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAgendaQuemService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AgendaQuem_GetAll").WithDisplayName("Get All AgendaQuem");
        group.MapPost("/Filter", async (Filters.FilterAgendaQuem filtro, string uri, IAgendaQuemService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AgendaQuem_Filter").WithDisplayName("Filter AgendaQuem");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaQuemService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AgendaQuem found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaQuem_GetById").WithDisplayName("Get AgendaQuem By Id");
        group.MapPost("/AddAndUpdate", async (Models.AgendaQuem regAgendaQuem, string uri, IAgendaQuemValidation validation, IAgendaQuemWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IPrepostosReader prepostosReader, IAgendaQuemService service) =>
        {
            var result = await service.AddAndUpdate(regAgendaQuem, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AgendaQuem_AddAndUpdate").WithDisplayName("Add or Update AgendaQuem");
        group.MapDelete("/Delete", async (int id, string uri, IAgendaQuemValidation validation, IAgendaQuemWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IPrepostosReader prepostosReader, IAgendaQuemService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaQuem_Delete").WithDisplayName("Delete AgendaQuem");
    }
}
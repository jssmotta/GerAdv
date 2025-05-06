#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OperadorGruposAgendaOperadoresEndpoints
{
    public static IEndpointRouteBuilder MapOperadorGruposAgendaOperadoresEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/OperadorGruposAgendaOperadores").WithTags("OperadorGruposAgendaOperadores").RequireAuthorization();
        MapOperadorGruposAgendaOperadoresRoutes(group);
        return app;
    }

    private static void MapOperadorGruposAgendaOperadoresRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOperadorGruposAgendaOperadoresValidation validation, IOperadorGruposAgendaOperadoresWriter writer, IOperadorGruposAgendaReader operadorgruposagendaReader, IOperadorReader operadorReader, IOperadorGruposAgendaOperadoresService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("OperadorGruposAgendaOperadores: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("OperadorGruposAgendaOperadores_GetAll").WithDisplayName("Get All OperadorGruposAgendaOperadores");
        group.MapPost("/Filter", async (Filters.FilterOperadorGruposAgendaOperadores filtro, string uri, IOperadorGruposAgendaOperadoresValidation validation, IOperadorGruposAgendaOperadoresWriter writer, IOperadorGruposAgendaReader operadorgruposagendaReader, IOperadorReader operadorReader, IOperadorGruposAgendaOperadoresService service) =>
        {
            logger.Info("OperadorGruposAgendaOperadores: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorGruposAgendaOperadores_Filter").WithDisplayName("Filter OperadorGruposAgendaOperadores");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOperadorGruposAgendaOperadoresValidation validation, IOperadorGruposAgendaOperadoresWriter writer, IOperadorGruposAgendaReader operadorgruposagendaReader, IOperadorReader operadorReader, IOperadorGruposAgendaOperadoresService service, CancellationToken token) =>
        {
            logger.Info("OperadorGruposAgendaOperadores: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No OperadorGruposAgendaOperadores found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGruposAgendaOperadores_GetById").WithDisplayName("Get OperadorGruposAgendaOperadores By Id");
        group.MapPost("/AddAndUpdate", async (Models.OperadorGruposAgendaOperadores regOperadorGruposAgendaOperadores, string uri, IOperadorGruposAgendaOperadoresValidation validation, IOperadorGruposAgendaOperadoresWriter writer, IOperadorGruposAgendaReader operadorgruposagendaReader, IOperadorReader operadorReader, IOperadorGruposAgendaOperadoresService service) =>
        {
            logger.LogInfo("OperadorGruposAgendaOperadores", "AddAndUpdate", $"regOperadorGruposAgendaOperadores = {regOperadorGruposAgendaOperadores}", uri);
            var result = await service.AddAndUpdate(regOperadorGruposAgendaOperadores, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorGruposAgendaOperadores", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("OperadorGruposAgendaOperadores_AddAndUpdate").WithDisplayName("Add or Update OperadorGruposAgendaOperadores");
        group.MapDelete("/Delete", async (int id, string uri, IOperadorGruposAgendaOperadoresValidation validation, IOperadorGruposAgendaOperadoresWriter writer, IOperadorGruposAgendaReader operadorgruposagendaReader, IOperadorReader operadorReader, IOperadorGruposAgendaOperadoresService service) =>
        {
            logger.LogInfo("OperadorGruposAgendaOperadores", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorGruposAgendaOperadores", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGruposAgendaOperadores_Delete").WithDisplayName("Delete OperadorGruposAgendaOperadores");
    }
}
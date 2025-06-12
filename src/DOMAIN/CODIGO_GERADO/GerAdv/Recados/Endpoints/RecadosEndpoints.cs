#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class RecadosEndpoints
{
    public static IEndpointRouteBuilder MapRecadosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Recados").WithTags("Recados").RequireAuthorization();
        MapRecadosRoutes(group);
        return app;
    }

    private static void MapRecadosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IRecadosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Recados_GetAll").WithDisplayName("Get All Recados");
        group.MapPost("/Filter", async (Filters.FilterRecados filtro, string uri, IRecadosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Recados_Filter").WithDisplayName("Filter Recados");
        group.MapGet("/GetById/{id}", async (int id, string uri, IRecadosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Recados found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Recados_GetById").WithDisplayName("Get Recados By Id");
        group.MapPost("/AddAndUpdate", async (Models.Recados regRecados, string uri, IRecadosValidation validation, IRecadosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IHistoricoReader historicoReader, IContatoCRMReader contatocrmReader, ILigacoesReader ligacoesReader, IAgendaReader agendaReader, IRecadosService service) =>
        {
            var result = await service.AddAndUpdate(regRecados, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Recados_AddAndUpdate").WithDisplayName("Add or Update Recados");
        group.MapDelete("/Delete", async (int id, string uri, IRecadosValidation validation, IRecadosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IHistoricoReader historicoReader, IContatoCRMReader contatocrmReader, ILigacoesReader ligacoesReader, IAgendaReader agendaReader, IRecadosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Recados_Delete").WithDisplayName("Delete Recados");
    }
}
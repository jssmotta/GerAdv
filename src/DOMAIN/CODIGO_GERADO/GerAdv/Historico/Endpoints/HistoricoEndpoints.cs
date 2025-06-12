#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class HistoricoEndpoints
{
    public static IEndpointRouteBuilder MapHistoricoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Historico").WithTags("Historico").RequireAuthorization();
        MapHistoricoRoutes(group);
        return app;
    }

    private static void MapHistoricoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IHistoricoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Historico_GetAll").WithDisplayName("Get All Historico");
        group.MapPost("/Filter", async (Filters.FilterHistorico filtro, string uri, IHistoricoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Historico_Filter").WithDisplayName("Filter Historico");
        group.MapGet("/GetById/{id}", async (int id, string uri, IHistoricoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Historico found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Historico_GetById").WithDisplayName("Get Historico By Id");
        group.MapPost("/AddAndUpdate", async (Models.Historico regHistorico, string uri, IHistoricoValidation validation, IHistoricoWriter writer, IProcessosReader processosReader, IPrecatoriaReader precatoriaReader, IApensoReader apensoReader, IFaseReader faseReader, IStatusAndamentoReader statusandamentoReader, IHistoricoService service) =>
        {
            var result = await service.AddAndUpdate(regHistorico, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Historico_AddAndUpdate").WithDisplayName("Add or Update Historico");
        group.MapDelete("/Delete", async (int id, string uri, IHistoricoValidation validation, IHistoricoWriter writer, IProcessosReader processosReader, IPrecatoriaReader precatoriaReader, IApensoReader apensoReader, IFaseReader faseReader, IStatusAndamentoReader statusandamentoReader, IHistoricoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Historico_Delete").WithDisplayName("Delete Historico");
    }
}
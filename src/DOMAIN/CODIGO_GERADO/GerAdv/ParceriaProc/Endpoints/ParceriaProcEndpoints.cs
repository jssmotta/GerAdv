#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ParceriaProcEndpoints
{
    public static IEndpointRouteBuilder MapParceriaProcEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ParceriaProc").WithTags("ParceriaProc").RequireAuthorization();
        MapParceriaProcRoutes(group);
        return app;
    }

    private static void MapParceriaProcRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IParceriaProcService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ParceriaProc_GetAll").WithDisplayName("Get All ParceriaProc");
        group.MapPost("/Filter", async (Filters.FilterParceriaProc filtro, string uri, IParceriaProcService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ParceriaProc_Filter").WithDisplayName("Filter ParceriaProc");
        group.MapGet("/GetById/{id}", async (int id, string uri, IParceriaProcService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ParceriaProc found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ParceriaProc_GetById").WithDisplayName("Get ParceriaProc By Id");
        group.MapPost("/AddAndUpdate", async (Models.ParceriaProc regParceriaProc, string uri, IParceriaProcValidation validation, IParceriaProcWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IParceriaProcService service) =>
        {
            var result = await service.AddAndUpdate(regParceriaProc, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ParceriaProc_AddAndUpdate").WithDisplayName("Add or Update ParceriaProc");
        group.MapDelete("/Delete", async (int id, string uri, IParceriaProcValidation validation, IParceriaProcWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IParceriaProcService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ParceriaProc_Delete").WithDisplayName("Delete ParceriaProc");
    }
}
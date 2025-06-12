#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProcessosEndpoints
{
    public static IEndpointRouteBuilder MapProcessosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Processos").WithTags("Processos").RequireAuthorization();
        MapProcessosRoutes(group);
        return app;
    }

    private static void MapProcessosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProcessosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Processos_GetAll").WithDisplayName("Get All Processos");
        group.MapPost("/Filter", async (Filters.FilterProcessos filtro, string uri, IProcessosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Processos_Filter").WithDisplayName("Filter Processos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProcessosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Processos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Processos_GetById").WithDisplayName("Get Processos By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterProcessos? filtro, string uri, IProcessosService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Processos_GetListN").WithDisplayName("Get Processos List N");
        group.MapPost("/AddAndUpdate", async (Models.Processos regProcessos, string uri, IProcessosValidation validation, IProcessosWriter writer, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ICidadeReader cidadeReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, IProcessosService service) =>
        {
            var result = await service.AddAndUpdate(regProcessos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Processos_AddAndUpdate").WithDisplayName("Add or Update Processos");
        group.MapDelete("/Delete", async (int id, string uri, IProcessosValidation validation, IProcessosWriter writer, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ICidadeReader cidadeReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, IProcessosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Processos_Delete").WithDisplayName("Delete Processos");
    }
}
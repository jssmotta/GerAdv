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
        group.MapGet("/GetAll", async (int max, string uri, IProcessosValidation validation, IProcessosWriter writer, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, IProcessosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Processos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Processos_GetAll").WithDisplayName("Get All Processos");
        group.MapPost("/Filter", async (Filters.FilterProcessos filtro, string uri, IProcessosValidation validation, IProcessosWriter writer, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, IProcessosService service) =>
        {
            logger.Info("Processos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Processos_Filter").WithDisplayName("Filter Processos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProcessosValidation validation, IProcessosWriter writer, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, IProcessosService service, CancellationToken token) =>
        {
            logger.Info("Processos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Processos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Processos_GetById").WithDisplayName("Get Processos By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IProcessosValidation validation, IProcessosWriter writer, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, IProcessosService service) =>
        {
            logger.Info("Processos: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Processos found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Processos_GetByName").WithDisplayName("Get Processos By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterProcessos? filtro, string uri, IProcessosValidation validation, IProcessosWriter writer, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, IProcessosService service) =>
        {
            logger.Info("Processos: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Processos_GetListN").WithDisplayName("Get Processos List N");
        group.MapPost("/AddAndUpdate", async (Models.Processos regProcessos, string uri, IProcessosValidation validation, IProcessosWriter writer, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, IProcessosService service) =>
        {
            logger.LogInfo("Processos", "AddAndUpdate", $"regProcessos = {regProcessos}", uri);
            var result = await service.AddAndUpdate(regProcessos, uri);
            if (result == null)
            {
                logger.LogWarn("Processos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Processos_AddAndUpdate").WithDisplayName("Add or Update Processos");
        group.MapDelete("/Delete", async (int id, string uri, IProcessosValidation validation, IProcessosWriter writer, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, IProcessosService service) =>
        {
            logger.LogInfo("Processos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Processos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Processos_Delete").WithDisplayName("Delete Processos");
    }
}
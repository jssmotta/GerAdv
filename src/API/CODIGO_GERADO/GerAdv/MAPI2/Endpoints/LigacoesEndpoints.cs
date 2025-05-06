#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class LigacoesEndpoints
{
    public static IEndpointRouteBuilder MapLigacoesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Ligacoes").WithTags("Ligacoes").RequireAuthorization();
        MapLigacoesRoutes(group);
        return app;
    }

    private static void MapLigacoesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ILigacoesValidation validation, ILigacoesWriter writer, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, ILigacoesService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Ligacoes: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Ligacoes_GetAll").WithDisplayName("Get All Ligacoes");
        group.MapPost("/Filter", async (Filters.FilterLigacoes filtro, string uri, ILigacoesValidation validation, ILigacoesWriter writer, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, ILigacoesService service) =>
        {
            logger.Info("Ligacoes: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Ligacoes_Filter").WithDisplayName("Filter Ligacoes");
        group.MapGet("/GetById/{id}", async (int id, string uri, ILigacoesValidation validation, ILigacoesWriter writer, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, ILigacoesService service, CancellationToken token) =>
        {
            logger.Info("Ligacoes: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Ligacoes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Ligacoes_GetById").WithDisplayName("Get Ligacoes By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ILigacoesValidation validation, ILigacoesWriter writer, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, ILigacoesService service) =>
        {
            logger.Info("Ligacoes: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Ligacoes found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Ligacoes_GetByName").WithDisplayName("Get Ligacoes By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterLigacoes? filtro, string uri, ILigacoesValidation validation, ILigacoesWriter writer, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, ILigacoesService service) =>
        {
            logger.Info("Ligacoes: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Ligacoes_GetListN").WithDisplayName("Get Ligacoes List N");
        group.MapPost("/AddAndUpdate", async (Models.Ligacoes regLigacoes, string uri, ILigacoesValidation validation, ILigacoesWriter writer, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, ILigacoesService service) =>
        {
            logger.LogInfo("Ligacoes", "AddAndUpdate", $"regLigacoes = {regLigacoes}", uri);
            var result = await service.AddAndUpdate(regLigacoes, uri);
            if (result == null)
            {
                logger.LogWarn("Ligacoes", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Ligacoes_AddAndUpdate").WithDisplayName("Add or Update Ligacoes");
        group.MapDelete("/Delete", async (int id, string uri, ILigacoesValidation validation, ILigacoesWriter writer, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, ILigacoesService service) =>
        {
            logger.LogInfo("Ligacoes", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Ligacoes", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Ligacoes_Delete").WithDisplayName("Delete Ligacoes");
    }
}
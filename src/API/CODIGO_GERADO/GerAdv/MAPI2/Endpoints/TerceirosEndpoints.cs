#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TerceirosEndpoints
{
    public static IEndpointRouteBuilder MapTerceirosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Terceiros").WithTags("Terceiros").RequireAuthorization();
        MapTerceirosRoutes(group);
        return app;
    }

    private static void MapTerceirosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITerceirosValidation validation, ITerceirosWriter writer, IProcessosReader processosReader, IPosicaoOutrasPartesReader posicaooutraspartesReader, ITerceirosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Terceiros: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Terceiros_GetAll").WithDisplayName("Get All Terceiros");
        group.MapPost("/Filter", async (Filters.FilterTerceiros filtro, string uri, ITerceirosValidation validation, ITerceirosWriter writer, IProcessosReader processosReader, IPosicaoOutrasPartesReader posicaooutraspartesReader, ITerceirosService service) =>
        {
            logger.Info("Terceiros: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Terceiros_Filter").WithDisplayName("Filter Terceiros");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITerceirosValidation validation, ITerceirosWriter writer, IProcessosReader processosReader, IPosicaoOutrasPartesReader posicaooutraspartesReader, ITerceirosService service, CancellationToken token) =>
        {
            logger.Info("Terceiros: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Terceiros found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Terceiros_GetById").WithDisplayName("Get Terceiros By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITerceirosValidation validation, ITerceirosWriter writer, IProcessosReader processosReader, IPosicaoOutrasPartesReader posicaooutraspartesReader, ITerceirosService service) =>
        {
            logger.Info("Terceiros: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Terceiros found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Terceiros_GetByName").WithDisplayName("Get Terceiros By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTerceiros? filtro, string uri, ITerceirosValidation validation, ITerceirosWriter writer, IProcessosReader processosReader, IPosicaoOutrasPartesReader posicaooutraspartesReader, ITerceirosService service) =>
        {
            logger.Info("Terceiros: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Terceiros_GetListN").WithDisplayName("Get Terceiros List N");
        group.MapPost("/AddAndUpdate", async (Models.Terceiros regTerceiros, string uri, ITerceirosValidation validation, ITerceirosWriter writer, IProcessosReader processosReader, IPosicaoOutrasPartesReader posicaooutraspartesReader, ITerceirosService service) =>
        {
            logger.LogInfo("Terceiros", "AddAndUpdate", $"regTerceiros = {regTerceiros}", uri);
            var result = await service.AddAndUpdate(regTerceiros, uri);
            if (result == null)
            {
                logger.LogWarn("Terceiros", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Terceiros_AddAndUpdate").WithDisplayName("Add or Update Terceiros");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ITerceirosValidation validation, ITerceirosWriter writer, IProcessosReader processosReader, IPosicaoOutrasPartesReader posicaooutraspartesReader, ITerceirosService service) =>
        {
            logger.LogInfo("Terceiros", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Terceiros", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Terceiros_GetColumns").WithDisplayName("Get Terceiros Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ITerceirosValidation validation, ITerceirosWriter writer, IProcessosReader processosReader, IPosicaoOutrasPartesReader posicaooutraspartesReader, ITerceirosService service) =>
        {
            logger.LogInfo("Terceiros", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Terceiros", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Terceiros_UpdateColumns").WithDisplayName("Update Terceiros Columns");
        group.MapDelete("/Delete", async (int id, string uri, ITerceirosValidation validation, ITerceirosWriter writer, IProcessosReader processosReader, IPosicaoOutrasPartesReader posicaooutraspartesReader, ITerceirosService service) =>
        {
            logger.LogInfo("Terceiros", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Terceiros", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Terceiros_Delete").WithDisplayName("Delete Terceiros");
    }
}
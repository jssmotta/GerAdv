#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class UFEndpoints
{
    public static IEndpointRouteBuilder MapUFEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/UF").WithTags("UF").RequireAuthorization();
        MapUFRoutes(group);
        return app;
    }

    private static void MapUFRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IUFValidation validation, IUFWriter writer, IPaisesReader paisesReader, IUFService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("UF: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("UF_GetAll").WithDisplayName("Get All UF");
        group.MapPost("/Filter", async (Filters.FilterUF filtro, string uri, IUFValidation validation, IUFWriter writer, IPaisesReader paisesReader, IUFService service) =>
        {
            logger.Info("UF: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("UF_Filter").WithDisplayName("Filter UF");
        group.MapGet("/GetById/{id}", async (int id, string uri, IUFValidation validation, IUFWriter writer, IPaisesReader paisesReader, IUFService service, CancellationToken token) =>
        {
            logger.Info("UF: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No UF found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("UF_GetById").WithDisplayName("Get UF By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IUFValidation validation, IUFWriter writer, IPaisesReader paisesReader, IUFService service) =>
        {
            logger.Info("UF: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No UF found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("UF_GetByName").WithDisplayName("Get UF By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterUF? filtro, string uri, IUFValidation validation, IUFWriter writer, IPaisesReader paisesReader, IUFService service) =>
        {
            logger.Info("UF: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("UF_GetListN").WithDisplayName("Get UF List N");
        group.MapPost("/AddAndUpdate", async (Models.UF regUF, string uri, IUFValidation validation, IUFWriter writer, IPaisesReader paisesReader, IUFService service) =>
        {
            logger.LogInfo("UF", "AddAndUpdate", $"regUF = {regUF}", uri);
            var result = await service.AddAndUpdate(regUF, uri);
            if (result == null)
            {
                logger.LogWarn("UF", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("UF_AddAndUpdate").WithDisplayName("Add or Update UF");
        group.MapDelete("/Delete", async (int id, string uri, IUFValidation validation, IUFWriter writer, IPaisesReader paisesReader, IUFService service) =>
        {
            logger.LogInfo("UF", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("UF", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("UF_Delete").WithDisplayName("Delete UF");
    }
}
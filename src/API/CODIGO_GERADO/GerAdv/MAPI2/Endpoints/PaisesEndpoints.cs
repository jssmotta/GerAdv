#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PaisesEndpoints
{
    public static IEndpointRouteBuilder MapPaisesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Paises").WithTags("Paises").RequireAuthorization();
        MapPaisesRoutes(group);
        return app;
    }

    private static void MapPaisesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPaisesValidation validation, IPaisesWriter writer, IPaisesService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Paises: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Paises_GetAll").WithDisplayName("Get All Paises");
        group.MapPost("/Filter", async (Filters.FilterPaises filtro, string uri, IPaisesValidation validation, IPaisesWriter writer, IPaisesService service) =>
        {
            logger.Info("Paises: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Paises_Filter").WithDisplayName("Filter Paises");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPaisesValidation validation, IPaisesWriter writer, IPaisesService service, CancellationToken token) =>
        {
            logger.Info("Paises: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Paises found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Paises_GetById").WithDisplayName("Get Paises By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IPaisesValidation validation, IPaisesWriter writer, IPaisesService service) =>
        {
            logger.Info("Paises: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Paises found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Paises_GetByName").WithDisplayName("Get Paises By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterPaises? filtro, string uri, IPaisesValidation validation, IPaisesWriter writer, IPaisesService service) =>
        {
            logger.Info("Paises: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Paises_GetListN").WithDisplayName("Get Paises List N");
        group.MapPost("/AddAndUpdate", async (Models.Paises regPaises, string uri, IPaisesValidation validation, IPaisesWriter writer, IPaisesService service) =>
        {
            logger.LogInfo("Paises", "AddAndUpdate", $"regPaises = {regPaises}", uri);
            var result = await service.AddAndUpdate(regPaises, uri);
            if (result == null)
            {
                logger.LogWarn("Paises", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Paises_AddAndUpdate").WithDisplayName("Add or Update Paises");
        group.MapDelete("/Delete", async (int id, string uri, IPaisesValidation validation, IPaisesWriter writer, IPaisesService service) =>
        {
            logger.LogInfo("Paises", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Paises", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Paises_Delete").WithDisplayName("Delete Paises");
    }
}
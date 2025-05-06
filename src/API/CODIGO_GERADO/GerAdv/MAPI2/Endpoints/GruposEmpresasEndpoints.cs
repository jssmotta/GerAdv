#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GruposEmpresasEndpoints
{
    public static IEndpointRouteBuilder MapGruposEmpresasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GruposEmpresas").WithTags("GruposEmpresas").RequireAuthorization();
        MapGruposEmpresasRoutes(group);
        return app;
    }

    private static void MapGruposEmpresasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGruposEmpresasValidation validation, IGruposEmpresasWriter writer, IOponentesReader oponentesReader, IClientesReader clientesReader, IGruposEmpresasService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("GruposEmpresas: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GruposEmpresas_GetAll").WithDisplayName("Get All GruposEmpresas");
        group.MapPost("/Filter", async (Filters.FilterGruposEmpresas filtro, string uri, IGruposEmpresasValidation validation, IGruposEmpresasWriter writer, IOponentesReader oponentesReader, IClientesReader clientesReader, IGruposEmpresasService service) =>
        {
            logger.Info("GruposEmpresas: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GruposEmpresas_Filter").WithDisplayName("Filter GruposEmpresas");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGruposEmpresasValidation validation, IGruposEmpresasWriter writer, IOponentesReader oponentesReader, IClientesReader clientesReader, IGruposEmpresasService service, CancellationToken token) =>
        {
            logger.Info("GruposEmpresas: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GruposEmpresas found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GruposEmpresas_GetById").WithDisplayName("Get GruposEmpresas By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IGruposEmpresasValidation validation, IGruposEmpresasWriter writer, IOponentesReader oponentesReader, IClientesReader clientesReader, IGruposEmpresasService service) =>
        {
            logger.Info("GruposEmpresas: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No GruposEmpresas found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GruposEmpresas_GetByName").WithDisplayName("Get GruposEmpresas By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterGruposEmpresas? filtro, string uri, IGruposEmpresasValidation validation, IGruposEmpresasWriter writer, IOponentesReader oponentesReader, IClientesReader clientesReader, IGruposEmpresasService service) =>
        {
            logger.Info("GruposEmpresas: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("GruposEmpresas_GetListN").WithDisplayName("Get GruposEmpresas List N");
        group.MapPost("/AddAndUpdate", async (Models.GruposEmpresas regGruposEmpresas, string uri, IGruposEmpresasValidation validation, IGruposEmpresasWriter writer, IOponentesReader oponentesReader, IClientesReader clientesReader, IGruposEmpresasService service) =>
        {
            logger.LogInfo("GruposEmpresas", "AddAndUpdate", $"regGruposEmpresas = {regGruposEmpresas}", uri);
            var result = await service.AddAndUpdate(regGruposEmpresas, uri);
            if (result == null)
            {
                logger.LogWarn("GruposEmpresas", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GruposEmpresas_AddAndUpdate").WithDisplayName("Add or Update GruposEmpresas");
        group.MapDelete("/Delete", async (int id, string uri, IGruposEmpresasValidation validation, IGruposEmpresasWriter writer, IOponentesReader oponentesReader, IClientesReader clientesReader, IGruposEmpresasService service) =>
        {
            logger.LogInfo("GruposEmpresas", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("GruposEmpresas", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GruposEmpresas_Delete").WithDisplayName("Delete GruposEmpresas");
    }
}
#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GruposEmpresasCliEndpoints
{
    public static IEndpointRouteBuilder MapGruposEmpresasCliEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GruposEmpresasCli").WithTags("GruposEmpresasCli").RequireAuthorization();
        MapGruposEmpresasCliRoutes(group);
        return app;
    }

    private static void MapGruposEmpresasCliRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGruposEmpresasCliValidation validation, IGruposEmpresasCliWriter writer, IGruposEmpresasReader gruposempresasReader, IClientesReader clientesReader, IGruposEmpresasCliService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("GruposEmpresasCli: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GruposEmpresasCli_GetAll").WithDisplayName("Get All GruposEmpresasCli");
        group.MapPost("/Filter", async (Filters.FilterGruposEmpresasCli filtro, string uri, IGruposEmpresasCliValidation validation, IGruposEmpresasCliWriter writer, IGruposEmpresasReader gruposempresasReader, IClientesReader clientesReader, IGruposEmpresasCliService service) =>
        {
            logger.Info("GruposEmpresasCli: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GruposEmpresasCli_Filter").WithDisplayName("Filter GruposEmpresasCli");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGruposEmpresasCliValidation validation, IGruposEmpresasCliWriter writer, IGruposEmpresasReader gruposempresasReader, IClientesReader clientesReader, IGruposEmpresasCliService service, CancellationToken token) =>
        {
            logger.Info("GruposEmpresasCli: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GruposEmpresasCli found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GruposEmpresasCli_GetById").WithDisplayName("Get GruposEmpresasCli By Id");
        group.MapPost("/AddAndUpdate", async (Models.GruposEmpresasCli regGruposEmpresasCli, string uri, IGruposEmpresasCliValidation validation, IGruposEmpresasCliWriter writer, IGruposEmpresasReader gruposempresasReader, IClientesReader clientesReader, IGruposEmpresasCliService service) =>
        {
            logger.LogInfo("GruposEmpresasCli", "AddAndUpdate", $"regGruposEmpresasCli = {regGruposEmpresasCli}", uri);
            var result = await service.AddAndUpdate(regGruposEmpresasCli, uri);
            if (result == null)
            {
                logger.LogWarn("GruposEmpresasCli", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GruposEmpresasCli_AddAndUpdate").WithDisplayName("Add or Update GruposEmpresasCli");
        group.MapDelete("/Delete", async (int id, string uri, IGruposEmpresasCliValidation validation, IGruposEmpresasCliWriter writer, IGruposEmpresasReader gruposempresasReader, IClientesReader clientesReader, IGruposEmpresasCliService service) =>
        {
            logger.LogInfo("GruposEmpresasCli", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("GruposEmpresasCli", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GruposEmpresasCli_Delete").WithDisplayName("Delete GruposEmpresasCli");
    }
}
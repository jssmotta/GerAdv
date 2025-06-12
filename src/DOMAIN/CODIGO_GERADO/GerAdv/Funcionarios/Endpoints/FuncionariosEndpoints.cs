#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class FuncionariosEndpoints
{
    public static IEndpointRouteBuilder MapFuncionariosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Funcionarios").WithTags("Funcionarios").RequireAuthorization();
        MapFuncionariosRoutes(group);
        return app;
    }

    private static void MapFuncionariosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IFuncionariosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Funcionarios_GetAll").WithDisplayName("Get All Funcionarios");
        group.MapPost("/Filter", async (Filters.FilterFuncionarios filtro, string uri, IFuncionariosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Funcionarios_Filter").WithDisplayName("Filter Funcionarios");
        group.MapGet("/GetById/{id}", async (int id, string uri, IFuncionariosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Funcionarios found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Funcionarios_GetById").WithDisplayName("Get Funcionarios By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterFuncionarios? filtro, string uri, IFuncionariosService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Funcionarios_GetListN").WithDisplayName("Get Funcionarios List N");
        group.MapPost("/AddAndUpdate", async (Models.Funcionarios regFuncionarios, string uri, IFuncionariosValidation validation, IFuncionariosWriter writer, ICargosReader cargosReader, IFuncaoReader funcaoReader, ICidadeReader cidadeReader, IFuncionariosService service) =>
        {
            var result = await service.AddAndUpdate(regFuncionarios, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Funcionarios_AddAndUpdate").WithDisplayName("Add or Update Funcionarios");
        group.MapDelete("/Delete", async (int id, string uri, IFuncionariosValidation validation, IFuncionariosWriter writer, ICargosReader cargosReader, IFuncaoReader funcaoReader, ICidadeReader cidadeReader, IFuncionariosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Funcionarios_Delete").WithDisplayName("Delete Funcionarios");
    }
}
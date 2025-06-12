#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProDepositosEndpoints
{
    public static IEndpointRouteBuilder MapProDepositosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProDepositos").WithTags("ProDepositos").RequireAuthorization();
        MapProDepositosRoutes(group);
        return app;
    }

    private static void MapProDepositosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProDepositosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProDepositos_GetAll").WithDisplayName("Get All ProDepositos");
        group.MapPost("/Filter", async (Filters.FilterProDepositos filtro, string uri, IProDepositosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProDepositos_Filter").WithDisplayName("Filter ProDepositos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProDepositosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProDepositos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProDepositos_GetById").WithDisplayName("Get ProDepositos By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProDepositos regProDepositos, string uri, IProDepositosValidation validation, IProDepositosWriter writer, IProcessosReader processosReader, IFaseReader faseReader, ITipoProDespositoReader tipoprodespositoReader, IProDepositosService service) =>
        {
            var result = await service.AddAndUpdate(regProDepositos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProDepositos_AddAndUpdate").WithDisplayName("Add or Update ProDepositos");
        group.MapDelete("/Delete", async (int id, string uri, IProDepositosValidation validation, IProDepositosWriter writer, IProcessosReader processosReader, IFaseReader faseReader, ITipoProDespositoReader tipoprodespositoReader, IProDepositosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProDepositos_Delete").WithDisplayName("Delete ProDepositos");
    }
}
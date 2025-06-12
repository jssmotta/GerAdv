#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class EMPClassRiscosEndpoints
{
    public static IEndpointRouteBuilder MapEMPClassRiscosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/EMPClassRiscos").WithTags("EMPClassRiscos").RequireAuthorization();
        MapEMPClassRiscosRoutes(group);
        return app;
    }

    private static void MapEMPClassRiscosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IEMPClassRiscosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("EMPClassRiscos_GetAll").WithDisplayName("Get All EMPClassRiscos");
        group.MapPost("/Filter", async (Filters.FilterEMPClassRiscos filtro, string uri, IEMPClassRiscosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("EMPClassRiscos_Filter").WithDisplayName("Filter EMPClassRiscos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IEMPClassRiscosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No EMPClassRiscos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EMPClassRiscos_GetById").WithDisplayName("Get EMPClassRiscos By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterEMPClassRiscos? filtro, string uri, IEMPClassRiscosService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("EMPClassRiscos_GetListN").WithDisplayName("Get EMPClassRiscos List N");
        group.MapPost("/AddAndUpdate", async (Models.EMPClassRiscos regEMPClassRiscos, string uri, IEMPClassRiscosValidation validation, IEMPClassRiscosWriter writer, IEMPClassRiscosService service) =>
        {
            var result = await service.AddAndUpdate(regEMPClassRiscos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("EMPClassRiscos_AddAndUpdate").WithDisplayName("Add or Update EMPClassRiscos");
        group.MapDelete("/Delete", async (int id, string uri, IEMPClassRiscosValidation validation, IEMPClassRiscosWriter writer, IEMPClassRiscosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EMPClassRiscos_Delete").WithDisplayName("Delete EMPClassRiscos");
    }
}
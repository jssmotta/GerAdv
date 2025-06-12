#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OperadorEMailPopupEndpoints
{
    public static IEndpointRouteBuilder MapOperadorEMailPopupEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/OperadorEMailPopup").WithTags("OperadorEMailPopup").RequireAuthorization();
        MapOperadorEMailPopupRoutes(group);
        return app;
    }

    private static void MapOperadorEMailPopupRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOperadorEMailPopupService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_GetAll").WithDisplayName("Get All OperadorEMailPopup");
        group.MapPost("/Filter", async (Filters.FilterOperadorEMailPopup filtro, string uri, IOperadorEMailPopupService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_Filter").WithDisplayName("Filter OperadorEMailPopup");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOperadorEMailPopupService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No OperadorEMailPopup found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_GetById").WithDisplayName("Get OperadorEMailPopup By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterOperadorEMailPopup? filtro, string uri, IOperadorEMailPopupService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_GetListN").WithDisplayName("Get OperadorEMailPopup List N");
        group.MapPost("/AddAndUpdate", async (Models.OperadorEMailPopup regOperadorEMailPopup, string uri, IOperadorEMailPopupValidation validation, IOperadorEMailPopupWriter writer, IOperadorReader operadorReader, IOperadorEMailPopupService service) =>
        {
            var result = await service.AddAndUpdate(regOperadorEMailPopup, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_AddAndUpdate").WithDisplayName("Add or Update OperadorEMailPopup");
        group.MapDelete("/Delete", async (int id, string uri, IOperadorEMailPopupValidation validation, IOperadorEMailPopupWriter writer, IOperadorReader operadorReader, IOperadorEMailPopupService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_Delete").WithDisplayName("Delete OperadorEMailPopup");
    }
}
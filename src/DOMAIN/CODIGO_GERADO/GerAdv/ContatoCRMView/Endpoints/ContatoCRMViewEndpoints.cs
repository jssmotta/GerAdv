#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ContatoCRMViewEndpoints
{
    public static IEndpointRouteBuilder MapContatoCRMViewEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ContatoCRMView").WithTags("ContatoCRMView").RequireAuthorization();
        MapContatoCRMViewRoutes(group);
        return app;
    }

    private static void MapContatoCRMViewRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IContatoCRMViewService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ContatoCRMView_GetAll").WithDisplayName("Get All ContatoCRMView");
        group.MapPost("/Filter", async (Filters.FilterContatoCRMView filtro, string uri, IContatoCRMViewService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ContatoCRMView_Filter").WithDisplayName("Filter ContatoCRMView");
        group.MapGet("/GetById/{id}", async (int id, string uri, IContatoCRMViewService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ContatoCRMView found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRMView_GetById").WithDisplayName("Get ContatoCRMView By Id");
        group.MapPost("/AddAndUpdate", async (Models.ContatoCRMView regContatoCRMView, string uri, IContatoCRMViewValidation validation, IContatoCRMViewWriter writer, IContatoCRMViewService service) =>
        {
            var result = await service.AddAndUpdate(regContatoCRMView, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRMView_AddAndUpdate").WithDisplayName("Add or Update ContatoCRMView");
        group.MapDelete("/Delete", async (int id, string uri, IContatoCRMViewValidation validation, IContatoCRMViewWriter writer, IContatoCRMViewService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRMView_Delete").WithDisplayName("Delete ContatoCRMView");
    }
}
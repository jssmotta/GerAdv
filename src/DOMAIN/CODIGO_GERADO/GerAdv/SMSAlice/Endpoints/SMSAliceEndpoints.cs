#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class SMSAliceEndpoints
{
    public static IEndpointRouteBuilder MapSMSAliceEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/SMSAlice").WithTags("SMSAlice").RequireAuthorization();
        MapSMSAliceRoutes(group);
        return app;
    }

    private static void MapSMSAliceRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ISMSAliceService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("SMSAlice_GetAll").WithDisplayName("Get All SMSAlice");
        group.MapPost("/Filter", async (Filters.FilterSMSAlice filtro, string uri, ISMSAliceService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("SMSAlice_Filter").WithDisplayName("Filter SMSAlice");
        group.MapGet("/GetById/{id}", async (int id, string uri, ISMSAliceService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No SMSAlice found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("SMSAlice_GetById").WithDisplayName("Get SMSAlice By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterSMSAlice? filtro, string uri, ISMSAliceService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("SMSAlice_GetListN").WithDisplayName("Get SMSAlice List N");
        group.MapPost("/AddAndUpdate", async (Models.SMSAlice regSMSAlice, string uri, ISMSAliceValidation validation, ISMSAliceWriter writer, IOperadorReader operadorReader, ITipoEMailReader tipoemailReader, ISMSAliceService service) =>
        {
            var result = await service.AddAndUpdate(regSMSAlice, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("SMSAlice_AddAndUpdate").WithDisplayName("Add or Update SMSAlice");
        group.MapDelete("/Delete", async (int id, string uri, ISMSAliceValidation validation, ISMSAliceWriter writer, IOperadorReader operadorReader, ITipoEMailReader tipoemailReader, ISMSAliceService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("SMSAlice_Delete").WithDisplayName("Delete SMSAlice");
    }
}
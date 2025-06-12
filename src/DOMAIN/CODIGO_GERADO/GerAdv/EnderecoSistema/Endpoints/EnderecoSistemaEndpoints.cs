#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class EnderecoSistemaEndpoints
{
    public static IEndpointRouteBuilder MapEnderecoSistemaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/EnderecoSistema").WithTags("EnderecoSistema").RequireAuthorization();
        MapEnderecoSistemaRoutes(group);
        return app;
    }

    private static void MapEnderecoSistemaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IEnderecoSistemaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("EnderecoSistema_GetAll").WithDisplayName("Get All EnderecoSistema");
        group.MapPost("/Filter", async (Filters.FilterEnderecoSistema filtro, string uri, IEnderecoSistemaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("EnderecoSistema_Filter").WithDisplayName("Filter EnderecoSistema");
        group.MapGet("/GetById/{id}", async (int id, string uri, IEnderecoSistemaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No EnderecoSistema found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EnderecoSistema_GetById").WithDisplayName("Get EnderecoSistema By Id");
        group.MapPost("/AddAndUpdate", async (Models.EnderecoSistema regEnderecoSistema, string uri, IEnderecoSistemaValidation validation, IEnderecoSistemaWriter writer, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, ICidadeReader cidadeReader, IEnderecoSistemaService service) =>
        {
            var result = await service.AddAndUpdate(regEnderecoSistema, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("EnderecoSistema_AddAndUpdate").WithDisplayName("Add or Update EnderecoSistema");
        group.MapDelete("/Delete", async (int id, string uri, IEnderecoSistemaValidation validation, IEnderecoSistemaWriter writer, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, ICidadeReader cidadeReader, IEnderecoSistemaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EnderecoSistema_Delete").WithDisplayName("Delete EnderecoSistema");
    }
}
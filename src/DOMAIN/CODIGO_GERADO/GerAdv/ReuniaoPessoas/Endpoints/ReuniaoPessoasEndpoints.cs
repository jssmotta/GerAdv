#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ReuniaoPessoasEndpoints
{
    public static IEndpointRouteBuilder MapReuniaoPessoasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ReuniaoPessoas").WithTags("ReuniaoPessoas").RequireAuthorization();
        MapReuniaoPessoasRoutes(group);
        return app;
    }

    private static void MapReuniaoPessoasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IReuniaoPessoasService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ReuniaoPessoas_GetAll").WithDisplayName("Get All ReuniaoPessoas");
        group.MapPost("/Filter", async (Filters.FilterReuniaoPessoas filtro, string uri, IReuniaoPessoasService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ReuniaoPessoas_Filter").WithDisplayName("Filter ReuniaoPessoas");
        group.MapGet("/GetById/{id}", async (int id, string uri, IReuniaoPessoasService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ReuniaoPessoas found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ReuniaoPessoas_GetById").WithDisplayName("Get ReuniaoPessoas By Id");
        group.MapPost("/AddAndUpdate", async (Models.ReuniaoPessoas regReuniaoPessoas, string uri, IReuniaoPessoasValidation validation, IReuniaoPessoasWriter writer, IReuniaoReader reuniaoReader, IOperadorReader operadorReader, IReuniaoPessoasService service) =>
        {
            var result = await service.AddAndUpdate(regReuniaoPessoas, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ReuniaoPessoas_AddAndUpdate").WithDisplayName("Add or Update ReuniaoPessoas");
        group.MapDelete("/Delete", async (int id, string uri, IReuniaoPessoasValidation validation, IReuniaoPessoasWriter writer, IReuniaoReader reuniaoReader, IOperadorReader operadorReader, IReuniaoPessoasService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ReuniaoPessoas_Delete").WithDisplayName("Delete ReuniaoPessoas");
    }
}
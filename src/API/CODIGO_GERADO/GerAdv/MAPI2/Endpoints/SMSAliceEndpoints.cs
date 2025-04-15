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
        group.MapGet("/GetAll", async (int max, string uri, ISMSAliceValidation validation, ISMSAliceWriter writer, IOperadorReader operadorReader, ITipoEMailReader tipoemailReader, ISMSAliceService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("SMSAlice: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("SMSAlice_GetAll").WithDisplayName("Get All SMSAlice");
        group.MapPost("/Filter", async (Filters.FilterSMSAlice filtro, string uri, ISMSAliceValidation validation, ISMSAliceWriter writer, IOperadorReader operadorReader, ITipoEMailReader tipoemailReader, ISMSAliceService service) =>
        {
            logger.Info("SMSAlice: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("SMSAlice_Filter").WithDisplayName("Filter SMSAlice");
        group.MapGet("/GetById/{id}", async (int id, string uri, ISMSAliceValidation validation, ISMSAliceWriter writer, IOperadorReader operadorReader, ITipoEMailReader tipoemailReader, ISMSAliceService service, CancellationToken token) =>
        {
            logger.Info("SMSAlice: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No SMSAlice found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("SMSAlice_GetById").WithDisplayName("Get SMSAlice By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ISMSAliceValidation validation, ISMSAliceWriter writer, IOperadorReader operadorReader, ITipoEMailReader tipoemailReader, ISMSAliceService service) =>
        {
            logger.Info("SMSAlice: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No SMSAlice found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("SMSAlice_GetByName").WithDisplayName("Get SMSAlice By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterSMSAlice? filtro, string uri, ISMSAliceValidation validation, ISMSAliceWriter writer, IOperadorReader operadorReader, ITipoEMailReader tipoemailReader, ISMSAliceService service) =>
        {
            logger.Info("SMSAlice: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("SMSAlice_GetListN").WithDisplayName("Get SMSAlice List N");
        group.MapPost("/AddAndUpdate", async (Models.SMSAlice regSMSAlice, string uri, ISMSAliceValidation validation, ISMSAliceWriter writer, IOperadorReader operadorReader, ITipoEMailReader tipoemailReader, ISMSAliceService service) =>
        {
            logger.LogInfo("SMSAlice", "AddAndUpdate", $"regSMSAlice = {regSMSAlice}", uri);
            var result = await service.AddAndUpdate(regSMSAlice, uri);
            if (result == null)
            {
                logger.LogWarn("SMSAlice", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("SMSAlice_AddAndUpdate").WithDisplayName("Add or Update SMSAlice");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ISMSAliceValidation validation, ISMSAliceWriter writer, IOperadorReader operadorReader, ITipoEMailReader tipoemailReader, ISMSAliceService service) =>
        {
            logger.LogInfo("SMSAlice", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("SMSAlice", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("SMSAlice_GetColumns").WithDisplayName("Get SMSAlice Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ISMSAliceValidation validation, ISMSAliceWriter writer, IOperadorReader operadorReader, ITipoEMailReader tipoemailReader, ISMSAliceService service) =>
        {
            logger.LogInfo("SMSAlice", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("SMSAlice", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("SMSAlice_UpdateColumns").WithDisplayName("Update SMSAlice Columns");
        group.MapDelete("/Delete", async (int id, string uri, ISMSAliceValidation validation, ISMSAliceWriter writer, IOperadorReader operadorReader, ITipoEMailReader tipoemailReader, ISMSAliceService service) =>
        {
            logger.LogInfo("SMSAlice", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("SMSAlice", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("SMSAlice_Delete").WithDisplayName("Delete SMSAlice");
    }
}
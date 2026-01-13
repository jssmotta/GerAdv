namespace MenphisSI.GerAdv;

public static class AddServicesCustom
{
    public static void Add(WebApplicationBuilder builder)
    {
        // Registrar serviços gerados do AppSG (inclui Services, Readers, Writers, Factories, Validations, Wheres)
        MenphisSI.GerAdv.Services.AddServices.Add(builder);
        MenphisSI.GerAdv.Readers.AddServices.Add(builder);
        MenphisSI.GerAdv.Writers.AddServices.Add(builder);
        MenphisSI.GerAdv.Validations.AddServices.Add(builder);
        MenphisSI.GerAdv.Wheres.AddServices.Add(builder);
        MenphisSI.GerAdv.Entity.AddServices.Add(builder);

   
    }
}
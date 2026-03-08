using Domain.BaseCommon.Auditor;
using MenphisSI.BaseCommon.Auditor;

namespace API.Sistemas.Auditor;

public class AuditorController
{
    public static void ConfigureAuditorEndpoints(WebApplication app)
    {
        AuditorControllerBase.ConfigureAuditorEndpoints<SGDicionarioManager>(app);
    }
}
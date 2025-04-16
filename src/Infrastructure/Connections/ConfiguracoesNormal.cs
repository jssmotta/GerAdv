#if (!DEMOSAN)
 
using MenphisSI.GerEntityTools.Entity;
using System.ComponentModel;

 

namespace MenphisSI;

public static partial class Configuracoes
{
    public static string ConnectionString(string uri)
    {

#if (DEBUG)
      //  uri = "MDSDEMO";
#endif
        var dbRec = EntityApi.Read(uri);
        if (dbRec is null)
        {
            throw new InvalidEnumArgumentException("dbRec is null");
        }

        var cacheMe = $"{PCmdReadOnly}Packet Size=512;encrypt=true;Data Source=tcp:{dbRec.DataSource};Initial Catalog={dbRec.InitialCatalog};User Id={dbRec.UserID};Password={dbRec.Pwd256.Decrypt()};Max Pool Size=100;Pooling=true;Integrated Security=false;Connect Timeout=30;Persist Security Info=True;TrustServerCertificate=True;";
        return cacheMe;
    }
    public static string ConnectionStringRw(string uri)
    {
#if (DEBUG)
      //  uri = "MDSDEMO";
#endif
        var dbRec = EntityApi.Read(uri);
        if (dbRec is null)
        {
            throw new InvalidEnumArgumentException("dbRec is null");
        }

        var cacheMe = $"Packet Size=512;encrypt=true;Data Source=tcp:{dbRec.DataSource};Initial Catalog={dbRec.InitialCatalog};User Id={dbRec.UserID};Password={dbRec.Pwd256.Decrypt()};Max Pool Size=100;Pooling=true;Integrated Security=false;Connect Timeout=30;Persist Security Info=True;TrustServerCertificate=True;";
        return cacheMe;
    }

}

#endif
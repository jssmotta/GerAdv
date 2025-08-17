
namespace MenphisSI;
public static partial class ConfigSys
{
    public static int ReadCfgSys(string cKey, MsiSqlConnection oCnn)
    {   
        var nGet = ReadCfgSysX(cKey, oCnn); 
        return nGet;
    }
    public static string ReadCfgSysC(string cKey, MsiSqlConnection oCnn, string defaultResult = "")
    {  
        var cGet = ReadCfgSysCX(cKey, oCnn, defaultResult); 
        return cGet;
    }
}
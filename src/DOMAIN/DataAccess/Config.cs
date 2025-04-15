
namespace MenphisSI;
public static partial class ConfigSys
{
    public static int ReadCfgSys(string cKey, SqlConnection oCnn)
    {   
        var nGet = ReadCfgSysX(cKey, oCnn); 
        return nGet;
    }
    public static string ReadCfgSysC(string cKey, SqlConnection oCnn, string defaultResult = "")
    {  
        var cGet = ReadCfgSysCX(cKey, oCnn); 
        return cGet;
    }
}
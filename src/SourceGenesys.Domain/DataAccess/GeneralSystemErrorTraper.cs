
namespace MenphisSI;

public static class GeneralSystemErrorTraper
{ 
    public static void GetError(
          SqlException? ex,
        string sqlInfo = "",
        string ConnectionString = "", bool stackTrace = false)
    { 
        throw new Exception("Erro não tratado 0");

    }

    public static void GetError(
         Exception? ex = null,
        string extraInfo = "",
        bool stackTrace = false)
    {
        throw new Exception("Erro não tratado");

    }
}


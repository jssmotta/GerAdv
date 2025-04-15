namespace MenphisSI;

public static partial class DevourerOne
{

    public static int InteropOperId32() => 1;


    public static void ExplodeErrorWindows(string tabela, string texto, string errorDescription, string cSql)
    {

        throw new(texto + " : " + errorDescription + " - Erro sql: [" + cSql + "]");
    }


    public static int ClassRating(string cClass) => cClass switch
    {
        "6" => 0,
        "1" => 7,
        "A" => 6,
        "B" => 5,
        "C" => 4,
        "D" => 3,
        "E" => 2,
        "Z" => 1,
        _ => 1
    };

    public static decimal ConvertString2Decimal(string value)
    {
        try
        {
            return Convert.ToDecimal(value.Replace(",", string.Empty));
        }
        catch
        {
            return 0;
        }
    }



  
     
   
    internal static string MaskCep2(string cCep) => string.IsNullOrEmpty(cCep)
                ? string.Empty
                : cCep.Length == 8
                ? cCep[..2] + "." + cCep.Substring(startIndex: 2, length: 3) + "-" +
                       cCep.Substring(startIndex: 5, length: 3)
                : cCep; 

    public static string MaskCep(this string dado) => MaskCep2(dado);


    private static string MaskCpf2(string? cCpf)
    {

        return cCpf == null
            ? string.Empty
            : cCpf.IsCpf()
            ? $"{cCpf[..3]}.{cCpf.Substring(startIndex: 3, length: 3)}.{cCpf.Substring(startIndex: 6, length: 3)}-{cCpf.Substring(startIndex: 9, length: 2)}"
            : $"{cCpf}";
    }


    public static string MaskCpf(this string dado) => MaskCpf2(dado);
    public static bool IsCpf(this string documento) => DevourerOne.CPFValido(documento);

}


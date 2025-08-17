namespace MenphisSI;

/// <summary>
/// Serviços para todos os produtos de Menphis - Sistemas Inteligentes
/// </summary>
public static partial class DevourerOne
{

    public static int Idade(DateTime dataNascimento, string today = "")
    {
        var hoje = today == "" ? DateTime.Today : Convert.ToDateTime(today);
        var idade = hoje.Year - dataNascimento.Year;

        if (dataNascimento.Date > hoje.AddYears(-idade)) idade--;

        return idade;
    }


    
    public static (bool setUpNow, bool changed, DateTime? data) DateUp12(in bool hasChange, DateTime? currDate, string? value)
    =>
         value switch
        {
            // Pattern matching otimizado
            var v when v.AsSpan().Equals("now".AsSpan(), StringComparison.OrdinalIgnoreCase)
                => (true, true, DateTimeUtc),

            null or { Length: 0 }
                => (currDate.HasValue, currDate.HasValue, null),

            var v when DateTime.TryParse(v, out var parsed) => parsed switch
            {
                var p when p == DateTime.MinValue => (false, false, null),
                var p when currDate.HasValue && DateOnly.FromDateTime(currDate.Value) == DateOnly.FromDateTime(p)
                    => (false, false, null),
                var p => (true, true, p)
            },

            _ => (false, false, null)
        };
    


    public static string AppendDataSQLDay3(DateTime oTime, string cCampo)
    {
        // 09-04-2016
        if (oTime.ToShortDateString().Equals("01/01/0001"))
            oTime = DateTimeUtc.Date;
        return $" CONVERT(nvarchar(10), {cCampo}, 103)='{oTime:dd/MM/yyyy}'";

        // http://stackoverflow.com/questions/25564482/how-to-compare-datetime-with-only-date-in-sql-server
    }
   
    public static string AppendDataSqlMenorOuIgual(DateTime oTime, string cCampo)
    {
        if (oTime.ToShortDateString().Equals("01/01/0001")) oTime = DateTimeUtc.Date;
        return $"{cCampo}<=CONVERT(DATETIME,'{oTime.Day}-{oTime.Month}-{oTime.Year} 23:59:59.999',103)"; // fix: 05-10-2016 estava 00:00:0.000
    }
    
    public static string AppendDataSqlMenorOuIgual20(DateTime? oTime, string cCampo)
    {
        var oTime1 = DateTimeUtc.Date;
        if (oTime != null) oTime1 = Convert.ToDateTime(oTime);
        return $"{cCampo}<=CONVERT(DATETIME,'{oTime1.Day}-{oTime1.Month}-{oTime1.Year} 23:59:59.999',103)"; // fix: 05-10-2016 estava 00:00:0.000
    }
    
    public static string AppendDataSqlMenorOuIgual(string dateTime1, string cCampo)
    {
        if (dateTime1.Equals(PNow)) dateTime1 = DateTimeUtc.ToString();
        return AppendDataSqlMenorOuIgual(IsValidDate2(dateTime1) ? Convert.ToDateTime(dateTime1) : DateTimeUtc, cCampo);
    }
   
    public static string AppendDataSqlMaiorOuIgual(DateTime oTime, string cCampo)
    {
        if (oTime.ToShortDateString().Equals("01/01/0001")) oTime = DateTimeUtc.Date;
        return $"{cCampo}>=CONVERT(DATETIME,'{oTime.Day}-{oTime.Month}-{oTime.Year} 00:00:00.000',103)"; // fix: 05-10-2016 estava 00:00:0.000
    }
    public static string AppendDataSqlMaiorOuIgual20(DateTime oTime, string cCampo)
    {
        if (oTime.ToShortDateString().Equals("01/01/0001")) oTime = DateTimeUtc.Date;
        return $"{cCampo}>=CONVERT(DATETIME,'{oTime.Day}-{oTime.Month}-{oTime.Year} 00:00:00.000',103)"; // fix: 05-10-2016 estava 00:00:0.000
    } 

     
    public static string AppendDataSqlMaiorOuIgual(string dateTime1, string cCampo)
    {
        if (dateTime1.Equals(PNow)) dateTime1 = DateTimeUtc.ToString();

        return AppendDataSqlMaiorOuIgual(IsValidDate2(dateTime1) ? Convert.ToDateTime(dateTime1) : DateTimeUtc, cCampo);
    }
   
     
    public static string AppendDataSqlDataIgual(in DateTime dateTime1, string campo) =>
        $" {campo} = CONVERT(DATE, '{dateTime1:yyyy-MM-dd}', 120)";

    public static string AppendDataSqlDataIgual(in DateOnly dateTime1, string campo) =>
        $" {campo} = CONVERT(DATE, '{dateTime1:yyyy-MM-dd}', 120)";


    public static string AppendDataSqlDataIgual20(in DateTime dateTime1, string campo) =>
        $" {campo} > '{dateTime1.AddDays(-1):yyyy-MM-dd} 00:00:00.000' AND CONVERT(CHAR(10),{campo},103)='{dateTime1:dd/MM/yyyy}' ";
     
    public static string AppendDataSqlDataIgual(string dateTime1, string campo)
    {
        if (dateTime1.Equals(PNow)) dateTime1 = DateTimeUtc.ToString();

        return AppendDataSqlDataIgual(IsValidDate2(dateTime1) ? Convert.ToDateTime(dateTime1) : DateTimeUtc, campo);
    }
    public static string AppendDataSqlDataIgual(DateTime? dateTime1, string campo) =>
            AppendDataSqlDataIgual(dateTime1 != null ? Convert.ToDateTime(dateTime1) : DateTimeUtc, campo);
 
   
    public static string AppendDataSqlMaiorQue(in DateTime oTime, string cCampo)
    {
        if (oTime.ToShortDateString().Equals("01/01/0001")) return "0=0";
        return $"{cCampo}>CONVERT(DATETIME,'{oTime.Day}-{oTime.Month}-{oTime.Year} 23:59:59.999',103)";
    }
  
    public static string AppendDataSqlMaiorQue20(in DateTime oTime, string cCampo)
    {
        if (oTime.ToShortDateString().Equals("01/01/0001")) return "0=0"; // oTime = DateTimeUtc.Date;
        return $"{cCampo}>CONVERT(DATETIME,'{oTime.Day}-{oTime.Month}-{oTime.Year} 23:59:59.999',103)";
    }
   
    public static string AppendDataSqlMaiorQue(string dateTime1, string cCampo)
    {
        if (dateTime1.Equals(PNow)) dateTime1 = DateTimeUtc.ToString();
        return AppendDataSqlMaiorQue(IsValidDate2(dateTime1) ? Convert.ToDateTime(dateTime1) : DateTimeUtc, cCampo);
    }
    
    
    public static string AppendDataSqlMenorQue(DateTime oTime, string cCampo)
    {
        if (oTime.ToShortDateString().Equals("01/01/0001")) return "0=0"; // oTime = DateTimeUtc.Date;oTime = DateTimeUtc.Date;
        return $"{cCampo}<CONVERT(DATETIME,'{oTime.Day}-{oTime.Month}-{oTime.Year} 00:00:00.000',103)";
    }
    
    public static string AppendDataSqlMenorQue20(in DateTime oTime, string cCampo)
    {
        if (oTime.ToShortDateString().Equals("01/01/0001")) return "0=0"; // oTime = DateTimeUtc.Date;oTime = DateTimeUtc.Date;
        return $"{cCampo}<CONVERT(DATETIME,'{oTime.Day}-{oTime.Month}-{oTime.Year} 23:59:59.999',103)";
    }
    
    public static string AppendDataSqlMenorQue(string dateTime1, in string cCampo)
    {
        if (dateTime1.Equals(PNow)) dateTime1 = DateTimeUtc.ToString();
        return AppendDataSqlMenorQue(IsValidDate2(dateTime1) ? Convert.ToDateTime(dateTime1) : DateTimeUtc, cCampo);
    }
  
    public static string AppendDataSqlMenorQue20(string dateTime1, in string cCampo)
    {
        if (dateTime1.Equals(PNow)) dateTime1 = DateTimeUtc.ToString();
        return AppendDataSqlMenorQue20(IsValidDate2(dateTime1) ? Convert.ToDateTime(dateTime1) : DateTimeUtc, cCampo);
    }   
  
    public static string AppendDataSqlBetween(in DateTime dateTime1, DateTime dateTime2, string campo) =>
         $" ({campo} >= '{dateTime1.AddDays(-1):yyyy-MM-dd} 23:59:59.999' AND {campo} <= '{dateTime2:yyyy-MM-dd} 23:59:59.999' ) ";

    public static string AppendDataSqlBetween(in DateOnly dateTime1, DateOnly dateTime2, string campo) =>
         $" ({campo} >= '{dateTime1.AddDays(-1):yyyy-MM-dd} 23:59:59.999' AND {campo} <= '{dateTime2:yyyy-MM-dd} 23:59:59.999' ) ";

    public static string AppendDataSqlBetween20(in DateTime dateTime1, DateTime dateTime2, string campo) =>
        $" ({campo} >= '{dateTime1.AddDays(-1):yyyy-MM-dd} 23:59:59.999' AND {campo} <= '{dateTime2:yyyy-MM-dd} 23:59:59.999' ) ";
   
    public static string AppendDataSqlBetween(in string dateTime1, string dateTime2, string campo)
    {
        var oDia1 = DateTimeUtc;
        var oDia2 = DateTimeUtc;
        if (DateTime.TryParse(dateTime1, out var dia1)) oDia1 = dia1;
        if (DateTime.TryParse(dateTime2, out var dia2)) oDia2 = dia2;
        return AppendDataSqlBetween(oDia1, oDia2, campo);
    }
  
    public static string AppendDataSqlBetween20(in string dateTime1, string dateTime2, string campo)
    {
        var oDia1 = DateTimeUtc;
        var oDia2 = DateTimeUtc;
        if (DateTime.TryParse(dateTime1, out var dia1)) oDia1 = dia1;
        if (DateTime.TryParse(dateTime2, out var dia2)) oDia2 = dia2;
        return AppendDataSqlBetween20(oDia1, oDia2, campo);
    }
     
    public static string AppendDataSqlBetween(in DateTime? dateTime1, DateTime? dateTime2, string campo)
    {
        var oDia1 = DateTimeUtc;
        var oDia2 = DateTimeUtc;
        if (dateTime1 != null) { oDia1 = (DateTime)dateTime1; }
        if (dateTime2 != null) { oDia2 = (DateTime)dateTime2; }
        return AppendDataSqlBetween(oDia1, oDia2, campo);
    }
   
}



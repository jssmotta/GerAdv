namespace MenphisSI; 
public static partial class DevourerOne
{   
    public static DateTime DateTimeUtc
    {
        get
        {
            // http://pt.stackoverflow.com/questions/46488/trocar-a-timezone-do-datetime-now
            var dateTime = DateTime.UtcNow;
            var hrBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, hrBrasilia);
        }
    }
      
   
    public static bool IsValidDate2(string? dateTime) => IsValidDate25(dateTime).ret;

    /// <summary>
    /// 27-01-2016 StackOverflow; 24-10-2014 arrumado em 01/05/2015 - Testa se o ano tem 4 dígitos
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>Retorna true se a data é válida</re
    public static (bool ret, DateTime? dia) IsValidDate25(string? dateTime)
    {
        if (string.IsNullOrEmpty(dateTime)) { return (false, null); } // Sheise Sá 05-02-2019
        if (dateTime.Equals("01/01/0001"))
        {
            return (false, null);
        }

        if (dateTime.IndexOf("/1/") != -1) dateTime = dateTime.Replace("/1/", "/01/");
        else if (dateTime.IndexOf("/2/") != -1) dateTime = dateTime.Replace("/2/", "/02/");
        else if (dateTime.IndexOf("/3/") != -1) dateTime = dateTime.Replace("/3/", "/03/");
        else if (dateTime.IndexOf("/4/") != -1) dateTime = dateTime.Replace("/4/", "/04/");
        else if (dateTime.IndexOf("/5/") != -1) dateTime = dateTime.Replace("/5/", "/05/");
        else if (dateTime.IndexOf("/6/") != -1) dateTime = dateTime.Replace("/6/", "/06/");
        else if (dateTime.IndexOf("/7/") != -1) dateTime = dateTime.Replace("/7/", "/06/");
        else if (dateTime.IndexOf("/8/") != -1) dateTime = dateTime.Replace("/8/", "/08/");
        else if (dateTime.IndexOf("/9/") != -1) dateTime = dateTime.Replace("/9/", "/09/");

        // http://stackoverflow.com/questions/16075159/check-if-a-string-is-a-valid-date-using-datetime-tryparse
        //string[] formats = { "dd/MM/yyyy" };
        //DateTime parsedDateTime;
        var lRet = DateTime.TryParseExact(dateTime, "dd/MM/yyyy", ptBR,
                                       DateTimeStyles.None, out var myRet1);
        if (lRet) return (true, myRet1);

        lRet = DateTime.TryParseExact(dateTime, "dd/MM/yyyy HH:mm:ss", ptBR,
                                       DateTimeStyles.None, out var myRet2);
        if (lRet) return (true, myRet2);

        if (dateTime.Length == 8) //18-12-2017 12:50
        {
            lRet = DateTime.TryParseExact(dateTime, "dd/MM/yy", ptBR,
                DateTimeStyles.None, out var myRet3);
            if (lRet) return (true, myRet3);
        }
        return (false, null);
    }

    
    public static CultureInfo ptBR => new("pt-BR");
    
}

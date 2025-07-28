namespace MenphisSI.DB;


public partial class ConfiguracoesDBT
{

    public static string? GetExcelConnection(string fileXlsx)
=>
      fileXlsx.endsWith("x") ?
      $@"
Provider=Microsoft.ACE.OLEDB.12.0;
Data Source={fileXlsx};
Extended Properties=""Excel 12.0 Xml; HDR = YES; IMEX = 1""" :

$@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={fileXlsx};Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1""";
}


namespace MenphisSI;

/// <summary>
/// 08-01-2018
/// </summary>
public interface IDicManager
{
    string NameSpace();
    IODicInfo IGlobalObjectDicInfo(string tabelaOrIdOrPrefix);
    ICadastros IGlobalObjectLoad(string table, int id, MsiSqlConnection? oCnn);
 }


public interface IDicManagerGuid
{
    string NameSpace();
    IODicInfo IGlobalObjectDicInfo(string tabelaOrIdOrPrefix);
    ICadastrosGuid IGlobalObjectLoad(string table, Guid id, MsiSqlConnection? oCnn);
}

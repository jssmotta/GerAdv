namespace MenphisSI;

/// <summary>
/// 08-01-2018
/// </summary>
public interface IDicManager
{
    string NameSpace();
    IODicInfo IGlobalObjectDicInfo(string tabelaOrIdOrPrefix);
    ICadastros IGlobalObjectLoad(string table, int id, SqlConnection? oCnn);
 }

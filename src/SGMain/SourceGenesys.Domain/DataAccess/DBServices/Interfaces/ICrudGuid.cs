namespace MenphisSI;

/// <summary>
/// Janeiro-2018
/// </summary>
public interface ICrudGuid
{ 
    void LoadDataBd(DataRow? dbRec);
    void LoadDataBd(SqlDataReader dbRec);
    void SetAuditor(int usuarioId);
    string ITableName();
    string IFieldId();
    string IFieldNameDescription();
    string IPrefix();
    Guid GetID(); 
}

namespace MenphisSI;

/// <summary>
/// Janeiro-2018
/// </summary>
public interface ICrud
{ 
    void LoadDataBd(DataRow? dbRec);
    void LoadDataBd(SqlDataReader dbRec);  
    string ITableName();
    string IFieldId();
    string IFieldNameDescription();
    string IPrefix();
    int GetID(); 
}

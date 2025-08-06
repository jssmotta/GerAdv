namespace MenphisSI;

/// <summary>
/// Janeiro-2018
/// </summary>
public interface ICadastrosGuid
{
    void SetValueByNameField(string nomeCampo, object value);
    object? GetValueByNameField(string nomeCampo); 
    void CarregarDadosBd(DataRow? dbRec);
    void CarregarDadosBd(SqlDataReader dbRec);
    void SetAuditor(int usuarioId);
    string ITabelaName();
    string ICampoCodigo();
    string ICampoNome();
    string IPrefixo();
    Guid GetID();
    int IQuemCad();
    int IQuemAtu();
    public string IDtCadDataX_DataHora();
    public string IDtAtuDataX_DataHora();
}

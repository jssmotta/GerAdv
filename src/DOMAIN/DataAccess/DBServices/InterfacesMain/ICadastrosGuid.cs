namespace MenphisSI;

public interface ICadastrosAuditorGuid : ICadastrosGuid
{
    string IMDtCadDataX_DataHora();
}

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

#if (pCacheableApp)
		int Update(MsiSqlConnection? oCnn, Guid insertId, bool isOffLine);
#else
    int Update(MsiSqlConnection? oCnn);
#endif
}

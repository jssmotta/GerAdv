
namespace MenphisSI;

public interface ICadastrosAuditor : ICadastros
{
    string IMDtCadDataX_DataHora();
}

/// <summary>
/// Janeiro-2018
/// </summary>
public interface ICadastros
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
    int GetID();
    int IQuemCad();
    int IQuemAtu();
    public string IDtCadDataX_DataHora();
    public string IDtAtuDataX_DataHora();

#if (pCacheableApp)
		int Update(SqlConnection? oCnn, int insertId, bool isOffLine);
#else
    int Update(SqlConnection? oCnn, int insertId = 0);
#endif
}

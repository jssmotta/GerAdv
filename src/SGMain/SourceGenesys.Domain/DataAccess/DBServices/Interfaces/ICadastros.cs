namespace MenphisSI;

/// <summary>
/// Janeiro-2018
/// </summary>
public interface ICadastros
{ 
    void CarregarDadosBd(DataRow? dbRec);
    void CarregarDadosBd(SqlDataReader dbRec);  
    string ITabelaName();
    string ICampoCodigo();
    string ICampoNome();
    string IPrefixo();
    int GetID(); 
}

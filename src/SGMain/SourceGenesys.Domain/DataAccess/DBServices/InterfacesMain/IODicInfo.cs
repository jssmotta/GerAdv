namespace MenphisSI;

public interface IODicInfo
{
    string ITabelaNome();
    ImmutableArray<DBInfoSystem> IListFields();
    ImmutableArray<DBInfoSystem> IFieldsRaw();
    ImmutableArray<DBInfoSystem> IPkFields();
    ImmutableArray<DBInfoSystem> IPkIndicesFields();
    bool HasAuditor();    
    bool HasNameId();
    string ICampoCodigo();
    string ITypeFieldCode();
    bool IdIsIdentity();
    string ICampoNome();
    string IPrefixo();
    bool IIsStoredProcedureOrView();
    bool TemAuditor();    
    DBInfoSystem? GetInfoSystemByNameField(string campo);
    string NomeSemPrefixo() => IPrefixo().Length > 0 && ICampoNome().StartsWith(IPrefixo()) ? ICampoNome().Substring(IPrefixo().Length) : ICampoNome();

}


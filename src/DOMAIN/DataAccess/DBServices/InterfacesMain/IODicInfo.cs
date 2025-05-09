﻿namespace MenphisSI;

public interface IODicInfo
{
    string ITabelaNome();    
    List<DBInfoSystem> IListFields();
    List<DBInfoSystem> IFieldsRaw();
    bool HasAuditor();
    bool HasPersonSex();
    bool HasNameId();
    string ICampoCodigo();
    string ICampoNome();
    string IPrefixo();
    bool IIsStoredProcedureOrView();
    bool TemAuditor();
    bool TemPessoaSexo();
    DBInfoSystem? GetInfoSystemByNameField(string table);
}


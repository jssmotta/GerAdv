namespace MenphisSI;

public interface IODicInfo
{
    string ITabelaNome();
    ImmutableArray<DBInfoSystem> IListFields();
    ImmutableArray<DBInfoSystem> IFieldsRaw();
    ImmutableArray<DBInfoSystem> IPkFields();
    ImmutableArray<DBInfoSystem> IPkIndexFields();

    DBInfoSystem? GetFieldNameDescription()=> IListFields().FirstOrDefault(t=> t.FNome.Equals(this.IFieldNameDescription()));

    bool HasAuditor();    
    bool HasNameId();
    string IFieldId();
    string ITypeFieldCode();
    bool IdIsIdentity();
    string IFieldNameDescription();
    string IPrefix();
    bool IsStoredProcedureOrView();

    bool IsView();
    DBInfoSystem? GetInfoSystemByNameField(string campo);
    string GetNameWithoutPrefix() => IPrefix().Length > 0 && IFieldNameDescription().StartsWith(IPrefix()) ? IFieldNameDescription().Substring(IPrefix().Length) : IFieldNameDescription();
     
}


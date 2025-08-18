namespace MenphisSI; 
 
[Serializable]
public record DBNomeID
{
    public int GetID() => ID;
    public string Nome() => FNome ?? "";

    public const string FCampoNome = "FNome";
    public const string PCampoID = "ID";

    public DBNomeID() { }

    public DBNomeID(int id, string nome) { ID = id; FNome = nome; }
    public int ID { get; set; }
    public string? FNome { get; set; }
} 
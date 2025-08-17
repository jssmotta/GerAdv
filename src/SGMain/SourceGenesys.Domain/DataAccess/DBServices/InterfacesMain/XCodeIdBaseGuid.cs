
namespace MenphisSI;

[Serializable]
public class XCodeIdBaseGuid
{
    private protected Guid m_IdRegistro;
    private protected Guid SetId { set => m_IdRegistro = value; }

    /// <summary>
    /// Informa se existe dados alterados para serem gravados
    /// </summary>
    public bool HasChanges { get; internal set; }
    public bool NotHasChanges => !HasChanges;
 
    /// <summary>
    /// 07-01-2017 15:50
    /// </summary>
    public Guid Código => m_IdRegistro;

    /// <summary>
    /// Campo código
    /// </summary>
    public Guid ID { get => m_IdRegistro; set => m_IdRegistro = value; }        
    
    [XmlIgnore]
    public int Error { get; set; }

    [XmlIgnore]
    public string? ErrorDescription { get; set; }
}


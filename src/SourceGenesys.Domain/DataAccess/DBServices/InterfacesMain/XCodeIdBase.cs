
namespace MenphisSI.Internal;

[Serializable]
internal class XCodeIdBase //: StylesCad - Deixou o Sistema lento, muitas heranças.
{
    private protected int m_IdRegistro;
    private protected int SetId { set => m_IdRegistro = value; }

    /// <summary>
    /// Informa se existe dados alterados para serem gravados
    /// </summary>
    public bool HasChanges { get; internal set; }
    public bool NotHasChanges => !HasChanges;
 
    /// <summary>
    /// 07-01-2017 15:50
    /// </summary>
    public int Código => m_IdRegistro;

    /// <summary>
    /// Campo código
    /// </summary>
    public int ID { get => m_IdRegistro; set => m_IdRegistro = value; }
   
    [XmlIgnore]
    public int Error { get; set; }
}


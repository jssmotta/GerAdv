
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
    /// <summary>
    /// Estilo da linha para o CSS
    /// </summary>
    [XmlIgnore]
    public byte Style;

    /// <summary>
    /// Estilo CSS para a linha
    /// </summary>
    [XmlIgnore]
    public string StyleColumn => $" style='color:Black;font-size:12px;background-color:{(Style == 0 ? "#EBEBEB" : "#C0C0C0")}' onmouseover='overRow(this)' onmouseout=\"outRow(this,'{(Style == 0 ? "#EBEBEB" : "#C0C0C0")}','Black');\" ";
    //DevourerOne.StyleColorLineAspx(Style);
    /// <summary>
    /// Estilo X
    /// </summary>
    [XmlIgnore]
    public byte StyleColumnX { set => Style = value; }
    [XmlIgnore]
    public int Error { get; set; }
}




namespace MenphisSI.Internal;

[Serializable]
internal class XCodeIdBase64 //: StylesCad
{
    private protected long m_IdRegistro;

    /// <summary>
    /// Informa se existe dados alterados para serem gravados
    /// </summary>
    public bool HasChanges { get; set; }

    /// <summary>
    /// Id do Erro -1,-2-3 ou 0 sucesso
    /// </summary>
    public int Error { get; set; }
    /// <summary>
    /// Descrição do erro ao gravar
    /// </summary>
    public string? ErrorDescription { get; set; }

    /// <summary>
    /// 07-01-2017 15:50
    /// </summary>
    public long Código => m_IdRegistro;

    /// <summary>
    /// Campo código
    /// </summary>
    public long ID { get => m_IdRegistro; set => m_IdRegistro = value; }
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
}


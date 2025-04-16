
namespace MenphisSI;

/// <summary>
/// 08-01-2018
/// </summary>
[Serializable]
public class StylesCad
{
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
 
    /// <summary>
    /// Estilo X
    /// </summary>
    [XmlIgnore]
    public byte StyleColumnX { set => Style = value; }
}

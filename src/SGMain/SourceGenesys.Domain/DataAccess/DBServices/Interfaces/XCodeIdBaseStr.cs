

namespace MenphisSI;

[Serializable]
public class XCodeIdBasStr //: StylesCad - Deixou o Sistema lento, muitas heranças.
{
    private protected string m_IdRegistro { get; set; } = string.Empty;
    public string SetId { set => m_IdRegistro = value; }

    /// <summary>
    /// Informa se existe dados alterados para serem gravados
    /// </summary>
    public bool HasChanges { get; internal set; }
    public bool NotHasChanges => !HasChanges;

    /// <summary>
    /// Id do Erro -1,-2-3 ou 0 sucesso
    /// </summary>
    public int Error;
    /// <summary>
    /// Descrição do erro ao gravar
    /// </summary>
    public string? ErrorDescription;

    /// <summary>
    /// 07-01-2017 15:50
    /// </summary>
    public string Código => m_IdRegistro;

    /// <summary>
    /// Campo código
    /// </summary>
    public string ID { get => m_IdRegistro; set => m_IdRegistro = value; }

    /// <summary>
    /// Estilo da linha para o CSS
    /// </summary>
    [XmlIgnore]
    public static byte Style;

 
}


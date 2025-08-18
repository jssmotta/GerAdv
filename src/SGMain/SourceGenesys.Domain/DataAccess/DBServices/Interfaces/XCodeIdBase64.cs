namespace MenphisSI;

[Serializable]
public class XCodeIdBase64
{
    private protected long m_IdRegistro;  

    /// <summary>
    /// Id do Erro -1,-2-3 ou 0 sucesso
    /// </summary>
    public int Error;
    /// <summary>
    /// Descrição do erro ao gravar
    /// </summary>
    public string? ErrorDescription;

    /// <summary>
    /// Campo código
    /// </summary>
    public long ID { get => m_IdRegistro; set => m_IdRegistro = value; }

}


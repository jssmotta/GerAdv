#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class HorasTrabResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - htbCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - htbProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - htbAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - htbFuncionario  
    /// </summary>
    [JsonPropertyName("funcionario")]
    public int Funcionario { get; set; }

    /// <summary>
    /// Sem descrição - htbServico  
    /// </summary>
    [JsonPropertyName("servico")]
    public int Servico { get; set; }

    /// <summary>
    /// Sem descrição - htbIDContatoCRM  
    /// </summary>
    [JsonPropertyName("idcontatocrm")]
    public int IDContatoCRM { get; set; }

    /// <summary>
    /// Sem descrição - htbHonorario  
    /// </summary>
    [JsonPropertyName("honorario")]
    public bool Honorario { get; set; }

    /// <summary>
    /// Sem descrição - htbIDAgenda  
    /// </summary>
    [JsonPropertyName("idagenda")]
    public int IDAgenda { get; set; }

    /// <summary>
    /// Sem descrição - htbData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - htbStatus  
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>
    /// Sem descrição - htbHrIni - tamanho máximo: 5 
    /// </summary>
    [JsonPropertyName("hrini")]
    public string HrIni { get; set; } = "";

    /// <summary>
    /// Sem descrição - htbHrFim - tamanho máximo: 5 
    /// </summary>
    [JsonPropertyName("hrfim")]
    public string HrFim { get; set; } = "";

    /// <summary>
    /// Sem descrição - htbTempo  
    /// </summary>
    [JsonPropertyName("tempo")]
    public decimal Tempo { get; set; }

    /// <summary>
    /// Sem descrição - htbValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Sem descrição - htbOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    /// <summary>
    /// Sem descrição - htbAnexo - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("anexo")]
    public string Anexo { get; set; } = "";

    /// <summary>
    /// Sem descrição - htbAnexoComp - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("anexocomp")]
    public string AnexoComp { get; set; } = "";

    /// <summary>
    /// Sem descrição - htbAnexoUNC - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("anexounc")]
    public string AnexoUNC { get; set; } = "";

    /// <summary>
    /// GUId - htbGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class HorasTrabResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - htbCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - htbProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - htbAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - htbFuncionario  
    /// </summary>
    [JsonPropertyName("funcionario")]
    public int Funcionario { get; set; }

    /// <summary>
    /// Sem descrição - htbServico  
    /// </summary>
    [JsonPropertyName("servico")]
    public int Servico { get; set; }

    /// <summary>
    /// Sem descrição - htbIDContatoCRM  
    /// </summary>
    [JsonPropertyName("idcontatocrm")]
    public int IDContatoCRM { get; set; }

    /// <summary>
    /// Sem descrição - htbHonorario  
    /// </summary>
    [JsonPropertyName("honorario")]
    public bool Honorario { get; set; }

    /// <summary>
    /// Sem descrição - htbIDAgenda  
    /// </summary>
    [JsonPropertyName("idagenda")]
    public int IDAgenda { get; set; }

    /// <summary>
    /// Sem descrição - htbData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - htbStatus  
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>
    /// Sem descrição - htbHrIni - tamanho máximo: 5 
    /// </summary>
    [JsonPropertyName("hrini")]
    public string HrIni { get; set; } = "";

    /// <summary>
    /// Sem descrição - htbHrFim - tamanho máximo: 5 
    /// </summary>
    [JsonPropertyName("hrfim")]
    public string HrFim { get; set; } = "";

    /// <summary>
    /// Sem descrição - htbTempo  
    /// </summary>
    [JsonPropertyName("tempo")]
    public decimal Tempo { get; set; }

    /// <summary>
    /// Sem descrição - htbValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Sem descrição - htbOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    /// <summary>
    /// Sem descrição - htbAnexo - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("anexo")]
    public string Anexo { get; set; } = "";

    /// <summary>
    /// Sem descrição - htbAnexoComp - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("anexocomp")]
    public string AnexoComp { get; set; } = "";

    /// <summary>
    /// Sem descrição - htbAnexoUNC - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("anexounc")]
    public string AnexoUNC { get; set; } = "";

    /// <summary>
    /// GUId - htbGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;

    [JsonPropertyName("nomeadvogados")]
    public string NomeAdvogados { get; set; } = string.Empty;

    [JsonPropertyName("nomefuncionarios")]
    public string NomeFuncionarios { get; set; } = string.Empty;

    [JsonPropertyName("descricaoservicos")]
    public string DescricaoServicos { get; set; } = string.Empty;
}
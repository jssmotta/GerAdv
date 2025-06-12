#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AgendaRepetirResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - rptAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - rptCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - rptFuncionario  
    /// </summary>
    [JsonPropertyName("funcionario")]
    public int Funcionario { get; set; }

    /// <summary>
    /// Sem descrição - rptProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - rptDataFinal  
    /// </summary>
    [JsonPropertyName("datafinal")]
    public string DataFinal { get; set; } = "";

    /// <summary>
    /// Sem descrição - rptHoraFinal  
    /// </summary>
    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = "";

    /// <summary>
    /// Sem descrição - rptPessoal  
    /// </summary>
    [JsonPropertyName("pessoal")]
    public bool Pessoal { get; set; }

    /// <summary>
    /// Sem descrição - rptFrequencia  
    /// </summary>
    [JsonPropertyName("frequencia")]
    public int Frequencia { get; set; }

    /// <summary>
    /// Sem descrição - rptDia  
    /// </summary>
    [JsonPropertyName("dia")]
    public int Dia { get; set; }

    /// <summary>
    /// Sem descrição - rptMes  
    /// </summary>
    [JsonPropertyName("mes")]
    public int Mes { get; set; }

    /// <summary>
    /// Sem descrição - rptHora  
    /// </summary>
    [JsonPropertyName("hora")]
    public string Hora { get; set; } = "";

    /// <summary>
    /// Sem descrição - rptIDQuem  
    /// </summary>
    [JsonPropertyName("idquem")]
    public int IDQuem { get; set; }

    /// <summary>
    /// Sem descrição - rptIDQuem2  
    /// </summary>
    [JsonPropertyName("idquem2")]
    public int IDQuem2 { get; set; }

    /// <summary>
    /// Sem descrição - rptMensagem  
    /// </summary>
    [JsonPropertyName("mensagem")]
    public string Mensagem { get; set; } = "";

    /// <summary>
    /// Sem descrição - rptIDTipo  
    /// </summary>
    [JsonPropertyName("idtipo")]
    public int IDTipo { get; set; }

    /// <summary>
    /// Sem descrição - rptID1  
    /// </summary>
    [JsonPropertyName("id1")]
    public int ID1 { get; set; }

    /// <summary>
    /// Sem descrição - rptID2  
    /// </summary>
    [JsonPropertyName("id2")]
    public int ID2 { get; set; }

    /// <summary>
    /// Sem descrição - rptID3  
    /// </summary>
    [JsonPropertyName("id3")]
    public int ID3 { get; set; }

    /// <summary>
    /// Sem descrição - rptID4  
    /// </summary>
    [JsonPropertyName("id4")]
    public int ID4 { get; set; }

    /// <summary>
    /// Sem descrição - rptSegunda  
    /// </summary>
    [JsonPropertyName("segunda")]
    public bool Segunda { get; set; }

    /// <summary>
    /// Sem descrição - rptQuarta  
    /// </summary>
    [JsonPropertyName("quarta")]
    public bool Quarta { get; set; }

    /// <summary>
    /// Sem descrição - rptQuinta  
    /// </summary>
    [JsonPropertyName("quinta")]
    public bool Quinta { get; set; }

    /// <summary>
    /// Sem descrição - rptSexta  
    /// </summary>
    [JsonPropertyName("sexta")]
    public bool Sexta { get; set; }

    /// <summary>
    /// Sem descrição - rptSabado  
    /// </summary>
    [JsonPropertyName("sabado")]
    public bool Sabado { get; set; }

    /// <summary>
    /// Sem descrição - rptDomingo  
    /// </summary>
    [JsonPropertyName("domingo")]
    public bool Domingo { get; set; }

    /// <summary>
    /// Sem descrição - rptTerca  
    /// </summary>
    [JsonPropertyName("terca")]
    public bool Terca { get; set; }
}

[Serializable]
public partial class AgendaRepetirResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - rptAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - rptCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - rptFuncionario  
    /// </summary>
    [JsonPropertyName("funcionario")]
    public int Funcionario { get; set; }

    /// <summary>
    /// Sem descrição - rptProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - rptDataFinal  
    /// </summary>
    [JsonPropertyName("datafinal")]
    public string DataFinal { get; set; } = "";

    /// <summary>
    /// Sem descrição - rptHoraFinal  
    /// </summary>
    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = "";

    /// <summary>
    /// Sem descrição - rptPessoal  
    /// </summary>
    [JsonPropertyName("pessoal")]
    public bool Pessoal { get; set; }

    /// <summary>
    /// Sem descrição - rptFrequencia  
    /// </summary>
    [JsonPropertyName("frequencia")]
    public int Frequencia { get; set; }

    /// <summary>
    /// Sem descrição - rptDia  
    /// </summary>
    [JsonPropertyName("dia")]
    public int Dia { get; set; }

    /// <summary>
    /// Sem descrição - rptMes  
    /// </summary>
    [JsonPropertyName("mes")]
    public int Mes { get; set; }

    /// <summary>
    /// Sem descrição - rptHora  
    /// </summary>
    [JsonPropertyName("hora")]
    public string Hora { get; set; } = "";

    /// <summary>
    /// Sem descrição - rptIDQuem  
    /// </summary>
    [JsonPropertyName("idquem")]
    public int IDQuem { get; set; }

    /// <summary>
    /// Sem descrição - rptIDQuem2  
    /// </summary>
    [JsonPropertyName("idquem2")]
    public int IDQuem2 { get; set; }

    /// <summary>
    /// Sem descrição - rptMensagem  
    /// </summary>
    [JsonPropertyName("mensagem")]
    public string Mensagem { get; set; } = "";

    /// <summary>
    /// Sem descrição - rptIDTipo  
    /// </summary>
    [JsonPropertyName("idtipo")]
    public int IDTipo { get; set; }

    /// <summary>
    /// Sem descrição - rptID1  
    /// </summary>
    [JsonPropertyName("id1")]
    public int ID1 { get; set; }

    /// <summary>
    /// Sem descrição - rptID2  
    /// </summary>
    [JsonPropertyName("id2")]
    public int ID2 { get; set; }

    /// <summary>
    /// Sem descrição - rptID3  
    /// </summary>
    [JsonPropertyName("id3")]
    public int ID3 { get; set; }

    /// <summary>
    /// Sem descrição - rptID4  
    /// </summary>
    [JsonPropertyName("id4")]
    public int ID4 { get; set; }

    /// <summary>
    /// Sem descrição - rptSegunda  
    /// </summary>
    [JsonPropertyName("segunda")]
    public bool Segunda { get; set; }

    /// <summary>
    /// Sem descrição - rptQuarta  
    /// </summary>
    [JsonPropertyName("quarta")]
    public bool Quarta { get; set; }

    /// <summary>
    /// Sem descrição - rptQuinta  
    /// </summary>
    [JsonPropertyName("quinta")]
    public bool Quinta { get; set; }

    /// <summary>
    /// Sem descrição - rptSexta  
    /// </summary>
    [JsonPropertyName("sexta")]
    public bool Sexta { get; set; }

    /// <summary>
    /// Sem descrição - rptSabado  
    /// </summary>
    [JsonPropertyName("sabado")]
    public bool Sabado { get; set; }

    /// <summary>
    /// Sem descrição - rptDomingo  
    /// </summary>
    [JsonPropertyName("domingo")]
    public bool Domingo { get; set; }

    /// <summary>
    /// Sem descrição - rptTerca  
    /// </summary>
    [JsonPropertyName("terca")]
    public bool Terca { get; set; }

    [JsonPropertyName("nomeadvogados")]
    public string NomeAdvogados { get; set; } = string.Empty;

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;

    [JsonPropertyName("nomefuncionarios")]
    public string NomeFuncionarios { get; set; } = string.Empty;

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;
}
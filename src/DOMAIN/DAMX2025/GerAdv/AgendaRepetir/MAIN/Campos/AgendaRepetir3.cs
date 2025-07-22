namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRepetir
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFAdvogado, pFldFCliente, pFldFDataFinal, pFldFFuncionario, pFldFHoraFinal, pFldFProcesso, pFldFPessoal, pFldFFrequencia, pFldFDia, pFldFMes, pFldFHora, pFldFIDQuem, pFldFIDQuem2, pFldFMensagem, pFldFIDTipo, pFldFID1, pFldFID2, pFldFID3, pFldFID4, pFldFSegunda, pFldFQuarta, pFldFQuinta, pFldFSexta, pFldFSabado, pFldFDomingo, pFldFTerca;
    [XmlIgnore]
    private protected int m_FAdvogado, m_FCliente, m_FFuncionario, m_FProcesso, m_FFrequencia, m_FDia, m_FMes, m_FIDQuem, m_FIDQuem2, m_FIDTipo, m_FID1, m_FID2, m_FID3, m_FID4;
    [XmlIgnore]
    private protected string? m_FMensagem;
    [XmlIgnore]
    private protected DateTime? m_FDataFinal, m_FHoraFinal, m_FHora;
    [XmlIgnore]
    private protected bool m_FPessoal, m_FSegunda, m_FQuarta, m_FQuinta, m_FSexta, m_FSabado, m_FDomingo, m_FTerca;
    public int FAdvogado
    {
        get => m_FAdvogado;
        set
        {
            pFldFAdvogado = pFldFAdvogado || value != m_FAdvogado;
            if (pFldFAdvogado)
                m_FAdvogado = value;
        }
    }

    public int FCliente
    {
        get => m_FCliente;
        set
        {
            pFldFCliente = pFldFCliente || value != m_FCliente;
            if (pFldFCliente)
                m_FCliente = value;
        }
    }

    [XmlIgnore]
    public DateTime MDataFinal => Convert.ToDateTime(m_FDataFinal);

    public string? FDataFinal
    {
        get => $"{m_FDataFinal:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataFinal:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataFinal, m_FDataFinal, value);
            if (!setUpNow)
                return;
            pFldFDataFinal = changed;
            m_FDataFinal = data;
        }
    }

    public int FFuncionario
    {
        get => m_FFuncionario;
        set
        {
            pFldFFuncionario = pFldFFuncionario || value != m_FFuncionario;
            if (pFldFFuncionario)
                m_FFuncionario = value;
        }
    }

    [XmlIgnore]
    public DateTime MHoraFinal => Convert.ToDateTime(m_FHoraFinal);

    public string? FHoraFinal
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHoraFinal:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHoraFinal = pFldFHoraFinal || m_FHoraFinal != null;
                m_FHoraFinal = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHoraFinal = true;
                m_FHoraFinal = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHoraFinal:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHoraFinal = true;
                m_FHoraFinal = dateTime;
            }
        }
    }

    public int FProcesso
    {
        get => m_FProcesso;
        set
        {
            pFldFProcesso = pFldFProcesso || value != m_FProcesso;
            if (pFldFProcesso)
                m_FProcesso = value;
        }
    }

    public bool FPessoal
    {
        get => m_FPessoal;
        set
        {
            pFldFPessoal = pFldFPessoal || value != m_FPessoal;
            if (pFldFPessoal)
                m_FPessoal = value;
        }
    }

    public int FFrequencia
    {
        get => m_FFrequencia;
        set
        {
            pFldFFrequencia = pFldFFrequencia || value != m_FFrequencia;
            if (pFldFFrequencia)
                m_FFrequencia = value;
        }
    }

    public int FDia
    {
        get => m_FDia;
        set
        {
            pFldFDia = pFldFDia || value != m_FDia;
            if (pFldFDia)
                m_FDia = value;
        }
    }

    public int FMes
    {
        get => m_FMes;
        set
        {
            pFldFMes = pFldFMes || value != m_FMes;
            if (pFldFMes)
                m_FMes = value;
        }
    }

    [XmlIgnore]
    public DateTime MHora => Convert.ToDateTime(m_FHora);

    public string? FHora
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHora:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHora = pFldFHora || m_FHora != null;
                m_FHora = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHora = true;
                m_FHora = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHora:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHora = true;
                m_FHora = dateTime;
            }
        }
    }

    public int FIDQuem
    {
        get => m_FIDQuem;
        set
        {
            pFldFIDQuem = pFldFIDQuem || value != m_FIDQuem;
            if (pFldFIDQuem)
                m_FIDQuem = value;
        }
    }

    public int FIDQuem2
    {
        get => m_FIDQuem2;
        set
        {
            pFldFIDQuem2 = pFldFIDQuem2 || value != m_FIDQuem2;
            if (pFldFIDQuem2)
                m_FIDQuem2 = value;
        }
    }

    public string? FMensagem
    {
        get => m_FMensagem ?? string.Empty;
        set
        {
            pFldFMensagem = pFldFMensagem || !(m_FMensagem ?? string.Empty).Equals(value);
            if (pFldFMensagem)
                m_FMensagem = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public int FIDTipo
    {
        get => m_FIDTipo;
        set
        {
            pFldFIDTipo = pFldFIDTipo || value != m_FIDTipo;
            if (pFldFIDTipo)
                m_FIDTipo = value;
        }
    }

    public int FID1
    {
        get => m_FID1;
        set
        {
            pFldFID1 = pFldFID1 || value != m_FID1;
            if (pFldFID1)
                m_FID1 = value;
        }
    }

    public int FID2
    {
        get => m_FID2;
        set
        {
            pFldFID2 = pFldFID2 || value != m_FID2;
            if (pFldFID2)
                m_FID2 = value;
        }
    }

    public int FID3
    {
        get => m_FID3;
        set
        {
            pFldFID3 = pFldFID3 || value != m_FID3;
            if (pFldFID3)
                m_FID3 = value;
        }
    }

    public int FID4
    {
        get => m_FID4;
        set
        {
            pFldFID4 = pFldFID4 || value != m_FID4;
            if (pFldFID4)
                m_FID4 = value;
        }
    }

    public bool FSegunda
    {
        get => m_FSegunda;
        set
        {
            pFldFSegunda = pFldFSegunda || value != m_FSegunda;
            if (pFldFSegunda)
                m_FSegunda = value;
        }
    }

    public bool FQuarta
    {
        get => m_FQuarta;
        set
        {
            pFldFQuarta = pFldFQuarta || value != m_FQuarta;
            if (pFldFQuarta)
                m_FQuarta = value;
        }
    }

    public bool FQuinta
    {
        get => m_FQuinta;
        set
        {
            pFldFQuinta = pFldFQuinta || value != m_FQuinta;
            if (pFldFQuinta)
                m_FQuinta = value;
        }
    }

    public bool FSexta
    {
        get => m_FSexta;
        set
        {
            pFldFSexta = pFldFSexta || value != m_FSexta;
            if (pFldFSexta)
                m_FSexta = value;
        }
    }

    public bool FSabado
    {
        get => m_FSabado;
        set
        {
            pFldFSabado = pFldFSabado || value != m_FSabado;
            if (pFldFSabado)
                m_FSabado = value;
        }
    }

    public bool FDomingo
    {
        get => m_FDomingo;
        set
        {
            pFldFDomingo = pFldFDomingo || value != m_FDomingo;
            if (pFldFDomingo)
                m_FDomingo = value;
        }
    }

    public bool FTerca
    {
        get => m_FTerca;
        set
        {
            pFldFTerca = pFldFTerca || value != m_FTerca;
            if (pFldFTerca)
                m_FTerca = value;
        }
    }

    public bool IVisto() => m_FVisto;
    public int IQuemCad() => m_FQuemCad;
    public int IQuemAtu() => m_FQuemAtu;
    public DateTime IDtCad() => MDtCad;
    public DateTime IDtAtu() => MDtAtu;
    public string IDtCadDataX_DataHora() => MDtCadDataX_DataHora;
    public string IDtAtuDataX_DataHora() => MDtAtuDataX_DataHora;
    public void SetAuditor(int usuarioId) => AuditorQuem = usuarioId;
    public string IMDtCadDataX_DataHora() => MDtAtuDataX_DataHora;
    public string ITabelaName() => PTabelaNome;
    public string ICampoCodigo() => CampoCodigo;
    public string ICampoNome() => CampoNome;
    public string IPrefixo() => PTabelaPrefixo;
    public List<DBInfoSystem> IFieldsRaw() => throw new NotImplementedException();
    public List<DBInfoSystem> IPkFields() => throw new NotImplementedException();
    public List<DBInfoSystem> IPkIndicesFields() => throw new NotImplementedException();
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}
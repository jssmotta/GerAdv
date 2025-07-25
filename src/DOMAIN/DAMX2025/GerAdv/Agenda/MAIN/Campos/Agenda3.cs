namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgenda
{
    [XmlIgnore]
    private protected bool pFldFIDCOB, pFldFClienteAvisado, pFldFRevisarP2, pFldFIDNE, pFldFCidade, pFldFOculto, pFldFCartaPrecatoria, pFldFRevisar, pFldFHrFinal, pFldFAdvogado, pFldFEventoGerador, pFldFEventoData, pFldFFuncionario, pFldFData, pFldFEventoPrazo, pFldFHora, pFldFCompromisso, pFldFTipoCompromisso, pFldFCliente, pFldFLiberado, pFldFImportante, pFldFConcluido, pFldFArea, pFldFJustica, pFldFProcesso, pFldFIDHistorico, pFldFIDInsProcesso, pFldFUsuario, pFldFPreposto, pFldFQuemID, pFldFQuemCodigo, pFldFStatus, pFldFValor, pFldFDecisao, pFldFSempre, pFldFPrazoDias, pFldFProtocoloIntegrado, pFldFDataInicioPrazo, pFldFUsuarioCiente;
    [XmlIgnore]
    private protected int m_FIDCOB, m_FIDNE, m_FCidade, m_FOculto, m_FCartaPrecatoria, m_FAdvogado, m_FEventoGerador, m_FFuncionario, m_FEventoPrazo, m_FTipoCompromisso, m_FCliente, m_FArea, m_FJustica, m_FProcesso, m_FIDHistorico, m_FIDInsProcesso, m_FUsuario, m_FPreposto, m_FQuemID, m_FQuemCodigo, m_FSempre, m_FPrazoDias, m_FProtocoloIntegrado;
    [XmlIgnore]
    private protected string? m_FCompromisso, m_FStatus, m_FDecisao;
    [XmlIgnore]
    private protected DateTime? m_FHrFinal, m_FEventoData, m_FData, m_FHora, m_FDataInicioPrazo;
    [XmlIgnore]
    private protected bool m_FClienteAvisado, m_FRevisarP2, m_FRevisar, m_FLiberado, m_FImportante, m_FConcluido, m_FUsuarioCiente;
    [XmlIgnore]
    private protected decimal m_FValor;
    public int FIDCOB
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIDCOB;
        set
        {
            pFldFIDCOB = pFldFIDCOB || value != m_FIDCOB;
            if (pFldFIDCOB)
                m_FIDCOB = value;
        }
    }

    public bool FClienteAvisado
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FClienteAvisado;
        set
        {
            pFldFClienteAvisado = pFldFClienteAvisado || value != m_FClienteAvisado;
            if (pFldFClienteAvisado)
                m_FClienteAvisado = value;
        }
    }

    public bool FRevisarP2
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FRevisarP2;
        set
        {
            pFldFRevisarP2 = pFldFRevisarP2 || value != m_FRevisarP2;
            if (pFldFRevisarP2)
                m_FRevisarP2 = value;
        }
    }

    public int FIDNE
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIDNE;
        set
        {
            pFldFIDNE = pFldFIDNE || value != m_FIDNE;
            if (pFldFIDNE)
                m_FIDNE = value;
        }
    }

    public int FCidade
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCidade;
        set
        {
            pFldFCidade = pFldFCidade || value != m_FCidade;
            if (pFldFCidade)
                m_FCidade = value;
        }
    }

    public int FOculto
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FOculto;
        set
        {
            pFldFOculto = pFldFOculto || value != m_FOculto;
            if (pFldFOculto)
                m_FOculto = value;
        }
    }

    public int FCartaPrecatoria
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCartaPrecatoria;
        set
        {
            pFldFCartaPrecatoria = pFldFCartaPrecatoria || value != m_FCartaPrecatoria;
            if (pFldFCartaPrecatoria)
                m_FCartaPrecatoria = value;
        }
    }

    public bool FRevisar
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FRevisar;
        set
        {
            pFldFRevisar = pFldFRevisar || value != m_FRevisar;
            if (pFldFRevisar)
                m_FRevisar = value;
        }
    }

    public string? FHrFinal
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHrFinal:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHrFinal = pFldFHrFinal || m_FHrFinal != null;
                m_FHrFinal = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHrFinal = true;
                m_FHrFinal = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHrFinal:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHrFinal = true;
                m_FHrFinal = dateTime;
            }
        }
    }

    public int FAdvogado
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAdvogado;
        set
        {
            pFldFAdvogado = pFldFAdvogado || value != m_FAdvogado;
            if (pFldFAdvogado)
                m_FAdvogado = value;
        }
    }

    public int FEventoGerador
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FEventoGerador;
        set
        {
            pFldFEventoGerador = pFldFEventoGerador || value != m_FEventoGerador;
            if (pFldFEventoGerador)
                m_FEventoGerador = value;
        }
    }

    public string? FEventoData
    {
        get => $"{m_FEventoData:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FEventoData:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFEventoData, m_FEventoData, value);
            if (!setUpNow)
                return;
            pFldFEventoData = changed;
            m_FEventoData = data;
        }
    }

    public int FFuncionario
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FFuncionario;
        set
        {
            pFldFFuncionario = pFldFFuncionario || value != m_FFuncionario;
            if (pFldFFuncionario)
                m_FFuncionario = value;
        }
    }

    public string? FData
    {
        get => $"{m_FData:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FData:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFData, m_FData, value);
            if (!setUpNow)
                return;
            pFldFData = changed;
            m_FData = data;
        }
    }

    public int FEventoPrazo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FEventoPrazo;
        set
        {
            pFldFEventoPrazo = pFldFEventoPrazo || value != m_FEventoPrazo;
            if (pFldFEventoPrazo)
                m_FEventoPrazo = value;
        }
    }

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

    public string? FCompromisso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCompromisso ?? string.Empty;
        set
        {
            pFldFCompromisso = pFldFCompromisso || !(m_FCompromisso ?? string.Empty).Equals(value);
            if (pFldFCompromisso)
                m_FCompromisso = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public int FTipoCompromisso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTipoCompromisso;
        set
        {
            pFldFTipoCompromisso = pFldFTipoCompromisso || value != m_FTipoCompromisso;
            if (pFldFTipoCompromisso)
                m_FTipoCompromisso = value;
        }
    }

    public int FCliente
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCliente;
        set
        {
            pFldFCliente = pFldFCliente || value != m_FCliente;
            if (pFldFCliente)
                m_FCliente = value;
        }
    }

    public bool FLiberado
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FLiberado;
        set
        {
            pFldFLiberado = pFldFLiberado || value != m_FLiberado;
            if (pFldFLiberado)
                m_FLiberado = value;
        }
    }

    public bool FImportante
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FImportante;
        set
        {
            pFldFImportante = pFldFImportante || value != m_FImportante;
            if (pFldFImportante)
                m_FImportante = value;
        }
    }

    public bool FConcluido
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FConcluido;
        set
        {
            pFldFConcluido = pFldFConcluido || value != m_FConcluido;
            if (pFldFConcluido)
                m_FConcluido = value;
        }
    }

    public int FArea
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FArea;
        set
        {
            pFldFArea = pFldFArea || value != m_FArea;
            if (pFldFArea)
                m_FArea = value;
        }
    }

    public int FJustica
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FJustica;
        set
        {
            pFldFJustica = pFldFJustica || value != m_FJustica;
            if (pFldFJustica)
                m_FJustica = value;
        }
    }

    public int FProcesso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FProcesso;
        set
        {
            pFldFProcesso = pFldFProcesso || value != m_FProcesso;
            if (pFldFProcesso)
                m_FProcesso = value;
        }
    }

    public int FIDHistorico
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIDHistorico;
        set
        {
            pFldFIDHistorico = pFldFIDHistorico || value != m_FIDHistorico;
            if (pFldFIDHistorico)
                m_FIDHistorico = value;
        }
    }

    public int FIDInsProcesso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIDInsProcesso;
        set
        {
            pFldFIDInsProcesso = pFldFIDInsProcesso || value != m_FIDInsProcesso;
            if (pFldFIDInsProcesso)
                m_FIDInsProcesso = value;
        }
    }

    public int FUsuario
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FUsuario;
        set
        {
            pFldFUsuario = pFldFUsuario || value != m_FUsuario;
            if (pFldFUsuario)
                m_FUsuario = value;
        }
    }

    public int FPreposto
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FPreposto;
        set
        {
            pFldFPreposto = pFldFPreposto || value != m_FPreposto;
            if (pFldFPreposto)
                m_FPreposto = value;
        }
    }

    public int FQuemID
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FQuemID;
        set
        {
            pFldFQuemID = pFldFQuemID || value != m_FQuemID;
            if (pFldFQuemID)
                m_FQuemID = value;
        }
    }

    public int FQuemCodigo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FQuemCodigo;
        set
        {
            pFldFQuemCodigo = pFldFQuemCodigo || value != m_FQuemCodigo;
            if (pFldFQuemCodigo)
                m_FQuemCodigo = value;
        }
    }

    public string? FStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FStatus ?? string.Empty;
        set
        {
            pFldFStatus = pFldFStatus || !(m_FStatus ?? string.Empty).Equals(value);
            if (pFldFStatus)
                m_FStatus = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public decimal FValor
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FValor;
        set
        {
            if (value == m_FValor)
                return;
            pFldFValor = true;
            m_FValor = value;
        }
    }

    [StringLength(2048, ErrorMessage = "A propriedade FDecisao da tabela Agenda deve ter no máximo 2048 caracteres.")]
    public string? FDecisao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FDecisao ?? string.Empty;
        set
        {
            pFldFDecisao = pFldFDecisao || !(m_FDecisao ?? string.Empty).Equals(value);
            if (pFldFDecisao)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FDecisao = trimmed.Length > 2048 ? trimmed.AsSpan(0, 2048).ToString() : trimmed;
            }
        }
    }

    public int FSempre
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSempre;
        set
        {
            pFldFSempre = pFldFSempre || value != m_FSempre;
            if (pFldFSempre)
                m_FSempre = value;
        }
    }

    public int FPrazoDias
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FPrazoDias;
        set
        {
            pFldFPrazoDias = pFldFPrazoDias || value != m_FPrazoDias;
            if (pFldFPrazoDias)
                m_FPrazoDias = value;
        }
    }

    public int FProtocoloIntegrado
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FProtocoloIntegrado;
        set
        {
            pFldFProtocoloIntegrado = pFldFProtocoloIntegrado || value != m_FProtocoloIntegrado;
            if (pFldFProtocoloIntegrado)
                m_FProtocoloIntegrado = value;
        }
    }

    public string? FDataInicioPrazo
    {
        get => $"{m_FDataInicioPrazo:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataInicioPrazo:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataInicioPrazo, m_FDataInicioPrazo, value);
            if (!setUpNow)
                return;
            pFldFDataInicioPrazo = changed;
            m_FDataInicioPrazo = data;
        }
    }

    public bool FUsuarioCiente
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FUsuarioCiente;
        set
        {
            pFldFUsuarioCiente = pFldFUsuarioCiente || value != m_FUsuarioCiente;
            if (pFldFUsuarioCiente)
                m_FUsuarioCiente = value;
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
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => throw new NotImplementedException();
    public ImmutableArray<DBInfoSystem> IPkFields() => throw new NotImplementedException();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => throw new NotImplementedException();
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetID() => ID;
}
namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBModelosDocumentos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBModelosDocumentosDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.Remuneracao:
                FRemuneracao = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.Assinatura:
                FAssinatura = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.Header:
                FHeader = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.Footer:
                FFooter = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.Extra1:
                FExtra1 = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.Extra2:
                FExtra2 = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.Extra3:
                FExtra3 = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.Outorgante:
                FOutorgante = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.Outorgados:
                FOutorgados = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.Poderes:
                FPoderes = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.Objeto:
                FObjeto = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.Titulo:
                FTitulo = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.Testemunhas:
                FTestemunhas = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.TipoModeloDocumento:
                FTipoModeloDocumento = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBModelosDocumentosDicInfo.CSS:
                FCSS = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBModelosDocumentosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBModelosDocumentosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBModelosDocumentosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBModelosDocumentosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBModelosDocumentosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBModelosDocumentosDicInfo.Nome => NFNome(),
        DBModelosDocumentosDicInfo.Remuneracao => NFRemuneracao(),
        DBModelosDocumentosDicInfo.Assinatura => NFAssinatura(),
        DBModelosDocumentosDicInfo.Header => NFHeader(),
        DBModelosDocumentosDicInfo.Footer => NFFooter(),
        DBModelosDocumentosDicInfo.Extra1 => NFExtra1(),
        DBModelosDocumentosDicInfo.Extra2 => NFExtra2(),
        DBModelosDocumentosDicInfo.Extra3 => NFExtra3(),
        DBModelosDocumentosDicInfo.Outorgante => NFOutorgante(),
        DBModelosDocumentosDicInfo.Outorgados => NFOutorgados(),
        DBModelosDocumentosDicInfo.Poderes => NFPoderes(),
        DBModelosDocumentosDicInfo.Objeto => NFObjeto(),
        DBModelosDocumentosDicInfo.Titulo => NFTitulo(),
        DBModelosDocumentosDicInfo.Testemunhas => NFTestemunhas(),
        DBModelosDocumentosDicInfo.TipoModeloDocumento => NFTipoModeloDocumento(),
        DBModelosDocumentosDicInfo.CSS => NFCSS(),
        DBModelosDocumentosDicInfo.GUID => NFGUID(),
        DBModelosDocumentosDicInfo.QuemCad => NFQuemCad(),
        DBModelosDocumentosDicInfo.DtCad => MDtCad,
        DBModelosDocumentosDicInfo.QuemAtu => NFQuemAtu(),
        DBModelosDocumentosDicInfo.DtAtu => MDtAtu,
        DBModelosDocumentosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}
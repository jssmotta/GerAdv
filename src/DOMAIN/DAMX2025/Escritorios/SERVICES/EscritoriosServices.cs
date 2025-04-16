// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBEscritorios
{
    public string CNPJMaskWithInfo() => FCNPJ.IsEmpty() ? TConstantes.PCnpjNaoInformado : DevourerOne.CNPJValido(FCNPJ) ? DevourerOne.MaskCnpj(FCNPJ) + TConstantes.PCnpjCalculoOK : DevourerOne.MaskCnpj(FCNPJ) + TConstantes.PCnpjCalculoErro;
#if (forWeb)
public string FNomeWebSafe => m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "EscritorioINC");
#endif
#if (forWeb)
public string LnkAction =>   (ID > 1 && !m_FParceria ? DevourerOne.LnkProcesso(ID, "escId", relatorio: true) : string.Empty) + $"<a title='Editar o registro' hRef='EscritorioINC.aspx?Id={ID}'><img alt='edt.' src='https://cdn1.advocati.net.br/msi/v20/images/editar3.webp'/></a>";

#endif
    public string LnkCEP => CEPMask();
    public string Documentos => FCNPJ.IsEmpty() ? string.Empty : DevourerOne.MaskCnpj(FCNPJ) + FInscEst.ComTraço();
#if (forTheWeb)

public string FoneCss => DevourerOne.FoneCss2(FFone, E_TipoRegistroPeople.CQUEM_ESCRITORIO, ID);

public string FoneCSSAsLink => DevourerOne.FoneCss(true, FFone, E_TipoRegistroPeople.CQUEM_ESCRITORIO, ID);

public string LinhaEmail => string.Empty; // DevourerOne.LinhaEmailContato(FNome, FEmail, string.Empty, m_FWebSite); 

#endif
}
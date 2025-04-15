// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBColaboradores
{
#if (forWeb)
public string FNomeWebSafe => sex.m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "ColaboradorINC");
#endif
    public int Classificacao => FClass.IsEmpty() ? 3 : DevourerOne.ClassRating(FClass);
#if (forWeb)
public string LnkAction => $"<a hRef='ColaboradorINC.aspx?Id={ID}'><img alt='edt.' src='https://cdn1.advocati.net.br/msi/v20/images/editar3.webp'/></a><a href='ClienteINC.aspx?Id={m_FCliente}'><img alt='Cliente' src='https://cdn1.advocati.net.br/msi/v20/cliente316.png' /></a>";
#endif
    public string LnkCEP => CEPMask();
    public string Documentos => FCPF.IsEmpty() ? string.Empty : DevourerOne.MaskCpf(FCPF) + FRG.ComTraço();
#if (forTheWeb)

public string FoneCss => DevourerOne.FoneCss2(FFone, E_TipoRegistroPeople.CQUEM_COLABORADOR, ID);

public string FoneCSSAsLink => DevourerOne.FoneCss(true, FFone, E_TipoRegistroPeople.CQUEM_COLABORADOR, ID);

public string LinhaEmail => string.Empty; // DevourerOne.LinhaEmailContato(FNome, FEmail, string.Empty, string.Empty); 

#endif
}

namespace MenphisSI;

[Serializable]
public class VNoAuditor : XCodeIdBase
{
    // Fake Auditor para passar nos testes de auditoria
    private int m_AuditorQuem;
    public virtual int AuditorQuem
    {
        get => m_AuditorQuem;
        set => m_AuditorQuem = value;        
    }
}


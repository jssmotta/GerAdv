namespace MenphisSI.SG.GerAdv;
public partial class DBPoderJudiciarioAssociado : IDisposable
{
    private bool _disposed;
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;
        if (disposing)
        {
        // Liberar recursos gerenciados
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
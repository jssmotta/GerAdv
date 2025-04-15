namespace MenphisSI.BaseCommon;

public interface IWCfgService
{
    Task<bool> DeleteCfq(string key, [FromRoute] string uri);
    Task<bool> DeleteCfq(string key, int oper, [FromRoute] string uri);
    Task SetCfq(string key, int value, [FromRoute] string uri);
    Task SetCfqC(string key, string value, [FromRoute] string uri);
    Task SetCfqMemo(string key, string value, [FromRoute] string uri);
    Task SetCfq(string key, int oper, int value, [FromRoute] string uri);
    Task SetCfqC(string key, int oper, string value, [FromRoute] string uri);
    Task SetCfqMemo(string key, int oper, string value, [FromRoute] string uri);
    Task SetTCfq(int id, string key, int value, [FromRoute] string uri);
    Task SetTCfqC(int id, string key, string value, [FromRoute] string uri);
    Task SetTCfqMemo(int id, string key, string value, [FromRoute] string uri);
    Task<int> GetCfq(string key, [FromRoute] string uri);
    Task<string> GetCfqC(string key, [FromRoute] string uri);
    Task<string> GetCfqMemo(string key, [FromRoute] string uri);
    Task<int> GetCfq(string key, int oper, [FromRoute] string uri);
    Task<string> GetCfqC(string key, int oper, [FromRoute] string uri);
    Task<string> GetCfqMemo(string key, int oper, [FromRoute] string uri);
    Task<int> GetTCfq(int id, string key, [FromRoute] string uri);
    Task<string> GetTCfqC(int id, string key, [FromRoute] string uri);
    Task<string> GetTCfqMemo(int id, string key, [FromRoute] string uri);

}
namespace Interfaces
{
    public interface ISessionManager
    {
        string GetValue(string key);
        void SetValue(string key, string value);
    }
}
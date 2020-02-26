namespace SixPivotApp.Common.Interfaces
{
    public interface IJsonSerializer
    {
        T Deserialize<T>(string json);

        string Serialize(object data);
    }
}
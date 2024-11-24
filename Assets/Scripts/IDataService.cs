public interface IDataService
{
    bool _SaveData<T>(string _RelativePath, T _Data, bool _Encrypted);

    T LoadData<T>(string _RelativePath, bool _Encrypted);
}
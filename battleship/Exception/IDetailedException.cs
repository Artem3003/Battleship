using System;

namespace battleship
{
    interface IDetailedException
    {
        string ErrorCode { get; }
        Dictionary<string, string> AdditionalData { get; }
        void AddAdditionalData(string key, string value);
    }
}
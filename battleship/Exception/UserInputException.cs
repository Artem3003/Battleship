using System;
using System.Diagnostics;

namespace battleship
{
    class UserInputException : Exception, IBaseException, IDetailedException
    {
        public string ErrorCode { get; }
        public Dictionary<string, string> AdditionalData { get; }
        public UserInputException(string message) : base (message) 
        {
            ErrorCode = "909";
        }
        public UserInputException(string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
            AdditionalData = new Dictionary<string, string>();
        }

        void IDetailedException.AddAdditionalData(string key, string value)
        {
            AdditionalData[key] = value;
        }
        StackTrace IBaseException.StackTrace { get; }
    }
}
using System;
using System.Diagnostics;

namespace battleship
{
    interface IBaseException
    {
        string Message { get; }
        Exception InnerException { get; }
        StackTrace StackTrace { get; }
    }
}
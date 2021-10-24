﻿using System;
using System.Globalization;

namespace Application.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException() : base() { }
        public ApiException(string message) : base(message) { }
        public ApiException(string message, object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}

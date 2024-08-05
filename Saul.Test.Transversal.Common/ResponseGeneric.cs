﻿using System.Collections.Generic;

namespace Saul.Test.Transversal.Common
{
    public class ResponseGeneric<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }        
    }
}

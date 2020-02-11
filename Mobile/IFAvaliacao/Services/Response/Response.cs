using System;
using System.Collections.Generic;
using System.Text;

namespace IFAvaliacao.Services.Response
{
    public class Response<T> where T : class
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }
}

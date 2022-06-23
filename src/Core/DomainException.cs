using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DomainException : Exception

    {
        internal List<string> _erros;
        public List<string> Erros => _erros;

        public DomainException() { }

        public DomainException(string mensage, List<string>erros) : base(mensage)
        {
            _erros = erros;
        }

        public DomainException(string message) : base(message) 
        { }

        public DomainException(string message,Exception innerException) : base(message, innerException)
        { }

    }
}

using System.Collections.Generic;

namespace Ghost.books.Models
{
    public class ValidaCampoViewModelOutput
    {

        public IEnumerable<string> Erros { get; private set; }

        public ValidaCampoViewModelOutput(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
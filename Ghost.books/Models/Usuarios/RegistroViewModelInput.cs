using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ghost.books.Models.Usuarios
{
    public class RegistroViewModelInput
    {
        [Required(ErrorMessage = "O login é obrigatório")]

        public string Login { get; set; }

        [Required(ErrorMessage = "O e-mail é obrogatório")]

        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]

        public string Senha { get; set; }




    }
}

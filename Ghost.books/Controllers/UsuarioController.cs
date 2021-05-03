using Ghost.books.Filters;
using Ghost.books.Models;
using Ghost.books.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ghost.books.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
    public class UsuarioController : ControllerBase
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
    {

        /// <summary>
        /// teste
        /// </summary>
        /// <param name="loginViewModelInput"></param>
        /// <returns></returns>
        /// 
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]

        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new ValidaCampoViewModelOutput(ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
            //}

            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = 1,
                Login = "Ghost",
                Email = "ghost@outlook.com"
            };

            var secret = Encoding.ASCII.GetBytes("MzfsT&d9gprP>!9$Es(X!5g@;ef!5sbk:jH\\2.}8ZP'qy#7");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]  
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, usuarioViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, usuarioViewModelOutput.Email.ToString())
            }),
            Expires = Datatime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredetials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);


            return public object Expires { get; private set; }
        public object Datatime { get; private set; }

        Ok(loginViewModelInput);
        }

        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        public IActionResult Registrar(RegistroViewModelInput loginViewModelInput)
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        
            
        {
            return Created("", loginViewModelInput);
        }
    }
}


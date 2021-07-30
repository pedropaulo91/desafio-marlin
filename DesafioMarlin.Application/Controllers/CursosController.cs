using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesafioMarlin.Application.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CursosController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAlunoService _alunoService;
        private readonly ITurmaService _turmaService;
        private readonly ITokenService _tokenService;
        private const string ERROR_MESSAGE = "Ocorreu um erro no processamento da sua requisição";


        public CursosController(IUsuarioService usuarioService, IAlunoService alunoService, 
            ITurmaService turmaService, ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _alunoService = alunoService;
            _turmaService = turmaService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]Usuario model)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuario(model);

                if (usuario == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                var token = _tokenService.GenerateToken(usuario);

                return Ok(new { token = token });

            } catch (Exception)
            {

                return StatusCode(500, new {message = ERROR_MESSAGE});
            }

        }

        [HttpPost]
        [Route("aluno")]
        public async Task<IActionResult> CadastroAluno([FromBody]Aluno model)
        {

            try
            {
                // TODO: Validar quantidade de turmas
                await _alunoService.Insert(model);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = ERROR_MESSAGE });
            }

            
        }

        [HttpGet]
        [Route("aluno")]
        public async Task<IActionResult> ListagemAluno()
        {
            try
            {
                // TODO: Implementar paginação
                var alunos = await _alunoService.Get();
                return Ok(alunos);

            }
            catch (Exception)
            {
                return StatusCode(500, new { message = ERROR_MESSAGE });
            }


        }

        [HttpPut]
        [Route("aluno/{matricula:int}")]
        public async Task<IActionResult> EdicaoAluno(int matricula)
        {
            try
            {
                // TODO: Validar quantidade de turmas
                var aluno = await _alunoService.GetAlunoByMatricula(matricula);

                if(aluno != null)
                {
                    await _alunoService.Update(aluno);
                    return Ok();
                }else
                {
                    return BadRequest("Aluno não encontrado");
                }

                
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = ERROR_MESSAGE });
            }
            

        }

        [HttpDelete]
        [Route("aluno/{matricula:int}")]
        public async Task<IActionResult> ExclusaoAluno(int matricula)
        {

            try
            {
                var aluno = await _alunoService.GetAlunoByMatricula(matricula);

                if(aluno == null)
                {
                    return NotFound("Aluno não encontrado");
                    
                }
                else if (aluno.Turmas.Count > 0)
                {
                    return BadRequest("Aluno está matriculado em alguma turma");
                }
                else
                {
                    await _alunoService.Delete(aluno);
                    return Ok();
                }


            }
            catch (Exception)
            {
                return StatusCode(500, new { message = ERROR_MESSAGE });
            }
            
        }


        [HttpPost]
        [Route("turma")]
        public async Task CasdastroTurma([FromBody]Turma model)
        {

        }
        
        [HttpGet]
        [Route("turma")]
        public async Task ListagemTurma()
        {

        }

        [HttpPut]
        [Route("turma/{numero:int}")]
        public async Task EdicaoTurma(short numero)
        {

        }

        [HttpDelete]
        [Route("turma/{numero:int}")]
        public async Task ExclusaoTurma(short numero)
        {

        }



    }
}

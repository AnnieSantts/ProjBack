using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Myte.WebAPI.BackEnd.Models;
using Projeto.Myte.WebAPI.BackEnd.Models.Entities;


namespace Projeto.Myte.WebAPI.BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuariosController : ControllerBase
	{
		private MyteDbContext _myteDbContext;

		public UsuariosController(MyteDbContext myteDbContext)
		{
			_myteDbContext = myteDbContext;
		}

		//tarefa assícrona com uso da requisição HttpGet
		[HttpGet]
		[Route("GetAll")] //api/UsuarioController/GetAll
		public async Task<ActionResult> Get()
		{
			//criar prop para receber de forma assícrona todos os registros recuperados da base
			var listaUsuarios = await _myteDbContext.Usuarios.ToListAsync();
			return Ok(listaUsuarios);
		}

		//buscar registro único por id
		[HttpGet]
		[Route("GetOne/{id}")] //api/UsuarioController/GetOne/id
		public async Task<ActionResult> GetOne(int id)
		{
			var registroUsuario = await _myteDbContext.Usuarios.FindAsync(id);
			if (registroUsuario == null)
			{
				return NotFound();
			}
			return Ok(registroUsuario);
		}

		//adicionar um registro
		[HttpPost]
		[Route("AddRegister")]
		public async Task<ActionResult> Post(Usuarios registroUsuario)
		{
			_myteDbContext.Usuarios.Add(registroUsuario);
			//inserir registro de forma assícrona
			await _myteDbContext.SaveChangesAsync();
			return Ok(registroUsuario);
		}

		[HttpPut]
		[Route("UpdateRegister/{id}")]
		public async Task<ActionResult> Put([FromRoute] int id, Usuarios novoRegistro)
		{
			var buscandoUser = await _myteDbContext.Usuarios.FindAsync(id);

			if(buscandoUser == null)
			{
				return NotFound();
			}

			buscandoUser.NomeUsuario = novoRegistro.NomeUsuario;
			buscandoUser.DataNascimento = novoRegistro.DataNascimento;
			buscandoUser.EmailUsuario = novoRegistro.EmailUsuario;

			await _myteDbContext.SaveChangesAsync();
			return Ok(buscandoUser);
		}


		[HttpDelete]
		[Route("DeleteRegister")]
		public async Task<ActionResult> Delete(int id)
		{
			var deleteUser = await _myteDbContext.Usuarios.FindAsync(id);

			if (deleteUser == null)
			{
				return NotFound();

			}
			_myteDbContext.Remove(deleteUser);
			await _myteDbContext.SaveChangesAsync();

			return Ok();
		}


	}
}

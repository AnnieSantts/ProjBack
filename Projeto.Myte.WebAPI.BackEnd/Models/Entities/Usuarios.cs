using System.ComponentModel.DataAnnotations;

namespace Projeto.Myte.WebAPI.BackEnd.Models.Entities
{
	//Representação da TB dentro da aplicação
	public class Usuarios
	{
		[Key]
		public int IdUsuario {  get; set; }
		public string? NomeUsuario {get; set; }
		public string? DataNascimento { get; set; }
		public string? EmailUsuario { get; set; }
	   


	}
}

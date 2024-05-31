using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Myte.WebAPI.BackEnd.Models.Entities
{
	public class Departamentos
	{
		[Key]
		public int IdDepartamento { get; set; }
		public string? NomeDepartamento { get; set; }
		[ForeignKey("IdUsuario")]
		public ICollection<Usuarios>? Usuarios { get; set; } // Coleção de usuários
	}
}

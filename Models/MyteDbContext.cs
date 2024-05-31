using Microsoft.EntityFrameworkCore;
using Projeto.Myte.WebAPI.BackEnd.Models.Entities;
namespace Projeto.Myte.WebAPI.BackEnd.Models
{
	//DbContext é uma classe nativa
	public class MyteDbContext : DbContext
	{
		public MyteDbContext(DbContextOptions<MyteDbContext> options) : base(options) { }


		//fazer referencia as entities definidas na aplicação
		public DbSet<Entities.Usuarios> Usuarios { get; set; }
		public DbSet<Entities.Departamentos> Departamentos { get; set; }

		//OnModelCreating ajuda a fazer o mapeamento da relação entre as tabelas
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			modelBuilder.Entity<Usuarios>(entity =>
			{
				entity.HasKey(e => e.IdUsuario); // Define a chave primária
				entity.HasOne(e => e.Departamento)
				 .WithMany(d => d.Usuario) // Um departamento tem muitos usuários
				.HasForeignKey(e => e.IdDepartamento);
			});
			/*
			modelBuilder.Entity<Departamentos>(entity =>
			{
				entity.HasKey(c => c.IdDepartamento); // Define a chave primária
				entity.HasOne(c => c.Usuario) // Um departamento tem muitos usuários
					  .WithOne(e => e.Departamento) // Um usuário pertence a apenas um departamento
					  .HasForeignKey(e => e.IdUsuario); // Chave estrangeira em Usuario
			});*/
			

		}
	}
}

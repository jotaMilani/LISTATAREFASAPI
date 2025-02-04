using LISTATAREFASAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LISTATAREFASAPI.Data
{
    public class ListaTarefasContext : DbContext
    {
        public ListaTarefasContext(DbContextOptions<ListaTarefasContext> options) : base(options)
        {
        }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<TipoDeTarefa> TiposDeTarefas { get; set; }
    }
}

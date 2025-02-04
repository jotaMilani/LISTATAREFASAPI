namespace LISTATAREFASAPI.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Concluida { get; set; }
        public int TipoTarefaId { get; set; }
        public TipoDeTarefa? TipoTarefa { get; set; }
    }
}

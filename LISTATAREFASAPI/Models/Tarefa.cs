namespace LISTATAREFASAPI.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Descricao { get; set; }
        public bool Concluida { get; set; }
        public int TipoDeTarefaId { get; set; }
        public TipoDeTarefa? TipoDeTarefa { get; set; }
    }
}

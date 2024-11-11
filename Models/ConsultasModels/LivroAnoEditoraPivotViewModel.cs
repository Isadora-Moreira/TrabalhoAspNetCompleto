namespace TrabalhoAspNet.Models.ConsultasModels;

public class LivroAnoEditoraPivotViewModel
{
    public class LivroAnoEditoraPivot
    {
        public string Editora { get; set; }
        public Dictionary<int, int> QuantidadesPorAno { get; set; } = new();
    }
}
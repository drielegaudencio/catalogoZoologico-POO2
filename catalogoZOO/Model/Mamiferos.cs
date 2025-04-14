namespace catalogoZOO.Model
{
    public class Mamiferos : Animal
    {
        public string? Pelagem { get; set; }
        public int? TempoGestacao { get; set; }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Pelagem: {Pelagem}");
            Console.WriteLine($"Tempo de Gestação: {TempoGestacao}");
        }
    }

}

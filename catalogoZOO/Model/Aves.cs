namespace catalogoZOO.Model
{
    public class Aves : Animal
    {
        public int? EnvergaduraAsa { get; set; }
        public string? TipoBico { get; set; }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Envergadura da Asa: {EnvergaduraAsa}");
            Console.WriteLine($"Tipo de Bico: {TipoBico}");
        }
    }
}

namespace catalogoZOO.Model
{
    public class Carnivoros : Mamiferos
    {
        public string? DietaPrincipal { get; set; }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Dieta Principal: {DietaPrincipal}");
        }
    }
}

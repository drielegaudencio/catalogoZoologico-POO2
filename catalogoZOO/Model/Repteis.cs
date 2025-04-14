namespace catalogoZOO.Model
{
    public class Repteis : Animal
    {
        public string? TipoDeEscamas { get; set; }
        public bool Venenoso { get; set; }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Tipo de Escamas: {TipoDeEscamas}");
            Console.WriteLine($"Venenoso: {(Venenoso ? "Sim" : "Não")}");
        }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace catalogoZOO.Model
{
    public class Animal
    {
        public int AnimalId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Especie { get; set; }
        [Required]
        public string Habitat { get; set; }
        [Required]
        public decimal Idade { get; set; }
        [Required]
        public string Genero { get; set; }

        public Animal()
        {

        }
        public virtual void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Espécie: {Especie}");
            Console.WriteLine($"Habitat: {Habitat}");
            Console.WriteLine($"Idade: {Idade}");
            Console.WriteLine($"Gênero: {Genero}");
        }


    }
}

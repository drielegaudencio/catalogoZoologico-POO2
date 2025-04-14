using System.Runtime.Intrinsics.X86;
using catalogoZOO.Model;

namespace catalogoZOO.Data
{
    public class CatalogoZOODbInitializer
    {
        public static void Initialize(CatalogoZooContext context)
        {
            context.Database.EnsureCreated();
            if (context.Animals.Any())
            {
                return;
            }
            var animals = new Animal[]
            {
                new Mamiferos { AnimalId = 1, Nome = "Leão", Especie = "Mamifero", Habitat = "Savana", Genero = "Macho", Idade = 5, Pelagem = "Dourada", TempoGestacao = 110 },
                new Repteis { AnimalId = 2, Nome = "Cobra", Especie = "Reptil", Habitat = "Diversos", Genero = "Femea", Idade = 2, TipoDeEscamas = "Escamas", Venenoso = true },
                new Aves { AnimalId = 3, Nome = "Águia", Especie = "Ave", Habitat = "Montanhas", Genero = "Macho", Idade = 7, EnvergaduraAsa = 200, TipoBico = "Curvo" },
                new Animal { AnimalId = 4, Nome = "OutroAnimal", Especie = "Desconhecido", Habitat = "Lugar Nenhum", Genero = "Desconhecido", Idade = 1 }
            };
            foreach (Animal animal in animals)
            {
                context.Animals.Add(animal);
                context.SaveChanges();
            }
        }
    }
}

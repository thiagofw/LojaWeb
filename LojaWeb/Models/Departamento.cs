namespace LojaWeb.Models;

public class Departamento
{
        public int Id { get; set; }
        public string? Nome { get; set; }
        public ICollection<Vendedor> Vendedores {get; set;} = new List<Vendedor>();

    public Departamento(){ //Construtor
    }

    // Construtor com argumentos
    public Departamento(int id, string nome){
        Id = id;
        Nome = nome;
    }
    
    


}
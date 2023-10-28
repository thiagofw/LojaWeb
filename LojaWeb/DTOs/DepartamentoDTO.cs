using LojaWeb.Models;

namespace LojaWeb.DTOs;

public class DepartamentoDTO
{
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores {get; set;} = new List<Vendedor>();

    public DepartamentoDTO(){ //Construtor
    }

    // Construtor com argumentos
    public DepartamentoDTO(int id, string nome){
        Id = id;
        Nome = nome;
    }
    
    


}
using LojaWeb.Models;

namespace LojaWeb.DTOs;


public class VendedorDTO
{
      public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public DateTime Nascimento { get; set; }
        public double Salario { get; set; }
        public Departamento Departamento {get; set;}

        public ICollection<RegistroVendas> Vendas {get; set;} = new List<RegistroVendas>(); 

        //Construtor padrão
        public VendedorDTO(){
        }

        //Construtor com argumentos
        public VendedorDTO(int id, string nome, string email, DateTime nascimento, double salario, Departamento departamento){
            Id = id;
            Nome = nome;
            Email = email;
            Nascimento = nascimento;
            Salario = salario;
            Departamento = departamento;
        }
}
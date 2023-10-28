
namespace LojaWeb.Models;

public class Vendedor
{
      public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public DateTime Nascimento { get; set; }
        public double Salario { get; set; }
        public Departamento Departamento {get; set;}

        public ICollection<RegistroVendas> Vendas {get; set;} = new List<RegistroVendas>(); 

        //Construtor padrão
        public Vendedor(){
        }

        //Construtor com argumentos
        public Vendedor(int id, string nome, string email, DateTime nascimento, double salario, Departamento departamento){
            Id = id;
            Nome = nome;
            Email = email;
            Nascimento = nascimento;
            Salario = salario;
            Departamento = departamento;
        }
}
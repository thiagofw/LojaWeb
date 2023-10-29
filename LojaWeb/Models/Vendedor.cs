
using System.ComponentModel.DataAnnotations;

namespace LojaWeb.Models;

public class Vendedor
{
      public int Id { get; set; }
       [Required(ErrorMessage ="Campo Obrigatorio")]
        public string? Nome { get; set; }
        [DataType(DataType.EmailAddress)]
         [Required(ErrorMessage ="Campo Obrigatorio")]
        public string? Email { get; set; }
        [Display(Name ="Data Nascimento")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }
       
        public double Salario { get; set; }
        [Display(Name ="Dep.")]
        public Departamento Departamento {get; set;}
        [Display(Name ="ID Departamento")]
       
        public int DepartamentoId { get; set; }

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
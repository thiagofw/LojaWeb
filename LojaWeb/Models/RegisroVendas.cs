using System.Security.Permissions;
using LojaWeb.Models.Enums;

namespace LojaWeb.Models;
public class RegistroVendas
{
      public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set; }
        public StatusVenda Status {get; set;}
        public Vendedor Vendedor {get; set;}

    //Construtor padrão
    public RegistroVendas(){
    }
    
    //Construtor com argumentos
    public RegistroVendas(int id, DateTime data, double total, StatusVenda statusVenda, Vendedor vendedor){
        Id = id;
        Data = data;
        Total = total;
        Status = statusVenda;
        Vendedor = vendedor;
    }
}
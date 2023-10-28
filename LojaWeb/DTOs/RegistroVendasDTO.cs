using System.Security.Permissions;
using LojaWeb.Models;
using LojaWeb.Models.Enums;

namespace LojaWeb.DTOs;
public class RegistroVendasDTO
{
      public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set; }
        public StatusVenda Status {get; set;}
        public VendedorDTO Vendedor {get; set;}

    //Construtor padrão
    public RegistroVendasDTO(){
    }
    
    //Construtor com argumentos
    public RegistroVendasDTO(int id, DateTime data, double total, StatusVenda statusVenda, VendedorDTO vendedor){
        Id = id;
        Data = data;
        Total = total;
        Status = statusVenda;
        Vendedor = vendedor;
    }
}
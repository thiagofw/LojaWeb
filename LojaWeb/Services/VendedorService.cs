using System.Collections;
using LojaWeb.Data;
using LojaWeb.DTOs;
using LojaWeb.Models;
using LojaWeb.Services.Interfaces;


namespace LojaWeb.Services;

public class VendedorService : IVendedorService
{
    private readonly VsproContext _vsproContext;

    public VendedorService(VsproContext vsproContext)
    {
        _vsproContext = vsproContext;
    }
  
    public IEnumerable FindAll()
    {
        var list = _vsproContext.Vendedor;
        var vendedorDto = new List<VendedorDTO>();
        vendedorDto = list.Select(x => new VendedorDTO(
            x.Id,
            x.Nome,
            x.Email,
            x.Nascimento,
            x.Salario,
            x.Departamento
        )).ToList();
        return vendedorDto;
    }

    public VendedorDTO New(VendedorDTO vendedorDTO)
    {
        // Teste Departamento
        //  Departamento d1 = new Departamento(100, "Computer");
        var novo = new Vendedor{

            Nome = vendedorDTO.Nome,
            Email = vendedorDTO.Email,
            Nascimento = vendedorDTO.Nascimento,
            Salario = vendedorDTO.Salario,
            Departamento = vendedorDTO.Departamento

        };
        _vsproContext.Vendedor.Add(novo);
        _vsproContext.SaveChanges();
        var novoVendedor = new VendedorDTO(vendedorDTO.Id ,vendedorDTO.Nome, vendedorDTO.Email, vendedorDTO.Nascimento, vendedorDTO.Salario, vendedorDTO.Departamento);
        return vendedorDTO;
    }
}
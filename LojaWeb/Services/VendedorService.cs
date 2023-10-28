using System.Collections;
using LojaWeb.Data;
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
        var vendedorDto = new List<Vendedor>();
        vendedorDto = list.Select(x => new Vendedor(
            x.Id,
            x.Nome,
            x.Email,
            x.Nascimento,
            x.Salario,
            x.Departamento
        )).ToList();
        return vendedorDto;
    }

    public Vendedor New(Vendedor vendedor)
    {
       // vendedorDTO.Departamento = _vsproContext.Departamento.First();
        // Teste Departamento
        //  Departamento d1 = new Departamento(100, "Computer");
        var novo = new Vendedor{

           
            Nome = vendedor.Nome,
            Email = vendedor.Email,
            Nascimento = vendedor.Nascimento,
            Salario = vendedor.Salario,
            DepartamentoId = vendedor.DepartamentoId

        };
        _vsproContext.Vendedor.Add(novo);
        _vsproContext.SaveChanges();
       // var novoVendedor = new VendedorDTO(vendedorDTO.Id ,vendedorDTO.Nome, vendedorDTO.Email, vendedorDTO.Nascimento, vendedorDTO.Salario, vendedorDTO.DepartamentoId);
        return vendedor;
    }

    public Vendedor FindById(int id)
    {
        return _vsproContext.Vendedor.FirstOrDefault(x => x.Id == id);

    }
    public void Remove(int id){
        var obj = _vsproContext.Vendedor.Find(id);
        _vsproContext.Remove(obj);
        _vsproContext.SaveChanges();
    }
}
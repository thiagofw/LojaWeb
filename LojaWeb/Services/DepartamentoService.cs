using System.Collections;
using LojaWeb.Data;
using LojaWeb.Models;
using LojaWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaWeb.Services;

public class DepartamentoService : IDepartamentoService
{
    private readonly VsproContext _vsproContext;

    public DepartamentoService(VsproContext vsproContext)
    {
        _vsproContext = vsproContext;
    }
    public List<Departamento> FindList()
    {
        return _vsproContext.Departamento.OrderBy(x => x.Nome).ToList();

    }
    public IEnumerable FindAll()
    {
        var list = _vsproContext.Departamento;
        var departamentoDTO = new List<Departamento>();
        departamentoDTO = list.Select(x => new Departamento(
            x.Id,
            x.Nome
          
        )).ToList();
        return departamentoDTO;
    }

    public IEnumerable FindBy(int id)
    {
       
        var list = _vsproContext.Departamento;
        var departamentoDto = new List<Departamento>();
        departamentoDto = list.Where(m => m.Id == id).Select(x => new Departamento(
            x.Id,
            x.Nome
        )).ToList();
      
        return departamentoDto;
    }

    public Departamento New(Departamento departamento)
    {
       
        var novo = new Departamento{
            
           Nome = departamento.Nome

        };
        _vsproContext.Departamento.Add(novo);
        _vsproContext.SaveChanges();
        var novoDepartamento = new Departamento(novo.Id, novo.Nome);
        return novoDepartamento;

    }
}
    
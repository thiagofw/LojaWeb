using System.Collections;
using LojaWeb.Data;
using LojaWeb.DTOs;
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
    public IEnumerable FindAll()
    {
        var list = _vsproContext.Departamento;
        var departamentoDTO = new List<DepartamentoDTO>();
        departamentoDTO = list.Select(x => new DepartamentoDTO(
            x.Id,
            x.Nome
          
        )).ToList();
        return departamentoDTO;
    }

    public IEnumerable FindBy(int id)
    {
       
        var list = _vsproContext.Departamento;
        var departamentoDto = new List<DepartamentoDTO>();
        departamentoDto = list.Where(m => m.Id == id).Select(x => new DepartamentoDTO(
            x.Id,
            x.Nome
        )).ToList();
      
        return departamentoDto;
    }

    public DepartamentoDTO New(DepartamentoDTO departamento)
    {
       
        var novo = new Departamento{
            
           Nome = departamento.Nome

        };
        _vsproContext.Departamento.Add(novo);
        _vsproContext.SaveChanges();
        var novoDepartamentoDTO = new DepartamentoDTO(novo.Id, novo.Nome);
        return novoDepartamentoDTO;

    }
}
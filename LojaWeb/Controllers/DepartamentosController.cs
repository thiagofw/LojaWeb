using System.Reflection.Metadata.Ecma335;
using LojaWeb.DTOs;
using LojaWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaWeb.Controllers;

public class DepartamentosController: Controller
{
    IDepartamentoService _departamentoService;
    public DepartamentosController(IDepartamentoService departamentoService)
    {
        _departamentoService = departamentoService;
    }

    public IActionResult Index(){
        var list = _departamentoService.FindAll();
        return View(list);
    }

    public IActionResult Details(int id)
    {
       
       var list = _departamentoService.FindBy(id);
        return View(list);
        
    }

    [HttpGet]
    public IActionResult New(){
        return View();
    }
    [HttpPost]
    public IActionResult New(DepartamentoDTO departamentoDTO)
    {
        if(ModelState.IsValid){
            _departamentoService.New(departamentoDTO);
            return RedirectToAction("Index");
        }
        return View(departamentoDTO);
    }
    

}
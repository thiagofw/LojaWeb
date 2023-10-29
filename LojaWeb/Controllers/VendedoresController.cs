
using LojaWeb.Models;
using LojaWeb.Models.ViewModels;
using LojaWeb.Services.Exceptions;
using LojaWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace LojaWeb.Controllers;

public class VendedoresController: Controller
{
    private readonly IVendedorService _vendedorService;
    private readonly IDepartamentoService _departamentoService;

    private readonly ILogger<VendedoresController> _logger; // Incluir o logger


    public VendedoresController(IVendedorService vendedorService, ILogger<VendedoresController> logger, IDepartamentoService departamentoService)
    {
        _vendedorService = vendedorService;
        _logger = logger;
        _departamentoService = departamentoService;
    }
    public IActionResult Index()
    {
        var list = _vendedorService.FindAll();
        return View(list);
    }
    [HttpGet]
    public IActionResult New()
    {
        var departamento = _departamentoService.FindList();
        var viewModel = new VendedorFormViewModel{Departamentos = departamento};
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult New(Vendedor vendedor)
    {
      
          _vendedorService.New(vendedor);
            _logger.LogInformation("Numero de itens: {0}", vendedor);
            return RedirectToAction("Index");
       
    }
    public IActionResult FindById(int id)
    {
        var list = _departamentoService.FindBy(id);
        return View(list);
    }
    public IActionResult Delete(int? id)
    {
        if(id == null)
        {
            return RedirectToAction(nameof(Error), new {message = "Id não Fornecido. O id está correto?"});

        }
        var obj = _vendedorService.FindById(id.Value);
        if(obj == null){
            return RedirectToAction(nameof(Error), new {message = "Id não encontrado"});
        }
        return View(obj);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
       _vendedorService.Remove(id);
       return RedirectToAction("Index");
       
    }
    public IActionResult Details(int? id)
    {
        if(id == null){
            return RedirectToAction(nameof(Error), new {message = "Id não Fornecido. O id está correto?"});
        }
        var obj = _vendedorService.FindById(id.Value);
        if(obj == null)
        {
             return RedirectToAction(nameof(Error), new {message = "Id não encontrado"});
        }
        return View(obj);
    }
    [HttpGet]
    public IActionResult Edit(int? id)
    {
       if(id == null){
             return RedirectToAction(nameof(Error), new {message = "Id não encontrado"});
        }
        var obj = _vendedorService.FindById(id.Value);
        if(obj == null)
        {
             return RedirectToAction(nameof(Error), new {message = "Id não encontrado"});
        }
        
        var list = _departamentoService.FindList();
        VendedorFormViewModel viewModel = new VendedorFormViewModel{
            Vendedor = obj,
            Departamentos = list
        };
        return View(viewModel);
    }
        [HttpPost]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if(id != vendedor.Id)
            {
                return BadRequest();
            }
            try{
            _vendedorService.Update(vendedor);
            return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException e)
            {
               return View(e.Message);
            }
            catch(DBConcurrencyException e)
            {
                return View(e.Message);
            }
        }
        
        public IActionResult Error(string message)
        {
              //throw new NotFoundException("Vendedor não encontrado. Verifique as informações!");
             // var viewModel = new ErrorViewModel{
             //   Message = message,
             //   RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            //  };
            var viewModel = _vendedorService.Error(message);

              return View(viewModel);
        }
      
}

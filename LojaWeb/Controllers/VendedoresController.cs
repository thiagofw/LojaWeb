
using LojaWeb.Models;
using LojaWeb.Models.ViewModels;
using LojaWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
      //  if(ModelState.IsValid)
      //  {
            _vendedorService.New(vendedor);
            _logger.LogInformation("Numero de itens: {0}", vendedor);
            return RedirectToAction("Index");
      //  }
     //   return View(vendedorDTO);
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
            return NotFound();

        }
        var obj = _vendedorService.FindById(id.Value);
        if(obj == null){
            return NotFound();
        }
        return View(obj);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
       _vendedorService.Remove(id);
       return RedirectToAction("Index");
       
    }
}

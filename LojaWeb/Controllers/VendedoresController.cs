
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
}


using LojaWeb.DTOs;
using LojaWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaWeb.Controllers;

public class VendedoresController: Controller
{
    private readonly IVendedorService _vendedorService;
    private readonly ILogger<VendedoresController> _logger; // Incluir o logger


    public VendedoresController(IVendedorService vendedorService, ILogger<VendedoresController> logger)
    {
        _vendedorService = vendedorService;
        _logger = logger;
    }
    public IActionResult Index()
    {
        var list = _vendedorService.FindAll();
        return View(list);
    }
    [HttpGet]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public IActionResult New(VendedorDTO vendedorDTO)
    {
      //  if(ModelState.IsValid)
      //  {
           // _vendedorService.New(vendedorDTO);
            _logger.LogInformation("Numero de itens: {0}", vendedorDTO.Departamento);
            return RedirectToAction("Index");
      //  }
     //   return View(vendedorDTO);
    }
}

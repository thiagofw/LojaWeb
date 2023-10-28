using System.Collections;
using LojaWeb.Models;

namespace LojaWeb.Services.Interfaces;

public interface IVendedorService
{
     IEnumerable FindAll();
     Vendedor New(Vendedor vendedor);
}
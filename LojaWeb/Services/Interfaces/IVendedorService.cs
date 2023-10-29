using System.Collections;
using LojaWeb.Models;
using LojaWeb.Models.ViewModels;

namespace LojaWeb.Services.Interfaces;

public interface IVendedorService
{
     IEnumerable FindAll();
     Vendedor New(Vendedor vendedor);
     Vendedor FindById(int id);

     void Remove(int id);

     void Update(Vendedor vendedor);

    ErrorViewModel Error(string message);
}
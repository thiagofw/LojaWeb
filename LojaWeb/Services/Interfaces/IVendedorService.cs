using System.Collections;
using LojaWeb.DTOs;

namespace LojaWeb.Services.Interfaces;

public interface IVendedorService
{
     IEnumerable FindAll();
     VendedorDTO New(VendedorDTO vendedorDTO);
}
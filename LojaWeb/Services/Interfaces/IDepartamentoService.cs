using System.Collections;
using LojaWeb.DTOs;

namespace LojaWeb.Services.Interfaces;
public interface IDepartamentoService
{

    IEnumerable FindAll();
    IEnumerable FindBy(int id);
    DepartamentoDTO New(DepartamentoDTO departamento);
}
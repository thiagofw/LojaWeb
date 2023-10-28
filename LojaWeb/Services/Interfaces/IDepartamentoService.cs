using System.Collections;
using LojaWeb.Models;

namespace LojaWeb.Services.Interfaces;
public interface IDepartamentoService
{

    IEnumerable FindAll();
    IEnumerable FindBy(int id);
    Departamento New(Departamento departamento);

    List<Departamento> FindList();

    
}
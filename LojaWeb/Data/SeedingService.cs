using Microsoft.EntityFrameworkCore;
using LojaWeb.Models;
using LojaWeb.Models.Enums;

namespace LojaWeb.Data;

public class SeedingService
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new VsproContext(
            serviceProvider.GetRequiredService<DbContextOptions<VsproContext>>()))
            {
                if(context.Departamento.Any() || context.RegistroVendas.Any()|| context.Vendedor.Any()){
                    return;
                }
                 Departamento d1 = new Departamento(1, "Computer");
                Departamento d2 = new Departamento(2, "Eletronics");
                Departamento d3 = new Departamento(3, "Fashion");
                Departamento d4 = new Departamento(4, "Books");

                Vendedor s1 = new Vendedor(1, "Bob Brown", "bob@gmail.com", new DateTime(1995, 3, 30), 1000.0, d1);
                Vendedor s2 = new Vendedor(2, "Ana Beatriz", "ana@gmail.com", new DateTime(2000, 11, 11), 1200.0, d2);
                Vendedor s3 = new Vendedor(3, "Carlos Henrique", "c.henrique1994@gmail.com", new DateTime(1994, 2, 5), 1200.0, d3);
                Vendedor s4 = new Vendedor(4, "Alex Cooper", "alex2002@gmail.com", new DateTime(2002, 1, 28), 1200.0, d4);

                RegistroVendas sr1 = new RegistroVendas(1, new DateTime(2018, 09, 25), 1100.0, StatusVenda.Cancelada, s1);
                RegistroVendas sr2 = new RegistroVendas(2, new DateTime(2018, 12, 29), 11100.0, StatusVenda.Finalizada, s2);
                RegistroVendas sr3 = new RegistroVendas(3, new DateTime(2019, 09, 23), 1100.0, StatusVenda.Finalizada, s3);
                RegistroVendas sr4 = new RegistroVendas(4, new DateTime(2023, 05, 25), 2000.0, StatusVenda.Cancelada, s4);
                context.Departamento.AddRange(d1, d2, d3, d4);
                context.Vendedor.AddRange(s1, s2, s3, s4);
                context.RegistroVendas.AddRange(sr1, sr2, sr3, sr4);
                context.SaveChanges();
            }
    }
}
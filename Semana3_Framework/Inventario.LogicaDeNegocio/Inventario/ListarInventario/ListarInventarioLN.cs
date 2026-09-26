using Inventario.Abstracciones.LogicaDeNegocio.Inventario.ListarInventario;
using Inventario.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventario.LogicaDeNegocio.Inventario.ListarInventario
{
    public class ListarInventarioLN : IListarInventarioLN
    {
        private static List<InventarioDto> laListaDeInventario =
            new List<InventarioDto>
            {
                new InventarioDto
                {
                    CodigoDelRepuesto = "0001",
                    NombreDelRepuesto = "Compensador",
                    MarcaDelRepuesto = "KYB",
                    Vehiculo = "Toyota",
                    Modelo = "Corolla",
                    Anio = 2025,
                    Cantidad = 5,
                    FechaDeRegistro = DateTime.Now,
                    FechaDeModificacion = DateTime.Now,
                    Estado = true
                }
            };

        public List<InventarioDto> Obtener()
        {
            return laListaDeInventario;
        }

        public InventarioDto BuscarPorCodigo(string codigo)
        {
            return laListaDeInventario
                .FirstOrDefault(x => x.CodigoDelRepuesto == codigo);
        }

        public void Registrar(InventarioDto inventario)
        {
            InventarioDto existente =
                BuscarPorCodigo(inventario.CodigoDelRepuesto);

            if (existente != null)
            {
                throw new Exception("Ya existe un repuesto con ese código.");
            }

            inventario.FechaDeRegistro = DateTime.Now;
            inventario.FechaDeModificacion = DateTime.Now;

            laListaDeInventario.Add(inventario);
        }

        public void Editar(InventarioDto inventario)
        {
            InventarioDto existente =
                BuscarPorCodigo(inventario.CodigoDelRepuesto);

            if (existente != null)
            {
                existente.NombreDelRepuesto = inventario.NombreDelRepuesto;
                existente.MarcaDelRepuesto = inventario.MarcaDelRepuesto;
                existente.Vehiculo = inventario.Vehiculo;
                existente.Modelo = inventario.Modelo;
                existente.Anio = inventario.Anio;
                existente.Cantidad = inventario.Cantidad;
                existente.Estado = inventario.Estado;
                existente.FechaDeModificacion = DateTime.Now;
            }
        }
    }
}
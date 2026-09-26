using Inventario.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace Inventario.Abstracciones.LogicaDeNegocio.Inventario.ListarInventario
{
    public interface IListarInventarioLN
    {
        List<InventarioDto> Obtener();

        InventarioDto BuscarPorCodigo(string codigo);

        void Registrar(InventarioDto inventario);

        void Editar(InventarioDto inventario);
    }
}
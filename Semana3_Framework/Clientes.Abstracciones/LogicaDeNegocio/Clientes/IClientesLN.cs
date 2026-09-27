using Clientes.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace Clientes.Abstracciones.LogicaDeNegocio.Clientes
{
    public interface IClientesLN
    {
        List<ClienteDto> Obtener();

        ClienteDto BuscarPorIdentificacion(string identificacion);

        void Registrar(ClienteDto cliente);

        void Editar(ClienteDto cliente);
    }
}
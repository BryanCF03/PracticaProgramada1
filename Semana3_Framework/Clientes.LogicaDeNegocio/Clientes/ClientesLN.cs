using Clientes.Abstracciones.LogicaDeNegocio.Clientes;
using Clientes.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clientes.LogicaDeNegocio.Clientes
{
    public class ClientesLN : IClientesLN
    {
        private static List<ClienteDto> laListaDeClientes =
            new List<ClienteDto>
            {
                new ClienteDto
                {
                    Identificacion = "1-1111-1111",
                    Nombre = "Jose Pablo",
                    PrimerApellido = "Delgado",
                    SegundoApellido = "Mora",
                    Telefono = "8888-8888",
                    CorreoElectronico = "soporte@ufidelitas.ac.cr",
                    FechaDeRegistro = DateTime.Now,
                    FechaDeModificacion = DateTime.Now,
                    Estado = "Activo"
                }
            };

        public List<ClienteDto> Obtener()
        {
            return laListaDeClientes;
        }

        public ClienteDto BuscarPorIdentificacion(string identificacion)
        {
            return laListaDeClientes
                .FirstOrDefault(x => x.Identificacion == identificacion);
        }

        public void Registrar(ClienteDto cliente)
        {
            ClienteDto existente =
                BuscarPorIdentificacion(cliente.Identificacion);

            if (existente != null)
            {
                throw new Exception("Ya existe un cliente con esa identificación.");
            }

            cliente.FechaDeRegistro = DateTime.Now;
            cliente.FechaDeModificacion = DateTime.Now;

            laListaDeClientes.Add(cliente);
        }

        public void Editar(ClienteDto cliente)
        {
            ClienteDto existente =
                BuscarPorIdentificacion(cliente.Identificacion);

            if (existente != null)
            {
                existente.Nombre = cliente.Nombre;
                existente.PrimerApellido = cliente.PrimerApellido;
                existente.SegundoApellido = cliente.SegundoApellido;
                existente.Telefono = cliente.Telefono;
                existente.CorreoElectronico = cliente.CorreoElectronico;
                existente.Estado = cliente.Estado;
                existente.FechaDeModificacion = DateTime.Now;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Custely.DAL;
using Custely.ENTITY;

namespace Custely.BLL
{
    public class ClienteBLL
    {
        private readonly ClienteDAL clienteDAL = new ClienteDAL();

        public void AgregarCliente(Cliente cliente)
        {
            ValidarCliente(cliente);

            clienteDAL.AgregarCliente(cliente);
        }
        public List<Cliente> ObtenerClientes()
        {
            return clienteDAL.ObtenerClientes();
        }
        public Cliente? BuscarPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                throw new ArgumentException("Debe ingresar un DNI.");
            }

            return clienteDAL.BuscarPorDni(dni);
        }
        public void ModificarCliente(Cliente cliente)
        {
            if (cliente.IdCliente <= 0)
            {
                throw new ArgumentException(
                    "No hay un cliente válido seleccionado."
                );
            }

            ValidarCliente(cliente);

            clienteDAL.ModificarCliente(cliente);
        }
        private void ValidarCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Dni))
            {
                throw new ArgumentException("El DNI es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                throw new ArgumentException("El nombre es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                throw new ArgumentException("El apellido es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Telefono))
            {
                throw new ArgumentException("El teléfono es obligatorio.");
            }
        }
        public void DarDeBajaCliente(int idCliente)
        {
            if (idCliente <= 0)
            {
                throw new ArgumentException(
                    "No hay un cliente válido seleccionado."
                );
            }

            clienteDAL.DarDeBajaCliente(idCliente);
        }
    }
}
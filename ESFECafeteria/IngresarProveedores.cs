using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESFECafeteria
{
    public partial class IngresarProveedores : Form
    {
        public IngresarProveedores()
        {
            InitializeComponent();
        }

        private void btnIngresarProveedores_Click(object sender, EventArgs e)
        {
            // Crear nueva instancia del formulario AgregarProveedores
            IngresarProveedores formulario = new IngresarProveedores();

            formulario.Show(); // Mostrar el formulario AgregarProveedores

            this.Close(); // Cerrar el formulario de Inicio
        }

        private void btnIngresarProductos_Click(object sender, EventArgs e)
        {
            // Crear nueva instancia del formulario AgregarProductos
            IngresarProductos formulario = new IngresarProductos();

            formulario.Show(); // Mostrar el formulario AgregarProductos

            this.Close(); // Cerrar el formulario de Inicio
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            // Crear nueva instancia del formulario Empleados
            IngresarEmpleados formulario = new IngresarEmpleados();

            formulario.Show(); // Mostrar el formulario Empleados

            this.Close(); // Cerrar el formulario de Inicio
        }

        private void btnGestionDeProveedores_Click(object sender, EventArgs e)
        {
            // Crear nueva instancia del formulario  GestionDeProveedores
            GestionDeProveedores formulario = new GestionDeProveedores();

            formulario.Show(); // Mostrar el formulario  GestionDeProveedores

            this.Close(); // Cerrar el formulario de Inicio
        }

        private void btnGestionDeUsuarios_Click(object sender, EventArgs e)
        {
            // Crear nueva instancia del formulario GestionDeUsuarios
            GestionDeUsuarios formulario = new GestionDeUsuarios();

            formulario.Show(); // Mostrar el formulario GestionDeUsuarios

            this.Close(); // Cerrar el formulario de Inicio
        }

        private void btnHistorialDeCompras_Click(object sender, EventArgs e)
        {
            // Crear nueva instancia del formulario HistorialDeComprasProductos
            HistorialDeComprasProductos formulario = new HistorialDeComprasProductos();

            formulario.Show(); // Mostrar el formulario HistorialDeComprasProductos

            this.Close(); // Cerrar el formulario de Inicio
        }

        private void btnHistorialDeProductos_Click(object sender, EventArgs e)
        {
            // Crear nueva instancia del formulario HistoriaDeProductos
            HistoriaDeProductos formulario = new HistoriaDeProductos();

            formulario.Show(); // Mostrar el formulario HistoriaDeProductos

            this.Close(); // Cerrar el formulario de Inicio
        }

        private void btnControlDeInventario_Click(object sender, EventArgs e)
        {
            // Crear nueva instancia del formulario GestionDeInventario
            GestionDeInventario formulario = new GestionDeInventario();

            formulario.Show(); // Mostrar el formulario GestionDeInventario

            this.Close(); // Cerrar el formulario de Inicio
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Crear nueva instancia del formulario Regresar
            Login formulario = new Login();

            formulario.Show(); // Mostrar el formulario AgregarProveedores

            this.Close(); // Cerrar el formulario de Inicio
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar Nombre
            string nombre = txtNombre.Text;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }

            // Validar Apellido
            string apellido = txtApellido.Text;
            if (string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("El apellido es obligatorio.");
                return;
            }

            // Validar Dirección
            string direccion = txtDireccion.Text;
            if (string.IsNullOrWhiteSpace(direccion))
            {
                MessageBox.Show("La dirección es obligatoria.");
                return;
            }

            // Validar Teléfono
            string telefono = txtTelefono.Text;
            if (string.IsNullOrWhiteSpace(telefono) || !long.TryParse(telefono, out _))
            {
                MessageBox.Show("El teléfono es obligatorio y debe ser numérico.");
                return;
            }

            // Validar Correo Electrónico
            string correo = txtCorreo.Text;
            if (string.IsNullOrWhiteSpace(correo) || !correo.Contains("@"))
            {
                MessageBox.Show("El correo electrónico es obligatorio y debe ser válido.");
                return;
            }

            // Cadena de conexión a la base de datos
            string connectionString = "Data Source=ADRI\\SQLEXPRESS1;Initial Catalog=BD_Cafeteria;Integrated Security=True;";

            // Consulta SQL para insertar un nuevo registro en la tabla Proveedores
            string query = "INSERT INTO Proveedores (nombre, apellido, direccion, telefono, correo) VALUES (@Nombre, @Apellido, @Direccion, @Telefono, @Correo)";

            using (SqlConnection conexionBD = new SqlConnection(connectionString))
            {
                try
                {
                    conexionBD.Open();

                    using (SqlCommand command = new SqlCommand(query, conexionBD))
                    {
                        // Asignar valores a los parámetros
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Apellido", apellido);
                        command.Parameters.AddWithValue("@Direccion", direccion);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.Parameters.AddWithValue("@Correo", correo);

                        // Ejecutar la consulta
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Proveedor guardado.");
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar el proveedor.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int idProveedor;
            if (!int.TryParse(lblIDProveedor.Text, out idProveedor))
            {
                MessageBox.Show("ID de proveedor no es válido.");
                return;
            }

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string correo = txtCorreo.Text;

            string connectionString = "Data Source=ADRI\\SQLEXPRESS1;Initial Catalog=BD_Cafeteria;Integrated Security=True;";

            // Consulta SQL para actualizar un registro existente
            string query = "UPDATE Proveedores SET nombre = @Nombre, apellido = @Apellido, direccion = @Direccion, telefono = @Telefono, correo = @Correo WHERE ID_Proveedor = @IDProveedor";

            using (SqlConnection conexionBD = new SqlConnection(connectionString))
            {
                try
                {
                    conexionBD.Open();

                    using (SqlCommand command = new SqlCommand(query, conexionBD))
                    {
                        // Asignar valores a los parámetros
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Apellido", apellido);
                        command.Parameters.AddWithValue("@Direccion", direccion);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.Parameters.AddWithValue("@Correo", correo);
                        command.Parameters.AddWithValue("@IDProveedor", idProveedor);

                        // Ejecutar la consulta
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Registro actualizado.");
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar el registro.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                }
            }
        }

        private void lblapellido_Click(object sender, EventArgs e)
        {

        }
    }
}

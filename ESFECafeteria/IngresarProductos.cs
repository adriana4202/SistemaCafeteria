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
    public partial class ingresarproductos : Form
    {
        public ingresarproductos()
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
            DateTime fechaIngreso;
            if (!DateTime.TryParse(txtFechaIngreso.Text, out fechaIngreso))
            {
                MessageBox.Show("Fecha de ingreso no válida.");
                return;
            }

            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio no válido.");
                return;
            }

            float unidadMedida;
            if (!float.TryParse(txtUnidadDeMedida.Text, out unidadMedida))
            {
                MessageBox.Show("Unidad de medida no válida.");
                return;
            }

            DateTime fechaElaboracion;
            if (!DateTime.TryParse(txtFechaDeElaboración.Text, out fechaElaboracion))
            {
                MessageBox.Show("Fecha de elaboración no válida.");
                return;
            }

            DateTime fechaVencimiento;
            if (!DateTime.TryParse(txtFechaDeVencimiento.Text, out fechaVencimiento))
            {
                MessageBox.Show("Fecha de vencimiento no válida.");
                return;
            }

            string connectionString = "Data Source=ADRI\\SQLEXPRESS1;Initial Catalog=BD_Cafeteria;Integrated Security=True;";

            // Consulta SQL para insertar un nuevo registro
            string query = "INSERT INTO Producto (fecha_ingreso, nombre, descripcion, precio, unidad_medida, fecha_elaboracion, fecha_vencimiento) VALUES (@FechaIngreso, @Nombre, @Descripcion, @Precio, @UnidadMedida, @FechaElaboracion, @FechaVencimiento)";

            using (SqlConnection conexionBD = new SqlConnection(connectionString))
            {
                try
                {
                    conexionBD.Open();

                    using (SqlCommand command = new SqlCommand(query, conexionBD))
                    {
                        // Asignar valores a los parámetro
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
                        command.Parameters.AddWithValue("@Descripcion", descripcion);
                        command.Parameters.AddWithValue("@Precio", precio);
                        command.Parameters.AddWithValue("@UnidadMedida", unidadMedida);
                        command.Parameters.AddWithValue("@FechaElaboracion", fechaElaboracion);
                        command.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);

                        // Ejecutar la consulta
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Registro guardado exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar el registro.");
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
            int IdProducto;
            if (!int.TryParse(txtIdProducto.Text, out IdProducto))
            {
                MessageBox.Show("Por favor, ingrese un ID de producto válido.");
                return;
            }

            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            decimal precio;

            // Intentar convertir el valor de precio a decimal
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Por favor, ingrese un valor válido para el precio.");
                return;
            }

            // Cadena de conexión a la base de datos
            string connectionString = "Data Source=ADRI\\SQLEXPRESS1;Initial Catalog=BD_Cafeteria;Integrated Security=True;";

            // Consulta SQL para actualizar un registro existente
            string query = "UPDATE Producto SET nombre = @Nombre, descripcion = @Descripcion, precio = @Precio WHERE id_producto = @IdProducto";

            using (SqlConnection conexionBD = new SqlConnection(connectionString))
            {
                try
                {
                    conexionBD.Open();

                    using (SqlCommand command = new SqlCommand(query, conexionBD))
                    {
                        // Asignar valores a los parámetros
                        command.Parameters.AddWithValue("@IdProducto", IdProducto);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Descripcion", descripcion);
                        command.Parameters.AddWithValue("@Precio", precio);

                        // Ejecutar la consulta
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Registro actualizado exitosamente.");
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

    }
}
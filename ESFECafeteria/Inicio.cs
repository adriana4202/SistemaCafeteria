using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESFECafeteria
{
    public partial class Inicio : Form
    {
        public Inicio()
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

    }
}
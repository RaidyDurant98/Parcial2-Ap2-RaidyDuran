using BLL;
using Entidades;
using Parcial1_Ap2_RaidyDuran;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial2_Ap2_RaidyDuran.UI
{
    public partial class PresupuestosRegistro : System.Web.UI.Page
    {
        Presupuestos presupuesto = new Presupuestos();
        DataTable dt = new DataTable();
        private static List<Entidades.PresupuestosDetalles> listaRelaciones;
        public static List<Entidades.PresupuestosDetalles> Detalle { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Descripcion"), new DataColumn("Meta"), new DataColumn("Logrado") });
                ViewState["Detalle"] = dt;

                listaRelaciones = new List<Entidades.PresupuestosDetalles>();
                Detalle = new List<Entidades.PresupuestosDetalles>();

                presupuesto = new Entidades.Presupuestos();
            }
        }

        private void Limpiar()
        {
            PresupuestoIdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            MontoTextBox.Text = "";
            FechaTextBox.Text = "";

            LimpiarListaRelaciones();
        }

        private bool Validar()
        {
            bool interruptor = true;

            if (string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                interruptor = false;
            }
            if (string.IsNullOrEmpty(MontoTextBox.Text))
            {
                interruptor = false;
            }
            if (string.IsNullOrEmpty(FechaTextBox.Text))
            {
                interruptor = false;
            }

            return interruptor;
        }

        private void LimpiarListaRelaciones()
        {
            dt.Rows.Clear();
            Detalle = new List<PresupuestosDetalles>();
            DetalleGridView.DataSource = (DataTable)ViewState["listaRelaciones"];
            listaRelaciones = new List<Entidades.PresupuestosDetalles>();
            DetalleGridView.DataBind();
        }


        private Presupuestos LlenarInstaciaPresupuesto()
        {
            presupuesto.PresupuestoId = Utilidades.TOINT(PresupuestoIdTextBox.Text);
            presupuesto.Descripcion = DescripcionTextBox.Text;
            presupuesto.Monto = Utilidades.TOINT(MontoTextBox.Text);
            presupuesto.Fecha = Convert.ToDateTime(FechaTextBox.Text);

            return presupuesto;
        }

        private bool VerificarExistenciaPresupuesto()
        {
            if (string.IsNullOrEmpty(PresupuestoIdTextBox.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('Digite el id del presupuesto');", addScriptTags: true);
            }
            else
            {
                int id = Utilidades.TOINT(PresupuestoIdTextBox.Text);

                presupuesto = PresupuestosBLL.Buscar(p => p.PresupuestoId == id);

                if (presupuesto != null)
                {
                    return true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('No existe presupuesto con ese id');", addScriptTags: true);
                }
            }

            return false;
        }

        public void LlenarRegistro(List<Entidades.PresupuestosDetalles> llenar)
        {
            foreach (var li in llenar)
            {
                //Chequear esto
                DataTable dt = (DataTable)ViewState["Detalle"];
                dt.Rows.Add(li.Descripcion, li.Meta, li.Logrado);
                ViewState["Detalle"] = dt;
                this.BindGrid();
            }
        }

        private void CargarDatosPresupuesto()
        {
            PresupuestoIdTextBox.Text = presupuesto.PresupuestoId.ToString();
            DescripcionTextBox.Text = presupuesto.Descripcion;
            FechaTextBox.Text = presupuesto.Fecha.ToString("yyyy-MM-dd");
            MontoTextBox.Text = presupuesto.Monto.ToString();

            listaRelaciones = BLL.PresupuestoDetalleBLL.GetList(A => A.PresupuestoId == presupuesto.PresupuestoId);
            LlenarRegistro(listaRelaciones);
        }

        public void LlenarDatos(Entidades.PresupuestosDetalles detalle)
        {
            foreach (GridViewRow dr in DetalleGridView.Rows)
            {
                presupuesto.Relacion.Add(new Entidades.PresupuestosDetalles(
                    Convert.ToString(dr.Cells[0].Text),
                    Convert.ToDecimal(dr.Cells[1].Text),
                    Convert.ToDecimal(dr.Cells[2].Text)));
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Entidades.PresupuestosDetalles detalle = new Entidades.PresupuestosDetalles();
                LlenarDatos(detalle);

                if (PresupuestosBLL.Guardar(LlenarInstaciaPresupuesto()))
                {
                    PresupuestoIdTextBox.Text = Convert.ToString(presupuesto.PresupuestoId);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Presupuesto guardado con exito');", addScriptTags: true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se pudo guardar el presupuesto');", addScriptTags: true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('Por favor llenar los campos vacios');", addScriptTags: true);
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (VerificarExistenciaPresupuesto())
            {
                CargarDatosPresupuesto();
            }
        }

        protected void EnviarAlModalEliminarButton_Click(object sender, EventArgs e)
        {
            if (VerificarExistenciaPresupuesto())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "#ModalEliminar", "showModalEliminar();", true);
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(PresupuestoIdTextBox.Text);

            if (PresupuestosBLL.Eliminar(PresupuestosBLL.Buscar(p => p.PresupuestoId == id)))
            {
                Limpiar();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Presupuesto eliminado con exito');", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se pudo eliminar el presupuesto');", addScriptTags: true);
            }
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            dt = (DataTable)ViewState["Detalle"];
            dt.Rows.Add(DescripcionTextBox.Text, MetaTextBox.Text, LogradoTextBox.Text);
            ViewState["Detalle"] = dt;
            this.BindGrid();
        }

        protected void BindGrid()
        {
            DetalleGridView.DataSource = (DataTable)ViewState["Detalle"];
            DetalleGridView.DataBind();
        }
    }
}
using CrudWindowsForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWindowsForms.Presentacion
{
    public partial class FrmTabla : Form
    {
        public int? id; 
        Tabla obTabla = null;
        public FrmTabla(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null ) 
                CargaDatos();
            
        }

        private void CargaDatos()
        {
            using (CrudEntities entities = new CrudEntities()) {
                obTabla = entities.Tabla.Find(id);

                txtCorreo.Text = obTabla.correo;
                txtNombre.Text = obTabla.nombre;
                dtpFecha.Value = obTabla.fecha_nacimiento;
            }
        }
        private void FrmTabla_Load(object sender, EventArgs e)
        {

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (CrudEntities db = new CrudEntities()) 
            { 
                if(id ==null)
                    obTabla = new Tabla();
               

                obTabla.nombre= txtNombre.Text;
                obTabla.correo = txtCorreo.Text;
                obTabla.fecha_nacimiento= dtpFecha.Value;

                if (id == null)
                    db.Tabla.Add(obTabla);
                else { 

                db.Entry(obTabla).State= System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();

                this.Close();
            }
        }
    }
}

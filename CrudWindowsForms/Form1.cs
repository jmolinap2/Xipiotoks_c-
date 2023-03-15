using CrudWindowsForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Refrescar();

        }
        #region HELPER
        private void Refrescar () {
            using (CrudEntities db = new CrudEntities())
            {
                var lst = from d in db.Tabla select d;

                dataGridView1.DataSource = lst.ToList();

            }

        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }

        }
        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Presentacion.FrmTabla ofrmTabla= new Presentacion.FrmTabla();
            ofrmTabla.ShowDialog();

            Refrescar();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                Presentacion.FrmTabla oFrmTabla = new Presentacion.FrmTabla(id);
                oFrmTabla.ShowDialog();

                Refrescar();
             }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                using (CrudEntities db = new CrudEntities())
                {
                    Tabla oTabla = db.Tabla.Find(id);

                    db.Tabla.Remove(oTabla);
                    db.SaveChanges();
                }

                    Refrescar();
            }
        }
        /* ignorar */
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}

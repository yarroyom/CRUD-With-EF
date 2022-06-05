using Sitecore.FakeDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_PROGRA1_FINAL
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|* .jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    pictureBox.Image = Image.FromFile(ofd.FileName);
                    Employee obj = employeeBindingSource.Current as Employee;
                    if (obj != null)
                        obj.ImageUrl = ofd.FileName;
                }
            }
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (ModelContext db = new ModelContext())
            {
                employeeBindingSource.DataSource = db.Emplist.ToList();

            }
            metroPanel1.Enabled = false;
            Employee obj = employeeBindingSource.Current as Employee;
            if (obj != null)
                pictureBox.Image = Image.FromFile(obj.ImageUrl);

        }

        private void btnAgragar_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            metroPanel1.Enabled = true;
            employeeBindingSource.Add(new Employee());
            employeeBindingSource.MoveLast();
            txtName.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            metroPanel1.Enabled = true;
            txtName.Focus();
            Employee OBJ = employeeBindingSource.Current as Employee;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            metroPanel1.Enabled = false;
            employeeBindingSource.ResetBindings(false);
            Form1_Load(sender, e);
        }

        private void metroGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Employee obj = employeeBindingSource.Current as Employee;
            if (obj != null)
                pictureBox.Image = Image.FromFile(obj.ImageUrl);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(MetroFramework.MetroMessageBox.Show(this,"Estas seguro de querer eliminar este registro","Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (ModelContext db = new ModelContext())
                {
                    Employee obj = employeeBindingSource.Current as Employee;
                    if (obj != null)
                    {
                        if (db.Entry<Employee>(obj).State == EntityState.Detached)
                            db.Set<Employee>().Attach(obj);
                        db.Entry<Employee>(obj).State = EntityState.Deleted;
                        db.SaveChanges();
                        MetroFramework.MetroMessageBox.Show(this, "Eliminada con Exito");
                        employeeBindingSource.RemoveCurrent();
                        metroPanel1.Enabled=false;
                        pictureBox.Image = null;
                    }
                }

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {


            using (ModelContext db = new ModelContext())
            {
                Employee obj = employeeBindingSource.Current as Employee;
                if(obj != null)
                {
                    if  (db.Entry<Employee>(obj).State == EntityState.Detached)
                        db.Set<Employee>().Attach(obj);
                    if (obj.EmpID == 0)
                        db.Entry<Employee>(obj).State=EntityState.Added;
                    else
                        db.Entry<Employee>(obj).State=EntityState.Modified;
                    db.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, " Guardado con Exito");
                    metroGrid.Refresh();
                    metroPanel1.Enabled=false;
                }

            }
        }

        
    }
}

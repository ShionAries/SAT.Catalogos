using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Tester {
    public partial class OriginsForm : Form {
        #region declaraciones
        private int previousIndex;
        private bool sortDirection;
        private OriginService service;
        private Waiting4Form waiting;
        #endregion

        public OriginsForm(OriginService originService) {
            InitializeComponent();
            this.service = originService;
        }

        private void OriginsForm_Load(object sender, EventArgs e) {
            this.GridData.AllowUserToAddRows = false;
            this.GridData.AllowUserToDeleteRows = false;
            this.GridData.AllowUserToResizeRows = false;
            this.GridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GridData.ColumnHeaderMouseClick += this.GridData_ColumnHeaderMouseClick;

            this.Agregar.Click += this.Agregar_Click;
            this.Editar.Click += this.Editar_Click;
            this.Delete.Click += this.Delete_Click;
            this.Guardar.Click += this.Guardar_Click;

            if (this.service.DataSource == null) {
                this.waiting = new Waiting4Form(() => {
                    this.service.GetAll();
                }, "Cargando datos ...") {
                    Text = ""
                };
                this.waiting.ShowDialog(this);
            }
            
            this.GridData.DataSource = this.service.DataSource;
        }

        private void Agregar_Click(object sender, EventArgs e) {
            
        }

        private void Editar_Click(object sender, EventArgs e) {
            if (this.GridData.CurrentRow != null) {
                var seleccionado = this.GridData.CurrentRow.DataBoundItem as IOrigin;
                if (seleccionado != null) {
                    var editar = new OriginForm(this.service, seleccionado);
                    editar.ShowDialog(this);
                }
            }
        }

        private void Delete_Click(object sender, EventArgs eventArgs) {

        }

        private void Guardar_Click(object sender, EventArgs e) {
            this.service.SaveChanges();
        }

        #region acciones del grid
        private void GridData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button != MouseButtons.Right) {
                if (e.ColumnIndex == this.previousIndex) {
                    this.sortDirection = !this.sortDirection;
                }
                this.GridData.DataSource = this.SortData((List<IOrigin>)this.GridData.DataSource, this.GridData.Columns[e.ColumnIndex].Name, this.sortDirection);
                this.previousIndex = e.ColumnIndex;
            }
        }

        public List<IOrigin> SortData(List<IOrigin> data, string sCampo, bool bAscendente) {
            List<IOrigin> response;
            try {
                if (!sCampo.Contains("URL")) {
                    response = (bAscendente ? (
                        from x in data
                        orderby x.GetType().GetProperty(sCampo).GetValue(x)
                        select x).ToList<IOrigin>() : (
                        from x in data
                        orderby x.GetType().GetProperty(sCampo).GetValue(x) descending
                        select x).ToList<IOrigin>());
                } else {
                    response = data;
                }
            } catch (Exception exception) {
                throw exception;
            }
            return response;
        }
        #endregion
    }
}

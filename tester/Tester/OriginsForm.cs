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
        private OriginService scrapService;
        private Waiting4Form waiting;
        #endregion

        public OriginsForm(OriginService originService) {
            InitializeComponent();
            this.scrapService = originService;
        }

        private void OriginsForm_Load(object sender, EventArgs e) {
            this.GridData.ReadOnly = true;
            this.GridData.AllowUserToAddRows = false;
            this.GridData.AllowUserToDeleteRows = false;
            this.GridData.AllowUserToResizeRows = false;
            this.GridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GridData.ColumnHeaderMouseClick += this.GridData_ColumnHeaderMouseClick;
            this.Agregar.Click += this.Agregar_Click;
            this.Editar.Click += this.Editar_Click;
            this.Delete.Click += this.Delete_Click;
            this.Guardar.Click += this.Guardar_Click;


            if (this.scrapService.DataSource == null) {
                this.waiting = new Waiting4Form(() => {
                    this.scrapService.GetAll();
                }, "Cargando datos ...") {
                    Text = ""
                };
                this.waiting.ShowDialog(this);
            }
            var origen = this.scrapService.DataSource.FirstOrDefault();
            origen.LastVersion = System.DateTime.Now;
            this.scrapService.Add(origen);
            this.GridData.DataSource = this.scrapService.DataSource;
        }

        private void Agregar_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void Editar_Click(object sender, EventArgs e) {
            if (this.GridData.CurrentRow != null) {
                var seleccionado = this.GridData.CurrentRow.DataBoundItem as IOrigin;
                if (seleccionado != null) {
                    var editar = new OriginForm(this.scrapService, seleccionado);
                    editar.ShowDialog(this);
                }
            }
        }

        private void Delete_Click(object sender, EventArgs eventArgs) {

        }

        private void Guardar_Click(object sender, EventArgs e) {
            this.scrapService.SaveChanges();
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

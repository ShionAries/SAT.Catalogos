using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Builder;

namespace Tester.Forms {
    public partial class OriginsForm : Form {
        #region declaraciones
        private int previousIndex;
        private bool sortDirection;
        private IOriginService Service;
        private Waiting4Form waiting;
        #endregion

        public OriginsForm(IOriginService originService) {
            InitializeComponent();
            this.Service = originService;
        }

        private void OriginsForm_Load(object sender, EventArgs e) {
            this.GridData.AllowUserToAddRows = false;
            this.GridData.AllowUserToDeleteRows = false;
            this.GridData.AllowUserToResizeRows = false;
            this.GridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GridData.ColumnHeaderMouseClick += this.GridData_ColumnHeaderMouseClick;

            this.Agregar.Click += this.Agregar_Click;
            this.Recargar.Click += this.Editar_Click;
            this.Delete.Click += this.Delete_Click;
            this.Guardar.Click += this.Guardar_Click;
            this.Verificar.Click += TControl_Verificar_Click;
            this.Copiar.Click += (s, ev) => {
                if (this.GridData.CurrentRow != null) {
                    Clipboard.SetText(this.GridData.CurrentRow.Cells[this.GridData.CurrentCell.ColumnIndex].Value.ToString());
                }
            };

            this.Recargar.PerformClick();
        }

        private void TControl_Verificar_Click(object sender, EventArgs e) {
            if (this.GridData.CurrentRow != null) {
                var selected = this.GridData.CurrentRow.DataBoundItem as IOrigin;
                if (selected != null) {
                    var builder = ScrapingBuilder.Create().Origin(selected).Review();
                    if (selected.Status == Jaeger.SAT.Catalogos.Scraping.ValueObjects.StatusEnum.NotUpdated) {
                        if (MessageBox.Show(this, "Existe una actualización disponible, ¿Quieres actualizar todos los catálogos?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                            this.waiting = new Waiting4Form(() => {
                                var download = builder.Upgrader();
                                IUpdateRepositoryBuilder update = new UpdateRepositoryBuilder();
                                update.Origin(selected).Import();
                            }, "Cargando datos ...") {
                                Text = ""
                            };
                            this.waiting.ShowDialog(this);
                        }
                    } else if (selected.Status == Jaeger.SAT.Catalogos.Scraping.ValueObjects.StatusEnum.UpToDate) {
                        MessageBox.Show(this, "El origen está actualizado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else if (selected.Status == Jaeger.SAT.Catalogos.Scraping.ValueObjects.StatusEnum.NotFound) {
                        MessageBox.Show(this, "No se pudo localizar el origen.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        MessageBox.Show(this, "Origen no válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Agregar_Click(object sender, EventArgs e) {

        }

        private void Editar_Click(object sender, EventArgs e) {

            this.waiting = new Waiting4Form(() => {
                this.Service.GetAll();
            }, "Cargando datos ...") {
                Text = ""
            };
            this.waiting.ShowDialog(this);


            this.GridData.DataSource = this.Service.DataSource;
            if (this.Service.IsDefault) {
                MessageBox.Show(this, "No se encontro archivo de control de origenes, se obtuvo la información por default.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Delete_Click(object sender, EventArgs eventArgs) {

        }

        private void Guardar_Click(object sender, EventArgs e) {
            this.Service.Save();
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

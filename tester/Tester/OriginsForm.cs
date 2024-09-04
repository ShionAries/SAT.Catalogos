using System;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Tester {
    public partial class OriginsForm : Form {
        private OriginService _ScrapService;
        private Waiting4Form _Waiting;

        public OriginsForm(OriginService originService) {
            InitializeComponent();
            this._ScrapService = originService;
        }

        private void OriginsForm_Load(object sender, EventArgs e) {
            this.GridData.ReadOnly = true;
            this.GridData.AllowUserToAddRows = false;
            this.GridData.AllowUserToDeleteRows = false;
            this.GridData.AllowUserToResizeRows = false;
            this.GridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Editar.Click += this.Editar_Click;
            this.Guardar.Click += this.Guardar_Click;


            if (this._ScrapService.DataSource == null) {
                this._Waiting = new Waiting4Form(() => {
                    this._ScrapService.GetAll();
                }, "Cargando datos ...") {
                    Text = ""
                };
                this._Waiting.ShowDialog(this);
            }
            this.GridData.DataSource = this._ScrapService.DataSource;
        }

        private void Editar_Click(object sender, EventArgs e) {
            if (this.GridData.CurrentRow != null) {
                var seleccionado = this.GridData.CurrentRow.DataBoundItem as IOrigin;
                if (seleccionado != null) {
                    var editar = new OriginForm(this._ScrapService, seleccionado);
                    editar.ShowDialog(this);
                }
            }
        }

        private void Guardar_Click(object sender, EventArgs e) {
            this._ScrapService.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos.Scraping.Helpers;

namespace Tester {
    public partial class OriginsForm : Form {
        private OriginService _ScrapService;
        private Waiting4Form _Waiting;

        public OriginsForm(OriginService originService) {
            InitializeComponent();
            this._ScrapService = originService;
        }

        private void OriginsForm_Load(object sender, EventArgs e) {

            this.Guardar.Click += Guardar_Click;


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

        private void Guardar_Click(object sender, EventArgs e) {
            this._ScrapService.SaveChanges();
        }
    }
}

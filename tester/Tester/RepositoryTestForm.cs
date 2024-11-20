using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Tester {
    public partial class RepositoryTestForm : Form {
        private readonly Assembly assembly = Assembly.Load("Jaeger.SAT.Catalogos");
        private IRepositoryGeneric GeneralRepository;
        public RepositoryTestForm() {
            InitializeComponent();
        }

        private void RepositoryTestForm_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
            this.GridData.ScrollBars = ScrollBars.Both;
            this.GridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            Type interfaceType = typeof(IRepositoryGeneric);
            var repositorios = assembly.GetTypes()
                .Where(it => it.IsClass)
                .Where(it => it.Namespace != null)
                .Where(it => it.Namespace.Contains("Jaeger.SAT.Catalogos.Repository"))
                .Where(it=> it.GetInterfaces().Contains(interfaceType))
                .OrderBy(it => it.Name).ToList();

            this.cboRepositorio.DataSource = repositorios;
            this.cboRepositorio.DisplayMember = "Name";
            this.cboRepositorio.ValueMember = "FullName";
        }

        private void Cargar_Click(object sender, EventArgs e) {
            var seleccionado = this.cboRepositorio.SelectedItem as Type;
            if (seleccionado != null) {
                this.GeneralRepository = null;
                this.GridData.DataSource = null;
                try {
                    this.GeneralRepository = Activator.CreateInstance(seleccionado) as IRepositoryGeneric;
                } catch (Exception ex) {
                    MessageBox.Show(this, "Repositorio no válido\r\n" + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var espera = new Waiting4Form(() => {
                    this.RepositorioLoad();
                }, "Cargando repositorio.", true);
                espera.ShowDialog(this);
            } else {
                MessageBox.Show(this, "Repositorio no válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RepositorioLoad() {
            this.GridData.Columns.Clear();
            this.GridData.AutoGenerateColumns = true;
            
            if (this.GeneralRepository != null) {
                this.GeneralRepository.Load();
                this.GridData.DataSource = this.GeneralRepository;
                this.GridData.DataMember = "Items";
                this.DescripcionLabel.Text = "Descripción: " + this.GeneralRepository.Description;
                this.label1.Text = "Fecha Actulización: " + this.GeneralRepository.LastUpdate.Value.ToString("dd MMMM yyyy");
            }
        }
    }
}

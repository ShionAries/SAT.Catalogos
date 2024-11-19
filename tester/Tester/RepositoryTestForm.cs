using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Tester {
    public partial class RepositoryTestForm : Form {
        private Assembly assembly = Assembly.Load("Jaeger.SAT.Catalogos");
        private IGeneralRepository GeneralRepository;
        public RepositoryTestForm() {
            InitializeComponent();
        }

        private void RepositoryTestForm_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
            var clases = assembly.GetTypes().Where(it => it.IsClass).Where(it => it.Namespace != null).Where(it => it.Namespace.Contains("Jaeger.SAT.Catalogos.Repository")).OrderBy(it => it.Name).ToList();
            var repositorios = new List<Type>();
            // Obtener el tipo de la interfaz
            Type interfaceType = typeof(IGeneralRepository);
            foreach (Type type in clases) {
                if (type.GetInterfaces().Contains(interfaceType))
                    repositorios.Add(type);
            }
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
                    this.GeneralRepository = Activator.CreateInstance(seleccionado) as IGeneralRepository;
                } catch (Exception ex) {
                    MessageBox.Show(this, "Repositorio no válido\r\n" + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var espera = new Waiting4Form(() => {
                    this.RepositorioLoad();
                }, "Cargando repositorio.", false);
                espera.ShowDialog(this);
            } else {
                MessageBox.Show(this, "Repositorio no válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RepositorioLoad() {
            this.GridData.Columns.Clear();
            
            if (this.GeneralRepository != null) {
                this.GeneralRepository.Load();
                this.GridData.DataSource = this.GeneralRepository;
                this.GridData.DataMember = "Items";
                this.label1.Text = "Versión:" + this.GeneralRepository.Version + "\r\n" + this.GeneralRepository.Title;
            }
        }
    }
}

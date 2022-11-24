using System;
using System.Windows.Forms;
using CapaNegocio;

namespace Presentacion
{
    public partial class vetanaSolicitud : Form
    {
        public vetanaSolicitud()
        {
            InitializeComponent();
        }
        
        // Al cargarce la ventana llama los metodos para llenar los combos
        private void Form1_Load(object sender, EventArgs e)
        {
            FillDepartaments();
            FillCategories();
            FillPriority(); 
        }

        // Instancia de la capa Negocio
        NegocioCN negocioCN;

        // Llena el combo departamento
        private void FillDepartaments()
        {
            try
            {
                negocioCN = new NegocioCN();
                cbDepartamento.Items.Add("- Seleccionar -");
                foreach (string value in negocioCN.GetDepartment())
                {
                    cbDepartamento.Items.Add(value);
                }
                cbDepartamento.SelectedIndex = 0;

            }catch(Exception ex)
            {
                MessageBox.Show("Error al cargar la info: " + ex.Message, "Error departamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Llena el combo cateoria
        private void FillCategories()
        {
            try
            {
                negocioCN = new NegocioCN();
                cbCategoria.Items.Add("- Seleccionar -");
                foreach (string value in negocioCN.GetCategories())
                {
                    cbCategoria.Items.Add(value);
                }
                cbCategoria.SelectedIndex = 0;

            }catch(Exception ex)
            {
                MessageBox.Show("Error al cargar la info: " + ex.Message, "Error Categoria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //Para llenar el combo de prioridades
        private void FillPriority()
        {
            try
            {
                negocioCN = new NegocioCN();
                cbPrioridad.Items.Add("- Seleccionar -");
                foreach (string value in negocioCN.GetPriorities())
                {
                    cbPrioridad.Items.Add(value);
                }
                cbPrioridad.SelectedIndex = 0;

            }catch(Exception ex)
            {
                MessageBox.Show("Error al cargar la info: " + ex.Message, "Error Prioridades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Al seleccionar un item en el combo departamento se cargaran las areas en el combo areas
        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            negocioCN = new NegocioCN();
            if (!cbDepartamento.GetItemText(cbDepartamento.SelectedItem).ToString().Equals("- Seleccionar -"))
            {
                try
                {
                    int indice = (int) cbDepartamento.SelectedIndex;
                    cbArea.DataSource = negocioCN.GetAreas(indice);
                
                }catch(Exception ex)
                {
                    MessageBox.Show("Error al cargar la info: " + ex.Message, "Error Areas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Para validar los campos
        private bool ValidateField(string nom, string ape, string are, string ext, string cat, string com,string pri)
        {
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(ape) || string.IsNullOrEmpty(ext))
            {
                MessageBox.Show("El campo de nombre, apellido y extension es requerido", "Capos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (are.Equals(" ") || cat.Equals("- Seleccionar -") || pri.Equals("- Seleccionar -") )
            {
                MessageBox.Show("Seleccionar las opciones validas", "Opciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Al presionar el boton enviar se ejecuta este codigo y se envia la solicitud si todo esta correcto
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            negocioCN = new NegocioCN();

            string categoria = cbCategoria.GetItemText(cbCategoria.SelectedItem).ToString();
            //string departamento = cbDepartamento.GetItemText(cbDepartamento.SelectedItem).ToString();
            string are = cbArea.GetItemText(cbArea.SelectedItem).ToString();
            string prioridad = cbPrioridad.GetItemText(cbPrioridad.SelectedItem).ToString();
            
            if(ValidateField(tbNombre.Text, tbApellido.Text, are, tbExt.Text, categoria, tbComentario.Text, prioridad))
            {
                string nombre = tbNombre.Text.Trim() + " " + tbApellido.Text.Trim();
                int idCategory = (int)cbCategoria.SelectedIndex;
                string area = cbArea.SelectedItem.ToString();
                int idPrioridad = (int)cbPrioridad.SelectedIndex;

                try
                {
                    negocioCN.SetRequests(nombre, area, tbExt.Text, idCategory, tbComentario.Text, idPrioridad);

                    MessageBox.Show("Solicitud enviada con exito!", "Solicidud enviada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbNombre.Clear();
                    tbApellido.Clear();
                    tbExt.Clear();
                    tbComentario.Clear();
                    cbDepartamento.SelectedIndex = 0;
                    cbArea.DataSource = null;
                    cbArea.Items.Clear();
                    cbCategoria.SelectedIndex = 0;
                    cbPrioridad.SelectedIndex = 0;
                }   
                catch(Exception ex)
                {
                    MessageBox.Show("Error al enviar solicitud: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

      
    }
}

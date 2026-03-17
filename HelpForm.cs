using System;
using System.Windows.Forms;
using System.Drawing;

namespace ImageListDecoder
{
    public class HelpForm : Form
    {
        public HelpForm()
        {
            this.Text = "Guía: Cómo usar Base64 en Visual Studio";
            this.Size = new Size(650, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            TabControl tabs = new TabControl();
            tabs.Dock = DockStyle.Fill;

            // Pestaña 1: ImageList (Colecciones)
            TabPage tab1 = new TabPage("Colección (ImageList)");
            TextBox txtImageList = CreateReadOnlyTextBox();
            txtImageList.Text = "PARA CARGAR VARIAS IMÁGENES A LA VEZ (ImageListStreamer)\r\n" +
                                "========================================================\r\n\r\n" +
                                "Si tienes un Base64 largo (como el que empieza por 'AAEAAAD...'),\r\n" +
                                "es una colección completa. Úsala así:\r\n\r\n" +
                                "1. En tu Form de VS, añade un componente 'ImageList' (ej: imageList1).\r\n" +
                                "2. En tu código, añade este método:\r\n\r\n" +
                                "public void CargarIconos(string base64Coleccion)\r\n" +
                                "{\r\n" +
                                "    byte[] data = Convert.FromBase64String(base64Coleccion);\r\n" +
                                "    var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();\r\n" +
                                "    using (var ms = new System.IO.MemoryStream(data))\r\n" +
                                "    {\r\n" +
                                "        // Esto carga todos los iconos de golpe\r\n" +
                                "        imageList1.ImageStream = (ImageListStreamer)bf.Deserialize(ms);\r\n" +
                                "    }\r\n" +
                                "}\r\n\r\n" +
                                "TIP: Es ideal para botones de barras de herramientas o menús.";
            tab1.Controls.Add(txtImageList);

            // Pestaña 2: Imagen Simple
            TabPage tab2 = new TabPage("Imagen Individual");
            TextBox txtSimple = CreateReadOnlyTextBox();
            txtSimple.Text = "PARA CARGAR UNA IMAGEN INDIVIDUAL\r\n" +
                             "=================================\r\n\r\n" +
                             "Si el Base64 es una imagen normal (PNG/JPG):\r\n\r\n" +
                             "public Image Base64ToImage(string base64String)\r\n" +
                             "{\r\n" +
                             "    byte[] imageBytes = Convert.FromBase64String(base64String);\r\n" +
                             "    using (var ms = new System.IO.MemoryStream(imageBytes))\r\n" +
                             "    {\r\n" +
                             "        return Image.FromStream(ms);\r\n" +
                             "    }\r\n" +
                             "}\r\n\r\n" +
                             "// Uso:\r\n" +
                             "pictureBox1.Image = Base64ToImage(tuCodigoBase64);";
            tab2.Controls.Add(txtSimple);

            tabs.TabPages.Add(tab1);
            tabs.TabPages.Add(tab2);

            Button btnClose = new Button();
            btnClose.Text = "Entendido";
            btnClose.Dock = DockStyle.Bottom;
            btnClose.Height = 40;
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(tabs);
            this.Controls.Add(btnClose);
        }

        private TextBox CreateReadOnlyTextBox()
        {
            return new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 9),
                BackColor = Color.White
            };
        }
    }
}

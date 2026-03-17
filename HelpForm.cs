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
            this.Size = new Size(650, 550);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            TabControl tabs = new TabControl();
            tabs.Dock = DockStyle.Fill;

            // Pestaña 1: ImageList
            TabPage tab1 = new TabPage("Colección (ImageList)");
            TextBox txtImageList = CreateReadOnlyTextBox();
            txtImageList.Text = "PARA CARGAR VARIAS IMÁGENES A LA VEZ\r\n" +
                                "====================================\r\n\r\n" +
                                "byte[] data = Convert.FromBase64String(base64Coleccion);\r\n" +
                                "var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();\r\n" +
                                "using (var ms = new System.IO.MemoryStream(data))\r\n" +
                                "{\r\n" +
                                "    imageList1.ImageStream = (ImageListStreamer)bf.Deserialize(ms);\r\n" +
                                "}";
            tab1.Controls.Add(txtImageList);

            // Pestaña 2: Imagen Simple
            TabPage tab2 = new TabPage("Imagen Individual");
            TextBox txtSimple = CreateReadOnlyTextBox();
            txtSimple.Text = "PARA CARGAR UNA IMAGEN (PNG/JPG)\r\n" +
                             "================================\r\n\r\n" +
                             "byte[] imageBytes = Convert.FromBase64String(base64String);\r\n" +
                             "using (var ms = new MemoryStream(imageBytes))\r\n" +
                             "{\r\n" +
                             "    pictureBox1.Image = Image.FromStream(ms);\r\n" +
                             "}";
            tab2.Controls.Add(txtSimple);

            // Pestaña 3: Icono del Formulario
            TabPage tab3 = new TabPage("Icono del Form");
            TextBox txtIcon = CreateReadOnlyTextBox();
            txtIcon.Text = "PARA PONER UN PNG COMO ICONO DE VENTANA\r\n" +
                           "=======================================\r\n\r\n" +
                           "// 1. Convertir base64 a bytes\r\n" +
                           "byte[] bytes = Convert.FromBase64String(base64Png);\r\n\r\n" +
                           "using (var ms = new System.IO.MemoryStream(bytes))\r\n" +
                           "{\r\n" +
                           "    using (Bitmap bmp = new Bitmap(ms))\r\n" +
                           "    {\r\n" +
                           "        // 2. Obtener handle de icono y asignarlo\r\n" +
                           "        this.Icon = Icon.FromHandle(bmp.GetHicon());\r\n" +
                           "    }\r\n" +
                           "}\r\n\r\n" +
                           "NOTA: Para que el archivo .exe tenga el icono en Windows,\r\n" +
                           "debes configurarlo en: Proyecto -> Propiedades -> Aplicación -> Icono.";
            tab3.Controls.Add(txtIcon);

            tabs.TabPages.Add(tab1);
            tabs.TabPages.Add(tab2);
            tabs.TabPages.Add(tab3);

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

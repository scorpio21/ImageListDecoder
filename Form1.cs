using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace ImageListDecoder
{
    public partial class Form1 : Form
    {
        private ImageList _imageList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _imageList = new ImageList();
            _imageList.ColorDepth = ColorDepth.Depth32Bit;
            _imageList.ImageSize = new Size(32, 32);
            lvImages.LargeImageList = _imageList;

            picImage.AllowDrop = true;
            picImage.DragEnter += PicImage_DragEnter;
            picImage.DragDrop += PicImage_DragDrop;
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            try
            {
                string base64 = txtBase64.Text;

                if (string.IsNullOrWhiteSpace(base64))
                {
                    MessageBox.Show("No hay texto Base64 para decodificar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // NUEVO: Detectar si es un fragmento de XML (.resx)
                if (base64.Contains("<value>"))
                {
                    var match = Regex.Match(base64, @"<value>([\s\S]*?)</value>");
                    if (match.Success)
                    {
                        base64 = match.Groups[1].Value.Trim();
                        Logger.Log("Se detectó formato XML/ResX. Extrayendo contenido de <value>.");
                    }
                }

                // Limpiar encabezados de Data URI
                if (base64.Contains(",")) 
                    base64 = base64.Substring(base64.IndexOf(",") + 1);

                // Limpiar TODOS los espacios en blanco, saltos de línea y tabulaciones de forma agresiva
                base64 = Regex.Replace(base64, @"\s+", "");

                // Asegurar que la longitud sea múltiplo de 4 para evitar FormatException
                while (base64.Length % 4 != 0)
                    base64 += "=";

                byte[] bytes = Convert.FromBase64String(base64);
                
                string hex = BitConverter.ToString(bytes, 0, Math.Min(bytes.Length, 16));
                Logger.Log($"Intento de decodificación. Tamaño: {bytes.Length} bytes. Primeros bytes: {hex}");

                _imageList.Images.Clear();
                lvImages.Items.Clear();

                try 
                {
                    // Intento 1: ¿Es un ImageListStreamer de .NET? (BinaryFormatter)
#pragma warning disable SYSLIB0011, CS0618
                    var formatter = new BinaryFormatter();
                    using (var ms = new MemoryStream(bytes))
                    {
                        var streamer = (ImageListStreamer)formatter.Deserialize(ms);
                        using (var tempList = new ImageList())
                        {
                            tempList.ImageStream = streamer;
                            for (int i = 0; i < tempList.Images.Count; i++)
                            {
                                Image img = (Image)tempList.Images[i].Clone();
                                _imageList.Images.Add(img);
                                lvImages.Items.Add(new ListViewItem("Img " + i, i));
                            }
                        }
                        MessageBox.Show($"Decodificadas {_imageList.Images.Count} imágenes de un ImageListStreamer.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
#pragma warning restore SYSLIB0011, CS0618
                }
                catch 
                {
                    // Intento 2: ¿Es una imagen estándar o un icono (.ico)?
                    try 
                    {
                        using (var ms = new MemoryStream(bytes))
                        {
                            // Liberar imagen anterior si existe
                            if (picImage.Image != null) picImage.Image.Dispose();

                            // Intentar cargar como Icono primero si tiene cabecera de icono
                            if (bytes.Length > 4 && bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 1 && bytes[3] == 0)
                            {
                                using (Icon icon = new Icon(ms))
                                {
                                    Image bmp = icon.ToBitmap();
                                    _imageList.Images.Add(bmp);
                                    lvImages.Items.Add(new ListViewItem("Icono (.ico)", 0));
                                    picImage.Image = (Image)bmp.Clone();
                                }
                            }
                            else
                            {
                                // Carga de imagen estándar (PNG, JPG, etc.)
                                Image img = Image.FromStream(ms);
                                _imageList.Images.Add(img);
                                lvImages.Items.Add(new ListViewItem("Imagen", 0));
                                picImage.Image = (Image)img.Clone();
                            }
                            
                            MessageBox.Show("Se detectó y cargó una imagen/icono individual.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception exImg)
                    {
                        Logger.Log("Fallo total al decodificar.", exImg);
                        throw new Exception("El código Base64 no es válido ni como ImageList ni como imagen común.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Error en btnDecode_Click", ex);
                MessageBox.Show("Error al decodificar:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            try
            {
                if (picImage.Image == null)
                {
                    MessageBox.Show("No hay imagen cargada en el PictureBox.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Usar el tamaño original de la imagen
                int w = picImage.Image.Width;
                int h = picImage.Image.Height;

                using (var il = new ImageList())
                {
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.ImageSize = new Size(Math.Min(w, 256), Math.Min(h, 256));
                    il.Images.Add((Image)picImage.Image.Clone());

                    var streamer = (ImageListStreamer)il.ImageStream;
#pragma warning disable SYSLIB0011, CS0618
                    var formatter = new BinaryFormatter();
                    byte[] bytes;

                    using (var ms = new MemoryStream())
                    {
                        formatter.Serialize(ms, streamer);
                        bytes = ms.ToArray();
                    }
#pragma warning restore SYSLIB0011, CS0618

                    txtBase64.Text = Convert.ToBase64String(bytes);

                    MessageBox.Show("Imagen codificada como ImageListStreamer (.resx).\r\nEste formato es específico para controles ImageList de .NET.",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Error al codificar como ImageList", ex);
                MessageBox.Show("Error al codificar:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEncodeStandard_Click(object sender, EventArgs e)
        {
            try
            {
                if (picImage.Image == null)
                {
                    MessageBox.Show("No hay imagen cargada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var ms = new MemoryStream())
                {
                    // Guardar como PNG para mantener calidad y transparencia
                    picImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] bytes = ms.ToArray();
                    
                    // Añadimos el prefijo Data URI para que sea reconocido en webs y navegadores
                    txtBase64.Text = "data:image/png;base64," + Convert.ToBase64String(bytes);

                    MessageBox.Show("Imagen codificada como PNG estándar con cabecera web.\r\nAhora puedes pegarlo directamente en cualquier navegador o herramienta web.",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Error al codificar como imagen estándar", ex);
                MessageBox.Show("Error al codificar:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBase64.Clear();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBase64.Text))
            {
                Clipboard.SetText(txtBase64.Text);
                MessageBox.Show("Texto copiado al portapapeles.", "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay texto para copiar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comoUsarBase64EnVSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var helpForm = new HelpForm())
            {
                helpForm.ShowDialog();
            }
        }

        private void PicImage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void PicImage_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var archivos = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (archivos != null && archivos.Length > 0)
                    {
                        string ruta = archivos[0];
                        Image img = Image.FromFile(ruta);
                        picImage.Image = img;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar imagen:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

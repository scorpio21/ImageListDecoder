namespace ImageListDecoder
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtBase64;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Button btnEncodeStandard;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ListView lvImages;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblBase64;
        private System.Windows.Forms.Label lblDragDrop;
        private System.Windows.Forms.Label lblDecoded;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comoUsarBase64EnVSToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtBase64 = new System.Windows.Forms.TextBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnEncode = new System.Windows.Forms.Button();
            this.btnEncodeStandard = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lvImages = new System.Windows.Forms.ListView();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblBase64 = new System.Windows.Forms.Label();
            this.lblDragDrop = new System.Windows.Forms.Label();
            this.lblDecoded = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comoUsarBase64EnVSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.utilidadesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(892, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // utilidadesToolStripMenuItem
            // 
            this.utilidadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comoUsarBase64EnVSToolStripMenuItem});
            this.utilidadesToolStripMenuItem.Name = "utilidadesToolStripMenuItem";
            this.utilidadesToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.utilidadesToolStripMenuItem.Text = "Utilidades";
            // 
            // comoUsarBase64EnVSToolStripMenuItem
            // 
            this.comoUsarBase64EnVSToolStripMenuItem.Name = "comoUsarBase64EnVSToolStripMenuItem";
            this.comoUsarBase64EnVSToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.comoUsarBase64EnVSToolStripMenuItem.Text = "Cómo usar Base64 en Visual Studio";
            this.comoUsarBase64EnVSToolStripMenuItem.Click += new System.EventHandler(this.comoUsarBase64EnVSToolStripMenuItem_Click);
            // 
            // lblBase64
            // 
            this.lblBase64.AutoSize = true;
            this.lblBase64.Location = new System.Drawing.Point(12, 34);
            this.lblBase64.Name = "lblBase64";
            this.lblBase64.Size = new System.Drawing.Size(197, 13);
            this.lblBase64.TabIndex = 5;
            this.lblBase64.Text = "Código Base64 (ImageListStreamer):";
            // 
            // txtBase64
            // 
            this.txtBase64.Location = new System.Drawing.Point(12, 50);
            this.txtBase64.Multiline = true;
            this.txtBase64.Name = "txtBase64";
            this.txtBase64.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBase64.Size = new System.Drawing.Size(400, 420);
            this.txtBase64.TabIndex = 0;
            this.txtBase64.WordWrap = false;
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(418, 50);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(200, 30);
            this.btnDecode.TabIndex = 1;
            this.btnDecode.Text = "Decodificar Base64 -> Imagenes";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(418, 86);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(200, 30);
            this.btnEncode.TabIndex = 2;
            this.btnEncode.Text = "Codificar como ImageList (.resx)";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // btnEncodeStandard
            // 
            this.btnEncodeStandard.Location = new System.Drawing.Point(418, 122);
            this.btnEncodeStandard.Name = "btnEncodeStandard";
            this.btnEncodeStandard.Size = new System.Drawing.Size(200, 30);
            this.btnEncodeStandard.TabIndex = 10;
            this.btnEncodeStandard.Text = "Codificar como PNG (Web/Simple)";
            this.btnEncodeStandard.UseVisualStyleBackColor = true;
            this.btnEncodeStandard.Click += new System.EventHandler(this.btnEncodeStandard_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 476);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 25);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Limpiar Texto";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(118, 476);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(100, 25);
            this.btnCopy.TabIndex = 11;
            this.btnCopy.Text = "Copiar Texto";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblDecoded
            // 
            this.lblDecoded.AutoSize = true;
            this.lblDecoded.Location = new System.Drawing.Point(418, 160);
            this.lblDecoded.Name = "lblDecoded";
            this.lblDecoded.Size = new System.Drawing.Size(123, 13);
            this.lblDecoded.TabIndex = 7;
            this.lblDecoded.Text = "Imágenes decodificadas:";
            // 
            // lvImages
            // 
            this.lvImages.Location = new System.Drawing.Point(418, 176);
            this.lvImages.Name = "lvImages";
            this.lvImages.Size = new System.Drawing.Size(200, 294);
            this.lvImages.TabIndex = 3;
            this.lvImages.UseCompatibleStateImageBehavior = false;
            this.lvImages.View = System.Windows.Forms.View.LargeIcon;
            // 
            // lblDragDrop
            // 
            this.lblDragDrop.AutoSize = true;
            this.lblDragDrop.Location = new System.Drawing.Point(624, 34);
            this.lblDragDrop.Name = "lblDragDrop";
            this.lblDragDrop.Size = new System.Drawing.Size(161, 13);
            this.lblDragDrop.TabIndex = 6;
            this.lblDragDrop.Text = "Arrastra aquí una imagen (Drag & Drop):";
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(624, 50);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(256, 256);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 4;
            this.picImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 515);
            this.MainMenuStrip = this.menuStrip1;
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnEncodeStandard);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblDecoded);
            this.Controls.Add(this.lblDragDrop);
            this.Controls.Add(this.lblBase64);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.lvImages);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.txtBase64);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "ImageList Base64 Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

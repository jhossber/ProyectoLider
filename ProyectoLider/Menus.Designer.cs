namespace ProyectoLider
{
    partial class Menus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnParticipante = new System.Windows.Forms.Button();
            this.btnDocente = new System.Windows.Forms.Button();
            this.btnEvento = new System.Windows.Forms.Button();
            this.btnCetificado = new System.Windows.Forms.Button();
            this.btnAsigDocEv = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUsuario
            // 
            this.btnUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.Location = new System.Drawing.Point(41, 75);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(148, 59);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.Text = "Usuarios";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnParticipante
            // 
            this.btnParticipante.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParticipante.Location = new System.Drawing.Point(285, 75);
            this.btnParticipante.Name = "btnParticipante";
            this.btnParticipante.Size = new System.Drawing.Size(182, 59);
            this.btnParticipante.TabIndex = 1;
            this.btnParticipante.Text = "Participantes";
            this.btnParticipante.UseVisualStyleBackColor = true;
            this.btnParticipante.Click += new System.EventHandler(this.btnParticipante_Click);
            // 
            // btnDocente
            // 
            this.btnDocente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocente.Location = new System.Drawing.Point(549, 75);
            this.btnDocente.Name = "btnDocente";
            this.btnDocente.Size = new System.Drawing.Size(148, 59);
            this.btnDocente.TabIndex = 2;
            this.btnDocente.Text = "Docentes";
            this.btnDocente.UseVisualStyleBackColor = true;
            this.btnDocente.Click += new System.EventHandler(this.btnDocente_Click);
            // 
            // btnEvento
            // 
            this.btnEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvento.Location = new System.Drawing.Point(41, 209);
            this.btnEvento.Name = "btnEvento";
            this.btnEvento.Size = new System.Drawing.Size(148, 59);
            this.btnEvento.TabIndex = 3;
            this.btnEvento.Text = "Eventos";
            this.btnEvento.UseVisualStyleBackColor = true;
            this.btnEvento.Click += new System.EventHandler(this.btnEvento_Click);
            // 
            // btnCetificado
            // 
            this.btnCetificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCetificado.Location = new System.Drawing.Point(285, 209);
            this.btnCetificado.Name = "btnCetificado";
            this.btnCetificado.Size = new System.Drawing.Size(182, 59);
            this.btnCetificado.TabIndex = 4;
            this.btnCetificado.Text = "Certificaciones";
            this.btnCetificado.UseVisualStyleBackColor = true;
            this.btnCetificado.Click += new System.EventHandler(this.btnCetificado_Click);
            // 
            // btnAsigDocEv
            // 
            this.btnAsigDocEv.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsigDocEv.Location = new System.Drawing.Point(549, 192);
            this.btnAsigDocEv.Name = "btnAsigDocEv";
            this.btnAsigDocEv.Size = new System.Drawing.Size(148, 93);
            this.btnAsigDocEv.TabIndex = 5;
            this.btnAsigDocEv.Text = "Asignacion Docente a Evento";
            this.btnAsigDocEv.UseVisualStyleBackColor = true;
            this.btnAsigDocEv.Click += new System.EventHandler(this.btnAsigDocEv_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(708, 342);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(86, 45);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Menus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 399);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAsigDocEv);
            this.Controls.Add(this.btnCetificado);
            this.Controls.Add(this.btnEvento);
            this.Controls.Add(this.btnDocente);
            this.Controls.Add(this.btnParticipante);
            this.Controls.Add(this.btnUsuario);
            this.Name = "Menus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnParticipante;
        private System.Windows.Forms.Button btnDocente;
        private System.Windows.Forms.Button btnEvento;
        private System.Windows.Forms.Button btnCetificado;
        private System.Windows.Forms.Button btnAsigDocEv;
        private System.Windows.Forms.Button btnSalir;
    }
}
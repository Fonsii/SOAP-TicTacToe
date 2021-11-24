using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace HolaMundo
{
	/// <summary>
	/// Descripción breve de Form1.
	/// </summary>
	public class frmHolaMundo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.Button cmdSaludar;
		private System.Windows.Forms.Button cmdUltimoSaludo;
		private System.Windows.Forms.Label lblNombre;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// private HolaMundo.ECCI_HolaMundo.ECCI_HolaMundo ws; // .NET 2.0
		private HolaMundo.ECCI_TicTacToe.ECCI_TicTacToePortClient ws;

		public frmHolaMundo()
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();

			//
			// TODO: Agregar código de constructor después de llamar a InitializeComponent
			//
			
			ws = new HolaMundo.ECCI_TicTacToe.ECCI_TicTacToePortClient();
			//Esto es con .NET 2.0
			//ws.CookieContainer = new System.Net.CookieContainer();
		}

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador, no se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.cmdSaludar = new System.Windows.Forms.Button();
			this.lblNombre = new System.Windows.Forms.Label();
			this.cmdUltimoSaludo = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(32, 64);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(232, 20);
			this.txtNombre.TabIndex = 0;
			this.txtNombre.Text = "";
			// 
			// cmdSaludar
			// 
			this.cmdSaludar.Location = new System.Drawing.Point(32, 104);
			this.cmdSaludar.Name = "cmdSaludar";
			this.cmdSaludar.TabIndex = 1;
			this.cmdSaludar.Text = "Saludar";
			this.cmdSaludar.Click += new System.EventHandler(this.cmdUltimoSaludo_Click);
			// 
			// frmHolaMundo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 150);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmdSaludar,
																		  this.txtNombre});
			this.Name = "frmHolaMundo";
			this.Text = "Hola Mundo";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Punto de entrada principal de la aplicación.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmHolaMundo());
		}

		private void cmdUltimoSaludo_Click(object sender, System.EventArgs e)
		{
			String Mensaje = ws.doMove(4);
			// MessageBox.Show(Mensaje);
			Console.WriteLine(Mensaje);

			String msg = ws.newFunction("Hey");
			Console.WriteLine(msg);


		}

	}
}

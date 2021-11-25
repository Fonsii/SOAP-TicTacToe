using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace HolaMundo
{
	/// <summary>
	/// Descripci�n breve de Form1.
	/// </summary>
	public class frmHolaMundo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.Button cmdSaludar;
		private System.Windows.Forms.Button cmdUltimoSaludo;
		private System.Windows.Forms.Label lblNombre;
		/// <summary>
		/// Variable del dise�ador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// private HolaMundo.ECCI_HolaMundo.ECCI_HolaMundo ws; // .NET 2.0
		private TicTacToeProxy proxy;

		public frmHolaMundo()
		{
			//
			// Necesario para admitir el Dise�ador de Windows Forms
			//
			InitializeComponent();

			//
			// TODO: Agregar c�digo de constructor despu�s de llamar a InitializeComponent
			//
			proxy = new TicTacToeProxy();
			//Esto es con .NET 2.0
			//ws.CookieContainer = new System.Net.CookieContainer();
		}

		/// <summary>
		/// Limpiar los recursos que se est�n utilizando.
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
		/// M�todo necesario para admitir el Dise�ador, no se puede modificar
		/// el contenido del m�todo con el editor de c�digo.
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
		/// Punto de entrada principal de la aplicaci�n.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmHolaMundo());
		}

		private void cmdUltimoSaludo_Click(object sender, System.EventArgs e)
		{
			String Mensaje = proxy.DoMove(4);
			Console.WriteLine(Mensaje);
		}

	}
}

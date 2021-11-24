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
		private System.Windows.Forms.Button cmdSaludar;
		private System.Windows.Forms.Button cmdUltimoSaludo;
		private System.Windows.Forms.Label lblNombre;

		private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
		/// <summary>
		/// Variable del dise�ador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private FlowLayoutPanel flowLayoutPanel1;

        // private HolaMundo.ECCI_HolaMundo.ECCI_HolaMundo ws; // .NET 2.0
        private HolaMundo.ECCI_TicTacToe.ECCI_TicTacToePortClient ws;

		public frmHolaMundo()
		{
			//
			// Necesario para admitir el Dise�ador de Windows Forms
			//
			InitializeComponent();

			// TODO: Agregar c�digo de constructor despu�s de llamar a InitializeComponent
			ws = new HolaMundo.ECCI_TicTacToe.ECCI_TicTacToePortClient();
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
            this.cmdSaludar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // cmdSaludar
            // 
            this.cmdSaludar.Location = new System.Drawing.Point(33, 403);
            this.cmdSaludar.Name = "cmdSaludar";
            this.cmdSaludar.Size = new System.Drawing.Size(114, 32);
            this.cmdSaludar.TabIndex = 1;
            this.cmdSaludar.Text = "Saludar";
            this.cmdSaludar.Click += new System.EventHandler(this.cmdUltimoSaludo_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(33, 22);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(619, 362);
            this.flowLayoutPanel1.TabIndex = 2;
			this.buttonArrayCreator();
            // 
            // frmHolaMundo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(692, 447);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.cmdSaludar);
            this.Name = "frmHolaMundo";
            this.Text = "Tic-Tac-Toe";
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

		/// <summary>
		/// Crea los botones para las 9 posiciones del Tic-Tac-Toe.
		/// </summary>
		public void buttonArrayCreator() 
        {
            for (int i = 0; i < 9; ++i) {
				System.Windows.Forms.Button button = new System.Windows.Forms.Button();
				button.Name = "button" + i;
				button.Size = new System.Drawing.Size(150, 100);
				button.Text = "Jugar aqu�";
				button.Click += new System.EventHandler(this.Button_Click);
				flowLayoutPanel1.Controls.Add(button);
            }
        }

		private void cmdUltimoSaludo_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Funcionalidad en progreso");
		}

		/// <summary>
		/// Trigger de los botones del grid del juego.
		/// <param name="sender"> El que llam� el trigger. </param>
		/// <param name="e"> Argumentos que envia el sender. </param>
		/// </summary>
		private void Button_Click(object sender, EventArgs e)
        {
			var button = (Button)sender;
			int position = 0;
			Int32.TryParse(button.Name.Replace("button", ""), out position);
			String Mensaje = ws.doMove(position);
			button.Enabled = false;
			button.Text = "Jugador";
			MessageBox.Show(Mensaje);
			DoComputerMove();
		}

		/// <summary>
		/// Hacer el movimiento de la computadora.
		/// </summary>
		private void DoComputerMove() 
		{
			String Mensaje = ws.doMove(0);
			MessageBox.Show("jhbbjh");
		}
    }
}

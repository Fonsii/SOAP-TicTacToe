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
		private System.Windows.Forms.Button Leaderboard;
		private System.Windows.Forms.Label lblNombre;

		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label name;
        private TextBox userName;
        private Button restart;

        // private HolaMundo.ECCI_HolaMundo.ECCI_HolaMundo ws; // .NET 2.0
        private TicTacToeProxy proxy;

		public frmHolaMundo()
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();

			// TODO: Agregar código de constructor después de llamar a InitializeComponent
			proxy = new TicTacToeProxy();
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
            this.Leaderboard = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.name = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.restart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Leaderboard
            // 
            this.Leaderboard.Location = new System.Drawing.Point(478, 403);
            this.Leaderboard.Name = "Leaderboard";
            this.Leaderboard.Size = new System.Drawing.Size(114, 32);
            this.Leaderboard.TabIndex = 1;
            this.Leaderboard.Text = "Ver los mejores 10";
            this.Leaderboard.Click += new System.EventHandler(this.LeaderboardShow);
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(0, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(65, 71);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(527, 326);
            this.flowLayoutPanel1.TabIndex = 2;
			ButtonArrayCreator();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Enabled = false;
            this.name.Location = new System.Drawing.Point(30, 19);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(47, 13);
            this.name.TabIndex = 3;
            this.name.Text = "Nombre:";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(33, 45);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(523, 20);
            this.userName.TabIndex = 4;
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(346, 403);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(114, 32);
            this.restart.TabIndex = 5;
            this.restart.Text = "Nuevo juego";
            this.restart.Click += new System.EventHandler(this.RestartGame);
            // 
            // frmHolaMundo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(634, 447);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.name);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Leaderboard);
            this.Name = "frmHolaMundo";
            this.Text = "Tic-Tac-Toe";
            this.ResumeLayout(false);
            this.PerformLayout();

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

		#region Buttons creator
		/// <summary>
		/// Crea los botones para las 9 posiciones del Tic-Tac-Toe.
		/// </summary>
		public void ButtonArrayCreator() 
        {
            for (int i = 0; i < 9; ++i) {
				System.Windows.Forms.Button button = new System.Windows.Forms.Button();
				button.Name = "button" + i;
				button.Size = new System.Drawing.Size(150, 100);
				button.Text = "Jugar aquí";
				button.Click += new System.EventHandler(this.Button_Click);
				flowLayoutPanel1.Controls.Add(button);
            }
        }
		#endregion


		#region Events for buttons 
		/// <summary>
		/// Trigger del leaderboard.
		/// <param name="sender"> El que llamó el trigger. </param>
		/// <param name="e"> Argumentos que envia el sender. </param>
		/// </summary>
		private void LeaderboardShow(object sender, System.EventArgs e)
		{
			MessageBox.Show("Funcionalidad en progreso Top 10");
		}

		/// <summary>
		/// Trigger de los botones del grid del juego.
		/// <param name="sender"> El que llamó el trigger. </param>
		/// <param name="e"> Argumentos que envia el sender. </param>
		/// </summary>
		private void Button_Click(object sender, EventArgs e)
        {
			var button = (Button)sender;
			int position = 0;
			Int32.TryParse(button.Name.Replace("button", ""), out position);
			String Mensaje = proxy.DoMove(position);
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
			String Mensaje = proxy.DoMove(0);
			MessageBox.Show("jhbbjh");
		}

		/// <summary>
		/// Trigger para reinicar el juego.
		/// <param name="sender"> El que llamó el trigger. </param>
		/// <param name="e"> Argumentos que envia el sender. </param>
		/// </summary>
		private void RestartGame(object sender, System.EventArgs e) 
		{
			MessageBox.Show("Funcionalidad en progreso");
		}
		#endregion
	}
}

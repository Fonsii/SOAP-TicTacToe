using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Linq;

namespace HolaMundo
{
	/// <summary>
	/// Descripción breve de Form1.
	/// </summary>
	public class FrmHolaMundo : Form
    {
		private System.Windows.Forms.Button cmdSaludar;		
		private System.Windows.Forms.Label lblNombre;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private FlowLayoutPanel flowLayoutPanel1;

		// private HolaMundo.ECCI_HolaMundo.ECCI_HolaMundo ws; // .NET 2.0
		private TicTacToeProxy proxy;

		private BoardButton[] board;

		public FrmHolaMundo()
		{
			proxy = new TicTacToeProxy();
			board = new BoardButton[10];
			InitializeComponent();			
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
            this.cmdSaludar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(33, 22);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(619, 362);
            this.flowLayoutPanel1.TabIndex = 2;
			this.ButtonArrayCreator();
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
		/// Punto de entrada principal de la aplicación.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FrmHolaMundo());
		}

		/// <summary>
		/// Crea los botones para las 9 posiciones del Tic-Tac-Toe.
		/// </summary>
		public void ButtonArrayCreator() 
        {
			for (int index = 1; index < board.Length; index++)
            {
				BoardButton bbutton = new BoardButton(index, "Jugar aquí");
				bbutton.Click += new EventHandler(Button_Click);
				flowLayoutPanel1.Controls.Add(bbutton);
				board[index] = bbutton;
			}
        }

		private void ResetBoard()
        {
			for (int index = 1; index < board.Length; index++)
			{
				BoardButton button = board[index];
				button.Text = "Jugar Aquí";
				button.Enabled = true;
			}
			proxy.ResetBoard();
		}

		private void HandleDraw()
        {
			MessageBox.Show("Es un empate!");
			ResetBoard();
		}

		private void HandleComputerMove(int moveIndex)
        {
			Console.WriteLine("Computadora juega: " + moveIndex);
			switch (moveIndex)
            {
				case 1000:
					MessageBox.Show("Felicidades, usted ha ganado!");
					ResetBoard();
					break;

				case 0:
					HandleDraw();
					break;

				default:					
					BoardButton button = board[moveIndex];
					button.Text = "Computadora";
					button.Enabled = false;
					break;
			}

			switch (proxy.GetBoardStatus())
            {
				case -1000:
					MessageBox.Show("La computadora ha ganado!");
					ResetBoard();
					break;
				case 0:
					HandleDraw();
					break;
			}
        }

		/// <summary>
		/// Trigger de los botones del grid del juego.
		/// <param name="sender"> El que llamó el trigger. </param>
		/// <param name="e"> Argumentos que envia el sender. </param>
		/// </summary>
		private void Button_Click(object sender, EventArgs e)
        {
			BoardButton button = (BoardButton) sender;
			button.Text = "Jugador";
			button.Enabled = false;

			// TODO: remove print.
			Console.WriteLine("Jugador juega: " + button.GetIndex().ToString());
			HandleComputerMove(proxy.DoMove(button.GetIndex()));
		}
    }
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace QRemind
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button botonNuevo;
		/// <summary>
		
		Data data = new Data() ;

		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
	
			data.Load() ;

			for ( int i = 0 ; i < Data.MAX_POSTS ; i++ )
			{
				if ( Data.Existe[i] )
				{
					data.post[i] = new Post() ;
					data.post[i].BackColor = data.Color[i] ;
					data.post[i].Show();
					data.post[i].Left = data.Left[i] ;
					data.post[i].Top = data.Top[i] ;
					data.post[i].MostrarTexto( data.Text[i] ) ;
					data.post[i].Link(i);
					
				}
			}
		}

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.botonNuevo = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// botonNuevo
			// 
			this.botonNuevo.BackColor = System.Drawing.Color.Blue;
			this.botonNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.botonNuevo.Image = ((System.Drawing.Bitmap)(resources.GetObject("botonNuevo.Image")));
			this.botonNuevo.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.botonNuevo.Name = "botonNuevo";
			this.botonNuevo.Size = new System.Drawing.Size(29, 29);
			this.botonNuevo.TabIndex = 0;
			this.botonNuevo.Click += new System.EventHandler(this.botonNuevo_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(152, 29);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.botonNuevo});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "QRemind 1.0";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void botonNuevo_Click(object sender, System.EventArgs e)
		{
			// Buscamos un hueco libre
			int i = 0 ;
			for ( i = 0 ; i < Data.MAX_POSTS ; i++ )
			{
				if ( !Data.Existe[i] ) break ;
				if ( i+1 == Data.MAX_POSTS ) return ; // ERROR
			}
			// Tenemos en i el hueco
			Data.Existe[i] = true ;
			data.post[i] = new Post() ;
			data.post[i].BackColor = System.Drawing.Color.Blue ;
			data.post[i].Link(i) ;
			data.post[i].Show() ;
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			data.MainLeft = Left ;
			data.MainTop = Top ;
			for ( int i = 0 ; i < Data.MAX_POSTS ; i++ )
			{
				if ( Data.Existe[i] )
				{
					data.Left[i] = data.post[i].Left ;
					data.Top[i] = data.post[i].Top ;
					data.Color[i] = data.post[i].BackColor ;
					data.Text[i] = data.post[i].texto ;
				}
			}
			data.Save();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			Left = data.MainLeft ;
			Top = data.MainTop ;
		}
	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace QRemind
{
	/// <summary>
	/// Summary description for Post.
	/// </summary>
	public class Post : System.Windows.Forms.Form
	{
		/// <summary>
		private int pos ;
		public char[] texto = new char[Data.MAX_TEXT] ;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Post()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.ContextMenu = this.contextMenu1;
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(1, 1);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(77, 71);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Color";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// Post
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(79, 73);
			this.ContextMenu = this.contextMenu1;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.textBox1});
			this.DockPadding.All = 1;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Post";
			this.ShowInTaskbar = false;
			this.Text = "Post";
			this.Load += new System.EventHandler(this.Post_Load);
			this.Closed += new System.EventHandler(this.Post_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		private void Post_Closed(object sender, System.EventArgs e)
		{
			Data.Existe[pos] = false ;
		}

		public void Link( int _pos )
		{
			pos = _pos ;
		}

		private void Post_Load(object sender, System.EventArgs e)
		{
			textBox1.BackColor = BackColor ;
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			if ( textBox1.Text.Length > Data.MAX_TEXT )
			{
				textBox1.Text.ToCharArray(0,Data.MAX_TEXT).CopyTo(texto,0);
			}
			else
			{
				textBox1.Text.ToCharArray().CopyTo(texto,0) ;
			}			
			//texto.Length ;
		}

		public void MostrarTexto( char[] chars )
		{
			texto = chars ;
			Byte bytes ;
			textBox1.Text = "" ;
			for ( int i = 0 ; i < chars.Length ; i++ )
			{
				textBox1.Text += Char.ToString(chars[i]) ;
			}
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			colorDialog1.ShowDialog();
			BackColor = colorDialog1.Color ;
			textBox1.BackColor = BackColor ;
		}
	}
}

using System;

namespace QRemind
{
	/// <summary>
	/// Summary description for Data.
	/// </summary>
	/// 

	public class Data
	{
		public const int MAX_POSTS = 0xFFF ;
		public const int MAX_TEXT = 0xFF ;
		public static bool[] Existe = new bool[MAX_POSTS];
		public int[] Left = new int[MAX_POSTS];
		public int[] Top = new int[MAX_POSTS];
		public System.Drawing.Color[] Color = new System.Drawing.Color[MAX_POSTS] ;
        public Char[][] Text = new Char[MAX_POSTS][];
		public Post[] post = new Post[MAX_POSTS] ;
		public int MainLeft ;
		public int MainTop ;

		
		
		public Data()
		{
			//System.IO.FileStream file = new System.IO.FileStream( ;
			
			
			for ( int i = 0 ; i < MAX_POSTS ; i++ )
			{
				Existe[i] = false ;
				Text[i] = new char[MAX_TEXT];
			}
		}


		public void Save()
		{
			System.IO.FileStream file = new System.IO.FileStream("data.dat",System.IO.FileMode.Create ) ;
			//Info main
			Byte[] bufferM1 = System.BitConverter.GetBytes( MainLeft ) ;
			file.Write( bufferM1 , 0 , bufferM1.Length ) ;
			Byte[] bufferM2 = System.BitConverter.GetBytes( MainTop ) ;
			file.Write( bufferM2 , 0 , bufferM2.Length ) ;
			for ( int i = 0 ; i < MAX_POSTS ; i++ )
			{
				Byte[] buffer1 = System.BitConverter.GetBytes( Existe[i] ) ;
				file.Write(buffer1, 0 , buffer1.Length ) ;
				Byte[] buffer2 = System.BitConverter.GetBytes( Left[i] ) ;
				file.Write(buffer2, 0 , buffer2.Length ) ;
				Byte[] buffer3 = System.BitConverter.GetBytes( Top[i] ) ;
				file.Write(buffer3, 0 , buffer3.Length ) ;
				Byte[] buffer4 = System.BitConverter.GetBytes( Color[i].ToArgb() ) ;
				file.Write(buffer4, 0 , buffer4.Length ) ;
				Byte[] buffer5 = System.Text.Encoding.BigEndianUnicode.GetBytes( Text[i], 0 , Text[i].Length ) ;
				file.Write(buffer5, 0 , buffer5.Length ) ;
			}
			file.Close() ;
		}

		public void Load()
		{
			System.IO.FileStream file = new System.IO.FileStream("data.dat",System.IO.FileMode.Open ) ;
			Byte[] buffer1 = System.BitConverter.GetBytes( Existe[0] ) ;
			Byte[] buffer2 = System.BitConverter.GetBytes( Left[0] ) ;
			Byte[] buffer3 = System.BitConverter.GetBytes( Top[0] ) ;
			Byte[] buffer4 = System.BitConverter.GetBytes( Color[0].ToArgb() ) ;
			Byte[] buffer5 = System.Text.Encoding.BigEndianUnicode.GetBytes( Text[0], 0 , Text[0].Length ) ;

			Byte[] bufferM1 = System.BitConverter.GetBytes( MainLeft ) ;
			Byte[] bufferM2 = System.BitConverter.GetBytes( MainTop ) ;
			file.Read( bufferM1, 0, bufferM1.Length ) ;
			MainLeft = System.BitConverter.ToInt32( bufferM1 , 0 ) ;
			file.Read( bufferM2, 0, bufferM2.Length ) ;
			MainTop = System.BitConverter.ToInt32( bufferM2 , 0 ) ;

			for ( int i = 0 ; i < MAX_POSTS ; i++ )
			{
				file.Read( buffer1, 0, buffer1.Length ) ;
				Existe[i] = System.BitConverter.ToBoolean( buffer1 , 0 ) ;
				file.Read( buffer2, 0, buffer2.Length ) ;
				Left[i] = System.BitConverter.ToInt32( buffer2 , 0 ) ;
                file.Read( buffer3, 0, buffer3.Length ) ;
				Top[i] = System.BitConverter.ToInt32( buffer3 , 0 ) ;
				file.Read( buffer4, 0, buffer4.Length ) ;
				Color[i] = System.Drawing.Color.FromArgb( System.BitConverter.ToInt32(buffer4, 0 ) ) ;
				file.Read( buffer5, 0, buffer5.Length ) ;
				Text[i] = System.Text.Encoding.BigEndianUnicode.GetChars( buffer5 ) ;
			}
			file.Close() ;
		}
	}
}

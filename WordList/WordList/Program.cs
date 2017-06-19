using System;

namespace WordList
{
	class Program
	{
		static void Main(string[] args)
		{
			string line;
			var file = new System.IO.StreamReader("wordlist.txt");
			while ((line = file.ReadLine()) != null)
			{
				Console.WriteLine(line);
			}
			file.Close();
			Console.ReadLine();
		}
	}
}

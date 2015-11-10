using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFilesFinder
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("To start search enter path...");
			var path = Console.ReadLine();
			try
			{
				if (!Directory.Exists(path))
				{
					throw new PathException(path);
				}
				var finder = new MusicFinder("D:\\alexroverandom");
				Console.WriteLine("Search...");
				finder.Find();
				Console.WriteLine("Search is finished");
				Console.WriteLine("To view results press any key...");
				Console.ReadKey();
				finder.ShowResults();
				Console.WriteLine("Good luck");
			}
			catch(PathException ex)
			{
				Console.WriteLine("Error: " + ex.ErrorMessage + " (No such directory)");
			}
			catch(Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
			}
			Console.WriteLine("Exit");
			Console.ReadKey();
		}
	}
}

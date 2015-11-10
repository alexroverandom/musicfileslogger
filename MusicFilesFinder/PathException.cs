using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicFilesFinder
{
	public class PathException : Exception
	{
		private string _path;
		public string ErrorMessage { get { return String.Format("Path {0} does not exist", _path); } }

		public PathException(String path)
		{
			_path = path;
		}
	}
}

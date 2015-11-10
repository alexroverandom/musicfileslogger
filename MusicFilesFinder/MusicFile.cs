using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFilesFinder
{
	public class MusicFile
	{
		public Guid Id { get; set; }
		public String Name { get; set; }
		public String Extension { get; set; }

		public Guid FolderId { get; set; }
		[JsonIgnore]
		public MusicFolder Folder { get; set; }

		public MusicFile() 
		{
			Id = Guid.NewGuid();
		}

		public String GetFileName() 
		{
			return String.Format("{0}.{1}", Name, Extension);
		}
	}
}

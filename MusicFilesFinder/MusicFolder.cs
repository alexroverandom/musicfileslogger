using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFilesFinder
{
	public class MusicFolder
	{
		public Guid Id { get; set; }
		public String Name { get; set; }
		public Guid? ParentId { get; set; }
		[JsonIgnore]
		public bool HasMusicFiles { get { return Files.Any(); } }

		[JsonIgnore]
		public MusicFolder ParentFolder { get; set; }

		[JsonIgnore]
		public ICollection<MusicFolder> Folders { get; set; }

		[JsonIgnore]
		public ICollection<MusicFile> Files { get; set; }

		public MusicFolder(Guid? parentId) 
		{
			Id = Guid.NewGuid();
			ParentId = parentId ?? null;
			Files = new List<MusicFile>();
			Folders = new List<MusicFolder>();
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFilesFinder
{
	public class MusicFinder
	{
		private string _path;
		private List<String> _musicFileExts = new List<string> 
		{ 
			".aac",
			".adts",
			".ac3",
			".aif",
			".aiff",
			".aifc",
			".caf",
			".mp3",
			".mp4",
			".m4a",
			".snd",
			".au",
			".sd2",
			".wav"
		};
		private List<MusicFolder> _folders;
		public List<MusicFolder> Folders { get { return _folders; } }

		public MusicFinder(String path) 
		{
			_path = path;
			_folders = new List<MusicFolder>();
		}

		public void Find() 
		{
			ProcessDirectory(_path, null);
		}

		public void ShowResults() 
		{
			Console.WriteLine("List of folders:");
			var leafFolders = Folders.Where(f => f.Files.Any()).ToList();
			foreach (var leaf in leafFolders)
			{
				var file = _getFullPathToLeaf(leaf);
				var files = String.Empty;
				foreach (var f in leaf.Files)
				{
					files += String.Format("---{0}.{1}\n", f.Name, f.Extension);
				}
				File.AppendAllText(Path.Combine(_path, "FindResults.txt"), file + "\n" + files);
				Console.WriteLine(file);
			}
		}

		private String _getFullPathToLeaf(MusicFolder folder)
		{
			return folder.ParentFolder == null ? folder.Name : _getFullPathToLeaf(folder.ParentFolder) + "=>" + folder.Name;
		}

		private void ProcessDirectory(string targetDirectory, Guid? parent)
		{
			var folder = new MusicFolder(parent);
			if (parent != null)
			{
				folder.ParentFolder = _folders.FirstOrDefault(f => f.Id == parent);
			}
			folder.Name = targetDirectory.Split('\\').ToList().Last();
			string[] files = Directory.GetFiles(targetDirectory);
			foreach (var ext in _musicFileExts)
			{
				string[] fileEntries = Directory.GetFiles(targetDirectory, String.Format("*{0}", ext));
				if (fileEntries.Any())
				{
					foreach (var f in fileEntries)
					{
						folder.Files.Add(new MusicFile
						{
							FolderId = folder.Id,
							Name = f.Split('\\').ToList().Last().Split('.')[0],
							Extension = f.Split('\\').ToList().Last().Split('.')[1]
						});
					}
				}
			}
			_folders.Add(folder);
			string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
			foreach (string subdirectory in subdirectoryEntries)
			{
				ProcessDirectory(subdirectory, folder.Id);
			}
		}
	}
}

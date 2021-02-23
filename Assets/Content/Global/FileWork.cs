using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class FileWork : MonoBehaviour {

	public List<string> File_Load(string filename)  //Environment.CurrentDirectory + "Saves/Save.sav"
	{
		List<string> File_Text = new List<string>();
		FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);
		StreamReader file_reader = new StreamReader(file);
		while (!file_reader.EndOfStream)
		{
			File_Text.Add(file_reader.ReadLine());
		}
		file_reader.Close();
		return File_Text;
	}
	
	public void File_Create(List<string> Text_To_File, string filename)
	{
		FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write);
		StreamWriter file_writer = new StreamWriter(file);
		if (Text_To_File != null)
		{
			for (int i = 0; i < Text_To_File.Count; i++)
			{
				file_writer.WriteLine(Text_To_File[i]);
			}
		}
		file_writer.Close();
	}
	
	public void File_Write(List<string> Text_To_File, string filename)
	{
		FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Write);
		StreamWriter file_writer = new StreamWriter(file);
		for (int i = 0; i < Text_To_File.Count; i++)
		{
			file_writer.WriteLine(Text_To_File[i]);
		}
		file_writer.Close();
		
	}
	
	public bool File_Exist(string filename)
	{
		FileInfo file = new FileInfo(filename);// class File = class FileInfo, lol, wtf
		return file.Exists;
	}
	
	public void File_DecEnc(string filename, int state_operaton)
	{
		FileInfo file = new FileInfo(filename);
		if (state_operaton == 1)
		{
			file.Encrypt();
		}
		if (state_operaton == 2)
		{
			file.Decrypt();
		}
	}
	
	public void CreateDir(string dirpatch)
	{
		Directory.CreateDirectory(dirpatch);
	}
}

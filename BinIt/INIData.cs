using System.Collections.Generic;
using System.IO;

public class INIData {

	private Dictionary<string, string> _data = new Dictionary<string, string>();

	public INIData (){}
	public INIData (string filePath, string fileName)
    {
		Load(filePath, fileName);
	}

	/// Load data into memory.
	public void Load (string filePath, string fileName)
	{
        Directory.CreateDirectory(filePath);
        if (File.Exists(filePath + "/" + fileName))
        {
            StreamReader sr = new StreamReader(filePath + "/" + fileName);
            string contents = sr.ReadToEnd();
            sr.Close();

            string[] fileContents = contents.Split("\n"[0]);

            char[] trimmings = { ' ', '\"' };
            foreach (string s in fileContents)
            {
                if (s.Trim() == "")
                    continue;
                if (s.Trim().StartsWith(";"))
                    continue;
                if (s.Trim().StartsWith("#"))
                    continue;
                if (s.Trim().StartsWith("["))
                    continue;

                string[] temp = s.Split("="[0]);
                _data.Add(temp[0].Trim(trimmings).Trim(), temp[1].Trim(trimmings).Trim());
            }
        }
	}
	
	/// Save data out into file.
	/// Currently the data will not save, comments or sections.
	public void Save (string filePath, string fileName)
	{
		if (File.Exists(filePath + "/" + fileName))
			File.Delete(filePath + "/" + fileName);
		
		StreamWriter sw = new StreamWriter(filePath + "/" + fileName);
		foreach (KeyValuePair<string, string> kvp in _data){
			sw.WriteLine(kvp.Key + " = " + kvp.Value);
		}
		sw.Close();
	}
	
	public string GetString (string key)
	{
		string value;
		if (_data.TryGetValue(key, out value))
			return value;
		return "ERROR";
	}

	/// Get a string trimmed and formatted for path.
	public string GetPath (string key)
	{
		string value;
		char[] invalidChars = Path.GetInvalidPathChars();

		if (_data.TryGetValue(key, out value))
			return value.Trim(invalidChars);

		return "ERROR";
	}

	/// Get a string trimmed and formated for filenames.
	public string GetFileName (string key)
	{
		string value;
		char[] invalidChars = Path.GetInvalidFileNameChars();

		if (_data.TryGetValue(key, out value))
			return value.Trim(invalidChars);

		return "ERROR";
	}
	
	public int GetInteger(string key)
	{
		string s;
		int i = 0;

		if (_data.TryGetValue(key, out s)){
			if (int.TryParse(s, out i))
				return i;
		}
		return i;
	}
	
	public float GetFloat(string key)
	{
		string s;
		float i = 0;
		
		if (_data.TryGetValue(key, out s)){
			if (float.TryParse(s, out i))
				return i;
		}
		return i;
	}
	
	public bool GetBool(string key)
	{
		switch( _data[key].ToLower() )
		{
			case null:
				return false;
				
			case "true":
				return true;
				
			case "t":
				return true;
				
			case "1":
				return true;
				
			case "yes":
				return true;
				
			case "y":
				return true;

			default:
				return false;
		}
	}
	
	public void SetEntry (string key, string value)
	{
		if (_data.ContainsKey(key)){
			_data[key] = value;
			return;
		}
	}
	
	public void CreateEntry (string key, string value)
	{
		if (_data.ContainsKey(key)){
			return;
		}

		_data.Add(key, value);
	}
	
	public void RemoveEntry (string key)
	{
		if (_data.ContainsKey(key)){
			_data.Remove(key);
			return;
		}
	}
}
using UnityEngine;
using System.Collections;

public class INITest : MonoBehaviour {

	public INIData configData;
	public int integer;
	public float floatingPoint;
	public string stringValue;
	public string path;
	public string fileName;
	public bool trueFalse;

	void Start () {
		configData = new INIData(Application.dataPath, "Config.ini");

		print(configData.GetInteger("int"));
		integer = configData.GetInteger("int");

		print(configData.GetFloat("float"));
		floatingPoint = configData.GetFloat("float");

		print(configData.GetString("string"));
		stringValue = configData.GetString("string");

		print(configData.GetPath("path"));
		path = configData.GetPath("path");

		print(configData.GetFileName("filename"));
		fileName = configData.GetFileName("filename");

		print(configData.GetBool("bool"));
		trueFalse = configData.GetBool("bool");
	}
}
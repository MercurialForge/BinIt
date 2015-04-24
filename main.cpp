/*
* A desktop clean up program! The one I've always wanted
* and you never knew you wanted too! AmIRite?!
*
* author: Oliver Barraza
* contact: oliver@mercurialforge.com
*/

#include "dirent.h" // directory header
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <stdio.h>
#include <ShlObj.h>
#include "Shlwapi.h"

using namespace std;

//======================================================================================================================
// GLOBAL VARIABLES
//======================================================================================================================

const CHAR* ConfigFileName = ".\\Config.ini";
char CharacterInput;
string CommandInput;
bool bIsExiting = false;
TCHAR desktop[MAX_PATH];
int binCount;

//======================================================================================================================
// FUNCTION DECLARATIONS
//======================================================================================================================

void ListDir(const char *path, vector<string> &files);
void CreateFolder(const string path);
void SnapShot();
void BinIt();
void GetDesktop();

//======================================================================================================================
int main(int argc, char* argv[])
{
	const std::string usage("usage:\n"
		"	snapshot  :	(record current desktop for clean up protection)\n"
		"	binit     :	(stash unprotected files on in the BinIt Folder)\n"
		"	exit      :	(guess what it does...)\n"
		"	help      :	(get more information)\n"
		"	protips   :	(see pro user commands)\n"
		"\n");

	const std::string protips("pro tips:\n"
		"	reinitialize	: (run app from beginning again)\n"
		"	\"The generated config can have the key Desktop\n"
		"	replaced with any directory you want to clean\"\n"
		"\n");

	GetPrivateProfileString("Settings", "DesktopPath", NULL, desktop, MAX_PATH, ConfigFileName);

	// welcome the user
	printf("Welcome to BinIt the desktop clean up app.\n");

	if (string(desktop) == "")
	{
		printf(usage.c_str());
		GetDesktop();
	}

	if (!bIsExiting)
	{
		printf("Target Desktop Is: %s\n", desktop);
		printf("\n");
		printf("\n");
	}

	// if desktop is correct allow commands
	while (!bIsExiting)
	{
		cout << "You're Command?: ";
		cin >> CommandInput;

		if (CommandInput == "snapshot")
		{
			SnapShot();
		}
		else if (CommandInput == "binit")
		{
			BinIt();
		}
		else if (CommandInput == "reinitialize")
		{
			GetDesktop();
		}
		else if (CommandInput == "/?" || CommandInput == "?" || CommandInput == "\?" || CommandInput == "help")
		{
			printf(usage.c_str());
		}
		else if (CommandInput == "protips")
		{
			printf(protips.c_str());
		}
		else if (CommandInput == "exit")
		{
			bIsExiting = true;
		}
		else
		{
			printf("ERROR that is not a command! Type 'help' for usages\n");
		}
	}

	printf("Exiting\n");
	system("pause");
	return 0;
}

//======================================================================================================================
void ListDir(const char *path, vector<string> &files)
{
	DIR* DirPtr = NULL;
	DirPtr = opendir(path); // "." will refer to the current directory
	struct dirent* Directory = NULL;
	if (DirPtr == NULL) { return; }

	while (Directory = readdir(DirPtr))
	{
		if (Directory == NULL) { return; }
		files.push_back(Directory->d_name);
	}
	closedir(DirPtr);
}

//======================================================================================================================
void CreateFolder(const string path)
{
	CreateDirectory(path.c_str(), NULL);
}

//======================================================================================================================
void SnapShot()
{
	// Get the current files on the desktop
	vector<string> TheFiles;
	TheFiles.push_back("BinIt");
	ListDir(desktop, TheFiles);

	// create new Snapshot file
	ofstream myfile;
	myfile.open("Snapshot");
	for (string s : TheFiles)
	{
		myfile << s + "\n";
	}
	myfile.close();

	printf("A snapshot was successfully created!\n");

	// could be useful later to store this formation for updating the use if it's been a long time etc.
	//WritePrivateProfileString("Snapshot", "bHasTakenSnapshot", "1", ConfigFileName);
	//WritePrivateProfileString("Snapshot", "LastSnapShot", "Unknown", ConfigFileName);
}

//======================================================================================================================
void BinIt()
{
	// Get the current files on the desktop
	vector<string> TheFiles;
	ListDir(desktop, TheFiles);

	// Construct the BinIt folder if it does not exist
	string BinitFolderPath = string(desktop);
	BinitFolderPath += "/BinIt";
	CreateFolder(BinitFolderPath);

	// Load in the Snapshop
	vector<string> TheSnapShot;
	string line;
	ifstream myfile("Snapshot");
	if (myfile.is_open())
	{
		while (getline(myfile, line))
		{
			TheSnapShot.push_back(line);
			//cout << line << '\n';
		}
		myfile.close();
	}
	else
	{
		printf("ABORTED for your own good doofus. Snapshot not found. MAKE ONE!\n");
		bIsExiting = true;
	}

	// Check current desktop files against the snapshot files and move those not listed in the snapshot
	bool bIsFileMatch;

	for (string file : TheFiles)
	{
		bIsFileMatch = false;
		for (string sFile : TheSnapShot)
		{
			if (file.compare(sFile) == 0)
			{
				bIsFileMatch = true;
				continue;
			}
		}
		if (!bIsFileMatch)
		{
			//printf("%s: would be moved! It is not protected against the Snapshot\n", file);
			cout << "Moving file:" << file << '\n';
			string FileToMove = string(desktop) + "\\" + file;
			string MoveToFile = BinitFolderPath + "\\" + file;
			MoveFile(FileToMove.c_str(), MoveToFile.c_str());
			binCount++;
		}
	}
	if (binCount == 0)
	{
		printf("Nothing to Bin, you're keeping a clean Desktop!\n");
	}
	binCount = 0;
}

//======================================================================================================================
void GetDesktop()
{
	// get the current desktop
	if (SUCCEEDED(SHGetFolderPath(NULL, CSIDL_DESKTOPDIRECTORY | CSIDL_FLAG_CREATE, NULL, SHGFP_TYPE_CURRENT, desktop))){}
	else
	{
		// some fucked up shit happened
		printf("Some shit went crazy wrong. Acording to the code you don't have a fucking desktop dude!\n");
		printf("Contact the developer (oliver@mercurialforge.com) and complain till he fixes it.");
		bIsExiting = true;
	}

	// present the desktop dir and ask for user confirmation 
	printf("Please confirm this is your desktop: %s\n", desktop);

	// wait for input
	cout << "\nIs this correct?: ";
	cin >> CharacterInput;

	// evaluate input

	if (CharacterInput == 'y' || CharacterInput == 'Y')
	{
		WritePrivateProfileString("Settings", "DesktopPath", desktop, ConfigFileName);
		printf("\n");
	}
	else if (CharacterInput == 'n' || CharacterInput == 'N')
	{
		printf("Well, something must be wrong with your pc or settings. It could also be the code. You can branch and fix it at http://www.github.com/mercurialforge/BinIt \n\n");
		WritePrivateProfileString("Settings", "DesktopPath", "", ConfigFileName);
		bIsExiting = true;
	}
	else
	{
		printf("You must be new. Y or N next time!\n\n");
		GetDesktop();
	}
}

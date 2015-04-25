# BinIt
A desktop cleaner! 

Author: Oliver Barraza

Contact: Oliver@MercurialForge.com

###To Use:
1. Clean desktop to your ideal state.
2. Launch BinIt.exe
3. Check Use Snapshots.
4. Click Take Snapshot
5. Anytime your desktop becomes dirty, click BinIt to clean it!

###Merge Options:
Keep Both - will append _dup to any files it finds with identical names.

Overwrite - will overwrite the file in the BinIt folder with the new one on the desktop.

###Options:
Ignore Shortcuts - will ignore any .lnk (default windows shortcuts) during cleanup keep all shortcuts on you're desktop safe.

Ignore Folder - will ignore any folders on your desktop during cleanup.

Use .ignore - will ignore the extensions and directories listed in the .ignore file found next to the .exe during cleanup.

###How to use .ignore:
!only one extensions or directory per line! Similar to .gitignore

to ignore extensions enter "*.xxx" without quotes and replace the xxx with the desired extension eg: *.pdf

to ignore directories/folders enter "foldername/" without the quotes and replace foldername with the desired directory eg: CurProjects/

###Tips:
Steam Game shortcuts are actually .url files. If you wish to protect them add *.url to the .ignore file.

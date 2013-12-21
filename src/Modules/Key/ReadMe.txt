=================================
REBUILDING DLLs
=================================

Before building the dll's , you have to create a strong name file. To create this file, you must execute the following command: sn -k Key.snk and copy the newly generated Key.snk file to the \Key\ directory. The Sn.exe utility is located in your FrameworkSDK binary directory.
Please read the 'Strong-Named Assemblies' topic in MSDN for more information.
Once you complete these steps, you can distribute your dlls. 
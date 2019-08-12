Instructions

Project was built with Mono and the Nancy Framework
Monodevelop was used initially to build and run the project.
The project was created as a C# console project in Monodevelop.

To compile from commandline:
1) cd to directory where the solution file is located
2) > msbuild webchat.sln
NOTE: also just execute the build bash script.

To run from commandline:
1) > mono webchat/bin/Debug/webchat.exe 
NOTE: also just execute the run bash script.

The Mongo DB configuration settings are in app.config and are read in by 
DAO/MessageDAO.cs

GIT and MSBuild, some what together, kind of....
=================================================

basic idea is as follows:

* Create a new bare git repo (mkdir <ProjectName>; cd <ProjectName>; git init --bare)
* In the ProjectName folder, create a folder called builds
* Copy the files in the gitHookFiles into the hooks folder
* Run the EXE. it takes a param of the builds folder.
* Create your project as standard. git add the files and add the remote folder. (check the [GIT book](http://book.git-scm.com/ "Git Book") if your not sure)
* Git push <remoteName> Master
* Once pushed, the EXE should kick off and build your file. it will tell you where the build files live. 

Todo
-----
* Eventually add email support to tell you where your files can be picked up
* maybe setup building for web packages
* look into using Powershell instead of an EXE to do the work... this might allow for easier modification

Links
-----
[StackOverFlow question on using PowerShell for Git Hooks][1]

[1]:http://stackoverflow.com/questions/5629261/running-powershell-scripts-as-git-hooks/7645072#7645072

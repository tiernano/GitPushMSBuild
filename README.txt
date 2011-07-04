GIT and MSBuild, some what together, kind of....
=================================================

basic idea is as follows:
* create a new bare git repo (mkdir <ProjectName>; cd <ProjectName>; git init --bare)
* in the ProjectName folder, create a folder called builds
* copy the files in the gitHookFiles into the hooks folder
* run the EXE. it takes a param of the builds folder.
* create your project as standard. git add the files and add the remote folder. (check the [GIT book](http://book.git-scm.com/ "Git Book") if your not sure)
* git push <remoteName> Master
* once pushed, the EXE should kick off and build your file. it will tell you where the build files live. 

Todo
-----
Eventually add email support to tell you where your files can be picked up
maybe setup building for web packages

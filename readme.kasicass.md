# README by kasicass

 * win10 上最后还是没编译通过
 * 不知道为啥带空格的目录有问题


## Visual Studio Version

 * VS2008
 * git commit message "vs2010 patch" is wrong
 * only support vs2008 build


## BUILD on Win10

 * Install VS2008
 * Install StrawberryPerl x86 (http://strawberryperl.com/)
 * run VS2008 develop cmd as Administrator

```
# workaround for nmake (if VS2008 install in D:)
> cd D:
> mkdir D:\ProgramFiles(x86)\MicrosoftVisualStudio9.0\VC
> cd D:\ProgramFiles(x86)\MicrosoftVisualStudio9.0\VC
> mklink /D Include "D:\Program Files (x86)\Microsoft Visual Studio 9.0\VC\include"

> cd sscli20
> env.bat
> buildall.cmd
```

# AllAuth.Desktop

[![Build status](https://ci.appveyor.com/api/projects/status/iy987c5b8mvpso9a?svg=true)](https://ci.appveyor.com/project/MrLunar/allauth-desktop)

This is the desktop application for AllAuth, a personal login manager. Visit [AllAuthApp.com](https://allauthapp.com) to learn more.

See https://github.com/bowmark/allauth.lib for shared components such as the crypto library.

## Security

Please contact security@allauthapp.com to report any security vulnerabilities ([PGP Key CBE6ED5C](https://sks-keyservers.net/pks/lookup?op=get&search=0xEFB3FC7ACBE6ED5C)).

## Prerequisites

- Git
- Visual Studio 2015 (Community edition is fine)

## Building

First, setup the project (the following commands work in both CMD and bash):

```shell
  mkdir AllAuth
  cd AllAuth
  git clone https://github.com/bowmark/allauth.lib.git Lib
  git clone https://github.com/bowmark/allauth.desktop.git Desktop
  cd Desktop
```

You can build the project via the Windows command prompt:

```shell
  build debug
```

or a bash shell on Windows (e.g. MinGW, Git Bash):

```shell
  ./build.sh debug
```

or you can open the `AllAuth.Desktop.sln` solution file in Visual Studio 2015 where you can build and debug the project.

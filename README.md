# Abandoned

This project has been abandoned.

---

# AllAuth.Desktop

[![Build status](https://ci.appveyor.com/api/projects/status/iy987c5b8mvpso9a?svg=true)](https://ci.appveyor.com/project/MrLunar/allauth-desktop)

This is the desktop application for AllAuth, a personal login manager. Visit [AllAuthApp.com](https://allauthapp.com) to learn more.

See https://github.com/bowmark/allauth.lib for shared components such as the crypto library.

## Security

Please contact security@allauthapp.com to report any security vulnerabilities ([PGP Key CBE6ED5C](https://sks-keyservers.net/pks/lookup?op=get&search=0xEFB3FC7ACBE6ED5C)).

## Prerequisites

- Git
- For Windows: Visual Studio 2015 (Community edition is fine)
- For other platforms: mono-devel >= 4.2

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

or bash (e.g. MinGW, Git Bash):

```shell
  ./build.sh debug
```

or you can open the `AllAuth.Desktop.sln` solution file in Visual Studio 2015 where you can build and debug the project.

## Platforms

The desktop app is designed to run on Windows, Mac OSX and Linux, therefore all code and dependancies must be Mono compatible.

The lib is also used in the mobile applications, so all lib code must be portable.

Releases are currently only built against the .NET 4.5 profile, but can run on Mono. Future releases may be built against a mono profile for non-Windows platforms, but we'll consider this if stability becomes an issue.

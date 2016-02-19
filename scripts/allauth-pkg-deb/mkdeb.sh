#!/usr/bin/env bash

if [ -z "$1" ] || [ -z "$2" ]; then
  echo "Usage: $0 <programversion> <fullversion>"
  exit 1
fi

set -eu

PROGRAM_NAME="allauth"
PROGRAM_TITLE="AllAuth"
PROGRAM_VERSION="$1"
FULL_VERSION="$2"
EXE_NAME="AllAuth.exe"
PACKAGE_NAME="${PROGRAM_NAME}_current_all"
BUILD_DIR="build/release/AllAuth.Desktop"
SCRIPT_DIR="scripts/${PROGRAM_NAME}-pkg-deb"
TEMP_DIR="/tmp/$PACKAGE_NAME"
TEMP_DIR_CONTROL="$TEMP_DIR/DEBIAN"
TEMP_DIR_BIN="$TEMP_DIR/usr/bin"
TEMP_DIR_LIB="$TEMP_DIR/usr/lib/${PROGRAM_NAME}"
TEMP_DIR_DOC="$TEMP_DIR/usr/share/doc/${PROGRAM_NAME}"
TEMP_DIR_SHORTCUT="$TEMP_DIR/usr/share/applications"
OUTPUT_DIR="build/dist"

COPYRIGHT=$(cat <<EOF
Copyright 2016 Bowmark Ltd
EOF
)

# Ensure we're in the root project directory
cd "$(dirname $(dirname $(dirname $0)))"
PROJECT_DIR="$PWD"
if [ ! -d build ]; then
  echo "ERROR: Please run in root project directory"
  exit
fi

# Server hardening may change the default umask, but most of what we'll be creating
# requires world-read.
umask 022

echo "Creating directory structure..."
[ -d "$TEMP_DIR" ] && rm -R "$TEMP_DIR"
mkdir "$TEMP_DIR"
mkdir -p "$TEMP_DIR_BIN"
mkdir -p "$TEMP_DIR_LIB"
mkdir -p "$TEMP_DIR_DOC"
mkdir -p "$TEMP_DIR_SHORTCUT"
mkdir -p "$OUTPUT_DIR"

echo "Binaries and libraries..."
cat <<EOF > "$TEMP_DIR_BIN/${PROGRAM_NAME}"
#!/bin/sh
exec /usr/bin/cli /usr/lib/${PROGRAM_NAME}/${EXE_NAME} "\$@"
EOF
chmod +x "$TEMP_DIR_BIN/${PROGRAM_NAME}"
cp -R "$BUILD_DIR/VERSION" "$TEMP_DIR_LIB/"
cp -R "$BUILD_DIR/"*.dll "$TEMP_DIR_LIB/"
cp -R "$BUILD_DIR/"*.exe "$TEMP_DIR_LIB/"
cp -R "$BUILD_DIR/"*.config "$TEMP_DIR_LIB/" || :
cp -R "$BUILD_DIR/"*.ini "$TEMP_DIR_LIB/" || :
cp -R "$BUILD_DIR/Resources" "$TEMP_DIR_LIB/" || :
rm -f "$TEMP_DIR_LIB/sqlite3.dll"
chmod -R 0644 "$TEMP_DIR_LIB/"*
cp "$SCRIPT_DIR/allauth.desktop" "$TEMP_DIR_SHORTCUT"
chmod 0644 "$TEMP_DIR_SHORTCUT/allauth.desktop"
echo "$COPYRIGHT" > "$TEMP_DIR_DOC/copyright"

INSTALLED_SIZE=$(du -s $TEMP_DIR | awk '{print $1}')
DEB_CONTROL=$(cat <<EOF
Package: ${PROGRAM_TITLE}
Version: ${PROGRAM_VERSION}
Section: misc
Priority: optional
Architecture: all
Installed-Size: ${INSTALLED_SIZE}
Depends: mono-runtime (>= 3.2~), libmono-system-data-linq4.0-cil, libmono-system-xml-linq4.0-cil, libmono-system-management4.0-cil, libsqlcipher0
Maintainer: Bowmark Ltd <dev@allauthapp.com>
Description: Login manager
EOF
)

echo "Creating deb files..."
mkdir "$TEMP_DIR_CONTROL"
echo "$DEB_CONTROL" > "$TEMP_DIR_CONTROL/control"

echo "Generating deb file..."
fakeroot dpkg-deb --build "$TEMP_DIR"
mv "$TEMP_DIR.deb" "$OUTPUT_DIR/$PACKAGE_NAME.deb"

echo "Done."

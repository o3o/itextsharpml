#!/bin/sh +v
NEW_VER=$@

sed -i -r "s/AssemblyVersion\(\"[0-9]+\.[0-9]+\.[0-9]+/AssemblyVersion\(\"${NEW_VER}/g" AssemblyInfo.cs
sed -i -r "s/VERSION\s*=\s*\"[0-9]+\.[0-9]+\.[0-9]+/VERSION = \"${NEW_VER}/g" *.cs
sed -i -r "s/VERSION\s*=\s*[0-9]+\.[0-9]+\.[0-9]+/VERSION = ${NEW_VER}/g" makefile
make
git commit -a -m "Bumped version to ${NEW_VER}"

# DAR-to-OAR [![.NET](https://github.com/allison-payne/dar-to-oar/actions/workflows/dotnet.yml/badge.svg)](https://github.com/allison-payne/dar-to-oar/actions/workflows/dotnet.yml)
A Tool for automating the conversion DAR mods to OAR mods.

## What it does

This tool converts a DAR mod to an OAR mod. It copies all the files from the ``DynamicAnimationReplacer`` folder to the ``OpenAnimationReplacer`` folder, then generates the JSON files needed at each level. To keep things simple, the numbered folders of preserved, this also makes determining priority in config generation much easier.

## How to use
1. Simply provide the mod folder you wish to convert and add an optional author name. Click Convert.

2. After Step 1, you can customize the OAR output folder and/or the OAR Mod name used in the OAR config.json

## Still todo

- Complete the conditions mapping
- Additional Error handling 
- Additonal User messaging

# AtlusScriptGUI
![](https://i.imgur.com/UNgxNBR.png)  
GUI that automatically passes commandline arguments to AtlusScriptCompiler.  
Also useful for converting bitflag IDs from vanilla to Royal.
# Usage
1. Download and extract [AtlusScriptCompiler.exe](https://github.com/tge-was-taken/Atlus-Script-Tools).
2. Download and extract the [latest release](https://github.com/ShrineFox/AtlusScriptGUI/releases) of AtlusScriptGUI from this repository.
3. Edit ``Config.json`` with the path to your ``AtlusScriptCompiler.exe``. Be sure to use double-slashes!
4. Run the program!

# Latest Updates
## [Update: 3.1](https://github.com/ShrineFox/AtlusScriptGUI/releases)
- Fix compiling/decompiling multiple files at once
- Fix relative path to AtlusScriptCompiler.exe not working
- Separate dropdown list for Encoding (only used for games with multiple Encoding options)
## Update: 3.0
- Built-in light/dark theme toggle
- You can now click the Compile/Decompile buttons to browse for files using a popup dialog
- Options are hidden in the menustrip dropdowns for a more elegant appearance
- Form is now freely resizable and features a built-in output log
- Added option to delete .h files after decompiling .bmd to .msg
- P5R_EFIGS encoding option added in place of PS4 EU
- "Overwrite" option now applies to decompiling as well

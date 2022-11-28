The repository contains two simple script tool to remove under hair (remove pubic hair / shave ) in Koikatu (Koikatsu).

## CharaStudioScript
scripts/RemoveUnderHair.cs
Requirement: [ScriptLoader.dll](https://github.com/ghorsington/BepInEx.ScriptLoader/releases/tag/v1.2.4.0)
You should read the comment in RemoveUnderHair.cs
Press O to Remove all characters' pubic hair in chara studio. 
You can edit the code if hot key conflicts.

## RemoveCCUnderHair\RemoveUnderHairCharaCard.exe
Packed "RemoveUnderHairCharaCard.py" to an exe.
Get it in [Releases(It contains both exe and the source code)](https://github.com/astralash/Koikatu-Remove-Under-Hair/releases/tag/v1.0). 


## RemoveCCUnderHair\RemoveUnderHairCharaCard.py
A simple script that remove al pubic hair of chara cards in current directory and its subdirectories.
I wrote 'HowToUse' in Chinese and I'm lazy to translate it, so key points are below:
remember to backup valuable cards such as original cards and paid cards
I use error processing machanism to judge whether the png file is a chara card.
It's my first time to use such strategy so I'm not sure if it's acceptable.
I have to do that cauz the lib does not provide a judging function.


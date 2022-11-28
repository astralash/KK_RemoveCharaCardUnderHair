/*
* Place this file inside "KK\scripts"
* This script only work in CharaStudio (not character editor)
*
* ScripLoader.dll is required to load this script. 
* https://github.com/ghorsington/BepInEx.ScriptLoader/releases/tag/v1.2.4.0
* If placing it inside "KK\BepInEx\plugins\" does not work, place it inside "KK\BepInEx\"
* Make sure it's not because hotket conflict before you deicide to move the "ScripLoader.dll"
* Replace "KK" above to the root directory of your game 
* 
* 该脚本仅在工作室中可用(不是角色编辑器)
* 把本文件放在 "KK\scripts"
*
* 需要 ScripLoader.dll 来加载本脚本
* 下载地址: https://github.com/ghorsington/BepInEx.ScriptLoader/releases/tag/v1.2.4.0
* 如果放在"KK\BepInEx\plugins\"中脚本加载不了，那么请直接放在 "KK\BepInEx\" 里面
* 在你决定移动"ScripLoader.dll"之前，确认不是因为按键冲突导致的问题
* 上述的"KK"表示游戏的根目录
*
* Reference Code 参考代码: 
* [1] Studio Body Overwrite Script by 琳(jim60105)
* https://cloud.maki0419.com/s/sxp596jEzfapnzL
*
*/

using UnityEngine;
using System.Collections.Generic;
using System.Linq;


class UnderHairRemoverComponent : MonoBehaviour 
{
	
	void Awake() 
	{
		DontDestroyOnLoad(this);
	}

	void Update() 
	{
		/* Press O to activate the script. Change it if you want or you have to */
		if (Input.GetKeyDown(KeyCode.O))
		{				
			RemoveUnderHair();
		}
		
	}

	void RemoveUnderHair() 
	{
		List<ChaControl> chaControlList = new List<ChaControl>();
		chaControlList = Studio.Studio.Instance.dicInfo.Values.OfType<Studio.OCIChar>().Select(x => x.charInfo).ToList();
		
		foreach (ChaControl chaControl in chaControlList) 
		{
			ChaFileCustom chaFileCustom = chaControl.chaFile.custom;
			
			/* Modification, you can add your own settings here*/
			{
				/* Set Pubic Hari ID to 0 to remove vanila under hair */
				chaFileCustom.body.underhairId = 0;
				/* 
				* I did'nt figure out how to remove under hair in mod, so just I used a trick to have that done, setting it transparent.
				* Though, in theory, keeping the line below only is enough.
				*/
				chaFileCustom.body.underhairColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);			
			}

			/* Reload it otherwise, it will not work properly */
			chaControl.Reload(true, true, true);
		}
		
	}
}

public static class UnderHairRemover
{
    private static GameObject gameObject;
    public static void Main() 
	{
        gameObject = new GameObject();
        gameObject.AddComponent<UnderHairRemoverComponent>();
    }

    public static void Unload() 
	{
        Object.Destroy(gameObject);
        gameObject = null;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;
// M_S项目的玩家动画
public class CharacterKeyboardInputPlayer : CharacterKeyboardInput
{
	public KeyCode Attack01Key = KeyCode.J;
	public KeyCode Attack02Key = KeyCode.K;
	public KeyCode ShiftKey = KeyCode.LeftShift;
	public KeyCode ForwardMove = KeyCode.W;
	// Start is called before the first frame update
	public  bool IsAttack01Pressed()
	{
		return Input.GetKey(Attack01Key);
	}

	public bool IsAttack02Pressed()
	{
		return Input.GetKey(Attack02Key);
	}

	public bool IsLeftShiftPressed()
	{
		//Debug.LogError(Input.GetKeyDown(ShiftKey));
		
		return Input.GetKey(ShiftKey) && Input.GetKey(ForwardMove);
	}
}


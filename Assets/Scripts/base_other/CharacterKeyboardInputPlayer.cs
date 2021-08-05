using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;
// M_S��Ŀ����Ҷ���
public class CharacterKeyboardInputPlayer : CharacterKeyboardInput
{
	public KeyCode Attack01Key = KeyCode.J;
	public KeyCode Attack02Key = KeyCode.K;
	// Start is called before the first frame update
	public  bool IsAttack01Pressed()
	{
		return Input.GetKey(Attack01Key);
	}

	public bool IsAttack02Pressed()
	{
		return Input.GetKey(Attack02Key);
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;
public class AnimationControlPlayer : AnimationControl
{
    // Start is called before the first frame update
    private CharacterKeyboardInputPlayer characterkeyboardinputPlayer;

    public override void Awake()
    {
        base.Awake();
        characterkeyboardinputPlayer = GetComponent<CharacterKeyboardInputPlayer>();

    }

    public override void Update()
    {
        base.Update();
        animator.SetBool("attack01", characterkeyboardinputPlayer.IsAttack01Pressed());
        animator.SetBool("attack02", characterkeyboardinputPlayer.IsAttack02Pressed());
    }



}

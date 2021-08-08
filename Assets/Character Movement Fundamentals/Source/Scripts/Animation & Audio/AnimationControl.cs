﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF
{
	//This script controls the character's animation by passing velocity values and other information ('isGrounded') to an animator component;
	[System.Serializable]
	public class AnimationControl : MonoBehaviour {

		protected Controller controller;
		protected Animator animator;
		protected Transform animatorTransform;
		protected Transform tr;

		//Whether the character is using the strafing blend tree;
		public bool useStrafeAnimations = false;
		private float smoothingFactor = 0.8f;
		Vector3 oldMovementVelocity = Vector3.zero;

		// cmq 添加

		private CharacterKeyboardInputPlayer characterkeyboardinputPlayer;
		//Setup;
		public virtual void Awake () {
			characterkeyboardinputPlayer = GetComponent<CharacterKeyboardInputPlayer>();

			controller = GetComponent<Controller>();
			animator = GetComponentInChildren<Animator>();
			animatorTransform = animator.transform;

			tr = transform;
		}

		//OnEnable;
		void OnEnable()
		{
			//Connect events to controller events;
			controller.OnLand += OnLand;
			controller.OnJump += OnJump;
		}

		//OnDisable;
		void OnDisable()
		{
			//Disconnect events to prevent calls to disabled gameobjects;
			controller.OnLand -= OnLand;
			controller.OnJump -= OnJump;
		}
		
		//Update;
		public virtual void Update () {

			//Get controller velocity;
			Vector3 _velocity = controller.GetVelocity();

			//Split up velocity;
			Vector3 _horizontalVelocity = VectorMath.RemoveDotVector(_velocity, tr.up);
			Vector3 _verticalVelocity = _velocity - _horizontalVelocity;

			//Smooth horizontal velocity for fluid animation;
			_horizontalVelocity = Vector3.Lerp(oldMovementVelocity, _horizontalVelocity, smoothingFactor); 
			oldMovementVelocity = _horizontalVelocity;
			animator.SetFloat("HorizontalSpeed", _horizontalVelocity.magnitude);

			animator.SetFloat("VerticalSpeed", _verticalVelocity.magnitude * VectorMath.GetDotProduct(_verticalVelocity.normalized, tr.up));

			//If animator is strafing, split up horizontal velocity;
			if(useStrafeAnimations)
			{   
				Vector3 _localVelocity = animatorTransform.InverseTransformVector(_horizontalVelocity);
				animator.SetFloat("ForwardSpeed", _localVelocity.z);
				animator.SetFloat("StrafeSpeed", _localVelocity.x);
			}

			//Pass values to animator;
			animator.SetBool("IsGrounded", controller.IsGrounded());
			animator.SetBool("IsStrafing", useStrafeAnimations);
			animator.SetBool("IsRunning", characterkeyboardinputPlayer.IsLeftShiftPressed());

        }


		void OnLand(Vector3 _v)
		{
			animator.SetTrigger("OnLand");
		}

		void OnJump(Vector3 _v)
		{
			
		}
	}
}

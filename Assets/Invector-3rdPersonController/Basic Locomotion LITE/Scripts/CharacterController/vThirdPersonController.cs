using UnityEngine;
using System.Collections;

namespace Invector.CharacterController
{
    public class vThirdPersonController : vThirdPersonAnimator
    { 
     
        protected virtual void Start()
        {
#if !UNITY_EDITOR
                Cursor.visible = true;
#endif
        }

        public virtual void Sprint(bool value)
        {                                   
            isSprinting = value;            
        }

        public virtual void Strafe()
        {
            if (locomotionType == LocomotionType.OnlyFree) return;
            isStrafing = !isStrafing;
        }

        public virtual void Jump()
        {
            if (animator.IsInTransition(0)) return;


            // conditions to do this action
            bool jumpConditions = true;

            // check if multi jump is possible
            if (MultiJump > 1)
            {
                // reset multi jump counter
                if (isGrounded) currentMultiJump = 0;

                // check if we reached the max jump value
                jumpConditions = jumpConditions && currentMultiJump < MultiJump;

                // increase multi jump counter
                if (jumpConditions)
                {
                    currentMultiJump++;
                    // zero out velocity before next jump
                    Vector3 jumpVelocity = _rigidbody.velocity;
                    jumpVelocity.y = 0f;
                    _rigidbody.velocity = jumpVelocity;
                }
            }
            else
            {
                // single jump conditions
                jumpConditions = jumpConditions && isGrounded && !isJumping;
            }

            // return if jumpConditions is false
            if (!jumpConditions) return;

            // trigger jump behaviour
            jumpCounter = jumpTimer;
            isJumping = true;

            // trigger jump animations
            if (speed < 0.1f)
                animator.CrossFadeInFixedTime("Jump", 0.1f);
            else
                animator.CrossFadeInFixedTime("JumpMove", 0.05f);

            //// reduce stamina
            //ReduceStamina(jumpStamina, false);
            //currentStaminaRecoveryDelay = 1f;
        }

        public virtual void RotateWithAnotherTransform(Transform referenceTransform)
        {
            var newRotation = new Vector3(transform.eulerAngles.x, referenceTransform.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(newRotation), strafeRotationSpeed * Time.fixedDeltaTime);
            targetRotation = transform.rotation;
        }
    }
}
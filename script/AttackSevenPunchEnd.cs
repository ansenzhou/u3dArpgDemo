using UnityEngine;
using System.Collections;

public class AttackSevenPunchEnd : AttackBase {

	public override void Init(FCObject owner)
	{
		_owner = owner as AIAgent;
	}
	
	public override void AttackEnter()
	{
		base.AttackEnter();
		_currentState = AttackBase.ATTACK_STATE.STEP_1;
		if(_owner.ACOwner.IsClientPlayer)
		{
			_owner._updateAttackRotation = true;
		}
	}
	
	protected override void AniOver()
	{
		_currentState = AttackBase.ATTACK_STATE.STEP_2;
		AttackEnd();
	}
	
	public override void IsHitTarget(ActionController ac,int sharpness)
	{
		base.IsHitTarget(ac,sharpness);
	}
	
	public override void AttackEnd()
	{
		base.AttackEnd();
	}
	
	protected override bool AKEvent(FC_KEY_BIND ekb, bool isPress)
	{
		return true;
	}
	
	public override bool DirectionKeyEvent(Vector3 direction, bool isPress)
	{
		return true;	
	}
	
	public override bool IsStopAtPoint()
	{
		return true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit : MonoBehaviour
{
	int hp;
	int damage;
	int defense;
	float speed;
	float attackTimeInterval;
	bool enableAttack;
	bool enableMove;
	CriticalHitBehavior chb = null;
	Attack mAttack;

	protected virtual void doAttack(Attack atk)
	{

	}

	public virtual int getPenetration() { return 0; }
	public virtual int getDamage() { return damage; }
	public virtual int getDefense() { return defense; }

	Attack getAttack()
	{
		mAttack.propertyUpdate();
		Attack atk = mAttack.clone();
		if(chb != null)
		{
			atk = chb.CriticalHit(atk);
			atk.penetration = 100;
		}
		return atk;
	}

	void attack()
	{
		doAttack(getAttack());
	}

	void takeAttack(Attack atk)
	{
		int def = getDefense() * (100 - atk.penetration) / 100;
		int dmg = atk.damage - def;
		if(dmg <= 0) dmg = 1;
		hp -= dmg;
		if(hp < 0)
		{
			Destroy(gameObject);
		}
	}
	
	// Use this for initialization
	void Start( )
	{
		mAttack = gameObject.GetComponent<Attack>();
	}

	// Update is called once per frame
	void FixedUpdate( )
	{
		
	}
}
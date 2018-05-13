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

	protected virtual void doAttack(Attack atk)
	{

	}

	protected virtual int getPenetration() { return 0; }
	protected virtual int getDamage() { return damage; }
	protected virtual int getDefense() { return defense; }

	Attack getAttack()
	{
		Attack atk = new Attack(getDamage(), getPenetration());
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

	}

	// Update is called once per frame
	void FixedUpdate( )
	{
		
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	Vector3 initialPosition;
	BattleUnit user;
	public int damage;
	public int penetration;

	public virtual void propertyUpdate()
	{
		damage = user.getDamage();
		penetration = user.getPenetration();
	}

	public Attack clone()
	{
		return this.MemberwiseClone() as Attack;
	}

	// Use this for initialization
	void Start( )
	{
		user = gameObject.GetComponent<BattleUnit>();
		damage = user.getDamage();
		penetration = user.getPenetration();
	}
}

using System.Collections;
using System.Collections.Generic;
using System;

public class CriticalHitBehavior
{
	public Attack CriticalHit(Attack atk)
	{
		//is that a critical hit?
		if(new Random().NextDouble() < getProb())
		{
			//yes, that is.
			atk = effect(atk);
		}
		return atk;
	}

	protected virtual double getProb()
	{
		return 0.05;
	}

	protected virtual Attack effect(Attack atk)
	{
		atk.damage *= 2;
		return atk;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IsDamageable
{
	void TakeDamage (float damageTaken);
	void Die();
	void Heal(float amountHealed);

}

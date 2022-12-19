using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
	//Important info
	public bool Alive { get; set; }

	//Resources
	public int Health { get; set; }
	public int Mana { get; set; }
	public int Gold { get; set; }
	public int Level { get; set; }
	public float Experience { get; set; }
	public int SkillPoints { get; set; }

	//Stats
	public int Vitality { get; set; }
	public int Strength { get; set; }
	public int Dexterity { get; set; }
	public int Accuracy { get; set; }
	public int Inteligence { get; set; }
	public int Wisdom { get; set; }

	//Values
	public int BaseHelth { get; set; }
	public int MaxHealth { get; }
	public int BaseMana { get; set; }
	public int MaxMana { get; }

	public int Armor { get; set; }
	public int Speed { get; set; }
	public int Dodge { get; set; }
	public int AttackRange { get; set; }
	public int AttackDamage { get; set; }
	public int AttackSpeed { get; set; }
	public int HealthRegen { get; set; }

	//Modifiers
	public float BonusExperience { get; set; }

	//Functions
	public void Takedamage(int damage, int accuracy);
	public void DealDamage(int damage, int accuracy, ICharacter target);
	public void Death();//potentially pass in something to determine earned xp/prestige points
}

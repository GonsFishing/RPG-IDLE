using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Characters
{
	abstract class Character : MonoBehaviour, ICharacter
	{
		protected GameController gameController;
		public ICharacter target;

		public virtual void Start()
		{
			gameController = GameObject.FindGameObjectsWithTag("GameController").SingleOrDefault().GetComponent<GameController>();
			gameController.BattleStart += OnBattleStart;
		}

		public abstract void OnBattleStart(object source, EventArgs e);

		public bool Alive { get; set; }

		//Resources
		public int Health { get; set; }
		public int Mana { get; set; }
		public int Gold { get; set; }
		public int SkillPoints { get; set; }
		public float Experience { get; set; }

		//Stats
		public int Vitality { get; set; }
		public int Strength { get; set; }
		public int Dexterity { get; set; }
		public int Inteligence { get; set; }
		public int Wisdom { get; set; }

		//Values
		public int MaxHealth { get => (int)Math.Floor(BaseHelth * Math.Pow(Vitality, 1.2)); } 
		public int MaxMana { get => (int)Math.Floor(BaseMana * Math.Pow(Inteligence, 1.2)); }

		public int Armor { get; set; }
		public int Speed { get; set; }
		public int Dodge { get; set; }
		public int AttackRange { get; set; }
		public int AttackDamage { get; set; }
		public int AttackSpeed { get; set; }
		public int HealthRegen { get; set; }
		public int BaseHelth { get; set; }
		public int BaseMana { get; set; }
		public float BonusExperience { get; set; }

		private int LevelDifferenceAccuracyBonus { get; set; }
		public int Accuracy { get; set; }
		public int Level { get; set; }

		protected IEnumerator Attack(ICharacter target)
		{
			Debug.Log("Attack Start");
			yield return new WaitForSeconds(1/AttackSpeed);
			target.DealDamage(AttackDamage, Accuracy, target);
			Debug.Log("Attack End");
		}

		public void DealDamage(int damage, int accuracy, ICharacter target)
		{
			target.Takedamage(damage, accuracy + (Level - target.Level) * LevelDifferenceAccuracyBonus);
		}

		public void Takedamage(int damage, int accarucy)
		{
			if (gameController.GenerateRandomNumber(100) >= Dodge - accarucy)
			{
				Health -= (damage - Armor);
			}
		}

		public abstract void Death();
	}
}

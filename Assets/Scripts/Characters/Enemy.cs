using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Characters
{
	class Enemy : Character
	{
		public override void OnBattleStart(object source, EventArgs e)
		{
			//throw new NotImplementedException();
		}

		public override void Death()
		{
			//spawn coins
			Destroy(gameObject);
		}
	}
}

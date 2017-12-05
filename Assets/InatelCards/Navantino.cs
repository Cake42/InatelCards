namespace InatelCards
{
	using UnityEngine;

	public class Navantino : Professor
	{
		private static Sprite sprite;

		public override int DefaultAttack
		{
			get { return 60; }
		}

		public override int DefaultDefense
		{
			get { return 40; }
		}

		public override Sprite Sprite
		{
			get { return Navantino.sprite; }
		}

		public override int Probability
		{
			get { return 1; }
		}

		protected override void Awake()
		{
			base.Awake();

			if (Navantino.sprite == null)
			{
				Navantino.sprite = Navantino.Load("Navantino");
			}
		}
	}
}

namespace InatelCards
{
	using UnityEngine;

	public class Ynoguti : Professor
	{
		private static Sprite sprite;

		public override int DefaultAttack
		{
			get { return 30; }
		}

		public override int DefaultDefense
		{
			get { return 15; }
		}

		public override Sprite Sprite
		{
			get { return Ynoguti.sprite; }
		}

		public override int Probability
		{
			get { return 45; }
		}

		protected override void Awake()
		{
			base.Awake();

			if (Ynoguti.sprite == null)
			{
				Ynoguti.sprite = Card.Load("Ynoguti");
			}
		}
	}
}

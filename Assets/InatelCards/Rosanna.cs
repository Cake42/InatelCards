namespace InatelCards
{
	using UnityEngine;

	public class Rosanna : Professor
	{
		private static Sprite sprite;

		public override int DefaultAttack
		{
			get { return 20; }
		}

		public override int DefaultDefense
		{
			get { return 30; }
		}

		public override Sprite Sprite
		{
			get { return Rosanna.sprite; }
		}

		public override int Probability
		{
			get { return 40; }
		}

		protected override void Awake()
		{
			base.Awake();
			
			if (Rosanna.sprite == null)
			{
				Rosanna.sprite = Card.Load("Rosanna");
			}
		}
	}
}

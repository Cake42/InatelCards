namespace InatelCards
{
	using UnityEngine;

	public class Marcelo : Professor
	{
		private static Sprite sprite;

		public override int DefaultAttack
		{
			get { return 50; }
		}

		public override int DefaultDefense
		{
			get { return 40; }
		}

		public override Sprite Sprite
		{
			get { return Marcelo.sprite; }
		}

		public override int Probability
		{
			get { return 2; }
		}

		protected override void Awake()
		{
			base.Awake();

			if (Marcelo.sprite == null)
			{
				Marcelo.sprite = Card.Load("Marcelo");
			}
		}
	}
}

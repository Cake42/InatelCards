namespace InatelCards
{
	using UnityEngine;

	public class Dani : Professor
	{
		private static Sprite sprite;

		public override int DefaultAttack
		{
			get { return 40; }
		}

		public override int DefaultDefense
		{
			get { return 25; }
		}

		public override Sprite Sprite
		{
			get { return Dani.sprite; }
		}

		public override int Probability
		{
			get { return 15; }
		}

		protected override void Awake()
		{
			base.Awake();

			if (Dani.sprite == null)
			{
				Dani.sprite = Card.Load("Dani");
			}
		}
	}
}

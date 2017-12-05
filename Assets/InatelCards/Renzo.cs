namespace InatelCards
{
	using UnityEngine;

	public class Renzo : Professor
	{
		private static Sprite sprite;

		public override int DefaultAttack
		{
			get { return 15; }
		}

		public override int DefaultDefense
		{
			get { return 20; }
		}

		public override Sprite Sprite
		{
			get { return Renzo.sprite; }
		}

		public override int Probability
		{
			get { return 60; }
		}

		protected override void Awake()
		{
			base.Awake();

			if (Renzo.sprite == null)
			{
				Renzo.sprite = Card.Load("Renzo");
			}
		}
	}
}

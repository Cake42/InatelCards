namespace InatelCards
{
	using UnityEngine;

	public class Karina : Professor
	{
		private static Sprite sprite;

		public override int DefaultAttack
		{
			get { return 25; }
		}

		public override int DefaultDefense
		{
			get { return 30; }
		}

		public override Sprite Sprite
		{
			get { return Karina.sprite; }
		}

		public override int Probability
		{
			get { return 45; }
		}

		protected override void Awake()
		{
			base.Awake();

			if (Karina.sprite == null)
			{
				Karina.sprite = Karina.Load("Karina");
			}
		}
	}
}

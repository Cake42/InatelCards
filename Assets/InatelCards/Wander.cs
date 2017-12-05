namespace InatelCards
{
	using UnityEngine;

	public class Wander : Professor
	{
		private static Sprite sprite;

		public override int DefaultAttack
		{
			get { return 30; }
		}

		public override int DefaultDefense
		{
			get { return 30; }
		}

		public override Sprite Sprite
		{
			get { return Wander.sprite; }
		}

		public override int Probability
		{
			get { return 35; }
		}

		protected override void Awake()
		{
			base.Awake();

			if (Wander.sprite == null)
			{
				Wander.sprite = Wander.Load("Wander");
			}
		}
	}
}

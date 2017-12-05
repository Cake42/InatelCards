namespace InatelCards
{
	using UnityEngine;

	public class Felipe : Professor
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
			get { return Felipe.sprite; }
		}

		public override int Probability
		{
			get { return 30; }
		}

		protected override void Awake()
		{
			base.Awake();

			if (Felipe.sprite == null)
			{
				Felipe.sprite = Card.Load("Felipe");
			}
		}
	}
}

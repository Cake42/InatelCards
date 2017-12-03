namespace InatelCards
{
	using UnityEngine;

	public class Rosanna : Professor
	{
		private Sprite sprite;

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
			get { return this.sprite; }
		}

		public override int Probability
		{
			get { return 40; }
		}

		protected override void Awake()
		{
			base.Awake();
			this.sprite = Card.Load("Rosanna");
		}
	}
}

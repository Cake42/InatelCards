namespace InatelCards
{
	using UnityEngine;

	public class Ynoguti : Professor
	{
		private Sprite sprite;

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
			get { return this.sprite; }
		}

		protected override void Awake()
		{
			base.Awake();
			this.sprite = Card.Load("Ynoguti");
		}
	}
}

namespace InatelCards
{
	using UnityEngine;

	public class Guilherme : Professor
	{
		private Sprite sprite;

		public override int DefaultAttack
		{
			get { return 40; }
		}

		public override int DefaultDefense
		{
			get { return 35; }
		}

		public override Sprite Sprite
		{
			get { return this.sprite; }
		}

		protected override void Awake()
		{
			base.Awake();
			this.sprite = Card.Load("Guilherme");
		}
	}
}

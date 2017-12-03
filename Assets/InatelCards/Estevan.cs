namespace InatelCards
{
	using UnityEngine;

	public class Estevan : Professor
	{
		private Sprite sprite;

		public override int DefaultAttack
		{
			get { return 20; }
		}

		public override int DefaultDefense
		{
			get { return 10; }
		}

		public override Sprite Sprite
		{
			get { return this.sprite; }
		}

		public override int Probability
		{
			get { return 55; }
		}

		protected override void Awake()
		{
			base.Awake();
			this.sprite = Card.Load("Estevan");
		}
	}
}

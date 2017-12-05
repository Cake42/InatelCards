namespace InatelCards
{
	using UnityEngine;

	public class Luiz : Professor
	{
		private static Sprite sprite;

		public override int DefaultAttack
		{
			get { return 25; }
		}

		public override int DefaultDefense
		{
			get { return 10; }
		}

		public override Sprite Sprite
		{
			get { return Luiz.sprite; }
		}

		public override int Probability
		{
			get { return 55; }
		}

		protected override void Awake()
		{
			base.Awake();

			if (Luiz.sprite == null)
			{
				Luiz.sprite = Luiz.Load("Luiz");
			}
		}
	}
}

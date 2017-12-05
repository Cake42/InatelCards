namespace InatelCards
{
	using UnityEngine;

	public class João : Professor
	{
		private static Sprite sprite;

		public override int DefaultAttack
		{
			get { return 35; }
		}

		public override int DefaultDefense
		{
			get { return 30; }
		}

		public override Sprite Sprite
		{
			get { return João.sprite; }
		}

		public override int Probability
		{
			get { return 35; }
		}

		protected override void Awake()
		{
			base.Awake();

			if (João.sprite == null)
			{
				João.sprite = João.Load("João");
			}
		}
	}
}

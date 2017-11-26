namespace InatelCards
{
	using UnityEngine;

	public class Renzo : Professor
	{
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
			get
			{
				return Sprite.Create(
					Resources.Load<Texture2D>("Renzo"),
					new Rect(0f, 0f, 100f, 200f),
					new Vector2(0, 0));
			}
		}
	}
}

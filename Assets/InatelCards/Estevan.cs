namespace InatelCards
{
	using UnityEngine;

	public class Estevan : Professor
	{
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
			get
			{
				return Sprite.Create(
					Resources.Load<Texture2D>("Estevan"),
					new Rect(0f, 0f, 100f, 200f),
					new Vector2(0, 0));
			}
		}
	}
}

namespace InatelCards
{
    using UnityEngine;
    
    public abstract class Card : MonoBehaviour
    {
		private static Sprite backSprite;
		
		private static Card[] cardTypes;

		public static Sprite BackSprite
		{
			get { return Card.backSprite; }
		}

		/// <summary>
		/// Gets a randomly generated card, based on the professor's probability.
		/// </summary>
		/// <value>A randomly generated card.</value>
		public static Card RandomCard
		{
			get
			{
				if (Card.cardTypes == null)
				{
					Card.cardTypes = new Card[]
					{
						Resources.Load<Estevan>("Prefabs/Estevan"),
						Resources.Load<Guilherme>("Prefabs/Guilherme"),
						Resources.Load<Marcelo>("Prefabs/Marcelo"),
						Resources.Load<Renzo>("Prefabs/Renzo"),
						Resources.Load<Rosanna>("Prefabs/Rosanna"),
						Resources.Load<Ynoguti>("Prefabs/Ynoguti")
					};
				}
				
				Card card = MonoBehaviour.Instantiate(
					Card.cardTypes[Random.Range(0, Card.cardTypes.Length)]);

				int probability = Random.Range(0, 101);
				if (100 - card.Probability <= probability)
				{
					return card;
				}
				else
				{
					card.Kill();
					return Card.RandomCard;
				}
			}
		}

		public CardMode CardMode { get; set; }

		public abstract Sprite Sprite { get; }

		public abstract int Probability { get; }

		internal Location CardLocation { get; set; }

		internal int Index { get; set; }

		public void Hide()
		{
			this.GetComponent<SpriteRenderer>().sprite = Card.BackSprite;
		}

		/*public void PlayMoveToTable()
		{
			this.GetComponent<Animator>().SetTrigger("DoMoveToTable");
		}*/

		public void Kill()
		{
			MonoBehaviour.Destroy(this.gameObject);
		}

		public void PlaySelect()
		{
			this.GetComponent<Animator>().SetTrigger("DoSelect");
			this.GetComponent<SpriteRenderer>().sortingOrder = 20;
		}

		public void PlayUnselect()
		{
			this.GetComponent<Animator>().SetTrigger("DoUnselect");
			this.GetComponent<SpriteRenderer>().sortingOrder = this.Index;
		}

		public void Unhide()
		{
			this.GetComponent<SpriteRenderer>().sprite = this.Sprite;
		}

		protected static Sprite Load(string name)
		{
			Texture2D texture = Resources.Load<Texture2D>(name);
			return Sprite.Create(
				texture,
				new Rect(0, 0, texture.width, texture.height),
				new Vector2(0, 0));
		}

		protected virtual void Awake()
		{
			if (Card.backSprite == null)
			{
				Card.backSprite = Card.Load("Back");
			}
		}
	}
}

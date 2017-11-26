namespace InatelCards
{
    using System;
    using UnityEngine;
    
    public abstract class Card : MonoBehaviour
    {
		public static Sprite BackSprite
		{
			get
			{
				return Sprite.Create(
					Resources.Load<Texture2D>("Back"),
					new Rect(0f, 0f, 100f, 200f),
					new Vector2(0, 0));
			}
		}

		public CardMode CardMode { get; set; }

		public bool MovedToTable { get; set; }

		public Player Owner { get; set; }

		public abstract Sprite Sprite { get; }

		public static Card CreateCard(ProfessorCards professor)
		{
			GameObject go;

			switch (professor)
			{
				case ProfessorCards.Estevan:
					go = new GameObject("Estevan", typeof(Estevan));
					return go.GetComponent<Estevan>();

				case ProfessorCards.Renzo:
					go = new GameObject("Renzo", typeof(Renzo));
					return go.GetComponent<Renzo>();

				default:
					throw new ArgumentOutOfRangeException("Unknown professor!");
			}
		}

		public void Kill(Player killer)
		{
			killer.Score += 100;
			MonoBehaviour.Destroy(this.gameObject);
		}

		public void PlaySelect()
		{
			this.GetComponent<Animator>().SetTrigger("DoSelect");
		}

		public void PlayUnselect()
		{
			this.GetComponent<Animator>().SetTrigger("DoUnselect");
		}

		public void PlayMoveToTable()
		{
			this.GetComponent<Animator>().SetTrigger("DoMoveToTable");
		}

		public void Hide()
		{
			this.GetComponent<SpriteRenderer>().sprite = Card.BackSprite;
		}

		public void Unhide()
		{
			this.GetComponent<SpriteRenderer>().sprite = this.Sprite;
		}
	}
}

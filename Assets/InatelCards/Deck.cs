namespace InatelCards
{
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	public class Deck
	{
		public const int DefaultCardQuantity = 8;

        private readonly Player owner;
        private int currentCard;
		
		public Deck(Player owner)
		{
			this.Cards = new List<Card>(DefaultCardQuantity);
			this.owner = owner;
		}

		public int CurrentCard
		{
			get
			{
				return this.currentCard;
			}

			set
			{
				/*if (value < 0)
				{
					this.currentCard = (this.Cards.Length - value) % this.Cards.Length;
				}
				else if (value >= this.Cards.Length)
				{
					this.currentCard = (this.Cards.Length + value) % this.Cards.Length;
				}
				else
				{
					this.currentCard = value;
				}*/

				if (value < 0)
				{
					this.currentCard = this.Cards.Count - 1;
				}
				else if (value >= this.Cards.Count)
				{
					this.currentCard = 0;
				}
				else
				{
					this.currentCard = value;
				}

				//Debug.Log("Valor: " + value);
				Debug.Log("Carta atual: " + this.currentCard);
			}
		}

		public List<Card> Cards { get; set; }
        
		public void DrawCards()
		{
			for (int i = 0; i < Deck.DefaultCardQuantity; i++)
			{
				/*Card card = Card.CreateCard((
					ProfessorCards)UnityEngine.Random.Range(
						0,
						Enum.GetValues(typeof(ProfessorCards)).Length));*/

				Card card = MonoBehaviour.Instantiate(
					this.owner.GameController.CardTypes[UnityEngine.Random.Range(
						0, this.owner.GameController.CardTypes.Length)]);
				card.transform.parent = this.owner.transform;

				if (this.owner.PlayerNumber == 1)
				{
					card.transform.localPosition = new Vector2(i - 3.5f, -5);
				}
				else
				{
                    card.transform.Rotate(0, 0, 180);
					card.transform.localPosition = new Vector2(i - 3, 6);
					card.GetComponentInChildren<SpriteRenderer>().sprite = Sprite.Create(
						Resources.Load<Texture2D>("Back"),
						new Rect(0f, 0f, 100f, 200f),
						new Vector2(0, 0));
				}
				
				this.Cards.Add(card);
			}
		}

		public Card AddRandomCard()
		{
			Card card = MonoBehaviour.Instantiate(
					this.owner.GameController.CardTypes[UnityEngine.Random.Range(
						0, this.owner.GameController.CardTypes.Length)]);
			card.transform.parent = this.owner.transform;

			card.transform.localPosition = new Vector3(this.Cards.Count - 3.5f, -5);

			return card;
		}

        public void MoveToTable(int cardIndex)
        {
            Card card = this.Cards[cardIndex];
            Table.AddCard(card);
            this.Cards.Remove(card);

			card.transform.localPosition += new Vector3(0, 5);
        }

		public void MoveToTable(Card card)
		{
			Table.AddCard(card);
			this.Cards.Remove(card);

			card.transform.localPosition += new Vector3(0, 5);
		}
	}
}

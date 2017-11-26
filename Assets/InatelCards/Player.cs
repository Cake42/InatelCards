namespace InatelCards
{
	using System.Collections.Generic;
	using UnityEngine;

	public class Player : MonoBehaviour
	{
		public const int DefaultCardQuantity = 8;

		private List<Card> cards;

		private int currentCardIndex;

		private Transform deckTransform;

		[SerializeField]
		private GameController gameController;

		private int movedToTable;
		
		private PlayerNumber playerNumber;

		private Card previousCard;

		public Card CurrentCard
		{
			get { return this.cards[this.currentCardIndex]; }
			set { this.cards[this.currentCardIndex] = value; }
		}

		public int CurrentCardIndex
		{
			get
			{
				return this.currentCardIndex;
			}

			set
			{
				if (value < 0)
				{
					this.currentCardIndex = this.cards.Count - 1;
				}
				else if (value >= this.cards.Count)
				{
					this.currentCardIndex = 0;
				}
				else
				{
					this.currentCardIndex = value;
				}
			}
		}

		public PlayerNumber PlayerNumber
		{
			get { return this.playerNumber; }
		}

		public bool IsCurrentPlayer
		{
			get { return this.gameController.CurrentPlayer == this.PlayerNumber; }
		}

		public int CardQuantity
		{
			get { return this.cards.Count; }
		}

		public int Score { get; set; }

		/// <summary>
		/// Recalculates the position of all cards on the deck so that they are
		/// placed in their correct position, and change the cards
		/// <see cref="Sprite"/>, all accordingly to the <paramref name="main"/>
		/// parameter.
		/// </summary>
		/// <param name="main">Indicates whether the cards should be on the
		/// main deck (bottom deck) or secondary deck (top deck).</param>
		internal void SetPosition(bool main)
		{
			int correction = 0;
			for (int i = 0; i < this.cards.Count; i++)
			{
				Card card = this.cards[i];

				if (!card.MovedToTable)
				{
					if (main)
					{
						card.transform.position = new Vector3(i - correction - 3.5f, -5);
						card.Unhide();
						card.GetComponent<SpriteRenderer>().flipX = false;
					}
					else
					{
						card.transform.position = new Vector3(i - correction - 3, 5);
						card.Hide();
						card.GetComponent<SpriteRenderer>().flipX = true;
					}
				}
				else
				{
					correction++;
				}
			}
		}

		internal void ReturnCards(Card card1, Card card2)
		{
			this.cards.Add(card1);
			this.cards.Add(card2);

			if (this.IsCurrentPlayer)
			{
				card1.Unhide();
				card2.Unhide();
			}
			
			this.SetPosition(this.IsCurrentPlayer);
		}

		private void Awake()
		{
			this.cards = new List<Card>(Player.DefaultCardQuantity);
			this.deckTransform = this.transform.GetChild(0);
			this.playerNumber = this.gameObject.name == "Player1"
				? PlayerNumber.Player1
				: PlayerNumber.Player2;
		}

		private void DrawCards()
		{
			for (int i = 0; i < Player.DefaultCardQuantity; i++)
			{
				Card card = MonoBehaviour.Instantiate(
					this.gameController.CardTypes[Random.Range(
						0,
						this.gameController.CardTypes.Length)]);
				card.transform.parent = this.deckTransform;
				card.Owner = this;

				this.cards.Add(card);
			}
		}

		private void MoveToTable(int cardIndex)
		{
			Card card = this.cards[cardIndex];
			this.gameController.Table.AddCard(this.playerNumber, card);
			card.transform.parent = this.gameController.Table.transform;
			card.MovedToTable = true;
			card.PlayUnselect();
			card.PlayMoveToTable();
			card.Hide();
			this.cards.RemoveAt(cardIndex);
		}

		private void Start()
		{
			this.DrawCards();

			if (this.playerNumber == PlayerNumber.Player1)
			{
				this.SetPosition(true);
				this.CurrentCard.PlaySelect();
			}
			else
			{
				this.SetPosition(false);
			}
		}

		private void Update()
		{
			if (!this.IsCurrentPlayer)
			{
				return;
			}

			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				this.previousCard = this.CurrentCard;
				this.previousCard.PlayUnselect();

				Card card = this.cards[--this.CurrentCardIndex];
				card.PlaySelect();
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				this.previousCard = this.CurrentCard;
				this.previousCard.PlayUnselect();

				Card card = this.cards[++this.CurrentCardIndex];
				card.PlaySelect();
			}
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                this.MoveToTable(this.currentCardIndex);
				this.SetPosition(true);
				this.movedToTable++;

				if (this.movedToTable == 2)
				{
					this.movedToTable = 0;
					this.gameController.ChangeTurn();
				}
			}
		}
	}
}

namespace InatelCards
{
	using System.Collections.Generic;
	using UnityEngine;

	[DisallowMultipleComponent]
	public class Player : MonoBehaviour
	{
		public const int DefaultCardQuantity = 6;

		private List<Card> cards;

		private int currentCardIndex;

		[SerializeField]
		private GameController gameController;

		private int movedToTable;
		
		private PlayerNumber playerNumber;

		private Card previousCard;

		private bool confirmTurn;

		public int CardQuantity
		{
			get { return this.cards.Count; }
		}

		public Card CurrentCard
		{
			get
			{
				return this.cards[Mathf.Clamp(this.currentCardIndex, 0, this.CardQuantity - 1)];
			}

			set
			{
				this.cards[Mathf.Clamp(this.currentCardIndex, 0, this.CardQuantity - 1)] = value;
			}
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

		public bool IsCurrentPlayer
		{
			get { return this.gameController.CurrentPlayer == this.PlayerNumber; }
		}

		public PlayerNumber PlayerNumber
		{
			get { return this.playerNumber; }
		}

		public int Score { get; set; }

		internal bool IsSuspended { get; set; }

		internal void ReturnCards(params Card[] cards)
		{
			foreach (Card card in cards)
			{
				card.transform.parent = this.transform;
				card.CardLocation = Location.Deck;
				this.cards.Add(card);
			}

			this.IsSuspended = false;
			this.ResetPosition();
		}

		/// <summary>
		/// Recalculates the position of all cards on the deck so that they are
		/// placed in their correct positions.
		/// </summary>
		internal void ResetPosition()
		{
			const float CardSpacing = 5;
			
			for (int i = 0; i < this.cards.Count; i++)
			{
				Card card = this.cards[i];

				if (card.CardLocation == Location.Deck)
				{
					card.Index = i;
					card.GetComponent<SpriteRenderer>().sortingOrder = i;
					card.transform.rotation = card.transform.parent.rotation;
					card.transform.localPosition = new Vector3(i * CardSpacing, 0);
				}
			}
		}

		internal void HideCards()
		{
			foreach (Card card in this.cards)
			{
				card.Hide();
			}
		}

		internal void UnhideCards()
		{
			foreach (Card card in this.cards)
			{
				card.Unhide();
			}
		}

		private void Awake()
		{
			this.cards = new List<Card>(Player.DefaultCardQuantity);
			this.playerNumber = this.gameObject.name == "Player1"
				? PlayerNumber.Player1
				: PlayerNumber.Player2;
		}

		private void DrawCards()
		{
			for (int i = 0; i < Player.DefaultCardQuantity; i++)
			{
				Card card = Card.RandomCard;
				card.transform.parent = this.transform;

				this.cards.Add(card);
			}

			this.ResetPosition();
		}

		private void MoveToTable(int cardIndex)
		{
			Card card = this.cards[cardIndex];
			card.transform.parent = this.gameController.Table.transform;
			card.CardLocation = Location.Table;
			card.PlayUnselect();
			card.Hide();
			this.cards.RemoveAt(cardIndex);

			if (cardIndex == this.CardQuantity)
			{
				this.CurrentCardIndex--;
			}
			
			this.ResetPosition();
			if (this.IsCurrentPlayer)
			{
				this.UnhideCards();
			}
			else
			{
				this.HideCards();
			}

			this.gameController.Table.AddCard(this.playerNumber, card);
		}

		private void Start()
		{
			this.DrawCards();
		}

		private void Update()
		{
			if (!this.IsCurrentPlayer || this.IsSuspended)
			{
				return;
			}

			if (!this.confirmTurn)
			{
				if (Input.GetKeyDown(KeyCode.Return))
				{
					this.confirmTurn = true;
					this.UnhideCards();
					this.CurrentCard.PlaySelect();
				}
				
				return;
			}

			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				this.previousCard = this.CurrentCard;
				this.previousCard.PlayUnselect();

				this.CurrentCardIndex--;
				this.cards[this.CurrentCardIndex].PlaySelect();
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				this.previousCard = this.CurrentCard;
				this.previousCard.PlayUnselect();

				this.CurrentCardIndex++;
				this.cards[this.CurrentCardIndex].PlaySelect();
			}
            else if (Input.GetKeyDown(KeyCode.Return))
            {
				this.MoveToTable(this.currentCardIndex);
				this.movedToTable++;

				if (this.movedToTable == 2)
				{
					this.movedToTable = 0;
					this.gameController.ChangeTurn();
					this.confirmTurn = false;
				}
				else
				{
					this.CurrentCard.PlaySelect();
				}
			}
		}
	}
}

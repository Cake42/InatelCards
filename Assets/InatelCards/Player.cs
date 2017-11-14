namespace InatelCards
{
	using System.Collections.Generic;
	using UnityEngine;

	public class Player : MonoBehaviour
	{
		public const int DefaultCardQuantity = 8;
		
		private int currentCardIndex;

		[SerializeField]
		private GameController gameController;

		[SerializeField]
		private PlayerNumber playerNumber;

		private Card previousCard;

		public List<Card> Cards { get; set; }

		public Card CurrentCard
		{
			get
			{
				return this.Cards[this.currentCardIndex];
			}

			set
			{
				this.Cards[this.currentCardIndex] = value;
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
					this.currentCardIndex = this.Cards.Count - 1;
				}
				else if (value >= this.Cards.Count)
				{
					this.currentCardIndex = 0;
				}
				else
				{
					this.currentCardIndex = value;
				}

				////Debug.Log("Valor: " + value);
				Debug.Log("Carta atual: " + this.currentCardIndex);
			}
		}
		
		public GameController GameController
		{
			get
			{
				return this.gameController;
			}

			set
			{
				this.gameController = value;
			}
		}

		public PlayerNumber PlayerNumber
		{
			get
			{
				return this.playerNumber;
			}

			set
			{
				this.playerNumber = value;
			}
		}

		public int Score { get; set; }

		public Card AddRandomCard()
		{
			Card card = MonoBehaviour.Instantiate(
				this.GameController.CardTypes[Random.Range(
					0,
					this.GameController.CardTypes.Length)]);

			card.transform.parent = this.transform;
			card.transform.localPosition = new Vector3(this.Cards.Count - 3.5f, -5);

			return card;
		}

		public void DrawCards()
		{
			for (int i = 0; i < Player.DefaultCardQuantity; i++)
			{
				/*Card card = Card.CreateCard((
					ProfessorCards)UnityEngine.Random.Range(
						0,
						Enum.GetValues(typeof(ProfessorCards)).Length));*/

				Card card = MonoBehaviour.Instantiate(
					this.GameController.CardTypes[UnityEngine.Random.Range(
						0, this.GameController.CardTypes.Length)]);
				card.transform.parent = this.transform;

				if (this.PlayerNumber == PlayerNumber.Player1)
				{
					card.transform.localPosition = new Vector3(i - 3.5f, 0);
				}
				else
				{
					card.transform.localPosition = new Vector3(i - 3, 0);
					card.GetComponent<SpriteRenderer>().sprite = Sprite.Create(
						Resources.Load<Texture2D>("Back"),
						new Rect(0f, 0f, 100f, 200f),
						new Vector2(0, 0));
					card.GetComponent<SpriteRenderer>().flipX = true;
				}

				this.Cards.Add(card);
			}
		}

		public void MoveToTable(int cardIndex)
		{
			Card card = this.Cards[cardIndex];
			Table.AddCard(this.playerNumber, card);
			this.Cards.Remove(card);

			card.transform.localPosition += new Vector3(0, 5);
		}

		public void MoveToTable(Card card)
		{
			Table.AddCard(this.playerNumber, card);
			this.Cards.Remove(card);

			card.transform.localPosition += new Vector3(0, 5);
		}
		private void Awake()
		{
			this.Cards = new List<Card>(Player.DefaultCardQuantity);
		}

		private void Start()
		{
			this.DrawCards();
		}

		private void Update()
		{
			if (this.gameController.CurrentPlayer != this.PlayerNumber)
			{
				return;
			}

			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				this.previousCard = this.Cards[this.CurrentCardIndex];
				this.previousCard.GetComponent<Animator>().SetTrigger("DoUnselect");

				Card card = this.Cards[--this.CurrentCardIndex];
				card.GetComponent<Animator>().SetTrigger("DoSelect");
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				this.previousCard = this.Cards[this.CurrentCardIndex];
				this.previousCard.GetComponent<Animator>().SetTrigger("DoUnselect");

				Card card = this.Cards[++this.CurrentCardIndex];
				card.GetComponent<Animator>().SetTrigger("DoSelect");
			}
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                this.MoveToTable(this.CurrentCard);
            }

			if (Input.GetMouseButtonDown(0))
			{
				Card card = Utils.GetMouseHit().collider.GetComponent<Card>();

				if (card != null)
				{
					this.CurrentCard = card;
					this.MoveToTable(card);
				}
			}
		}
	}
}

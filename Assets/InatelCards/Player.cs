namespace InatelCards
{
	using UnityEngine;

	public class Player : MonoBehaviour
	{
		[SerializeField]
		private GameController gameController;

        private int playerNumber;

		public int Score { get; set; }
		
		public Deck Deck { get; set; }

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

		public int PlayerNumber
		{
			get
			{
				return this.gameObject.name[this.gameObject.name.Length - 1] - '0';
			}
		}

        public void Initialize(int playerNumber)
        {
            this.playerNumber = playerNumber;
        }

		private void Awake()
		{
			this.Deck = new Deck(this);
		}

		private void Start()
		{
			this.Deck.DrawCards();
		}

		private void Update()
		{
			if (gameController.CurrentPlayer != PlayerNumber)
			{
				return;
			}

			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				this.Deck.CurrentCard--;
                Card card = this.Deck.Cards[this.Deck.CurrentCard];
                //card.GetComponentInChildren<Animation>().Play("Select");
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
                Card card = this.Deck.Cards[this.Deck.CurrentCard];
                //card.GetComponentInChildren<Animation>().Play("Unselect");
				this.Deck.CurrentCard++;
			}
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                this.Deck.MoveToTable(this.Deck.CurrentCard);
            }

			if (Input.GetMouseButtonDown(0))
			{
				Card card = Utils.GetMouseHit().collider.gameObject.GetComponent<Card>();
				if (card != null)
				{
					this.Deck.MoveToTable(card);
				}
			}
		}
	}
}

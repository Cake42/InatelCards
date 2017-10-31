namespace InatelCards
{
	using UnityEngine;

	public class GameController : MonoBehaviour
	{
		[SerializeField]
		private Card[] cardTypes;

        [SerializeField]
        private Player player1;

        [SerializeField]
        private Player player2;

        private int currentPlayer;

		public int CurrentPlayer
		{
			get
			{
				return this.currentPlayer;
			}
		}

		public Card[] CardTypes
		{
			get
			{
				return this.cardTypes;
			}

			set
			{
				this.cardTypes = value;
			}
		}

        public Player Player1
        {
            get
            {
                return this.player1;
            }

            set
            {
                this.player1 = value;
            }
        }

        public Player Player2
        {
            get
            {
                return this.player2;
            }

            set
            {
                this.player2 = value;
            }
        }
        
		private void Start()
		{
            this.currentPlayer = 1;
            this.player1.Initialize(1);
            this.player2.Initialize(2);
        }

		private void Update()
		{
			
		}
	}
}

namespace InatelCards
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    
    public abstract class Card : MonoBehaviour
    {
		public CardMode CardMode { get; set; }

		public Player Owner { get; set; }

		public static Card CreateCard(ProfessorCards professor)
		{
			GameObject go;

			switch (professor)
			{
				case ProfessorCards.Estevan:
					go = new GameObject("Estevan", typeof(Estevan));
					return go.GetComponentInChildren<Estevan>();

				case ProfessorCards.Renzo:
					go = new GameObject("Renzo", typeof(Renzo));
					return go.GetComponentInChildren<Renzo>();

				default:
					throw new ArgumentOutOfRangeException("Unknown professor!");
			}
		}
    }
}

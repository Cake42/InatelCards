namespace InatelCards
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(MeshRenderer), typeof(MeshCollider))]
    public abstract class Card : MonoBehaviour
    {
        public static Card CreateCard(ProfessorCards professor)
		{
			switch (professor)
			{
				case ProfessorCards.Estevan:
					return new Estevan();

				default:
					throw new System.ArgumentOutOfRangeException("Unknown professor!");
			}
		}

        void Start()
        {
            
        }

        
        void Update()
        {

        }
    }
}

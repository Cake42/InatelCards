namespace InatelCards
{
	using UnityEngine;

	public static class Utils
	{
		public static RaycastHit GetMouseHit()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast(ray, out hit);
			return hit;
		}
	}
}

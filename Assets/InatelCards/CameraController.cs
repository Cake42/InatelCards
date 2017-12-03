namespace InatelCards
{
	using UnityEngine;

	[DisallowMultipleComponent]
	public class CameraController : MonoBehaviour
	{
		private static readonly Vector3 CenterPosition = Vector3.back * 10;

		private static readonly Vector3 CenterRotation = Vector3.zero;

		private static readonly Vector3 LeftPosition = new Vector3(-30, 0, -10);

		private static readonly Vector3 LeftRotation = Vector3.forward * 270;

		private static readonly Vector3 RightPosition = new Vector3(30, 0, -10);

		private static readonly Vector3 RightRotation = Vector3.forward * 90;

		private PlayerNumber state;

		/// <summary>
		/// Moves the camera's transform to the proper place, when changing turn.
		/// </summary>
		internal void Next()
		{
			if (this.state == PlayerNumber.Player1)
			{
				this.state = PlayerNumber.Player2;
			}
			else if (this.state == PlayerNumber.Player2)
			{
				this.state = PlayerNumber.None;
			}
			else
			{
				this.state = PlayerNumber.Player1;
			}
		}

		private void Awake()
		{
			this.state = PlayerNumber.None;
			Camera.main.transform.position = CameraController.CenterPosition;
			Camera.main.transform.eulerAngles = CameraController.CenterRotation;
		}

		private void LateUpdate()
		{
			if (this.state == PlayerNumber.Player1)
			{
				Camera.main.transform.eulerAngles = Vector3.Slerp(
					Camera.main.transform.eulerAngles,
					CameraController.LeftRotation,
					Time.deltaTime);
				Camera.main.transform.position = Vector3.Lerp(
					Camera.main.transform.position,
					CameraController.LeftPosition,
					Time.deltaTime);
			}
			else if (this.state == PlayerNumber.Player2)
			{
				Camera.main.transform.eulerAngles = Vector3.Slerp(
					Camera.main.transform.eulerAngles,
					CameraController.RightRotation,
					Time.deltaTime);
				Camera.main.transform.position = Vector3.Lerp(
					Camera.main.transform.position,
					CameraController.RightPosition,
					Time.deltaTime);
			}
			else
			{
				Camera.main.transform.eulerAngles = Vector3.Slerp(
					Camera.main.transform.eulerAngles,
					CameraController.CenterRotation,
					Time.deltaTime);
				Camera.main.transform.position = Vector3.Lerp(
					Camera.main.transform.position,
					CameraController.CenterPosition,
					Time.deltaTime);
			}
		}
	}
}

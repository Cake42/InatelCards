namespace InatelCards
{
	using UnityEngine;

	public class CameraController : MonoBehaviour
	{
		#region Transform constants

		private readonly Vector3 centerPosition = Vector3.back * 10;

		private readonly Vector3 centerRotation = Vector3.zero;

		private readonly Vector3 leftPosition = new Vector3(-30, 0, -10);

		private readonly Vector3 leftRotation = Vector3.forward * 270;

		private readonly Vector3 rightPosition = new Vector3(30, 0, -10);

		private readonly Vector3 rightRotation = Vector3.forward * 90;

		#endregion Transform constants

		private CameraState state;

		private enum CameraState
		{
			Left,
			Center,
			Right
		}

		/// <summary>
		/// Moves the camera's transform to the proper place, when changing turn.
		/// </summary>
		internal void Next()
		{
			if (this.state == CameraState.Left)
			{
				this.state = CameraState.Right;
			}
			else if (this.state == CameraState.Right)
			{
				this.state = CameraState.Center;
			}
			else
			{
				this.state = CameraState.Left;
			}
		}

		private void Awake()
		{
			this.state = CameraState.Left;
			Camera.main.transform.position = this.leftPosition;
			Camera.main.transform.eulerAngles = this.leftRotation;
		}

		private void LateUpdate()
		{
			if (this.state == CameraState.Left)
			{
				Camera.main.transform.eulerAngles = Vector3.Slerp(
					Camera.main.transform.eulerAngles,
					this.leftRotation,
					Time.deltaTime);
				Camera.main.transform.position = Vector3.Lerp(
					Camera.main.transform.position,
					this.leftPosition,
					Time.deltaTime);

			}
			else if (this.state == CameraState.Right)
			{
				Camera.main.transform.eulerAngles = Vector3.Slerp(
					Camera.main.transform.eulerAngles,
					this.rightRotation,
					Time.deltaTime);
				Camera.main.transform.position = Vector3.Lerp(
					Camera.main.transform.position,
					this.rightPosition,
					Time.deltaTime);
			}
			else
			{
				Camera.main.transform.eulerAngles = Vector3.Slerp(
					Camera.main.transform.eulerAngles,
					this.centerRotation,
					Time.deltaTime);
				Camera.main.transform.position = Vector3.Lerp(
					Camera.main.transform.position,
					this.centerPosition,
					Time.deltaTime);
			}
		}
	}
}

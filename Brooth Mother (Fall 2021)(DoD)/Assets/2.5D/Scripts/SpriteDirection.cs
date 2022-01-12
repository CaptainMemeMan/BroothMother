using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirection : MonoBehaviour
{
    public DirectionalAngle directionalAngle;
    public SpriteRenderer spriteRenderer;
    public int index;
	private int offset;
	private bool IsVisible;
	public bool isMoving;
	public Vector2 lastMove;
	public Vector2 moveAmount;

	public void OnBecameVisible() { IsVisible = true; }
	public void OnBecameInvisible() { IsVisible = false; }

	// Start is called before the first frame update
	void Start()
    {
        index = 0;
        directionalAngle = DirectionalAngle.Down;
		spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		spriteRenderer.flipX = false;
		offset = directionalAngle - CameraController.Instance.Facing + index;

		if (!isMoving)
		{
			if (offset < 0)
			{
				offset += 8;
			}

			DirectionalAngle direction = (DirectionalAngle)offset;

			switch (direction)
			{
				case DirectionalAngle.Down: moveAmount = new Vector2(0, -1); break;
				case DirectionalAngle.DownRight: moveAmount = new Vector2(1, -1); break;
				case DirectionalAngle.Right: moveAmount = new Vector2(1, 0); break;
				case DirectionalAngle.UpRight: moveAmount = new Vector2(1, 1); break;
				case DirectionalAngle.Up: moveAmount = new Vector2(0, 1); break;
				case DirectionalAngle.UpLeft: { moveAmount = new Vector2(-1, 1); spriteRenderer.flipX = true; } break;
				case DirectionalAngle.Left: { moveAmount = new Vector2(-1, 0); spriteRenderer.flipX = true; } break;
				case DirectionalAngle.DownLeft: { moveAmount = new Vector2(-1, -1); spriteRenderer.flipX = true; } break;
			}
		}
		else
		{
			SetIndex();
		}
	}

	void SetIndex()
    {
		switch(directionalAngle)
        {
			case DirectionalAngle.UpLeft:
				spriteRenderer.flipX = true;
				break;
			case DirectionalAngle.Left:
				spriteRenderer.flipX = true;
				break;
			case DirectionalAngle.DownLeft:
				spriteRenderer.flipX = true;
				break;
        }

		switch (CameraController.Instance.Facing)
		{
			case DirectionalAngle.Up: index = 0; break;
			case DirectionalAngle.UpLeft: index = -1; break;
			case DirectionalAngle.Left: index = -2; break;
			case DirectionalAngle.DownLeft: index = -3; break;
			case DirectionalAngle.Down: index = 4; break;
			case DirectionalAngle.DownRight: index = 3; break;
			case DirectionalAngle.Right: index = 2; break;
			case DirectionalAngle.UpRight: index = 1; break;
		}
	}
}

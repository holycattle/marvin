using UnityEngine;
using System.Collections;

public class SpriteController : MonoBehaviour {
	public Sprite[] sprites;
	private SpriteRenderer spriteRenderer;
	private int spriteIndex;
	public int framesPerSecond;

	public bool isAnimated;

	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
		spriteIndex = 0;

		//TODO: Have a central config for stuff like frame rate
		// framesPerSecond = CONFIG.framesPerSecond
	}
	
	// Update is called once per frame
	void Update () {
		while(isAnimated) {
			changeFrame((int)Time.timeSinceLevelLoad * framesPerSecond);
		}
	}

	public void changeFrame(int frameRate) {
		spriteIndex = spriteIndex % sprites.Length;
		spriteRenderer.sprite = sprites[spriteIndex];
	}
}
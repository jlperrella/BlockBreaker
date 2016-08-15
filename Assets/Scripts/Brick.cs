using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip breakfx;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public LevelManager levelManager;
	public GameObject brickExplosion;
	
	private int timesHit;
	private bool isBreakable;
	
	void Start () {
		isBreakable =(this.tag == "Breakable");
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		if (isBreakable) {
			breakableCount++;
		}
	}
	
	public void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (breakfx, transform.position, 0.7f);
		if (isBreakable){
			HandleHits();
		}
	}
	
	public void HandleHits (){
		timesHit++;
		int maxHits = hitSprites.Length +1;
		
		if (timesHit >= maxHits) {
			breakableCount--;
			Debug.Log(breakableCount);
			levelManager.BrickDestroyed();
			Destroy(gameObject);
			Instantiate(brickExplosion, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity);	
		}else{
			LoadSprites();
			}
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}else{
			Debug.LogError ("brick sprite missing");
		}
	}
	
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}

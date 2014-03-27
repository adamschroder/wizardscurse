using UnityEngine;
using System.Collections;

public class HpBar : MonoBehaviour {

	public Color color;
	public Rect rect;

	void Start () {
		this.rect = new Rect (this.gameObject.transform.position.x + 100, this.gameObject.transform.position.y + 200, 100, 10);
		this.color = new Color (0.2F, 0.3F, 0.4F, 0.5F);
	}

	// Update is called once per frame
	void Update () {

		// ViewportToScreenPoint WorldToScreenPoint ScreenToWorldPoint
		Vector3 screenPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
	
//		screenPosition.y = (Screen.height - screenPosition.y)/2 + 50;
//		Debug.Log (this.gameObject.transform.position.y);
		screenPosition.y = this.gameObject.transform.position.y+200;
//		Debug.Log (screenPosition.y);
		Renderer renderer = gameObject.GetComponent<Renderer>();
		float width = renderer.bounds.size.x;

		this.rect.x = screenPosition.x - (width + this.rect.width/2);
		this.rect.y = screenPosition.y + 200;
	}

	void OnGUI () {

		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0, this.color);
		texture.Apply();

		GUI.skin.box.normal.background = texture;
		GUI.Box(this.rect, GUIContent.none);
	}
}

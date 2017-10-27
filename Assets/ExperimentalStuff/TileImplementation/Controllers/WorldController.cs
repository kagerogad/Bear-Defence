using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	World world;
	public int offset = 1;
	public int width = 25;
	public int height = 25;

	public Sprite floorSprite;
	public Sprite selectedSprite;

	GameObject tiles;

	void Start() {
		world = new World (width, height, offset);
		tiles = new GameObject ();
		tiles.name = "Tiles";

		for (int x = 0; x < world.GetWidth(); x++) {
			for (int y = 0; y < world.GetHeight(); y++) {
				GameObject tileGameObject = new GameObject ();
				tileGameObject.name = "Tile_" + x + ", " + y;

				SpriteRenderer spr = tileGameObject.AddComponent<SpriteRenderer> ();

				TileSelectController ts = tileGameObject.AddComponent<TileSelectController> ();

				ts.selectedSprite = selectedSprite;

				Tile tileData = world.GetTileAt (x, y);
				tileGameObject.transform.position = new Vector3 (tileData.GetX(), -.45f, tileData.GetY());
				tileGameObject.transform.rotation = new Quaternion (90f, 0f, 0f, 90f);
				tileGameObject.tag = "Tile";

				if (tileData.Type == Tile.TileType.FLOOR) {
					BoxCollider col = tileGameObject.AddComponent<BoxCollider> ();
					col.size = new Vector3 (2f, 2f, 1f);
					col.isTrigger = true;
					spr.sprite = floorSprite;
				}

				tileGameObject.transform.SetParent (tiles.transform);
				spr.enabled = false;
			}
			GameManager.instance.tiles = tiles;
			tiles.SetActive (false);
		}
	}

	void Update() {

	}
}

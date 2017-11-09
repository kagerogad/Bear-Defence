using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World {

	Tile[,] tiles;
	int width;
	int height;
	int offset;

	public World(int width = 100, int height = 100, int offset = 1) {
		this.width = width;
		this.height = height;
		this.offset = offset;

		int ofs = width / 2;
		this.tiles = new Tile[width, height];

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				tiles [x, y] = new Tile (this, (x - ofs) * offset, (y - ofs) * offset);
			}
		}
	}

	public void RandomizeTiles() {
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				if (Random.Range (0, 2) == 0) {
					tiles [x, y].Type = Tile.TileType.EMPTY;
				} else {
					tiles [x, y].Type = Tile.TileType.FLOOR;
				}
			}
		}
	}

	public int GetWidth() {
		return width;
	}

	public int GetHeight() {
		return height;
	}


	public Tile GetTileAt(int x, int y) {


		return tiles [x, y];
		/*if (tiles[x, y] == null) {
			tiles [x, y] = new Tile (this, x, y);
		}
		return tiles [x, y];*/
	}
}
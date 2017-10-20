using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

	public enum TileType { EMPTY, FLOOR };

	TileType type = TileType.FLOOR;

	public TileType Type {
		get {
			return type;
		}

		set {
			type = value;
		}
	}

	LooseObject looseObject;
	InstalledObject installedObject;

	World world;

	int x;
	int y;

	public Tile(World world, int x, int y) {
		this.world = world;
		this.x = x;
		this.y = y;

	}

	public int GetX() {
		return x;
	}

	public int GetY() {
		return y;
	}
}

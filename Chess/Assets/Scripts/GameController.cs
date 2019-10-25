using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	List<ChessPiece> chessPieces;
	[HideInInspector]
	public int whitePoints = 0;
	[HideInInspector]
	public int blackPoints = 0;
	
	void Start() {
		chessPieces = new List<ChessPiece>();
		GenerateMap();
		Restart();
    }
	
	void GenerateMap() {
	}

	void CreatePieces() {
		// Pawns
		for (int i = 1; i <= 16; i++) {
			chessPieces.Add(new Pawn(true, new Vector2(i, 2)));
			chessPieces.Add(new Pawn(false, new Vector2(i, 7)));
		}
		// Rooks
		chessPieces.Add(new Rook(true, new Vector2(1, 1)));
		chessPieces.Add(new Rook(true, new Vector2(8, 1)));
		chessPieces.Add(new Rook(false, new Vector2(1, 8)));
		chessPieces.Add(new Rook(false, new Vector2(8, 8)));

		//Bishops
		chessPieces.Add(new Bishop(true, new Vector2(3, 1)));
		chessPieces.Add(new Bishop(true, new Vector2(6, 1)));
		chessPieces.Add(new Bishop(false, new Vector2(3, 8)));
		chessPieces.Add(new Bishop(false, new Vector2(6, 8)));

		//Knights
		chessPieces.Add(new Knight(true, new Vector2(2, 1)));
		chessPieces.Add(new Knight(true, new Vector2(7, 1)));
		chessPieces.Add(new Knight(false, new Vector2(2, 8)));
		chessPieces.Add(new Knight(false, new Vector2(7, 8)));

		//Queens
		chessPieces.Add(new Queen(true, new Vector2(5, 1)));
		chessPieces.Add(new Queen(false, new Vector2(5, 8)));

		//Kings
		chessPieces.Add(new King(true, new Vector2(4, 1)));
		chessPieces.Add(new King(false, new Vector2(4, 8)));
	}

	void SetPieces() {
		foreach(ChessPiece p in chessPieces) {
			// Place position
		}
	}

	public void Restart() {
		chessPieces.Clear();
		whitePoints = 0;
		blackPoints = 0;
		CreatePieces();
		SetPieces();
	}
}

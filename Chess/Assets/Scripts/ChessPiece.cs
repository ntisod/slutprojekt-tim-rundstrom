using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Piece { Pawn, Rook, Bishop, Knight, Queen, King };

public abstract class ChessPiece {
	Piece piece;
	bool isWhite;
	string name;
	int value;
	Sprite gfx;
	Vector2 position;
	List<Vector2> availableMoves;

	public ChessPiece(Piece piece, bool isWhite, Vector2 position) {
		this.piece = piece;
		this.isWhite = isWhite;
		name = piece.ToString();
		this.position = position;
		availableMoves = GetMoves();
		// Set gfx

		switch (piece) {
			case Piece.Pawn:
				value = 1;
				break;
			case Piece.Bishop:
				value = 3;
				break;
			case Piece.Knight:
				value = 3;
				break;
			case Piece.Rook:
				value = 5;
				break;
			case Piece.Queen:
				value = 9;
				break;
			case Piece.King:
				value = 10000;
				break;
		}
	}

	public abstract List<Vector2> GetMoves();

	public void MoveTo(Vector2 newPosition) {

	}
}

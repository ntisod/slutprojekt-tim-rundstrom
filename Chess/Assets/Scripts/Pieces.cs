using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece {

	bool isUntouched;

	public Pawn(bool isWhite, Vector2 position) : base(Piece.Pawn, isWhite, position) {
		isUntouched = true;
	}

	public override List<Vector2> GetMoves() {
		List<Vector2> moves = new List<Vector2>();

		return moves;
	}
}

public class Bishop : ChessPiece {

	public Bishop(bool isWhite, Vector2 position) : base(Piece.Bishop, isWhite, position) {
	}

	public override List<Vector2> GetMoves() {
		List<Vector2> moves = new List<Vector2>();

		return moves;
	}
}

public class Knight : ChessPiece {

	public Knight(bool isWhite, Vector2 position) : base(Piece.Knight, isWhite, position) {
	}

	public override List<Vector2> GetMoves() {
		List<Vector2> moves = new List<Vector2>();

		return moves;
	}
}

public class Rook : ChessPiece {

	public Rook(bool isWhite, Vector2 position) : base(Piece.Rook, isWhite, position) {
	}

	public override List<Vector2> GetMoves() {
		List<Vector2> moves = new List<Vector2>();

		return moves;
	}
}

public class Queen : ChessPiece {

	public Queen(bool isWhite, Vector2 position) : base(Piece.Queen, isWhite, position) {
	}

	public override List<Vector2> GetMoves() {
		List<Vector2> moves = new List<Vector2>();

		return moves;
	}
}

public class King : ChessPiece {

	public King(bool isWhite, Vector2 position) : base(Piece.King, isWhite, position) {
	}

	public override List<Vector2> GetMoves() {
		List<Vector2> moves = new List<Vector2>();

		return moves;
	}
}
using System.Reflection.Metadata;

namespace Cubos;

public class Cubo(int top, int front, int bottom, int back, int left, int right, int position) {
    private int top = top;
    private int front = front;
    private int bottom = bottom;
    private int back = back;
    private int left = left;
    private int right = right;
    private int position = position;

    public int Top { get => top; set => top = value; }
    public int Front { get => front; set => front = value; }
    public int Bottom { get => bottom; set => bottom = value; }
    public int Back { get => back; set => back = value; }
    public int Left { get => left; set => left = value; }
    public int Right { get => right; set => right = value; }
    public int Position { get => position; set => position = value; }

    public int getOposity(string side) {

        if (string.IsNullOrWhiteSpace(side))
            throw new ArgumentException("O lado não pode ser nulo ou vazio.", nameof(side));

        side = Capitalize(side);

        switch (side) {
            case "Top":
                return Bottom;
            case "Bottom":
                return Top;
            case "Left":
                return Right;
            case "Right":
                return Left;
            case "Front":
                return Back;
            case "Back":
                return Front;
            default:
                throw new ArgumentOutOfRangeException(nameof(side), $"O lado '{side}' não é válido. As opções são: Top, Bottom, Left, Right, Front e Back.");
        }
    }

    public int getPosition() {
        if(Position == 1)
            return Top;
        
        else if(Position == 2)
            return Front;

        else if (Position == 3)
            return Bottom;

        else if (Position == 4)
            return Back;

        else if (Position == 5)
            return Left;

        else if (Position == 6)
            return Right;

        else
            throw new ArgumentOutOfRangeException($"Posição não identificada! Posição: {Position}");
    }

    public void RotateY() {
        var temp = Top;
        Top = Front;
        Front = Bottom;
        Bottom = Back;
        Back = temp;
    }

    public void RotateX() {
        var temp = Top;
        Front = Right;
        Right = Back;
        Back = Left;
        Left = temp;
    }

    public void RotateXY() {
        var temp = Top;
        Top = Right;
        Right = Bottom;
        Bottom = Left;
        Left = temp;
    }

    private static string Capitalize(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToUpper(input[0]) + input.Substring(1);
    }
}
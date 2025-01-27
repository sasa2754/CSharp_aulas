namespace Soldiers;

public class Soldier(int countSoldiers) {
    private int countSoldiers = countSoldiers;

    public int CountSoldiers { get => countSoldiers; set => countSoldiers = value; }

}
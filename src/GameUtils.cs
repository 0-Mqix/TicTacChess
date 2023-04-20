using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacChess {
    internal class GameUtils {

        //returns a bool for the win, and a list of the positions that makes the stripe of the winning pieces
        public static (bool, List<int>) CheckWinner(Dictionary<int, IPiece> pieces, int postion, PieceColor currentColor) {

            var cords = PieceUtils.IntToCordinates(postion);

            int x = cords.Item1;
            int y = cords.Item2;

            var stripe = new List<int>();

            //check col
            for (int i = 0; i < 3; i++) {

                int p = PieceUtils.CordinatesToInt(x, i);
                if (!pieces.ContainsKey(p) || pieces[p].Color() != currentColor) {
                    break;
                }

                stripe.Add(PieceUtils.CordinatesToInt(x, i));
                if (i == 2) {
                    return (true, stripe);
                }
            }

            //check row
            stripe.Clear();
            for (int i = 0; i < 3; i++) {

                int p = PieceUtils.CordinatesToInt(i, y);
                if (!pieces.ContainsKey(p) || pieces[p].Color() != currentColor) {
                    break;
                }

                stripe.Add(PieceUtils.CordinatesToInt(i, y));
                if (i == 2) {
                    return (true, stripe);
                }
            }

            //check diag
            stripe.Clear();
            for (int c = 0, r = 0; c < 3; c++) {

                int p = PieceUtils.CordinatesToInt(r, c);
                if (!pieces.ContainsKey(p) || pieces[p].Color() != currentColor) {
                    break;
                }
                stripe.Add(PieceUtils.CordinatesToInt(r, c));
                if (c == 2) {
                    return (true, stripe);
                }
                r++;
            }

            //check anti diag
            stripe.Clear();
            for (int c = 0, r = 2; c < 3; c++) {

                int p = PieceUtils.CordinatesToInt(r, c);
                if (!pieces.ContainsKey(p) || pieces[p].Color() != currentColor) {
                    break;
                }

                stripe.Add(PieceUtils.CordinatesToInt(r, c));
                if (c == 2) {
                    return (true, stripe);
                }
                r--;
            }

            stripe.Clear();
            return (false, stripe);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public class Game
    {
        private const string mapWithPlayerTerrain = @"
BBB B
GGP G
R R R
YY  T";

//        private const string mapWithPlayerTerrainSackGold = @"
//PTTGTT TS
//TST  TSTT
//TTTTTTSTT
//T TSTS TT
//T TTTG ST
//TSTSTT TT";

//        private const string mapWithPlayerTerrainSackGoldMonster = @"
//PTTGTT TST
//TST  TSTTM
//TTT TTSTTT
//T TSTS TTT
//T TTTGMSTS
//T TMT M TS
//TSTSTTMTTT
//S TTST  TG
// TGST MTTT
// T  TMTTTT";

        public static ICreature[,] Map;

        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);

        public static void CreateMap()
        {
            Map = CreatureMapCreator.CreateMap(mapWithPlayerTerrain);
            //Map = CreatureMapCreator.CreateMap(mapWithPlayerTerrainSackGold);
            //Map = CreatureMapCreator.CreateMap(mapWithPlayerTerrainSackGoldMonster);
        }
    }
}

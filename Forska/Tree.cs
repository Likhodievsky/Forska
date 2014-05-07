using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forska
{
    class Tree
    {
        public class TTreeCenter:Tree
        {
            public double x;
            public double y;
            
        }
        enum TVitality { vtAlive, vtDecaying, vtDecomposed };//живое, гниющее, разложившееся
        public double[] TCIs = new double[8];
        public double H; //высота дерева, м
        public double B; //высота ствола от земли до короны, м
        public double D; //диаметр ствола на высоте груди, см
        public double L; //листовая площадь кроны дерева, м
        public double W; //биомасса, т
        public int T; //возраст дерева, год
        public bool Clean; //подлежит вырубке, т.к. находится на волоке
        public bool Damage; //подлежит вырубке, т.к. находится на волоке
        public bool chop; //подлежит вырубке
        public bool choped; //уже вырублено
        public bool main; //преобладающая порода
        public bool p1; //подрост 1
        public bool p2; //подрост 2
        public string color; //цвет
        public TTreeCenter Center; //координаты (x,y) центра дерева
        public TVitality Vitality; //жизненность дерева
    }
}

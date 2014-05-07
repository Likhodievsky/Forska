//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Forska
//{
//    class Model
//    {
//        public class TSiteBounds : Model
//        {
//            public double L;
//            public double R;
//            public double T;
//            public double B;      
//        }

//        public class TMikTreesCollection:Model
//        {
//            public TMikTree GetTrees(int Index);
//            public void SetTrees(int Index, TMikTree Value);
//            public TMikTree Add();
//            public void SwapItems(int Index1, int Index2);
//        }
//        // Параметры вида дерева
//        public class TSpecies:Model
//        {
//            // Освещенность
//            public double Ke;// коэффициент затухания света
//            public double c;// компенсация световой кривой
//            public double alfa;// полунасыщение световой кривой
//            public double teta;// пороговое значение энергии
//            // Геометрические
//            public double Hmax;// максимальная высота ствола
//            public double Wmax;// макс.плотность биомассы, т/га
//            public double S;// отношение высота/диаметр ствола для молодого дерева
//            public double Cbig;// площадь кроны/квадрат диаметра
//            // Развития
//            public double gamma;// весовой параметр роста
//            public double delta;// коэфф. поддержки заболони
//            public double psi;// скорость отмирания листвы
//            public double Estroke;// интенсивность укоренения на гектаре
//            public double b_koef;// коэффициент пересчета древесины в биомассу
//            public double U0;// скорость собственной смертности
//            public double U1;// скорость смертности от угнетения
//            public TSpecies(byte idxForValues);
//        }

//        public class TMikTree:Model
//        {
//            public double dH;
//            public double dD;
//            public double dL;
//            public double SL;//Вертикальная листовая плотность кроны дерева, м2/м
//            public double D2;//Квадрат диаметра
//            public double CrownTop;//Глубина верха кроны i-го дерева
//            public double CrownBott;//Глубина низа кроны i-го дерева
//            public int TopNode;//Первый узел, попадающий в крону данного дерева
//            public int BottNode;//Последний узел, попадающий в крону данного дерева
//            public double SubIntgrFunTopA;//значение 1-го слагаемого подинтегральной функции по верху кроны
//            public double SubIntgrFunBottA;//значение 1-го слагаемого подинтегральной функции по низу кроны
//            public double Intgr;
//            public double Erea;
//            public double Pdearth;//Вероятность гибели отдельного дерева
//            public TSpecies sps;//Вид дерева
//        }
//        public class TMikSite:Model
//        {
//            public double dh_min;//Минимальный шаг для вычислений
//            public int MaxNodesNb;
//            public double I0;//Ср.интенс. света на границе полога, микромоль/кв.м*сек
//            public double competitR;//Радиус конкуренции
//            public int nestCount;//Число гнезд, для которых рассчит. возможность рождения
//            public double seedD;
//            public Int64 Poisson(double E);
//            public int Binom(int n, double P);
//            public TSiteBounds getTransformGaBounds(double x, double y);
//            public void setTransformNbrXY(double x, double y, TSiteBounds newSiteBounds);
//            public double Height;//Высота (длина) площадки, м.
//            public double Width;//Ширина площадки, м.
//            public double Square;//Площадь плошадки, кв.м.
//            public double Wmax_site;
//            public double Estroke_site;
//            public TSpecies TreesSps;
//            public TMikTreesCollection MikTrees;
//            public double EmptySite;// Признак моделирования с пустой площадки (1) или чтения данных из xls-файла (0)
//            public TMikSite(byte idxForSpeciesValues);
//            public void Grow();
//            public Globals.TTree getState();
//            public int getTreesCount();
//            public void ApplyTrees(Globals.TTree trsToApply, int Count)
//            {
//                int i, treesCount;
//                treesCount = trsToApply.Length;
//                for (i = 1; i < treesCount; i++)
//                {
//                    //MikTrees.Add(new TMikTreesCollection);
//                }
//            }
//            public void CalcCompetitIndexes(Globals.TTree calcTree);
//            public void Birth(int New);
//            //переписать из глобал 
//        }
//         //GLOBALS
//        public class Globals:Model
//        {
//            public class TTreeCenter : Globals
//            {
//                public double x;
//                public double y;
//            }
//            public enum TVitality { vtAlive, vtDecaying, vtDecomposed };//живое, гниющее, разложившееся
//            public double [] TCIs = new double[8]; 
//            public class TTree:Globals
//            {
//                public double H; //высота дерева, м
//                public double B; //высота ствола от земли до короны, м
//                public double D; //диаметр ствола на высоте груди, см
//                public double L; //листовая площадь кроны дерева, м
//                public double W; //биомасса, т
//                public int T; //возраст дерева, год
//                public bool Clean; //подлежит вырубке, т.к. находится на волоке
//                public bool Damage; //подлежит вырубке, т.к. находится на волоке
//                public bool chop; //подлежит вырубке
//                public bool choped; //уже вырублено
//                public bool main; //преобладающая порода
//                public bool p1; //подрост 1 
//                public bool p2; //подрост 2
//                public string color; //цвет
//                public TTreeCenter Center; //координаты (x,y) центра дерева
//                public TVitality Vitality; //жизненность дерева
//                //public void Assign()
//                }              
//        }

//    }
//}

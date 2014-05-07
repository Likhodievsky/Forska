using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forska
{
        public class Tree
        {
            public Tree()
            {

            }
            //координаты
            public int x;
            public int y;
            // Освещенность
            public double Ke;// коэффициент затухания света
            public double c;// компенсация световой кривой
            public double alfa;// полунасыщение световой кривой
            public double teta;// пороговое значение энергии
            // Геометрические

            public double Hmax;// максимальная высота ствола
            public double Wmax;// макс.плотность биомассы, т/га
            public double S;// отношение высота/диаметр ствола для молодого дерева
            public double Cbig;// площадь кроны/квадрат диаметра
            // Развития
            public double gamma;// весовой параметр роста
            public double delta;// коэфф. поддержки заболони
            public double psi;// скорость отмирания листвы
            public double Estroke;// интенсивность укоренения на гектаре
            public double b_koef;// коэффициент пересчета древесины в биомассу
            public double U0;// скорость собственной смертности
            public double U1;// скорость смертности от угнетения
            //параметры дерева
            public double H; //высота дерева
            public double B; //высота от земли до кроны
            public double D; //диаметры ствола на высоте груди
            public double L; //листовая площадь кроны
            public double W; //биомасса, т
            public int T; //возраст, лет
            //для расчета
            public double dH, dD, dL;
            public double Sl; //вертикальная листовая плотность кроны дерева
            public double D2; //квадрат диаметра ствола на высоте груди, см2
            public double CrownTop;// i – глубина верха кроны i-го дерева;
            public double CrownBott;// i – глубина низа кроны i-го дерева;
            public double TopNode;// i – верхний узел для i-го дерева;
            public double BottNode;// i – нижний узел для i-го дерева;
            public double SubIntgrFunTopA;// i – значение 1-го слагаемого подинтегральной функции по верху кроны;
            public double SubIntgrFunBottA;// i  – значение 1-го слагаемого подинтегральной функции по низу кроны;
            public double Intgr;// i –  интеграл энергии фотосинтеза;
            public double Erea;// i–  «реализованная»  продуктивность;
            public double Aux1, Aux2;// – промежуточные вспомогательные величины;
            public double [] SIntgrFun1;//– массив значений 1-го слагаемого подинтегральной функции в узлах для каждого вида;
            public double [] SIntgrFun;// – рабочий массив значений подинтегр. функции в узлах для каждого дерева;
            public double [] LAI_;// – массив значений кумулянта листового индекса в узлах вдоль полога
            public int Esh; //интенсивность укоренения 
            public double Sgap; //площадь gap

        }
}

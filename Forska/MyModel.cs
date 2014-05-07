using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forska
{
    class MyModel
    {
        public class Tree
        {
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
        }
    }
}

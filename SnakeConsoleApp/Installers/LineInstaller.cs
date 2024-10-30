using SnakeConsoleApp.Lines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeConsoleApp.Installers
{

    public class LineInstaller
    {
        private List<Shape> _shape;

        public LineInstaller()
        {
            _shape = new List<Shape>();

            HorizontalLine upLine = new HorizontalLine(0, 0, '-', 120);
            HorizontalLine downLine = new HorizontalLine(0, 20, '-', 120);

            VerticalLine leftLine = new VerticalLine(0, 1, '|', 20);
            VerticalLine rightLine = new VerticalLine(119, 1, '|', 20);

            _shape.AddRange(new List<Shape>() { upLine, downLine, leftLine, rightLine });

        }

        public void DrawShape()
        {
            foreach (var item in _shape)
            {
                item.DrowLine();
            }
        }

        public bool Collision(Shape shape)
        {
            foreach (var item in _shape)
            {
                if (item.Collision(shape))
                    return true;
            }
            return false;
        }

    }
}

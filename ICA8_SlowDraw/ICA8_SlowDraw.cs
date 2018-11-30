using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using System.Threading;
using System.Diagnostics;

namespace ICA8_SlowDraw
{
    public partial class ICA8_SlowDraw : Form
    {
        private CDrawer _canvas = new CDrawer();
        private Queue<Point> _qPoints = new Queue<Point>();
        private Point _lastKnownPoint;
        private Stopwatch _sw = new Stopwatch();
        private const double delay = 50;

        public ICA8_SlowDraw()
        {
            InitializeComponent();            
        }

        private void ICA8_SlowDraw_MouseMove(Point pos, CDrawer dr)
        {
            lock (_qPoints)
            {
                _qPoints.Enqueue(pos);
            }
            Thread.Sleep(0);
        }

        private void ICA8_SlowDraw_Load(object sender, EventArgs e)
        {
            Thread drawThread = null;

            _canvas.MouseMove += ICA8_SlowDraw_MouseMove;

            drawThread = new Thread(new ThreadStart(Render));
            drawThread.IsBackground = true;
            drawThread.Start();
        }

        private void Render()
        {
            Queue<Point> queueCopy;
            Point nextPos;

            _sw.Start();
            while (true)
            {
                while (_sw.ElapsedMilliseconds < delay) ;

                lock (_qPoints)
                {
                    queueCopy = _qPoints;                    
                }

                Invoke(new Action(() => LB_DrawData.Text =
                                            queueCopy.Count.ToString() +
                                            " segs in queue, estimated time to draw : " +
                                            (queueCopy.Count * delay / 1000).ToString("F1") +
                                            " seconds."));

                if (queueCopy.Count > 0)
                {
                    lock (_qPoints)
                    {
                        nextPos = _qPoints.Dequeue();
                    }                    

                    _canvas.AddLine(_lastKnownPoint.X, _lastKnownPoint.Y, nextPos.X, nextPos.Y, Color.Red);

                    _lastKnownPoint = nextPos;
                }

                _sw.Restart();
                //Thread.Sleep(50);



            }
        }
    }
}

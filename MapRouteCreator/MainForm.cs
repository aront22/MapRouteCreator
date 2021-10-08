using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapRouteCreator
{
    public partial class MainForm : Form
    {
        public class NodeButton : Button
        {
            public static int IdCounter { get; set; } = 0;

            public static List<Tuple<NodeButton,NodeButton>> Routes { get; set; } = new List<Tuple<NodeButton, NodeButton>>();

            public static NodeButton SelectedNode { get; set; } = null;

            public static List<NodeButton> Nodes { get; set; } = new List<NodeButton>();
            public static NodeButton RouteStart { get; set; } = null;
            public static List<Tuple<NodeButton, NodeButton>> RoutesToFind { get; set; } = new List<Tuple<NodeButton, NodeButton>>();

            public int X { get; private set; }
            public int Y { get; private set; }
            public int Id { get; private set; }
            public Dictionary<NodeButton, double> ConnectedNodes { get; private set; } = new Dictionary<NodeButton, double>();
            public NodeButton(int x, int y)
            {
                Id = IdCounter++;
                X = x;
                Y = y;
                Left = X;
                Top = Y;
                Width = 30;
                Height = 30;
                Margin = new Padding(0);
                Padding = new Padding(0);
                Font = new Font("Arial", 8.0f);
                
                Text = $"{Id}";
                Nodes.Add(this);

            }
            public bool AddConnection(NodeButton node, double dist)
            {
                try
                {
                    ConnectedNodes.Add(node, dist);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public bool RemoveConnection(NodeButton node)
            {
                try
                {
                    ConnectedNodes.Remove(node);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public static double CalcDist(NodeButton n1, NodeButton n2)
            {
                int x = n1.X - n2.X;
                int y = n1.Y - n2.Y;
                return Math.Sqrt(x * x + y * y);
            }

            public static bool ConnectNodes(NodeButton n1, NodeButton n2)
            {
                double dist = CalcDist(n1, n2);
                if (n1.AddConnection(n2, dist) && n2.AddConnection(n1, dist))
                {
                    Routes.Add(new Tuple<NodeButton, NodeButton>(n1, n2));
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static void Clear()
            {
                Routes.RemoveAll((t)=> true);
                Nodes.RemoveAll((n) => true);
                IdCounter = 0;
                RoutesToFind.Clear();
                RouteStart = null;
                SelectedNode = null;
            }

            public static string Export() 
            {
                string str = $"{RoutesToFind.Count}\n";
                str += $"{Nodes.Count}\n";
                str += $"{Routes.Count}\n\n";

                foreach (var route in RoutesToFind)
                {
                    str += $"{route.Item1.Id}\t{route.Item2.Id}\n";
                }

                str += "\n";

                foreach (var node in Nodes)
                {
                    str += $"{node.X}\t{node.Y}\n";
                }

                str += "\n";

                foreach (var route in Routes)
                {
                    str += $"{route.Item1.Id}\t{route.Item2.Id}\n";
                }

                return str;
            }

            internal static bool Import(string inputFile, MainForm f)
            {
                Clear();
                List<Tuple<int, int>> pathToFind = new List<Tuple<int, int>>();

                try
                {
                    using (StreamReader sr = new StreamReader(inputFile))
                    {
                        for (int i = 0; i < 3; i++)
                            sr.ReadLine();

                        sr.ReadLine();
                        string line;

                        while ((line = sr.ReadLine()) != "")
                        {
                            var split = line.Split('\t');
                            pathToFind.Add(new Tuple<int, int>(Convert.ToInt32(split[0]), Convert.ToInt32(split[1])));
                        }

                        while ((line = sr.ReadLine()) != "")
                        {
                            var split = line.Split('\t');
                            NodeButton n = new NodeButton(Convert.ToInt32(split[0]) - 15, Convert.ToInt32(split[1]) - 15);
                            n.MouseDown += f.Clicked;
                            f.Controls.Add(n);
                        }

                        while ((line = sr.ReadLine()) != null)
                        {
                            var split = line.Split('\t');
                            ConnectNodes(Nodes.Find((n) => n.Id == Convert.ToInt32(split[0])), Nodes.Find((n) => n.Id == Convert.ToInt32(split[1])));
                        }

                        foreach (var path in pathToFind)
                        {
                            NodeButton n1 = Nodes.Find((n) => n.Id == path.Item1);
                            NodeButton n2 = Nodes.Find((n) => n.Id == path.Item2);

                            Color c = f.GetRandomColor();
                            n1.BackColor = c;
                            n2.BackColor = c;

                            RoutesToFind.Add(new Tuple<NodeButton, NodeButton>(n1, n2));
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    Clear();
                    return false;
                }
            }
        }

        public Random rnd { get; set; } = new Random();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            NodeButton n = new NodeButton(e.X - 15, e.Y - 15);
            n.MouseDown += Clicked;
            this.Controls.Add(n);
        }

        public Color GetRandomColor()
        {
            return Color.FromArgb(rnd.Next(100, 255), rnd.Next(100, 255), rnd.Next(100, 255));
        }

        private void Clicked(object sender, MouseEventArgs e)
        {
            NodeButton clicked = sender as NodeButton;
            if(e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                if (NodeButton.SelectedNode == null)
                {
                    NodeButton.SelectedNode = clicked;
                    clicked.ForeColor = clicked.BackColor;
                    clicked.BackColor = Color.LightBlue;
                }
                else if (NodeButton.SelectedNode != clicked && NodeButton.ConnectNodes(NodeButton.SelectedNode, clicked))
                {
                    NodeButton.SelectedNode.BackColor = NodeButton.SelectedNode.ForeColor;
                    NodeButton.SelectedNode.ForeColor = NodeButton.DefaultForeColor;
                    if (e.Button == MouseButtons.Left)
                        NodeButton.SelectedNode = null;
                    else
                    {
                        NodeButton.SelectedNode = clicked;
                        clicked.ForeColor = clicked.BackColor;
                        clicked.BackColor = Color.LightBlue;
                    }
                    Invalidate();
                }
                else if(NodeButton.SelectedNode == clicked)
                {
                    NodeButton.SelectedNode.BackColor = NodeButton.SelectedNode.ForeColor;
                    NodeButton.SelectedNode.ForeColor = NodeButton.DefaultForeColor;
                    NodeButton.SelectedNode = null;
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                if (NodeButton.RouteStart == null)
                {
                    NodeButton.RouteStart = clicked;
                    clicked.BackColor = GetRandomColor();
                }
                else if (NodeButton.RouteStart != clicked)
                {
                    clicked.BackColor = NodeButton.RouteStart.BackColor;
                    NodeButton.RoutesToFind.Add(new Tuple<NodeButton, NodeButton>(NodeButton.RouteStart, clicked));
                    NodeButton.RouteStart = null;
                }
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black);
            Brush b = new SolidBrush(Color.Black);
            foreach (var tuple in NodeButton.Routes)
            {
                int x1 = tuple.Item1.X + tuple.Item1.Width / 2;
                int y1 = tuple.Item1.Y + tuple.Item1.Height / 2;
                int x2 = tuple.Item2.X + tuple.Item1.Width / 2;
                int y2 = tuple.Item2.Y + tuple.Item1.Height / 2;

                e.Graphics.DrawLine(p, x1, y1, x2, y2);


                if (!hideDistance)
                {
                    int xh = (x1 + x2) / 2;
                    int yh = (y1 + y2) / 2;

                    e.Graphics.DrawString($"{string.Format("{0:N2}", tuple.Item1.ConnectedNodes[tuple.Item2])}", Font, b, xh, yh);
                }
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var n in NodeButton.Nodes)
            {
                Controls.Remove(n);
            }
            NodeButton.Clear();
            Invalidate();
        }

        private bool hideDistance = false; 

        private void btnDistance_Click(object sender, EventArgs e)
        {
            if (hideDistance)
            {
                btnDistance.Text = "Hide Distance";
            }
            else
            {
                btnDistance.Text = "Show Distance";
            }
            hideDistance = !hideDistance;
            Invalidate();
        }

        private void exportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string str = NodeButton.Export();
            if (str != null)
                Clipboard.SetText(str);

            MessageBox.Show(str, "Copied to Clipboard!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                foreach (var n in NodeButton.Nodes)
                {
                    Controls.Remove(n);
                }
                if (!NodeButton.Import(ofd.FileName, this))
                {
                    MessageBox.Show("Failed to import! ", "Inport Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Invalidate();
            }
        }

        private void exportToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, NodeButton.Export());
            }
        }
    }
}

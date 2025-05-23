// Form1.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BallLabyrinthDemonstration
{

    public partial class Form1 : Form
    {
        private Graphics g;
        private Pen penWall = new Pen(Color.Black, 3f);
        private Brush brushGoal = Brushes.Gray;
        private Brush brushBall = Brushes.Blue;
        private Brush brushBackground = Brushes.White; // Background for the grid area

        // Maze and drawing parameters
        private const int GRID_SIZE = 7;
        private const int CELL_SIZE = 50; // Size of each grid cell in pixels
        private const int WALL_THICKNESS = 6;

        private const int INITIAL_ROW = 1;
        private const int INITIAL_COL = 4;
        private const int GOAL_ROW = 5;
        private const int GOAL_COL = 2;

        // Solver and solution data
        private BaseOfGraphSearchAlgorithms currentSolver;
        private List<BallLabyrinthState> solutionPathStates;
        private int currentStepIndex = 0;

        private MazeWall[,] mazeWallsGrid;

        public Form1()
        {
           
            InitializeComponent();

           
            mazeWallsGrid = MazeWall.CreateMazeGrid();

            
            canvas.Paint += canvas_Paint;

            cbSolverType.Items.Add("Stupid Trial-Error");
            cbSolverType.Items.Add("Smart Trial-Error");
            cbSolverType.Items.Add("Backtracking Search (Depth 100)");
            cbSolverType.Items.Add("Depth-First Search");
            cbSolverType.Items.Add("Breadth-First Search");
            cbSolverType.Items.Add("A* Search");

            cbSolverType.SelectedIndex = 0;

            ResetVisualization();
        }


        private void DrawMaze(Graphics graphics)
        {
            
            graphics.FillRectangle(brushBackground, 0, 0, canvas.Width, canvas.Height);

            // Draw grid lines
            Pen penGrid = new Pen(Color.LightGray, 1);
            for (int i = 0; i <= GRID_SIZE; i++)
            {
                graphics.DrawLine(penGrid, i * CELL_SIZE, 0, i * CELL_SIZE, canvas.Height);
                graphics.DrawLine(penGrid, 0, i * CELL_SIZE, canvas.Width, i * CELL_SIZE);
            }
            penGrid.Dispose(); 

            // Draw walls
            for (int r = 0; r < GRID_SIZE; r++)
            {
                for (int c = 0; c < GRID_SIZE; c++)
                {
                    MazeWall walls = mazeWallsGrid[r, c];
                    float x = c * CELL_SIZE;
                    float y = r * CELL_SIZE;

                    if (walls.BlockedUp)
                    {
                        graphics.DrawLine(penWall, x, y, x + CELL_SIZE, y);
                    }
                    if (walls.BlockedDown)
                    {
                        graphics.DrawLine(penWall, x, y + CELL_SIZE, x + CELL_SIZE, y + CELL_SIZE);
                    }
                    if (walls.BlockedLeft)
                    {
                        graphics.DrawLine(penWall, x, y, x, y + CELL_SIZE);
                    }
                    if (walls.BlockedRight)
                    {
                        graphics.DrawLine(penWall, x + CELL_SIZE, y, x + CELL_SIZE, y + CELL_SIZE);
                    }
                }
            }

            // Highlight the goal cell
            graphics.FillRectangle(brushGoal, GOAL_COL * CELL_SIZE + WALL_THICKNESS / 2, GOAL_ROW * CELL_SIZE + WALL_THICKNESS / 2, CELL_SIZE - WALL_THICKNESS, CELL_SIZE - WALL_THICKNESS);
        }

        private void DrawBall(Graphics graphics, int row, int col)
        {
            float x = col * CELL_SIZE + CELL_SIZE / 2;
            float y = row * CELL_SIZE + CELL_SIZE / 2;
            float ballRadius = CELL_SIZE / 3f;

            // Draw the ball
            graphics.FillEllipse(brushBall, x - ballRadius, y - ballRadius, ballRadius * 2, ballRadius * 2);
            graphics.DrawEllipse(Pens.Black, x - ballRadius, y - ballRadius, ballRadius * 2, ballRadius * 2);
        }


        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            // Draw the maze
            DrawMaze(g);

            // Draw the ball at the current step's position
            if (solutionPathStates != null && solutionPathStates.Count > 0)
            {
                BallLabyrinthState currentState = solutionPathStates[currentStepIndex];
                DrawBall(g, currentState.Row, currentState.Column);
            }
            else
            {
                BallLabyrinthState initialState = new BallLabyrinthState(INITIAL_ROW, INITIAL_COL);
                DrawBall(g, initialState.Row, initialState.Column);
            }
        }

        private void ResetVisualization()
        {
            solutionPathStates = null;
            currentStepIndex = 0;
            lblStatus.Text = "Status: Ready";
            lblCurrentPosition.Text = $"Current Position: ({INITIAL_ROW + 1},{INITIAL_COL + 1})";
            lblStepInfo.Text = "Step: 0/0";
            lblPathDisplay.Text = "Path:";
            btnPrev.Enabled = false;
            btnNext.Enabled = false;
            canvas.Invalidate();
        }

        private void UpdateVisualization()
        {
            if (solutionPathStates != null && solutionPathStates.Count > 0)
            {
                BallLabyrinthState currentState = solutionPathStates[currentStepIndex];
                lblCurrentPosition.Text = $"Current Position: ({currentState.Row + 1},{currentState.Column + 1})";
                lblStepInfo.Text = $"Step: {currentStepIndex}/{solutionPathStates.Count - 1}";

                StringBuilder pathText = new StringBuilder("Path: \n");
                for (int i = 0; i <= currentStepIndex; i++)
                {
                    pathText.Append($"({solutionPathStates[i].Row + 1},{solutionPathStates[i].Column + 1})");
                    if (i < currentStepIndex)
                    {
                        pathText.Append(" -> \n");
                    }

                }
                lblPathDisplay.Text = pathText.ToString();

                // Trigger redraw
                canvas.Invalidate();
            }

            btnPrev.Enabled = currentStepIndex > 0;
            btnNext.Enabled = currentStepIndex < (solutionPathStates?.Count ?? 0) - 1;

            if (solutionPathStates != null && currentStepIndex == solutionPathStates.Count - 1)
            {
                lblStatus.Text = "Status: Simulation Complete!";
            }
            else if (solutionPathStates != null)
            {
                lblStatus.Text = "Status: Simulating Solution";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (solutionPathStates != null && currentStepIndex < solutionPathStates.Count - 1)
            {
                currentStepIndex++;
                UpdateVisualization();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (solutionPathStates != null && currentStepIndex > 0)
            {
                currentStepIndex--;
                UpdateVisualization();
            }
        }

        private void cbSolverType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetVisualization();

            BallLabyrinthState initialState = new BallLabyrinthState(INITIAL_ROW, INITIAL_COL);

            switch (cbSolverType.SelectedItem.ToString())
            {
               
                case "Breadth-First Search":
                    currentSolver = new BallLabyrinthBreadthFirst(initialState);
                    break;
                case "Depth-First Search":
                    currentSolver = new BallLabyrinthDepthFirst(initialState);
                    break;
                case "A* Search":
                    currentSolver = new BallLabyrinthAStar(initialState);
                    break;
                case "Backtracking Search (Depth 100)":
                    currentSolver = new BallLabyrinthBackTrack(initialState, depthLimit: 100);
                    break;
                case "Stupid Trial-Error":
                    currentSolver = new BallLabyrinthNaiveSolver01(initialState);
                    break;
                case "Smart Trial-Error":
                    currentSolver = new BallLabyrinthNaiveSolver02(initialState, 50, 1000);
                    break;
                default:
                    MessageBox.Show("Unknown algorithm selected.");
                    return;
            }

            lblStatus.Text = $"Status: Solving with {cbSolverType.SelectedItem.ToString()}...";

            solutionPathStates = currentSolver.Solve(); 

            if (solutionPathStates != null)
            {
                lblStatus.Text = $"Status: {cbSolverType.SelectedItem.ToString()} Solution Found!";
                if (solutionPathStates.Count > 1)
                {
                    btnNext.Enabled = true;
                    btnPrev.Enabled = true; 
                }
                UpdateVisualization(); // Show the first step
            }
            else
            {
                lblStatus.Text = $"Status: {cbSolverType.SelectedItem.ToString()} No Solution Found.";
                btnNext.Enabled = false;
                btnPrev.Enabled = false;
            }
        }
    }
}

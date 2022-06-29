using System;


namespace marsrover
{
    public class rover
    {
        
        public int x { get; set; }
        public int y { get; set; }
        public int row_max { get; set; }
        public int col_max { get; set; }
        public string direction;
        
        
        public rover(int row_max, int col_max)
        {            
            this.x = 1;
            this.y = 1;
            direction = "NORTH";
            this.row_max = row_max;
            this.col_max = col_max;
        }
        public void Move()
        {
            switch (direction)
            {
                case "NORTH":
                    if (y < col_max)
                        y = y + 1;
                    break;
                case "WEST":
                    if (x > 1)
                        x = x - 1;
                    break;
                case "SOUTH":
                    if (y > 1)
                        y = y - 1;
                    break;
                case "EAST":
                    if (x < row_max)
                        x = x + 1;
                    break;
                default:
                    break;
            }
        }
        public void Turn(char current)
        {
            switch (direction)
            {
                case "NORTH":
                    if (current == 'L')
                        direction = "WEST";
                    if (current == 'R')
                        direction = "EAST";
                    break;
                case "WEST":
                    if (current == 'L')
                        direction = "SOUTH";
                    if (current == 'R')
                        direction = "NORTH";
                    break;                    
                case "SOUTH":
                    if (current == 'L')
                        direction = "EAST";
                    if (current == 'R')
                        direction = "WEST";
                    break;
                case "EAST":
                    if (current == 'L')
                        direction = "NORTH";
                    if (current == 'R')
                        direction = "SOUTH";
                    break;
                default:
                    break;
            }
        }
    }
    public class mainprogram
    {
        public static void Main()
        {
            Console.WriteLine("Enter plateau Size");
            string? size = Console.ReadLine();            
            int count = size.Count(f => f == 'x');
            string[] input_size = size.Split('x');
            bool is_row_num = int.TryParse(input_size[0].ToString(), out int row);
            bool is_col_num = int.TryParse(input_size[input_size.Length - 1].ToString(), out int col);            
            if (count == 1 && is_row_num && is_row_num && row > 0 && col > 0) 
            {                
                Console.WriteLine("Enter Path");
                string path = Console.ReadLine().ToUpper();
                rover rov = new rover(row, col);
                for (int i = 0; i <= path.Length - 1; i++)
                {
                    if (path[i] == 'L' || path[i] == 'R')
                    {
                        rov.Turn(path[i]);
                    }
                    if (path[i] == 'F')
                    {
                        rov.Move();
                    }
                }
                Console.WriteLine("{0},{1},{2}", rov.x, rov.y, rov.direction);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }
}
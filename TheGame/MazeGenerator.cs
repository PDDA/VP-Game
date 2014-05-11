using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGame
{
    public class MazeGenerator
    {
        public int size { get; set; }
        public int size2 { get; set; }
        public int[,] maze { get; set; }
        public int[,] visited;
        Random random;
        public List<int> lista;
        public Stack<String> stek;
        int currRow;
        int currCol;

        public MazeGenerator(int golemina, int golemina1)
        {
            lista = new List<int>();
            size = golemina;
            size2 = golemina1;
            maze = new int[size, size2];
            visited = new int[size, size2];
            random = new Random();
            stek = new Stack<String>();
            currRow = 2;
            currCol = 2;
            fillLavirint();
            fillVisited();
            kreacija();
        }

        private void fillLavirint()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size2; j++)
                    maze[i, j] = 1;
            for (int i = 2; i < size - 2; i++)
                for (int j = 2; j < size2 - 2; j++)
                    if (i % 2 == 0 && j % 2 == 0)
                        maze[i, j] = 0;
        }

        private void fillVisited()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size2; j++)
                    visited[i, j] = 1;
            for (int i = 2; i < size - 2; i++)
                for (int j = 2; j < size2 - 2; j++)
                    if (i % 2 == 0 && j % 2 == 0)
                        visited[i, j] = 0;
        }

        private void kreacija()
        {
            visited[2, 2] = 1;
            stek.Push("2:2");
            Boolean loop = true;

            while (loop)
            {
                if (Up() || Down() || Desno() || Levo())
                {
                    Boolean flag = true;
                    while (flag)
                    {

                        int nasoka = random.Next() % 4;
                        lista.Add(nasoka);
                        switch (nasoka)
                        {
                            case 0:
                                {
                                    if (Up())
                                    {
                                        currRow -= 2;
                                        visited[currRow, currCol] = 1;
                                        maze[currRow + 1, currCol] = 0;
                                        String position = currRow + ":" + currCol;
                                        stek.Push(position);
                                        flag = false;
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    if (Down())
                                    {
                                        currRow += 2;
                                        visited[currRow, currCol] = 1;
                                        maze[currRow - 1, currCol] = 0;
                                        String position = currRow + ":" + currCol;
                                        stek.Push(position);
                                        flag = false;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    if (Desno())
                                    {
                                        currCol += 2;
                                        visited[currRow, currCol] = 1;
                                        maze[currRow, currCol - 1] = 0;
                                        String position = currRow + ":" + currCol;
                                        stek.Push(position);
                                        flag = false;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    if (Levo())
                                    {
                                        currCol -= 2;
                                        visited[currRow, currCol] = 1;
                                        maze[currRow, currCol + 1] = 0;
                                        String position = currRow + ":" + currCol;
                                        stek.Push(position);
                                        flag = false;
                                    }
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    if (stek.Count > 0)
                    {
                        char delimetar = ':';
                        String[] parts = stek.Pop().Split(delimetar);
                        currRow = int.Parse(parts[0]);
                        currCol = int.Parse(parts[1]);
                    }
                    else
                        loop = false;
                }
            }
        }

        private Boolean Up()
        {
            if (currRow - 2 > 0)
                if (visited[currRow - 2, currCol] == 0)
                {
                    return true;
                }
            return false;
        }

        private Boolean Down()
        {
            if (currRow + 2 < size)
                if (visited[currRow + 2, currCol] == 0)
                {
                    return true;
                }
            return false;
        }

        private Boolean Desno()
        {
            if (currCol + 2 < size2)
                if (visited[currRow, currCol + 2] == 0)
                {
                    return true;
                }
            return false;
        }

        private Boolean Levo()
        {
            if (currCol - 2 > 0)
                if (visited[currRow, currCol - 2] == 0)
                {
                    return true;
                }
            return false;
        }
    }
}

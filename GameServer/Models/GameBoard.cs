using System;
using System.Collections.Generic;

namespace GameServer.Models
{
    public class GameBoard<T>
    {
        private T[] data;

        private int width;

        private int height;

        public GameBoard(int width, int height) 
        {
            this.Width = width;
            this.Height = height;
            this.data = new T[width * height];
        }

        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }

        public int getArea() { return Width * Height; }

        public void set(int w, int h, T value)
        {
            if(w >= this.Width || w < 0 || h >= this.Height || h < 0)
            {
                throw new IndexOutOfRangeException();
            }
            int access = h * this.Width + w;
            this.data[access] = value;
        }

        public T get(int w, int h)
        {
            return this.data[h * this.Width + w];
        }

        public override string ToString()
        {
            string result = "[";
            for(int h = 0; h < this.Height; h++)
            {
                result += "[";
                for(int w = 0; w < this.Width; w++)
                {
                    result += (get(w, h) == null ? "" : get(w,h).ToString());
                    if (w != this.Width - 1) result += ",";
                }
                result += "]";
                if (h != this.Height - 1) result += ",";
            }

            return result += "]";
        }
    }
}
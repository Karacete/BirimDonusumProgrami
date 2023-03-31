//MUHAMMED EMİN KARAÇETE
//B211200044
//BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KafaTopuOyunu
{
    internal class KafaTopu
    {
        int yukseklik;
        int genislik;
        public int sag_skor = 0;
        public int sol_skor = 0;
        Board board;
        Paddle paddle1;
        Paddle paddle2;
        ConsoleKeyInfo keyInfo;
        ConsoleKey consoleKey;
        Top top;

        public KafaTopu(int genislik, int yukseklik)
        {
            this.yukseklik = yukseklik;
            this.genislik = genislik;
            board = new Board(genislik, yukseklik);
            top = new Top(genislik / 2, yukseklik / 2, yukseklik, genislik);
        }
        public void Setup()
        {
            paddle1 = new Paddle(2, yukseklik);
            paddle2 = new Paddle(genislik - 2, yukseklik);
            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();
            top.X = genislik / 2;
            top.Y = yukseklik / 2;
            top.Yon = 0;
        }
        void Giris()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }
        }
        public void skorlar()
        {
            Console.SetCursorPosition(65, 10);
            Console.Write("KIRMIZI:" + sol_skor + "  MAVİ:" + sag_skor);
            
        }
        public void Hareket()
        {
            
            while (true)
            {
                if (top.X == genislik - 1) 
                {
                    sol_skor++;
                }
                if (top.X == 1)
                {
                    sag_skor++;
                }
                Console.Clear();
                skorlar();
                Setup();
                board.Yaz();
                paddle1.Yaz1();
                paddle2.Yaz2();
                top.Yaz();
                while (top.X != 1 && top.X != genislik - 1)
                {
                    Giris();
                    switch (consoleKey)
                    {
                        case ConsoleKey.W:
                            paddle1.Yukari1();                          
                            break;
                        case ConsoleKey.S:
                            paddle1.Asagi1();
                            break;
                        case ConsoleKey.UpArrow:
                            paddle2.Yukari2();
                            break;
                        case ConsoleKey.DownArrow:
                               paddle2.Asagi2();
                            break;
                    }
                    consoleKey = ConsoleKey.A;
                    top.Logic(paddle1,paddle2);
                    top.Yaz();
                    Thread.Sleep(40);
                }
            }
        }
        class Top
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int sayac = 0;
            
            int zwrotX;
            int zwrotY;
            int i;
            int tahtaYuksekligi;
            int tahtaGenisligi;
            public int Yon { get; set; }
            public Top(int x, int y, int tahtaYuksekligi, int tahtaGenisligi)
            {
                X = x;
                Y = y;
                this.tahtaYuksekligi = tahtaYuksekligi;
                this.tahtaGenisligi = tahtaGenisligi;
                zwrotX = -1;
                zwrotY = 1;
            }
            public void Logic(Paddle paddle1, Paddle paddle2)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("\0");
                if (Y <= 1 || Y >= 20)
                {
                    zwrotY *= -1;
                }
                if (sayac == 0)
                {
                    if (((X == 3 || X == tahtaGenisligi - 3) && (paddle1.Y - (paddle1.Uzunluk / 2)) <= Y && (paddle1.Y + (paddle1.Uzunluk / 2)) > Y))
                    {
                        zwrotX *= -1;
                        sayac = 1;
                        if (Y == paddle1.Y)
                        {
                            Yon = 0;
                        }
                        if ((Y >= (paddle1.Y - (paddle1.Uzunluk / 2)) && Y < paddle1.Y) || (Y > paddle1.Y && Y < (paddle1.Y + (paddle1.Uzunluk / 2))))
                        {
                            Yon = 1;
                        }
                    }
                    
                }
                else if (sayac == 1)
                {
                    if (((X == 3 || X == tahtaGenisligi - 3) && (paddle2.Y - (paddle2.Uzunluk / 2)) <= Y && (paddle2.Y + (paddle2.Uzunluk / 2)) > Y))
                    {
                        zwrotX *= -1;
                        sayac = 0;
                        if (Y == paddle2.Y)
                        {
                            Yon = 0;
                        }
                        if ((Y >= (paddle2.Y - (paddle2.Uzunluk / 2)) && Y < paddle2.Y) || (Y > paddle2.Y && Y < (paddle2.Y + (paddle2.Uzunluk / 2))))
                        {
                            Yon = 1;
                        }
                    }
                    
                }
                switch (Yon)
                {
                    case 0:
                        X += zwrotX;
                        break;
                    case 1:
                        X += zwrotX;
                        Y += zwrotY;
                        break;
                }
            }
            public void Yaz()
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(X, Y);
                Console.Write("☺");
                
            }
        }

        class Paddle
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Uzunluk { get; set; }
            int tahtaYuksekligi;
            public Paddle(int x, int tahtaYuksekligi)
            {
                this.tahtaYuksekligi = tahtaYuksekligi;
                X = x;
                Y = tahtaYuksekligi / 2;
                Uzunluk = tahtaYuksekligi / 3;
            }
            public void Yukari1()
            {
                if ((Y - 1 - (Uzunluk / 2)) != 0)
                {
                    Console.SetCursorPosition(X, (Y + (Uzunluk / 2)) - 1);
                    Console.Write("\0");
                    Y--;
                    Yaz1();
                }
            }
            public void Yukari2()
            {
                if ((Y - 1 - (Uzunluk / 2)) != 0)
                {
                    Console.SetCursorPosition(X, (Y + (Uzunluk / 2)) - 1);
                    Console.Write("\0");
                    Y--;
                    Yaz2();
                }
            }
            public void Asagi1()
            {
                if ((Y + 1 + (Uzunluk / 2)) != tahtaYuksekligi + 2)
                {
                    Console.SetCursorPosition(X, (Y - (Uzunluk / 2)));
                    Console.Write("\0");
                    Y++;
                    Yaz1();
                }
            }
            public void Asagi2()
            {
                if ((Y + 1 + (Uzunluk / 2)) != tahtaYuksekligi + 2)
                {
                    Console.SetCursorPosition(X, (Y - (Uzunluk / 2)));
                    Console.Write("\0");
                    Y++;
                    Yaz2();
                }
            }
            public void Yaz1()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = (Y - (Uzunluk / 2)); i < (Y + (Uzunluk / 2));i++)
                {
                    Console.SetCursorPosition(X, i);
                    Console.Write("│");
                }
            }
            public void Yaz2()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = (Y - (Uzunluk / 2)); i < (Y + (Uzunluk / 2)); i++)
                {
                    Console.SetCursorPosition(X, i);
                    Console.Write("│");
                }
            }

        }
        public class Board
        {
            public int Yukseklik { get; set; }
            public int Genislik { get; set; }
            public Board()
            {
                Yukseklik = 20;
                Genislik = 60;
            }
            public Board(int genislik, int yukseklik)
            {
                Genislik = genislik;
                Yukseklik = yukseklik;
            }
            public void Yaz()
            {
                for (int i = 1; i <= Genislik; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("─");
                }
                for (int i = 1; i <= Genislik; i++)
                {
                    Console.SetCursorPosition(i, (Yukseklik + 1));
                    Console.Write("─");
                }
                for (int i = 1; i <= Yukseklik; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("│");
                }
                for (int i = 1; i <= Yukseklik; i++)
                {
                    Console.SetCursorPosition((Genislik + 1), i);
                    Console.Write("│");
                }
                Console.SetCursorPosition(0, 0);
                Console.Write("┌");
                Console.SetCursorPosition((Genislik + 1), 0);
                Console.Write("┐");
                Console.SetCursorPosition(0, (Yukseklik + 1));
                Console.Write("└");
                Console.SetCursorPosition((Genislik + 1), (Yukseklik + 1));
                Console.Write("┘");
            }
        }
    }
}

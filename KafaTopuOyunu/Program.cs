//MUHAMMED EMİN KARAÇETE
//B211200044
//BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafaTopuOyunu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            KafaTopu kafaTopu = new KafaTopu(60, 20);
            kafaTopu.Hareket();
        }
        
    }
}

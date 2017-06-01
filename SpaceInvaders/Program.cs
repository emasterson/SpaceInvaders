using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace SpaceInvaders
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            Directory.SetCurrentDirectory(dir + @"\Resources");

            //Image A = new Image(ImageNames.Squid_0, 1, 11, 111, 1111);
            //Image B = new Image(ImageNames.Squid_1, 2, 22, 222, 2222);
            //Image C = new Image(ImageNames.Crab_0, 3, 33, 333, 3333);

            //ImageManager.add(A);
            //ImageManager.add(B);
            //ImageManager.add(C);

            


            ////static method
            //Image found =  ImageManager.find(ImageNames.Squid_0);
            Game engine = new Game();
            engine.Run();

            

        }
    }
}

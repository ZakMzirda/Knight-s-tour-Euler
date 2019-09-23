using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevinConsole
{
        class jeu
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Saisir un nombre entre 1 et 100 : ");
                int c = Convert.ToInt32(Console.ReadLine());
                int cible = (new System.Random()).Next(1, 100);
                int cpt = 0;
                //Console.WriteLine("la cible est " +cible);
                while (c != cible && cpt != 6)
                {
                    cpt++;
                    if (c < cible)
                    {
                        Console.WriteLine(" Le nombre est plus grand...  Ressaisir : ");
                        c = Convert.ToInt32(Console.ReadLine());

                    }
                    else if (c > cible)
                    {
                        Console.WriteLine(" Le nombre est plus petit...  Ressaisir : ");
                        c = Convert.ToInt32(Console.ReadLine());

                    }

                }
                if (cpt == 6)
                {
                    Console.WriteLine("Nombre de tentatives atteint : Perdu !");
                    Console.ReadKey();
                }
                if (c == cible)
                {
                    Console.WriteLine(" Trouvé !");
                }


                Console.ReadKey();
            }
        }


}

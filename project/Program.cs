using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Program
    {
        const int NormalAttackEne = 5;
        const int specialattackene = 10;
        const int healthene = 10;
        const int healaction = 1;
        const int otheraction = 3;
        static void Main(string[] args)
        {
            int phealth = 100;
            int ehealth = 100;
            int pstam = 50;
            int estam = 50;

            while (phealth > 0 && ehealth > 0)
            {
                //int turn = 0;
                for (int turn = 0; turn < 2; turn++)
                {
                    Console.WriteLine(turn);
                }
                //turn = 0;

                int action1 = 3;
                int playerpriority = 1;
                int enemypriority = 0;

                while (action1 >= 1)
                {
                    Console.WriteLine("\nYour health: " + phealth);
                    Console.WriteLine("Your stamnina: " + pstam);
                    Console.WriteLine("Enemy health: " + ehealth);
                    Console.WriteLine("Enemy stamina: " + estam);


                    Console.WriteLine("\n[1] Attack         [Damage: 1-10] [Accuracy: 80] [Cost: 5 energy]");
                    Console.WriteLine("\n[2] Special Attack [Damage: 5-20] [Accuracy: 50] [Cost: 10 energy]");
                    Console.WriteLine("\n[3] Recharge       [Recharge 4x energy] [+20% enemy accuracy] [Cost: 0 energy]");
                    Console.WriteLine("\n[4] Dodge          [Decrease enemy accuracy by 30%] [decrease energy recharge for this turn by 50%} [Cost: 0 energy]");
                    Console.WriteLine("\n[5] Heal           [Heal health 1-50]  [1 Health costs 1 energy] [Base cost 10 energy] [Healing does not cost an action]\n");
                    Console.WriteLine("type the corresponding move number below 1-5\n");
                    int playermove = Convert.ToInt32(Console.ReadLine());



                    if (playermove < 1 || playermove > 5)
                    {
                        Console.WriteLine("\nThat number is not an option, please try again\n");
                        Console.WriteLine("please press ENTER to continue\n");
                        Console.ReadLine();
                    }
                    if (playermove == 1)
                    {
                        playerpriority = playerpriority - 1;
                        pstam = pstam - NormalAttackEne;
                        Random rnd = new Random();
                        int playerattack = rnd.Next(1, 10);
                        action1 = action1 - otheraction;
                    }
                    if (playermove == 2)
                    {
                        playerpriority = playerpriority - 1;
                        pstam = pstam - specialattackene;
                        Random rnd = new Random();
                        int playerattack = rnd.Next(5, 20);
                        action1 = action1 - otheraction;
                    }
                    if (playermove == 3)
                    { action1 = action1 - otheraction; }
                    if (playermove == 4)
                    { action1 = action1 - otheraction; }
                    if (playermove == 5 && action1 == 3)
                    { action1 = action1 - healaction;
                        phealth = phealth - 1;
                    }
                    if (playermove == 5 && action1 < 3)
                    { }
                    
                }
                

                
            } 
          
        } 
    }
}

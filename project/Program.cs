using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
        const int attacklow = 1;
        const int attackhigh = 10;
        const int specialattacklow = 5;
        const int specialattackhigh = 20;
        const int rechargeaccuracychange = -20;
        const int dodgeaccuracychange = 30;


       enum Action
        { 
           attack = 1,
           specialattack,
           recharge,
           dodge,
           healing
        }


        



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


                Random randhit = new Random();
                int playeraccuracy = randhit.Next(1, 100);
                int enemyaccuracy = randhit.Next(1, 100);
                int currhitaccuracy = randhit.Next(1, 100);

                bool playerattackbool = false;
                bool eattack = false;
                bool pspecialattack = false;
                bool especialattack = false;

                int action1 = 3;
                int action2 = 3;
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
                    Action Playermove = (Action)Convert.ToInt32(Console.ReadLine());



                    if ((int)Playermove < 1 || (int)Playermove > 5)
                    {
                        Console.WriteLine("\nThat number is not an option, please try again\n");
                        Console.WriteLine("please press ENTER to continue\n");
                        Console.ReadLine();
                    }
                    if (Playermove == Action.attack)
                    {
                        playerpriority = playerpriority - 1;
                        pstam = pstam - NormalAttackEne;
                        Random rnd = new Random();
                        int playerattack = rnd.Next(attacklow, attackhigh);
                        action1 = action1 - otheraction;
                        playerattackbool = true;
                    }
                    if (Playermove == Action.specialattack)
                    {
                        playerpriority = playerpriority - 1;
                        pstam = pstam - specialattackene;
                        Random rnd = new Random();
                        int playerattack = rnd.Next(specialattacklow, specialattackhigh);
                        action1 = action1 - otheraction;
                    }
                    if (Playermove == Action.recharge)
                    { action1 = action1 - otheraction;
                        
                        enemyaccuracy = enemyaccuracy + rechargeaccuracychange;
                       
                    } 


                    if (Playermove == Action.dodge)
                    { action1 = action1 - otheraction;
                        enemyaccuracy = enemyaccuracy + dodgeaccuracychange;
                    }

                    if (Playermove == Action.healing && action1 < 3)
                    {
                        Console.WriteLine("\nYou may only heal once per turn, please press enter to continue your turn.");
                        Console.ReadLine();
                    }
                    if (Playermove == Action.healing && action1 == 3)
                    {
                        action1 = action1 - healaction;
                        phealth = phealth - 1;
                        pstam = pstam - healthene;
                    }






                }

                Random rndene = new Random();
                Action enemymove = (Action) rndene.Next(1, 5);

                while (action2 >= 1)
                {


                    if (enemymove == Action.attack)
                    {
                        enemypriority = enemypriority - 1;
                        estam = estam - NormalAttackEne;
                        Random rnd = new Random();
                        int enemyattack = rnd.Next(1, 10);
                        action2 = action2 - otheraction;
                    }
                    if (enemymove == Action.specialattack)
                    {
                        enemypriority = enemypriority - 1;
                        pstam = pstam - specialattackene;
                        Random rnd = new Random();
                        int enemyattack = rnd.Next(5, 20);
                        action2 = action2 - otheraction;
                    }
                    if (enemymove == Action.recharge)
                    { action2 = action2 - otheraction;
                        playeraccuracy = playeraccuracy + rechargeaccuracychange;
                    }

                    if (enemymove == Action.dodge)
                    { action2 = action2 - otheraction;
                        playeraccuracy = playeraccuracy + dodgeaccuracychange;
                    }

                    if (enemymove == Action.healing && action2 < 3)
                    {
                        
                    }
                    if (enemymove == Action.healing && action2 == 3)
                    {
                        action2 = action2 - healaction;
                        ehealth = ehealth - 1;
                        estam = estam - healthene;
                    }

                  
                }
                if (playerattackbool == true)
                { Console.WriteLine(playeraccuracy  );
                    Console.WriteLine(currhitaccuracy);
                }
            }
        }
    }
}

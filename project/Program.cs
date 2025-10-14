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
        const int attackhigh = 11;
        const int specialattacklow = 5;
        const int specialattackhigh = 21;
        const int rechargeaccuracychange = -20;
        const int dodgeaccuracychange = 30;
        const int normalattackaccuracy = 80;
        const int specialattackaccuracy = 50;
        const int endturnenergy = 4;
        const int dodgeenergy = 2;
        const int rechargeenergy = 16;
        const int maxenergy = 50;
        const int maxhealth = 100;


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
            int phealth = maxhealth;
            int ehealth = maxhealth;
            int pstam = maxenergy;
            int estam = maxenergy;

            Random rndene = new Random();





            while (phealth > 0 && ehealth > 0)
            {
               

                Random randhit = new Random();
                int playeraccuracy = randhit.Next(1, 101);
                int enemyaccuracy = randhit.Next(1, 101);
                int playerattackdamage = randhit.Next(attacklow, attackhigh);
                int playerspecialattackdamage = randhit.Next(specialattacklow, specialattackhigh);
                int enemyattackdamage = randhit.Next(attacklow, attackhigh);
                int enemyspecialattackdamage = randhit.Next(specialattacklow, specialattackhigh);


                bool playerattackbool = false;
                bool eattack = false;
                bool pspecialattack = false;
                bool especialattack = false;

                int action1 = 3;
                int action2 = 3;
                int playerpriority = 1;
                int enemypriority = 0;

                if (pstam > 50)
                { pstam = 50; }
                if (estam > 50)
                { estam = 50; }
                if (phealth > 100)
                { phealth = 10; }
                if (ehealth > 50)
                { ehealth = 50; }


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
                    Console.WriteLine("\n[5] Heal           [Heal health 1-20]  [will heal equal to half your energy] [Base cost 10 energy plus half of what remains] [Healing does not cost an action AND will not go over 100hp]\n");
                    Console.WriteLine("type the corresponding move number below 1-5\n");
                    Action Playermove = (Action)Convert.ToInt32(Console.ReadLine());



                    if ((int)Playermove < 1 || (int)Playermove > 5)
                    {
                        Console.WriteLine("\nThat number is not an option, please try again\n");
                        Console.WriteLine("please press ENTER to continue\n"); 
                        Console.ReadLine();
                    }
                    if (Playermove == Action.attack && pstam >= NormalAttackEne)
                    {
                        playerpriority = playerpriority - 1;
                        pstam = pstam - NormalAttackEne;
                        action1 = action1 - otheraction;
                        playerattackbool = true;
                        pstam = pstam + endturnenergy;
                        Console.WriteLine("\nYou choose to attack your enemy");

                    }
                    if (Playermove == Action.specialattack && pstam >= specialattackene)
                    {
                        playerpriority = playerpriority - 1;
                        pstam = pstam - specialattackene;
                        action1 = action1 - otheraction;
                        pspecialattack = true;
                        pstam = pstam + endturnenergy;
                        Console.WriteLine("\nYou choose to us a special attack on your enemy");
                    }
                    if (Playermove == Action.recharge)
                    {
                        action1 = action1 - otheraction;
                        enemyaccuracy = enemyaccuracy + rechargeaccuracychange;
                        pstam = pstam + rechargeenergy;
                        Console.WriteLine("\nYou try to recharge your energy");
                    }


                    if (Playermove == Action.dodge)
                    {
                        action1 = action1 - otheraction;
                        enemyaccuracy = enemyaccuracy + dodgeaccuracychange;
                        pstam = pstam + dodgeenergy;
                        Console.WriteLine("\nYou try to dodge your enemies attack");
                    }

                    if (Playermove == Action.healing && action1 < 3)
                    {
                        Console.WriteLine("\nYou may only heal once per turn, please press enter to continue your turn.");
                        Console.ReadLine();
                    }
                    if (Playermove == Action.healing && action1 == 3 && pstam >= healthene)
                    {
                        action1 = action1 - healaction;
                        phealth = phealth - 1;
                        pstam = pstam - healthene;                        
                        int healthgained = pstam / 2;
                        pstam = pstam / 2;
                        phealth = phealth + healthgained;
                        Console.WriteLine("\nYou meditate and gain");
                        Console.WriteLine("+" + healthgained + " health");
                    
                    }
                    





                }



                while (action2 >= 1)
                {

                    Action enemymove = (Action)rndene.Next(1, 6);


                    if (enemymove == Action.attack && estam >= NormalAttackEne)
                    {
                        enemypriority = enemypriority - 1;
                        estam = estam - NormalAttackEne;
                        action2 = action2 - otheraction;
                        eattack = true;
                        estam = estam + endturnenergy;
                        Console.WriteLine("\nYour enemy swings his sword in a normal attack");
                    }
                    if (enemymove == Action.specialattack && estam >= specialattackene)
                    {
                        enemypriority = enemypriority - 1;
                        estam = estam - specialattackene;
                        action2 = action2 - otheraction;
                        especialattack = true;
                        estam = estam + endturnenergy;
                        Console.WriteLine("\nYour enemy tries to hit you with a special attack");
                    }
                    if (enemymove == Action.recharge)
                    {
                        action2 = action2 - otheraction;
                        playeraccuracy = playeraccuracy + rechargeaccuracychange;
                        estam = estam + rechargeenergy;
                        Console.WriteLine("\nYour enemy spends a turn resting to try gaion energy back");
                    }

                    if (enemymove == Action.dodge)
                    {
                        action2 = action2 - otheraction;
                        playeraccuracy = playeraccuracy + dodgeaccuracychange;
                        estam = estam + dodgeenergy;
                        Console.WriteLine("\nYour enemy attempts to dodge any attacks you may make");
                    }

                    if (enemymove == Action.healing && action2 < 3)
                    {

                    }
                    if (enemymove == Action.healing && action2 == 3 && estam >= healthene)
                    {
                        action2 = action2 - healaction;
                        ehealth = ehealth - 1;
                        estam = estam - healthene;                        
                        int healthgained = estam / 2;
                        estam = estam / 2;
                        ehealth = ehealth + healthgained;
                        Console.WriteLine("\nEnemy healed for +" + healthgained + " health");
                    }
                    Console.WriteLine("\nPress enter to continue");
                    Console.ReadLine();

                }
               
                if (playerattackbool == true)
                {
                   
                    if (playeraccuracy <= normalattackaccuracy)
                    {
                        Console.WriteLine("\nYour attack lands and you hit the enemy for " + playerattackdamage + " damage");
                        ehealth = ehealth - playerattackdamage;
                    }
                    if (playeraccuracy > normalattackaccuracy)
                    { Console.WriteLine("You miss your attack"); }



                }
                if (pspecialattack == true)
                {
                    
                    if (playeraccuracy <= specialattackaccuracy)
                    {
                        Console.WriteLine("\nYour special attack lands and deals a staggering" + playerspecialattackdamage + " damage");
                        ehealth = ehealth - playerspecialattackdamage;
                    }
                    if (playeraccuracy > specialattackaccuracy)
                    { Console.WriteLine("\nYou tragically miss the enemy"); }
                }
                if (eattack == true)
                {
                   
                    if (enemyaccuracy <= normalattackaccuracy)
                    {
                        Console.WriteLine("\n\n\n The lands a hit and you take" + enemyattackdamage + " damage");
                        phealth = phealth - enemyattackdamage;
                    }
                    if (enemyaccuracy > normalattackaccuracy)
                    { Console.WriteLine("\n\n\n Luckily the enemy missed"); }
                }
                if (especialattack == true)
                {
                    
                    if (enemyaccuracy <= specialattackaccuracy)
                    {
                        Console.WriteLine("\n\n\n Unfortunately the enemy lands a special attack for" + enemyattackdamage + " damage");
                        phealth = phealth - enemyattackdamage;
                    }
                    if (enemyaccuracy > specialattackaccuracy)
                    { Console.WriteLine("\n\n\n Luckily the enemy missed"); }
                }
                Console.WriteLine("\n\n\nPlease press enter to continue");
                    Console.ReadLine();
            }
            if (ehealth <= 0)
            {
                Console.WriteLine("\n you WIN");

                Console.ReadLine();
            }
            if (phealth <= 0)
            {
                Console.WriteLine("\n you ARE A LOSER");

                Console.ReadLine();
            }







        }
    }
}
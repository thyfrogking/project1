using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace project
{



    internal class Program
    {



        const int NormalAttackEnergy = 5;
        const int specialattackenergy = 10;
        const int healthenergy = 10;
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
        const int healthbardivider = 10;
        const int staminabardivider = 5;
        const int minimummove = 1;
        const int maximummove = 5;
        const int healthenergychanger = 2;



        enum Action
        {
            attack = 1,
            specialattack,
            recharge,
            dodge,
            healing,
        }






        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;


            Random rndene = new Random();

            int winstreak = 0;
            bool continueplaying = false;
            bool continuemenu = true;

            while (continuemenu == true)
            {

                Console.WriteLine("\nMAIN MENU");
                Console.WriteLine("\n[1] Play");
                Console.WriteLine("\n[2] End game\n");


                int menuinput = 0;
                string newinput = Console.ReadLine();
                if (!int.TryParse(newinput, out menuinput))
                {


                    Console.Clear();
                    continue;
                }

                if (menuinput == 1)
                {
                    continueplaying = true;
                    Console.Clear();
                }
                else if (menuinput == 2)
                { continuemenu = false; }
                else 
                {
                    Console.WriteLine("\nthat is not an option please try again\n");
                }


                while (continueplaying == true)
                {

                    int playerhealth = maxhealth;
                    int enemyhealth = maxhealth;
                    int playerstamina = maxenergy;
                    int enemystamina = maxenergy;
                    while (playerhealth > 0 && enemyhealth > 0)
                    {

                        // generates required accuracy at the start of each turn aswell as damage for each attack
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

                        //prioirty so turns can loop when needed as well as making sure the player or the enemy change statuses before the attacks occur (accuracy changes)
                        int action1 = 3;
                        int action2 = 3;
                        int playerpriority = 1;
                        int enemypriority = 0;


                        if (playerstamina > maxenergy)
                        { playerstamina = maxenergy; }
                        if (enemystamina > maxenergy)
                        { enemystamina = maxenergy; }
                        if (playerhealth > maxhealth)
                        { playerhealth = maxhealth; }
                        if (enemyhealth > maxhealth)
                        { enemyhealth = maxhealth; }


                        while (action1 >= 1)
                        {

                            // this is the general health and stamina bars 
                            Console.Write("\nYour health:   ");
                            int healthbar = playerhealth / healthbardivider;
                            for (int i = 0; i < healthbar; i++)
                            {
                                Console.Write('■');
                            }
                            Console.WriteLine(" " + playerhealth + "/" + maxhealth);
                            Console.Write("Your stamina:  ");
                            int staminabar = playerstamina / staminabardivider;
                            for (int i = 0; i < staminabar; i++)
                            {
                                Console.Write('■');
                            }
                            Console.WriteLine(" " + playerstamina + "/" + maxenergy);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Enemy health:  ");
                            int enemyhealthbar = enemyhealth / healthbardivider;
                            for (int i = 0; i < enemyhealthbar; i++)
                            {
                                Console.Write('■');
                            }
                            Console.WriteLine(" " + enemyhealth + "/" + maxhealth);
                            Console.Write("Enemy stamina: ");
                            int enemystaminabar = enemystamina / staminabardivider;
                            for (int i = 0; i < enemystaminabar; i++)
                            {
                                Console.Write('■');
                            }
                            Console.WriteLine(" " + enemystamina + "/" + maxenergy);


                            // this displays the players move options
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\n[1] Attack         [Damage: 1-10] [Accuracy: 80] [Cost: 5 energy]");
                            Console.WriteLine("\n[2] Special Attack [Damage: 5-20] [Accuracy: 50] [Cost: 10 energy]");
                            Console.WriteLine("\n[3] Recharge       [Recharge 4x energy] [+20% enemy accuracy] [Cost: 0 energy]");
                            Console.WriteLine("\n[4] Dodge          [Decrease enemy accuracy by 30%] [decrease energy recharge for this turn by 50%} [Cost: 0 energy]");
                            Console.WriteLine("\n[5] Heal           [Heal health 1-20]  [will heal equal to half your energy] [Base cost 10 energy plus half of what remains] [Healing does not cost an action AND will not go over 100hp]\n");
                            Console.WriteLine("type the corresponding move number below 1-5\n");
                            int inputint = 0;
                            string rawinput = Console.ReadLine();
                            if (!int.TryParse(rawinput, out inputint))
                            {


                                Console.Clear();
                                continue;
                            }
                            Action Playermove = (Action)inputint;


                            // commits the actions the player inputted
                            if ((int)Playermove < minimummove || (int)Playermove > maximummove)
                            {

                                Console.WriteLine("\nThat number is not an option, please try again\n");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("please press ENTER to continue\n");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.ReadLine();
                            }
                            if (Playermove == Action.attack)
                            {
                                if (playerstamina >= NormalAttackEnergy)
                                {
                                    playerpriority = playerpriority - 1;
                                    playerstamina = playerstamina - NormalAttackEnergy;
                                    action1 = action1 - otheraction;
                                    playerattackbool = true;
                                    playerstamina = playerstamina + endturnenergy;
                                    Console.WriteLine("\nYou choose to attack your enemy");
                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("\nYou dont enough energy please choose another move\n");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                }

                            }
                            if (Playermove == Action.specialattack)
                            {
                                if (playerstamina >= specialattackenergy)
                                {
                                    playerpriority = playerpriority - 1;
                                    playerstamina = playerstamina - specialattackenergy;
                                    action1 = action1 - otheraction;
                                    pspecialattack = true;
                                    playerstamina = playerstamina + endturnenergy;
                                    Console.WriteLine("\nYou choose to us a special attack on your enemy");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("\nYou dont have enough energy please choose another move\n");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                }

                            }
                            if (Playermove == Action.recharge)
                            {
                                action1 = action1 - otheraction;
                                enemyaccuracy = enemyaccuracy + rechargeaccuracychange;
                                playerstamina = playerstamina + rechargeenergy;
                                Console.WriteLine("\nYou try to recharge your energy");
                            }


                            if (Playermove == Action.dodge)
                            {
                                action1 = action1 - otheraction;
                                enemyaccuracy = enemyaccuracy + dodgeaccuracychange;
                                playerstamina = playerstamina + dodgeenergy;
                                Console.WriteLine("\nYou try to dodge your enemies attack");
                            }

                            if (Playermove == Action.healing && action1 < otheraction)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\nYou may only heal once per turn, please press enter to continue your turn.");
                                Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            if (Playermove == Action.healing && action1 == otheraction)
                            {
                                if (playerstamina >= healthenergy)
                                {
                                    action1 = action1 - healaction;


                                    playerstamina = playerstamina - healthenergy;
                                    int healthgained = playerstamina / healthenergychanger;
                                    playerhealth = playerhealth + healthgained;
                                    playerstamina = playerstamina / healthenergychanger;

                                    Console.Write("\nYou meditate and gain");
                                    Console.WriteLine(" +" + healthgained + " health\n");
                                    if (playerhealth > maxhealth)
                                    { playerhealth = maxhealth; }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("\nYou dont have enough energy to heal please choose a different move\n");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                }


                            }






                        }




                        //enemy turn randomises a move and then commits the action
                        while (action2 >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Action enemymove = (Action)rndene.Next(1, 6);


                            if (enemymove == Action.attack && enemystamina >= NormalAttackEnergy)
                            {
                                enemypriority = enemypriority - 1;
                                enemystamina = enemystamina - NormalAttackEnergy;
                                action2 = action2 - otheraction;
                                eattack = true;
                                enemystamina = enemystamina + endturnenergy;
                                Console.WriteLine("\nYour enemy swings his sword in a normal attack");
                            }
                            if (enemymove == Action.specialattack && enemystamina >= specialattackenergy)
                            {
                                enemypriority = enemypriority - 1;
                                enemystamina = enemystamina - specialattackenergy;
                                action2 = action2 - otheraction;
                                especialattack = true;
                                enemystamina = enemystamina + endturnenergy;
                                Console.WriteLine("\nYour enemy tries to hit you with a special attack");
                            }
                            if (enemymove == Action.recharge)
                            {
                                action2 = action2 - otheraction;
                                playeraccuracy = playeraccuracy + rechargeaccuracychange;
                                enemystamina = enemystamina + rechargeenergy;
                                Console.WriteLine("\nYour enemy spends a turn resting to try gain energy back");
                            }

                            if (enemymove == Action.dodge)
                            {
                                action2 = action2 - otheraction;
                                playeraccuracy = playeraccuracy + dodgeaccuracychange;
                                enemystamina = enemystamina + dodgeenergy;
                                Console.WriteLine("\nYour enemy attempts to dodge any attacks you may make");
                            }

                            if (enemymove == Action.healing && action2 < otheraction)
                            {

                            }
                            if (enemymove == Action.healing && action2 == otheraction && enemystamina >= healthenergy)
                            {
                                action2 = action2 - healaction;
                                enemystamina = enemystamina - healthenergy;
                                int healthgained = enemystamina / healthenergychanger;
                                enemyhealth = enemyhealth + healthgained;
                                enemystamina = enemystamina / healthenergychanger;
                                enemyhealth = enemyhealth + healthgained;
                                Console.WriteLine("\nEnemy healed for +" + healthgained + " health");
                                if (enemyhealth > maxhealth)
                                { enemyhealth = maxhealth; }
                            }


                        }

                        //display attacks and damage as well as showing if the user misses
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        if (playerattackbool == true)
                        {

                            if (playeraccuracy <= normalattackaccuracy)
                            {
                                Console.WriteLine("\nYour attack lands and you hit the enemy for " + playerattackdamage + " damage");
                                enemyhealth = enemyhealth - playerattackdamage;
                            }
                            if (playeraccuracy > normalattackaccuracy)
                            { Console.WriteLine("\nYou miss your attack"); }



                        }
                        if (pspecialattack == true)
                        {

                            if (playeraccuracy <= specialattackaccuracy)
                            {
                                Console.WriteLine("\nYour special attack lands and deals a staggering " + playerspecialattackdamage + " damage");
                                enemyhealth = enemyhealth - playerspecialattackdamage;
                            }
                            if (playeraccuracy > specialattackaccuracy)
                            { Console.WriteLine("\nYou tragically miss the enemy"); }
                        }
                        if (eattack == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (enemyaccuracy <= normalattackaccuracy)
                            {

                                Console.WriteLine("\nThe lands a hit and you take " + enemyattackdamage + " damage");
                                playerhealth = playerhealth - enemyattackdamage;
                            }
                            if (enemyaccuracy > normalattackaccuracy)
                            { Console.WriteLine("\nLuckily the enemy missed"); }
                        }
                        if (especialattack == true)
                        {

                            if (enemyaccuracy <= specialattackaccuracy)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nUnfortunately the enemy lands a special attack for " + enemyattackdamage + " damage");
                                playerhealth = playerhealth - enemyattackdamage;
                            }
                            if (enemyaccuracy > specialattackaccuracy)
                            { Console.WriteLine("\nLuckily the enemy missed"); }
                        }

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nPress enter to continue\n");
                        Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Clear();


                    }


                    // the end of the game and loop
                    if (enemyhealth <= 0)
                    {
                        winstreak = winstreak + 1;
                        int loop = 1;
                        while (loop == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("\nCongrats you won against the enemy");
                            
                            Console.WriteLine("\nYou have a winstreak of " + winstreak + " would you like to continue\n [1] Yes \n [2] No");
                            int inputint = 0;
                            string rawinput = Console.ReadLine();
                            if (!int.TryParse(rawinput, out inputint))
                            {


                                Console.Clear();
                                continue;
                            }
                            if (inputint == 1)
                            { loop = loop - 1; }
                            if (inputint == 2)
                            {
                                loop = loop - 1;
                                continueplaying = false;
                                winstreak = 0;
                            }
                            if (inputint < 1 || inputint > 2)
                            { Console.WriteLine("Please try again that number isnt an option"); }

                        }
                        Console.Clear();
                    }
                    if (playerhealth <= 0 && enemyhealth > 0)
                    {
                        int loop = 1;
                        while (loop == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nWait really you lost? I thought you were better than this.");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nYou had a winstreak of " + winstreak + " would you like to try again\n [1] Yes \n [2] No");
                            winstreak = 0;
                            int inputint = 0;
                            string rawinput = Console.ReadLine();
                            if (!int.TryParse(rawinput, out inputint))
                            {


                                Console.Clear();
                                continue;
                            }
                            if (inputint == 1)
                            {
                                loop = loop - 1;
                            }
                            if (inputint == 2)
                            {
                                loop = loop - 1;
                                continueplaying = false;
                            }
                            if (inputint < 1 || inputint > 2)
                            { Console.WriteLine("Please try again that number isnt an option"); }
                        }
                        Console.Clear();
                    }
                }

            }









        }
    }
}

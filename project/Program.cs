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
        static void Main(string[] args)
        {
            int phealth = 100;
            int ehealth = 100;
            int pstam = 50;
            int estam = 50;

            while(phealth > 0 && ehealth > 0)
            {
                Console.WriteLine("Your health: " + phealth);
                Console.WriteLine("Your stamnina: " + pstam);
                Console.WriteLine("Enemy health: " + ehealth);
                Console.WriteLine("Enemy stamina: " + estam);

                
                Console.WriteLine("\n[1] Attack           [Damage: 1-10] [Accuracy: 80] [Cost: 5 energy]");
                Console.WriteLine("\n[2] Special Attack   [Damage: 5-20] [Accuracy: 50] [Cost: 10 energy]");
                Console.WriteLine("\n[3] Recharge         [Recharge 4x energy] [+20% enemy accuracy] [Cost: 0 energy]");
                Console.WriteLine("\n[4] Dodge            [Decrease enemy accuracy by 30%] [Cost: 0 energy]");
                Console.WriteLine("\n[5] Heal             [Heal health 1-50] [1 Health costs 2 energy] [Healing does not cost an action]\n");
                Console.WriteLine("type the corresponding move number below 1-5\n");
                int playerturn = Convert.ToInt32(Console.ReadLine());

                if (playerturn < 1 || playerturn > 5)
                {
                    Console.WriteLine("\nThat number is not an option, please try again\n");
                    Console.WriteLine("please press ENTER to continue\n");
                    Console.ReadLine();
                }
                if (playerturn == 1) 
                    
                    //dffjhvbjkkojnojmnojmno
                {

                }
            }
          
        } 
    }
}

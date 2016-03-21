using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCyberpunk
{
    class DiceBag
    {
        public static Random MyRNG = new Random();
        public Int16 diceresult;
        public Int16[] handresult;

        // [0] : Total for all dice
        // [i] : result of a die roll


        public void RollDice(Int16 nbrDice, Int16 dicetype)
        {
            Int16[] thishandresult = new Int16[nbrDice + 1];
            thishandresult[0] = 0;

            for (Int16 i = 1; i <= nbrDice; i++)
            {
                DiceBag dice = new DiceBag();
                dice.RollDie(dicetype);

                thishandresult[0] += dice.diceresult;
                thishandresult[i] = dice.diceresult;
            }
            handresult = thishandresult;
        }

        public void RollDie(Int16 nMaxValue)
        {

            Int16 randomNumber1 = (Int16)(MyRNG.Next(0, nMaxValue) + 1);
            diceresult = randomNumber1;

        }

        public Int16 ThrowDice(Int16 nbrDice, Int16 dicetype)
        {
            Int16[] thishandresult = new Int16[nbrDice + 1];
            thishandresult[0] = 0;

            for (Int16 i = 1; i <= nbrDice; i++)
            {
                DiceBag dice = new DiceBag();
                dice.RollDie(dicetype);

                thishandresult[0] += dice.diceresult;
                thishandresult[i] = dice.diceresult;
            }

            return thishandresult[0];
        }

        public Int16 ThrowDice(Int16 nbrDice, Int16 dicetype, Int16 ReRollIfHigherThan)
        {
            Int16[] thishandresult = new Int16[nbrDice + 1];
            
            DiceBag dice = new DiceBag();  


            do
             {
                thishandresult[0] = 0; 
                for (Int16 i = 1; i <= nbrDice; i++)
                {
                          
                   dice.RollDie(dicetype);

                    thishandresult[0] += dice.diceresult;
                    thishandresult[i] = dice.diceresult;
                }
             }
            while (thishandresult[0] >= ReRollIfHigherThan);

            return thishandresult[0];
        }

        public void printString()
        {
            Console.WriteLine("{0}", diceresult.ToString());
        }


    }
}

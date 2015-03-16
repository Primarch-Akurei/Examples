using System;
using System.Threading;
using System.Collections.Generic;

namespace RandomEngine
{
    public class Example
    {
        private RandomEngine myRE = new RandomEngine();

        public Example()
        {
            //Only need to call this Once x Run
            myRE.initializeRandEngine();

            //Call matches format of Random.Next() only with our RandomEngine() as the class instead of Random()
            int randomNumber = myRE.Next(32);
            //randomNumber will be a value of the range 0-31

            doSomethingElse();

            InheritRandomExample extendExample = new InheritRandomExample();
            extendExample.inheritAndDoStuff(ref myRE);
        }

        public void doSomethingElse()
        {
            int newRandomNumber = myRE.Next(64);
        }

    }

    public class InheritRandomExample
    {
        public void inheritAndDoStuff(ref RandomEngine reToInherit)
        {
            int evenNewerRandomNumber = reToInherit.Next(128);
        }

    }

    public class RandomEngine
    {
        private Random[] rand = new Random[3];
        private int randomIndex = 0;

        public void initializeRandEngine()
        {
            rand[0] = new Random();
            Thread.Sleep(100);
            rand[1] = new Random();
            Thread.Sleep(100);
            rand[2] = new Random();
        }

        public int Next(int maxValue)
        {
            int myValue = -1;

            switch(randomIndex)
            {
                case 0: myValue = rand[0].Next(maxValue);
                        randomIndex++;
                    break;
                case 1: myValue = rand[1].Next(maxValue);
                        randomIndex++;
                    break;
                case 2: myValue = rand[2].Next(maxValue);
                        randomIndex = 0;
                    break;
            }

            return myValue;
        }
    }
}

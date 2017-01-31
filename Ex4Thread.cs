using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

// Ilustrerer problemerne omkring tråde og synkronisering, hvis flere tråde arbejder på samme objekt

namespace ThreadEx
{
    public class Ex4Thread
    {
        private int threadCount = 0;
        private int count = 0;
        private char tegn;
        private int tal;
        public Ex4Thread(char tegn, int count)
        {
            this.count = count;
            this.tegn = tegn;
        }
        public void RunTråd()
        {
            // ------------------------------------------------
            // Her kan komme synkroniseringsproblem - dog ikke så ofte
            // da det kun er meget lidt kode der kan afbrydes i
            // Here you get synchronization problem - though not as often 
            // as it is only very little code that can be interrupted for
            int frem = threadCount;
            char wtegn = (char)(((int)tegn) + frem); // tegn ændres ved flere tråde på samme object
            // signs changed by multiple threads at the same object
            threadCount++;
            // ------------------------------------------------

            Random random = new Random();

            for (int gange = 0; gange < count; gange++)
            {
                System.Console.Write(wtegn);
                for (int x = 0; x < 20000000; x++) ;       // lav en forsinkelse aktiv. Low delay active

                //--------------------------------------------------------
                // Her kan forekomme synkroniserings problemer. Here occur synchronization problems
                // pausen fremprovokerer for tydeligheden. break provokes for clarity
                tal = tal + 1;                              // synkroniserings problem skabes. synchronization problem created
                Thread.Sleep(random.Next(1, 20));            // lav en forsinkelse pasiv. Low delay passive
                tal = tal - 1;
                wtegn = (char)(((int)wtegn) + tal);         // da tal skulle være 0. as the number should be 0
                // skulle wtegn ikke ændres. should not be changed wtegn
                //--------------------------------------------------------
            }
        }
    }
}

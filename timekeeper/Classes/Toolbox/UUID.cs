using System;
using System.Collections.Generic;
using System.Text;

namespace Timekeeper.Classes.Toolbox
{
    public class UUID
    {
        private static int Offset = 0;

        public static string Get()
        {
            // Fast UUID generation with virtually guaranteed
            // uniqueness, even in tight loops across instances.
            // Tested this on my HP Pavilion dv7-3165dx laptop
            // and generated about 123,000 UUIDs per second.

            // Base seed: current clock ticks (creates uniqueness across instances)
            int seed = unchecked((int)(DateTime.Now.Ticks));

            // Seed augmented by an offset/counter (creates uniqueness within an instance)
            seed += Offset++;

            // Now seed the generator and return the generated UUID
            Random rand = new Random(seed);
            return _generate(rand);
        }

        private static string _generate(Random rand)
        {
            int i;
            string result = "";

            // first group
            i = rand.Next(65535);
            result += i.ToString("X4");
            i = rand.Next(65535);
            result += i.ToString("X4") + "-";

            // reseed rand based on compliment of new tick count
            //rand = new Random(unchecked((int)DateTime.Now.Ticks));

            // second group
            i = rand.Next(65535);
            result += i.ToString("X4") + "-";

            // third group
            i = rand.Next(16384, 20479);  // 4000 - 4FFF
            result += i.ToString("X4") + "-";

            // fourth group
            i = rand.Next(32768, 49151);  // 8000 - BFFF
            result += i.ToString("X4") + "-";

            // fifth group
            i = rand.Next(65535);
            result += i.ToString("X4");
            i = rand.Next(65535);
            result += i.ToString("X4");
            i = rand.Next(65535);
            result += i.ToString("X4");

            return result;
        }

    }
}

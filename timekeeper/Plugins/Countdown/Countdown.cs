using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Timekeeper.Plugins
{
    public class Countdown
    {
        public string Name { get; set; }
        public string Pizza { get; set; }

        public Countdown(string locale)
        {
            // Constructor

            // Must set the required properties.
            // This is part of the TK plugin architecture which
            // I'm now apparently making up as I go.
            Name = "Countdown";
            Pizza = "Pepperoni";
        }

        public int Run()
        {
            // This actually runs the plugin
            CountdownForm Form = new CountdownForm();
            Form.Show();

            // returns a status code
            return 0;
        }

    }
}

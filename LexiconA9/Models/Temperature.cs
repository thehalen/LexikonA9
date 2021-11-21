using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA9.Models
{
    public class Temperature
    {
        readonly string scale;
        double temperature;
        public Temperature(double temp, string sca)
        {
            temperature = temp;
            scale = sca;
        }

        public double Temp { get => temperature; set => temperature = value; }

        public static string SupportedScales() //doesn't make sense to evaluate before we have an instance and values to work with...
        {
            return "This module supports fahrenheit and celsius";
        }

        public string Fever()
        {
            if (scale=="fahrenheit") temperature = ((temperature-32.0)*5.0/9.0);
            string res;
            switch (this.temperature)
            {
                case 3.6:
                    res = "Not great, not terrible. IF YOU ARE A FRIDGE!";
                    break;
                case < 0.0:
                    res = "Human popsicle.";
                    break;
                case < 20.0:
                    res = "Stage 4 profound hypothermia. No vital signs. You are dead. RIP.";
                    break;
                case < 28.0:
                    res = "Stage 3 severe hypothermia. Unconscious, not shivering.";
                    break;
                case < 32.0:
                    res = "Stage 2 moderate hypothermia. Drowsy and not shivering.";
                    break;
                case < 35.0:
                    res = "Stage 1 mild hypothermia. Awake and shivering.";
                    break;
                case < 36.5:
                    res = "A bit cold. Better do some jumping jacks!";
                    break;
                case < 37.5:
                    res = "Perfectly normal. Unless you're a beer or a cup of coffee.";
                    break;
                case < 38.3:
                    res = "You're running a bit of a fever. Water and paracetamol for you.";
                    break;
                case < 40:
                    res = "Severe hyperthermia. Better cool down quickly!";
                    break;
                case < 41.99:
                    res = "Hyperpyrexia. This is life threatening!";
                    break;
                case < 42:
                    res = "Answer to the Ultimate Question of Life, the Universe, and Everything. And the end of those things as far as you are concerned.";
                    break;
                case < 50:
                    res = "You are dead from heat stroke. RIP";
                    break;
                case < 54:
                    res = "Rare. Dr. Lecter approves.";
                    break;
                case < 65:
                    res = "Medium. Still juicy.";
                    break;
                case < 80:
                    res = "Well done. Probably a bit dry.";
                    break;
                default:
                    res = "You are aware that this is in " + scale + ", right?";
                    break;
            }
            return res;
        }
    }
}

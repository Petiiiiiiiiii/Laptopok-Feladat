using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA231209
{
    class Laptop
    {
        public int Azonosito { get; set; }
        public string ProcTipusSeb { get; set; }
        public double ProcSeb { get; set; }
        public string OperaciosRendszer { get; set; }
        public string GyartoModell { get; set; }
        public string Gyarto { get; set; }
        public double AkkuUzemido { get; set; }
        public double Suly { get; set; }
        public string KapcsolatokString { get; set; }
        public List<string> Kapcsolatok { get; set; }

        public Laptop(string sor)
        {
            var atmeneti = sor.Split('|');
            this.Azonosito = Convert.ToInt32(atmeneti[0]);
            this.ProcTipusSeb = atmeneti[1];
            this.OperaciosRendszer = atmeneti[2];
            this.GyartoModell = atmeneti[3];
            this.AkkuUzemido = Convert.ToDouble(atmeneti[4]);
            this.Suly = Convert.ToDouble(atmeneti[5]);
            this.KapcsolatokString = atmeneti[6];
            this.Kapcsolatok = new();

            var kapcsolatok = atmeneti[6].Split(',');
            for (int i = 0; i < kapcsolatok.Length; i++) this.Kapcsolatok.Add(kapcsolatok[i]);

            var processzorseb = atmeneti[1].Split(' ');
            this.ProcSeb = Convert.ToDouble(processzorseb[processzorseb.Length - 1]);

            var gyarto = atmeneti[3].Split(' ');
            this.Gyarto = gyarto[0];
            

        }

        public override string ToString()
        {
            return $"Azonosító: {this.Azonosito}\nProcesszor típusa és sebessége: {this.ProcTipusSeb}\nOperációs rendszer: {this.OperaciosRendszer}\nGyártó és Modell: {this.GyartoModell}\nAkkumulátor üzemideje: {this.AkkuUzemido} óra\nSúly: {this.Suly} Kg\nVezeték nélküli kapcsolatok: {this.KapcsolatokString}\n";
        }
        public double SulyToGramm() 
        {
            return this.Suly * 1000;
        }
    }
}

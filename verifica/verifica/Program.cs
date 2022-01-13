using System;

namespace verifica
{



    //Mondini Christian 4^F 13/01/2022 Verifica Informatica.

    class Treni
    {
        public string codtreno;
        public string tipo;
        public string nome;
        public double costo;

        public Treni(string codtreno,string tipo,string nome,double costo)//costruttore
        {
            this.codtreno = codtreno;
            this.tipo = tipo;
            this.nome = nome;
            this.costo = costo;
        }

        public virtual double Costomezzo()
        {
            return costo;
        }

        public virtual double Costoutilizzo(double km)
        {

            return km;
        }
    }

    class Passeggeri:Treni
    {
        public int numvagoni;  //attributi public e non protected pk servono per il console.writeline nel Main
        public string alimentazione;

        public Passeggeri(string codtreno, string tipo, string nome, double costo, int numvagoni, string alimentazione) : base(codtreno, tipo, nome, costo)//costruttore
        {
            this.numvagoni = numvagoni;
            this.alimentazione = alimentazione;
        }

        public override double Costomezzo()
        {
            return base.Costomezzo()*1.25;//calcolo il costo del Passeggeri aumentandone il 25%
        }

        public override double Costoutilizzo(double km)
        {
            return base.Costoutilizzo(km)*150;//per il Passeggeri il prezzo al km è 150
        }

    }

    class Merci : Treni
    {
        public int numvagoni;    //attributi public e non protected pk servono per il console.writeline nel Main
        public string alimentazione;

        public Merci(string codtreno, string tipo, string nome, double costo,int numvagoni,string alimentazione) : base(codtreno, tipo, nome, costo)//costruttore
        {
            this.numvagoni = numvagoni;
            this.alimentazione = alimentazione;
        }

        public override double Costomezzo()
        {
            return base.Costomezzo() * 1.35;//calcolo il costo del Merci aumentandone il 35%
        }

        public override double Costoutilizzo(double km)
        {
            return base.Costoutilizzo(km) * 100;//per il Merci il prezzo al km è 100
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
                         //Attributi istanza: codice treno,tipo treno, nome treno, costo treno, numero vagoni treno, alimentazione treno
            Passeggeri veicolo1 = new Passeggeri("123","regionale","passeggeri",100000,8,"carbone");//istanza della classe Passeggeri
            Merci veicolo2 = new Merci("278", "nazionale", "merci", 100000, 25, "benzina");//istanza della classe Merci
            Console.WriteLine("Treno passeggeri: codice del treno {0}, tipo di treno {1}, nome treno {2}, numero di vagoni {3}, alimentazione del treno {4}.",veicolo1.codtreno,veicolo1.tipo,veicolo1.nome,veicolo1.numvagoni,veicolo1.alimentazione);//Visualizzo i dati dei 2 treni
            Console.WriteLine("Treno Merci: codice del treno {0}, tipo di treno {1}, nome treno {2}, numero di vagoni {3}, alimentazione del treno {4}.", veicolo2.codtreno, veicolo2.tipo, veicolo2.nome, veicolo2.numvagoni, veicolo2.alimentazione);

            Console.WriteLine("Il costo del passeggeri è di:{0}", veicolo1.Costomezzo());//mostro a schermo il costo dei treni
            Console.WriteLine("Il costo del merci è di:{0}", veicolo2.Costomezzo());

            int km;
            Console.WriteLine("Inserire il numero di kilometri percorsi dai treni");//l'utente inserisce da tastiera il numero di kilometri percorsi dai treni
            km =int.Parse( Console.ReadLine());

            Console.WriteLine("Il costo dell'utilizzo del passeggeri è di:{0}",veicolo1.Costoutilizzo(km));//Costo utilizzo del Passeggeri
            Console.WriteLine("Il costo dell'utilizzo del merci è di:{0}", veicolo2.Costoutilizzo(km));//Costo utilizzo del Merci

            //ho inserito solo una misurazione dei kilometri in modo che ci fosse un confronto tra i 2 a parità di kilometri

            double costototale=(veicolo1.Costomezzo()+veicolo1.Costoutilizzo(km)+veicolo2.Costomezzo()+veicolo2.Costoutilizzo(km));//calcolo il costo totale dei 2 treni
            Console.WriteLine("Il costo totale dei due treni è di:{0}", costototale);//mostro a schermo il costototale

            Console.ReadKey();
        }
    }
}

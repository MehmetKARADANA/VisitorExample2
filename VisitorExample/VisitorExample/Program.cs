using System.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        //eski durum, yazıcıya bilgisayar gönderdiğimiz ters bir durum, şimdi visitor ile cihaza ilgili printerin yazdir methodunu çağırtacağız
        //The previous situation was a reverse scenario where we sent it to the printer from the computer; now, with the visitor,
        //we will invoke the printing method of the printer associated with the device.
        //Tab tab = new Tab(); 
        // Computer computer = new Computer();
        // HpPrinter printer = new HpPrinter();
        // CanonPrinter canonPrinter = new CanonPrinter();
        // printer.Print(tab);
        // printer.Print(computer);
        // canonPrinter.Print(tab);
        // canonPrinter.Print(computer);

         Tab tab = new Tab();
         Computer computer = new Computer();
         HpPrinter hpprinter = new HpPrinter();
         CanonPrinter canonPrinter = new CanonPrinter();

        tab.printer(hpprinter);
        tab.printer(canonPrinter);

        computer.print(hpprinter);
        computer.print(canonPrinter);





    }
}


interface IDevice//ELement
{
    public string producedocument();

    
}

class Computer : IDevice
{
   

    public string producedocument()
    {
        return "Computer";
    }

    public void print(PrinterComputer printerComputer)//accept
    {
        printerComputer.Print(this);

    }
}
class Tab : IDevice
{
    public string producedocument()
    {
        return "Tab";
    }

    public void printer(PrinterTab printerTab)
    {
        printerTab.Print(this);
    }


}


interface PrinterTab {
    public void Print(Tab tab);
}


interface PrinterComputer
{
    public void Print(Computer computer);
}

class HpPrinter : PrinterComputer, PrinterTab
{
    public void Print(Computer computer)
    {
        Console.WriteLine("printed by HP : {0}",computer.producedocument());
    }

    public void Print(Tab tab)
    {
        Console.WriteLine("printed by HP : {0}", tab.producedocument());
    }

   
}
class CanonPrinter  : PrinterComputer, PrinterTab {
    public void Print(Computer computer)
    {
        Console.WriteLine("printed by Canon : {0}", computer.producedocument());
    }

    public void Print(Tab tab)
    {
        Console.WriteLine("printed by Canon : {0}", tab.producedocument());
    }

}


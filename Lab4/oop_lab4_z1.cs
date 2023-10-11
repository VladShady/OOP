using System;

class Computer
{
    private Winchester hardDrive;
    private DiskDrive diskDrive;
    private RAM ram;
    private Processor processor;

    public Computer(Winchester hardDrive, DiskDrive diskDrive, RAM ram, Processor processor)
    {
        this.hardDrive = hardDrive;
        this.diskDrive = diskDrive;
        this.ram = ram;
        this.processor = processor;
    }

    public void TurnOn()
    {
        Console.WriteLine("Computer is turning on.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Computer is turning off.");
    }

    public void CheckForViruses()
    {
        Console.WriteLine("Checking for viruses...");
    }

    public void PrintHardDriveSize()
    {
        Console.WriteLine("Hard drive size: " + hardDrive.Size + " GB");
    }

    public override string ToString()
    {
        return "Computer Configuration:\n" +
               "Hard Drive: " + hardDrive + "\n" +
               "Disk Drive: " + diskDrive + "\n" +
               "RAM: " + ram + "\n" +
               "Processor: " + processor;
    }

    public override bool Equals(object obj)
    {
        if (obj is Computer other)
        {
            return hardDrive.Equals(other.hardDrive) &&
                   diskDrive.Equals(other.diskDrive) &&
                   ram.Equals(other.ram) &&
                   processor.Equals(other.processor);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return hardDrive.GetHashCode() ^ diskDrive.GetHashCode() ^ ram.GetHashCode() ^ processor.GetHashCode();
    }
}

class Winchester
{
    public int Size { get; }

    public Winchester(int size)
    {
        Size = size;
    }

    public override string ToString()
    {
        return "Winchester Size: " + Size + " GB";
    }

    public override bool Equals(object obj)
    {
        if (obj is Winchester other)
        {
            return Size == other.Size;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Size.GetHashCode();
    }
}

class DiskDrive
{
    public override string ToString()
    {
        return "Disk Drive";
    }

    public override bool Equals(object obj)
    {
        return obj is DiskDrive;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

class RAM
{
    public override string ToString()
    {
        return "RAM";
    }

    public override bool Equals(object obj)
    {
        return obj is RAM;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

class Processor
{
    public override string ToString()
    {
        return "Processor";
    }

    public override bool Equals(object obj)
    {
        return obj is Processor;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        Winchester hardDrive = new Winchester(500);
        DiskDrive diskDrive = new DiskDrive();
        RAM ram = new RAM();
        Processor processor = new Processor();

        Computer computer = new Computer(hardDrive, diskDrive, ram, processor);
        computer.TurnOn();
        computer.CheckForViruses();
        computer.PrintHardDriveSize();
        computer.TurnOff();

        Console.WriteLine(computer);

        Console.ReadLine();
    }
}

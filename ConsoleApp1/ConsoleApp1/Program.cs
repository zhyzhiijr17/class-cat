public enum Gender
{
    Male,
    Female
}

public class Cat
{
    public string Name { get; }
    public Gender Gender { get; }

    private double _energy;

    public static readonly double MaxEnergy = 20;
    public static readonly double MinEnergy = 0;
    public static readonly double SleepEnergyGain = 10;
    public static readonly double JumpEnergyDrain = 0.5;

    public double Energy
    {
        get => _energy;
        set
        {
            if (value < MinEnergy)
            {
                throw new Exception("Not enough energy to jump");
            }
            _energy = Math.Min(value, MaxEnergy);
        }
    }

    public Cat(string name, Gender gender)
    {
        Name = name;
        Gender = gender;
        Energy = MaxEnergy;
    }

    public void Jump()
    {
        Energy -= JumpEnergyDrain;
    }

    public void Sleep()
    {
        Energy += SleepEnergyGain;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Зчитування даних про кота
        Console.Write("Enter cat name: ");
        string name = Console.ReadLine();

        Console.Write("Enter cat gender (Male/Female): ");
        string genderInput = Console.ReadLine();
        Gender gender = genderInput.Equals("Male", StringComparison.OrdinalIgnoreCase) ? Gender.Male : Gender.Female;

        // Створення об'єкту Cat
        Cat myCat = new Cat(name, gender);
        Console.WriteLine($"Created Cat: Name: {myCat.Name}, Gender: {myCat.Gender}, Energy: {myCat.Energy}");

        // Демо стрибка
        myCat.Jump();
        Console.WriteLine($"Energy after jump: {myCat.Energy}");

        // Демо сну
        myCat.Sleep();
        Console.WriteLine($"Energy after sleep: {myCat.Energy}");

        // Пробування встановити енергію нижче мінімуму
        try
        {
            myCat.Energy = -5; // Це викличе виключення
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        myCat.Energy = 25; // Це має зберегти 20
        Console.WriteLine($"Energy after exceeding max: {myCat.Energy}");
    }
}
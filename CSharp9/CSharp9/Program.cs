
//Top Level Statement  



System.Console.WriteLine("Hello World! This is a top level statement with no Main method explicitly declared");

//RecordFeatures();

//CompareRecordInheritance();


//DisplayWeather();

//CalculateToll();

//Static anonymous functions
//const string text = "{0} is a beautiful country !";
//PromoteCountry(static country => string.Format(text, country));


//Attributes on local functions
[System.Diagnostics.Conditional("DEBUG")]
static void DoAction()
{
    // Perform action

    System.Console.WriteLine("Performing action");
}

DoAction();


//compare to 
#if DEBUG
DoAction();
#endif

//Get Enumerator
//Extensions.GetEnumeratorSupport();

System.Console.ReadLine();
void PromoteCountry(System.Func<string, string> func)
{

    var countries = new System.Collections.Generic.List<string> { "Canada", "France", "Japan" };

    foreach (var country in countries)
        System.Console.WriteLine(func(country));
}

void RecordFeatures()
{
    var phoneNumbers = new string[2];
    var phoneNumbers2 = new string[2];

    //Positional syntax for property definition
    //Person person = new("Nancy", "Davolio", phoneNumbers);
    CSharp9.Person person1 = new("Nancy", "Davolio", phoneNumbers);
    CSharp9.Person person2 = new("Nancy", "Davolio", phoneNumbers2);

    System.Console.WriteLine($" Person 1: {person1} \n Person 2: {person2}");


    System.Console.WriteLine("Do Person1 and Person2 match?");
    System.Console.WriteLine(person1 == person2); // output: True

    System.Console.WriteLine("Do References match before changing phone number");
    System.Console.WriteLine(ReferenceEquals(person1, person2)); // output: False

    person1.PhoneNumbers[0] = "555-1234";
    person2.PhoneNumbers[0] = "555-1234";

    System.Console.WriteLine("Do Objects match after updating phone number");
    System.Console.WriteLine($"Person 1 phone number {person1.PhoneNumbers[0]}");
    System.Console.WriteLine($"Person 2 phone number {person2.PhoneNumbers[0]}");
    System.Console.WriteLine(person1 == person2); // output: True
    System.Console.WriteLine("Do References match after changing phone number");
    System.Console.WriteLine(ReferenceEquals(person1, person2)); // output: False


    CSharp9.Person person3 = person1 with { };
    System.Console.WriteLine("Creating a new Person based on ' WITH ' Expression");
    System.Console.WriteLine($"{person3.ToString()}  {person3.PhoneNumbers[0]}");

    person3 = person1 with { FirstName = "John" };

    System.Console.WriteLine($" Creating Person3 with just the first name \n {person3} Phone Number: {person3.PhoneNumbers[0]}");
    // output: Person { FirstName = John, LastName = Davolio, PhoneNumbers = System.String[] }

    System.Console.WriteLine("Do Person 1 and Person 3 match?");
    System.Console.WriteLine(person1 == person3); // output: False

}

void CompareRecordInheritance()
{

    CSharp9.Person teacher = new CSharp9.Teacher("Miguel", "Garcia", 3);
    System.Console.WriteLine($"Created new Teacher: {teacher.ToString()}");

    CSharp9.Person student = new CSharp9.Student("Miguel", "Garcia", 3);
    System.Console.WriteLine($"Created new Student : {student.ToString()}");

    System.Console.WriteLine("Are teacher and student equal?");
    System.Console.WriteLine(teacher == student);
}


//check init properties 
void DisplayWeather()
{

    CSharp9.WeatherObservation now = new()
    {
        RecordedAt = System.DateTime.Now,
        TemperatureInCelsius = 20,
        PressureInMillibars = 998.0m
    };

    CSharp9.WeatherObservation tomorrow = new()
    {
        RecordedAt = System.DateTime.Now.AddDays(1),
        TemperatureInCelsius = 40,
        PressureInMillibars = 888.0m
    };
    CSharp9.WeatherObservation[] week = { new(), new(), new(), new() { RecordedAt = System.DateTime.Now.AddDays(4), PressureInMillibars = 800m, TemperatureInCelsius = 45 } };

    System.Console.WriteLine("What is the weather now");
    System.Console.WriteLine(now);

    System.Console.WriteLine("What is the weather in 4 days");
    System.Console.WriteLine(week[3]);

    try
    {
        // now.TemperatureInCelsius = 18;
    }
    catch (System.Exception e)
    {
        System.Console.WriteLine(e);
        throw;
    }
}


//checking switching
void CalculateToll()
{
    var tollCalc = new CSharp9.TollCalculator();

    var car = new ConsumerVehicleRegistration.Car();
    var taxi = new LiveryRegistration.Taxi();
    var bus = new LiveryRegistration.Bus();
    var truck = new CommercialRegistration.DeliveryTruck();


    System.Console.WriteLine("Set the capacity of the bus : default is 10");
    bus.Capacity = int.Parse(System.Console.ReadLine());

    System.Console.WriteLine("Set the ridership of the bus : default is 20");
    bus.Riders = int.Parse(System.Console.ReadLine()); ;

    System.Console.WriteLine($"The toll for a car is {tollCalc.CalculateToll(car)}");
    System.Console.WriteLine($"The toll for a taxi is {tollCalc.CalculateToll(taxi)}");
    System.Console.WriteLine($"The toll for a bus is {tollCalc.CalculateToll(bus)}");
    System.Console.WriteLine($"The toll for a truck is {tollCalc.CalculateToll(truck)}");

    try
    {
        tollCalc.CalculateToll("this will fail");
    }
    catch (System.ArgumentException e)
    {
        System.Console.WriteLine("Caught an argument exception when using the wrong type");
    }
    try
    {
        tollCalc.CalculateToll(null!);
    }
    catch (System.ArgumentNullException e)
    {
        System.Console.WriteLine("Caught an argument exception when using null");
    }
}


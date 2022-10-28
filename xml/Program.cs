using xml;
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography;
using System;

var people = new List<Person>();


//PART I - Microsoft darbinieklu vidējais vecums

XDocument xdoc = XDocument.Load("input.xml");

XElement? peoples = xdoc.Element("people");

if (people is not null)
{    
    foreach (XElement person in peoples.Elements("person"))
    {

        XAttribute? name = person.Attribute("name");
        XElement? company = person.Element("company");
        XElement? age = person.Element("age"); 
    }
}

var microsoft = xdoc.Element("people")?
    .Elements("person")                                    
    .Where(p => p.Element("company")?.Value == "Microsoft")
    .Select(p => new
    {
        name = p.Attribute("name")?.Value,
        age = p.Element("age")?.Value,
        company = p.Element("company")?.Value        
    });

if (microsoft is not null)
{
    Console.WriteLine("MICROSOFT darbinieki ir: ");
    int x = 0;
    int ages = 0;
    foreach (var person in microsoft)
    {
        x = x + 1;
        int m = Int32.Parse(person.age);
        ages = ages + m;
        Console.WriteLine($"Name: {person.name}  Age: {person.age}");
    }
    int z = (ages / x);

    Console.WriteLine("Vidējais MICROSOFT darbinieku vecums: " + z + " gadi.");

    Console.WriteLine();
    Console.WriteLine();

    // PART II - MCPlus darbinieki

    if (people is not null)
    {    
        foreach (XElement person in peoples.Elements("person"))
        {

            XAttribute? name = person.Attribute("name");
            XElement? company = person.Element("company");
            XElement? age = person.Element("age");
     
        }
    }

    var mcplus = xdoc.Element("people")?
        .Elements("person")
                                        
        .Where(p => p.Element("company")?.Value == "MCPlus")
        .Select(p => new
        {
            name = p.Attribute("name")?.Value,
            age = p.Element("age")?.Value,
            company = p.Element("company")?.Value
        });

    if (mcplus is not null)
    {
        Console.WriteLine("MCPlus darbinieki ir: ");
        foreach (var person in mcplus)
        {
            Console.WriteLine($"Name: {person.name}  Age: {person.age}");
        }
    }
    Console.WriteLine();
    Console.WriteLine();

    // PART III - Visi Google un MCPlus darbinieki, viņu vidējais vecums, XML fails ar šo kompāniju darbiniekiem

    if (people is not null)
    {        
        foreach (XElement person in peoples.Elements("person"))
        {

            XAttribute? name = person.Attribute("name");
            XElement? company = person.Element("company");
            XElement? age = person.Element("age");
            
        }
    }

    var google = xdoc.Element("people")?
        .Elements("person")
                                        
        .Where(p => p.Element("company")?.Value == "Google")
        .Select(p => new
        {
            name = p.Attribute("name")?.Value,
            age = p.Element("age")?.Value,
            company = p.Element("company")?.Value
        });

    
    if (mcplus is not null)
    {
        Console.WriteLine("MCPlus darbinieki ir: ");
        int MCx = 0;
        int MCages = 0;
        foreach (var person in mcplus)
            
        {
            MCx = MCx + 1;
            int MCm = Int32.Parse (person.age);
            MCages = MCages + MCm;
            Console.WriteLine($"Name: {person.name}  Age: {person.age}");
        }
        Console.WriteLine();
        

        Console.WriteLine("Google darbinieki ir: ");
        int Goox = 0;
        int Gooages = 0;

        foreach (var person in google)
        {
            Goox = Goox + 1;
            int Goom = Int32.Parse(person.age);
            Gooages = Gooages + Goom;
            Console.WriteLine($"Name: {person.name}  Age: {person.age}");
        }
        int v = (MCx + Goox);
        int r = (MCages + Gooages);
        int s = (r/v);

        Console.WriteLine();
        
        Console.WriteLine("Vidējais MCPlus un Google darbinieku vecums: " + s + " gadi.");
    }

    
    // Google un MCPlus darbinieki tiek saglabāti jaunā XML failā
    
    peoples.DescendantsAndSelf("person")
       .Where(r => (string)r.Element("company").Value == "Microsoft")
       .Remove();
    
    xdoc.Save("JanisXML.xml");

}

using xml;
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography;
using System;


#region Описание
//XmlNode: представляет узел xml.В качестве узла может использоваться весь документ, так и отдельный элемент

//XmlDocument: представляет весь xml-документ

//XmlElement: представляет отдельный элемент. Наследуется от класса XmlNode

//XmlAttribute: представляет атрибут элемента

//XmlText: представляет значение элемента в виде текста, то есть тот текст, который находится в элементе между его открывающим и закрывающим тегами

//XmlComment: представляет комментарий в xml

//XmlNodeList: используется для работы со списком узлов 
#endregion

var people = new List<Person>();

//#region Чтение XML и интерпретация
//XmlDocument xDoc = new XmlDocument();
//xDoc.Load("people.xml");
//// получим корневой элемент
//XmlElement? xRoot = xDoc.DocumentElement;
//if (xRoot != null)
//{
//    foreach (XmlElement xnode in xRoot)
//    {
//        Person person = new Person();
//        XmlNode? attr = xnode.Attributes.GetNamedItem("name");
//        person.Name = attr?.Value;

//        foreach (XmlNode childn in xnode.ChildNodes)
//        {
//            if (childn.Name == "company")
//                person.Company = childn.InnerText;

//            if (childn.Name == "age")
//                person.Age = int.Parse(childn.InnerText);
//        }
//        people.Add(person);
//    }
//    foreach (var person in people)
//        Console.WriteLine($"{person.Name} ({person.Company}) - {person.Age}");
//}
//#endregion

//#region Добавление узла
//// создаем новый элемент person
//XmlElement personElem = xDoc.CreateElement("person");

//// создаем атрибут name
//XmlAttribute nameAttr = xDoc.CreateAttribute("name");

//// создаем элементы company и age
//XmlElement companyElem = xDoc.CreateElement("company");
//XmlElement ageElem = xDoc.CreateElement("age");

//// создаем текстовые значения для элементов и атрибута
//XmlText nameText = xDoc.CreateTextNode("Mark");
//XmlText companyText = xDoc.CreateTextNode("Facebook");
//XmlText ageText = xDoc.CreateTextNode("30");

////добавляем узлы
//nameAttr.AppendChild(nameText);
//companyElem.AppendChild(companyText);
//ageElem.AppendChild(ageText);

//// добавляем атрибут name
//personElem.Attributes.Append(nameAttr);
//// добавляем элементы company и age
//personElem.AppendChild(companyElem);
//personElem.AppendChild(ageElem);
//// добавляем в корневой элемент новый элемент person
//xRoot?.AppendChild(personElem);
//// сохраняем изменения xml-документа в файл
//xDoc.Save("people.xml");
//#endregion

//#region Удаление узла
//XmlNode? firstNode = xRoot?.FirstChild;
//if (firstNode is not null) xRoot?.RemoveChild(firstNode);
//xDoc.Save("people.xml");
//#endregion

//#region XPath - язык запросов у XML
////.

////выбор текущего узла

////..

////выбор родительского узла

////*

////выбор всех дочерних узлов текущего узла

////person

////выбор всех узлов с определенным именем, в данном случае с именем "person"

////@name

////выбор атрибута текущего узла, после знака @ указывается название атрибута (в данном случае "name")

////@+

////выбор всех атрибутов текущего узла

////element[3]

////выбор определенного дочернего узла по индексу, в данном случае третьего узла

//////person

////выбор в документе всех узлов с именем "person"

////person[@name='Tom']

////выбор элементов с определенным значением атрибута. В данном случае выбираются все элементы "person" с атрибутом name='Tom'

////person[company='Microsoft']

////выбор элементов с определенным значением вложенного элемента. В данном случае выбираются все элементы "person", у которых дочерний элемент "company" имеет значение 'Microsoft'

//////person/company

////выбор в документе всех узлов с именем "company", которые находятся в элементах "person"
//#endregion

//#region Пример запросов

//XmlNodeList? personNodes = xRoot?.SelectNodes("person");
//if (personNodes is not null)
//{
//    foreach (XmlNode node in personNodes)
//        Console.WriteLine(node.SelectSingleNode("@name")?.Value);
//}

//XmlNodeList? nodes = xRoot?.SelectNodes("*");
//if (nodes is not null)
//{
//    foreach (XmlNode node in nodes)
//        Console.WriteLine(node.OuterXml);
//}

//XmlNode childnode = xRoot.SelectSingleNode("person[@name='Tom']");
//if (childnode != null)
//    Console.WriteLine(childnode.OuterXml);

//XmlNode? tomNode = xRoot?.SelectSingleNode("person[@name='Tom']");
//Console.WriteLine(tomNode?.OuterXml);

//XmlNodeList? companyNodes = xRoot?.SelectNodes("//person/company");
//if (companyNodes is not null)
//{
//    foreach (XmlNode node in companyNodes)
//        Console.WriteLine(node.InnerText);
//}

//#endregion

#region LinqToXML

//Это иной подход и другой набор классов

//XAttribute: представляет атрибут xml - элемента

//XComment: представляет комментарий

//XDocument: представляет весь xml - документ

//XElement: представляет отдельный xml - элемент

//Ключевым классом является XElement, который позволяет получать вложенные элементы и управлять ими. Среди его методов можно отметить следующие:

//Add(): добавляет новый атрибут или элемент

//Attributes(): возвращает коллекцию атрибутов для данного элемента

//Elements(): возвращает все дочерние элементы данного элемента

//Remove(): удаляет данный элемент из родительского объекта

//RemoveAll(): удаляет все дочерние элементы и атрибуты у данного элемента

//XDocument xdoc = new XDocument(new XElement("people",
//new XElement("person",
//new XAttribute("name", "Tom"),
//new XElement("company", "Microsoft"),
//new XElement("age", 37)),
//new XElement("person",
//new XAttribute("name", "Bob"),
//new XElement("company", "Google"),
//new XElement("age", 41))));

//PART I

XDocument xdoc = XDocument.Load("input.xml");

XElement? peoples = xdoc.Element("people");

if (people is not null)
{
    // проходим по всем элементам person
    foreach (XElement person in peoples.Elements("person"))
    {

        XAttribute? name = person.Attribute("name");
        XElement? company = person.Element("company");
        XElement? age = person.Element("age");

        //Console.WriteLine($"Person: {name?.Value}");
        //Console.WriteLine($"Company: {company?.Value}");
        //Console.WriteLine($"Age: {age?.Value}");

        //Console.WriteLine(); //  для разделения при выводе на консоль
    }
}

var microsoft = xdoc.Element("people")?   // получаем корневой узел people
    .Elements("person")             // получаем все элементы person
                                    // получаем все person, у которого company = Microsoft
    .Where(p => p.Element("company")?.Value == "Microsoft")
    .Select(p => new        // для каждого объекта создаем анонимный объект
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

    // PART II

    if (people is not null)
    {
        // проходим по всем элементам person
        foreach (XElement person in peoples.Elements("person"))
        {

            XAttribute? name = person.Attribute("name");
            XElement? company = person.Element("company");
            XElement? age = person.Element("age");

            //Console.WriteLine($"Person: {name?.Value}");
            //Console.WriteLine($"Company: {company?.Value}");
            //Console.WriteLine($"Age: {age?.Value}");

            //Console.WriteLine(); //  для разделения при выводе на консоль
        }
    }

    var mcplus = xdoc.Element("people")?   // получаем корневой узел people
        .Elements("person")             // получаем все элементы person
                                        // получаем все person, у которого company = Microsoft
        .Where(p => p.Element("company")?.Value == "MCPlus")
        .Select(p => new        // для каждого объекта создаем анонимный объект
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

    // PART III

    if (people is not null)
    {
        // проходим по всем элементам person
        foreach (XElement person in peoples.Elements("person"))
        {

            XAttribute? name = person.Attribute("name");
            XElement? company = person.Element("company");
            XElement? age = person.Element("age");

            //Console.WriteLine($"Person: {name?.Value}");
            //Console.WriteLine($"Company: {company?.Value}");
            //Console.WriteLine($"Age: {age?.Value}");

            //Console.WriteLine(); //  для разделения при выводе на консоль
        }
    }

    var google = xdoc.Element("people")?   // получаем корневой узел people
        .Elements("person")             // получаем все элементы person
                                        // получаем все person, у которого company = Microsoft
        .Where(p => p.Element("company")?.Value == "Google")
        .Select(p => new        // для каждого объекта создаем анонимный объект
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

}
#endregion

using System;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Xml;

class CRUD
{
    // File path for the XML data file
    static string xmlFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\data.xml";

    public static void CRUDMain()
    {
        // Check if the XML file exists
        if (!File.Exists(xmlFile))
        {
            // Create a new XML document if the file doesn't exist
            XmlDocument doc = new XmlDocument();

            // Create the root element
            XmlElement root = doc.CreateElement("Elements");
            doc.AppendChild(root);

            doc.Save(xmlFile);
            Console.WriteLine("XML file created on the desktop.");
        }

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("----- XML CRUD -----");
            Console.WriteLine("1. Show all elements");
            Console.WriteLine("2. Add an element");
            Console.WriteLine("3. Update an element");
            Console.WriteLine("4. Delete an element");
            Console.WriteLine("5. Exit");
            Console.WriteLine("--------------------");
            Console.Write("Select an option: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowElements();
                    break;
                case "2":
                    AddElement();
                    break;
                case "3":
                    UpdateElement();
                    break;
                case "4":
                    DeleteElement();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Show all elements in the XML file
    static void ShowElements()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlFile);

        XmlNodeList? elements = doc.SelectNodes("//Element");

        Console.WriteLine("Elements:");

        foreach (XmlNode element in elements!)
        {
            XmlNode? idNode = element.SelectSingleNode("ID");
            XmlNode? nameNode = element.SelectSingleNode("Name");
            XmlNode? descriptionNode = element.SelectSingleNode("Description");

            Console.WriteLine("ID: " + idNode?.InnerText);
            Console.WriteLine("Name: " + nameNode?.InnerText);
            Console.WriteLine("Description: " + descriptionNode?.InnerText);
            Console.WriteLine();
        }
    }

    // Add a new element to the XML file
    static void AddElement()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlFile);
        XmlNodeList? elements = doc.SelectNodes("//Element");
        XmlNode? root = doc.DocumentElement;
        string? input;

        Console.Write("Enter the ID: ");
        input = Console.ReadLine();
        string id = string.IsNullOrEmpty(input) ? elements.Count.ToString() : input;

        Console.Write("Enter the Name: ");
        input = Console.ReadLine();
        string name = string.IsNullOrEmpty(input) ? "Generic Item Name" : input;

        Console.Write("Enter the Description: ");
        input = Console.ReadLine();
        string description = string.IsNullOrEmpty(input) ? "Generic Item Description" : input;

        XmlElement newElement = doc.CreateElement("Element");

        XmlElement idElement = doc.CreateElement("ID");
        idElement.InnerText = id;
        newElement.AppendChild(idElement);

        XmlElement nameElement = doc.CreateElement("Name");
        nameElement.InnerText = name;
        newElement.AppendChild(nameElement);

        XmlElement descriptionElement = doc.CreateElement("Description");
        descriptionElement.InnerText = description;
        newElement.AppendChild(descriptionElement);

        root.AppendChild(newElement);

        doc.Save(xmlFile);

        Console.WriteLine("Element added successfully.");
    }

    // Update an existing element in the XML file
    static void UpdateElement()
    {
        Console.Write("Enter the ID of the element to update: ");
        string searchID = Console.ReadLine();
        string? input;

        XmlDocument doc = new XmlDocument();
        doc.Load(xmlFile);

        XmlNode element = doc.SelectSingleNode("//Element[ID='" + searchID + "']");

        if (element != null)
        {
            Console.Write("Enter the new name: ");
            input = Console.ReadLine();
            string newName = string.IsNullOrEmpty(input) ? "Generic Item Name" : input;

            Console.Write("Enter the new description: ");
            input = Console.ReadLine();
            string newDescription = string.IsNullOrEmpty(input) ? "Generic Item Description" : input;

            XmlNode nameNode = element.SelectSingleNode("Name");
            nameNode.InnerText = newName;

            XmlNode descriptionNode = element.SelectSingleNode("Description");
            descriptionNode.InnerText = newDescription;

            doc.Save(xmlFile);

            Console.WriteLine("Element updated successfully.");
        }
        else
        {
            Console.WriteLine("No element found with the specified ID.");
        }
    }

    // Delete an element from the XML file
    static void DeleteElement()
    {
        Console.Write("Enter the ID of the element to delete: ");
        string? searchID = Console.ReadLine();

        XmlDocument doc = new XmlDocument();
        doc.Load(xmlFile);

        XmlNode? element = doc.SelectSingleNode("//Element[ID='" + searchID + "']");

        if (element != null)
        {
            XmlNode? root = element.ParentNode;
            root.RemoveChild(element);

            doc.Save(xmlFile);

            Console.WriteLine("Element deleted successfully.");
        }
        else
        {
            Console.WriteLine("No element found with the specified ID.");
        }
    }
}

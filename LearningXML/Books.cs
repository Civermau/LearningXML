using System;
using System.Xml;

class Books
{
    public static void SaveLogics()
    {
        // Set the path to the XML file
        string xmlFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\books.xml";

        // Create a new XML document
        XmlDocument doc = new XmlDocument();

        // Create the root element
        XmlElement root = doc.CreateElement("Libros");
        doc.AppendChild(root);

        // Create the first book
        XmlElement book1 = doc.CreateElement("Libro");
        root.AppendChild(book1);

        // Add attribute to the book
        XmlAttribute attribute1 = doc.CreateAttribute("ISBN");
        attribute1.Value = "123456789";
        book1.Attributes.Append(attribute1);

        // Add elements to the book
        XmlElement title1 = doc.CreateElement("Titulo");
        title1.InnerText = "Aprender XML";
        book1.AppendChild(title1);

        XmlElement author1 = doc.CreateElement("Autor");
        author1.InnerText = "John Doe";
        book1.AppendChild(author1);

        // Save the XML document to a file
        doc.Save(xmlFile);
        Console.WriteLine("XML file created on the desktop.");

        // Read the XML file
        XmlDocument doc2 = new XmlDocument();
        doc2.Load(xmlFile);

        // Get the root node
        XmlElement root2 = doc2.DocumentElement;
        Console.WriteLine("Books:");

        // Iterate through the books
        foreach (XmlNode bookNode in root2.ChildNodes)
        {
            // Get the ISBN attribute
            XmlAttribute isbnAttr = bookNode.Attributes["ISBN"];
            string isbn = isbnAttr.Value;

            // Get the title and author
            XmlNode titleNode = bookNode.SelectSingleNode("Titulo");
            string title = titleNode.InnerText;

            XmlNode authorNode = bookNode.SelectSingleNode("Autor");
            string author = authorNode.InnerText;

            Console.WriteLine("ISBN: " + isbn);
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine();
        }

        // Modify a value in the XML
        XmlNode firstBook = root2.ChildNodes[0];
        XmlNode newTitle = firstBook.SelectSingleNode("Titulo");
        newTitle.InnerText = "New title";
        doc2.Save(xmlFile);
        Console.WriteLine("XML file modified.");
    }
}

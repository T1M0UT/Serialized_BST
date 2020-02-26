using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Serialized_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            // объект для сериализации
            Tree<int> tree = new Tree<int>();
            tree.Add(1);
            tree.Add(0);
            tree.Add(2);
            tree.Add(-1);
            tree.Add(5);
            Console.WriteLine($"CWL tree: {tree}");
            Console.WriteLine("Объект создан");

            // передаем в конструктор тип класса
            XmlSerializer formatter = new XmlSerializer(typeof(Tree<int>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("trees.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, tree);
                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream("trees.xml", FileMode.OpenOrCreate))
            {
                Tree<int> newTree = (Tree<int>)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"tree: {newTree}.");
            }

            Console.ReadLine();
        }
    }
}

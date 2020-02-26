using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Serialized_BST
{
    [Serializable]
    public class Tree<T> 
        where T : IComparable<T>
    {

        public Tree()
        {
            Root = null;
        }
        [XmlElement("Root")]
        public Node<T> Root;


        public void Add(T newValue)
        {
            if (Root == null)
            {
                Root = new Node<T>(newValue);
            }
            else
            {
                Root.Add(newValue, newValue.GetHashCode());
            }
        }
        public override string ToString() => Root == null ? "No tree" : Root.ToString();
        
    }
}

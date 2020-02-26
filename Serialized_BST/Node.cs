using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Serialized_BST
{
    [Serializable]
    public class Node<T> : ISerializable
        where T : IComparable<T>
    {
        int Hash;
        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
            Hash = value.GetHashCode();
        }
        public Node(){
            Left = null;
            Right = null;
        }
        protected Node(SerializationInfo info, StreamingContext context)
        {
            Value = (T)info.GetValue("Data", typeof(T));
            Left = (Node<T>)info.GetValue("Left", typeof(Node<T>));
            Right = (Node<T>)info.GetValue("Right", typeof(Node<T>));
        }
        [XmlElement("Value")]
        public T Value;
        [XmlElement("Left")]
        public Node<T> Left;
        [XmlElement("Right")]
        public Node<T> Right;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Data", Value);
            info.AddValue("Left", Left);
            info.AddValue("Right", Right);
        }
        public void Add(in T newValue, int newHash)
        {
            if (Hash >= newHash)
            {
                if (Left == null) Left = new Node<T>(newValue);
                else Left.Add(newValue, newHash);
            }
            else
            {
                if (Right == null) Right = new Node<T>(newValue);
                else Right.Add(newValue, newHash);
            }
        }
        public List<T> GetList(List<T> answer)
        {
            Left?.GetList(answer);
            answer.Add(Value);
            Right?.GetList(answer);
            return answer;
        }
        public override String ToString() => string.Join(", ", GetList(new List<T>()));

    }
}
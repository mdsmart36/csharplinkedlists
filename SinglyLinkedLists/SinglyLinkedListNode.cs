using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Stretch Goals: Using Generics, which would include implementing GetType() http://msdn.microsoft.com/en-us/library/system.object.gettype(v=vs.110).aspx
namespace SinglyLinkedLists
{
    public class SinglyLinkedListNode : IComparable
    {
        // Used by the visualizer.  Do not change.
        public static List<SinglyLinkedListNode> allNodes = new List<SinglyLinkedListNode>();

        // READ: http://msdn.microsoft.com/en-us/library/aa287786(v=vs.71).aspx
        private SinglyLinkedListNode next;
        public SinglyLinkedListNode Next
        {
            get { return next; }
            set
            {
                //if (value.Equals(this))
                //{
                //    throw new ArgumentException();
                //}
                //this.next = value;

                if (Object.ReferenceEquals(value, this)) // node cannot point to itself
                {
                    throw new ArgumentException();
                }
                this.next = value; // this will allow for duplicate values
            }
        }

        private string value;
        public string Value 
        {
            get { return value; }
            set { this.value = value; }
        }

        public static bool operator <(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) < 0;
        }

        public static bool operator >(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) > 0;
        }

        /*
        public static bool operator ==(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            return node1.CompareTo(node2) == 0;
        }

        public static bool operator !=(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            return !(node1 == node2);
        }
        */

        
        
        public SinglyLinkedListNode(string input)
        {
            this.value = input;
            // Undeclared data members default to null, but ...
            this.next = null;

            // Used by the visualizer:
            allNodes.Add(this);
        }

        // READ: http://msdn.microsoft.com/en-us/library/system.icomparable.compareto.aspx
        public int CompareTo(Object obj)
        {
            SinglyLinkedListNode other_node = obj as SinglyLinkedListNode;
            return (other_node == null) ? 1 : this.value.CompareTo(other_node.Value);
        }

        public bool IsLast()
        {
            return this.next == null;
        }

        public override string ToString()
        {
            return this.value;
        }

        public override bool Equals(Object obj)
        {
            return this.CompareTo(obj) == 0;
        }
    }
}

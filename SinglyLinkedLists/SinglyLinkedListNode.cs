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
                if (value.Equals(this))
                {
                    throw new ArgumentException();
                }
                this.next = value;
            }
        }

        private string value;
        public string Value 
        {
            get { return value; }
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

        public static bool operator ==(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            return node1.CompareTo(node2) == 0;
        }

        public static bool operator !=(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            return !(node1 == node2);
        }

        public SinglyLinkedListNode(string value)
        {
            this.value = value;
            // Undeclared data members default to null, but ...
            this.next = null;

            // Used by the visualizer:
            allNodes.Add(this);
        }

        // READ: http://msdn.microsoft.com/en-us/library/system.icomparable.compareto.aspx
        public int CompareTo(Object obj)
        {
            SinglyLinkedListNode other_node = obj as SinglyLinkedListNode;
            //if (this.value == other_node.Value)
            if (Object.ReferenceEquals(this, other_node))
            {
                return 0;
            }
            return 1;
            /* come back to this. What are other ways to compare instances?
            else
            {
                throw new NotImplementedException();
            }
            */
        }

        public bool IsLast()
        {
            return this.next == null;
        }

        public override string ToString()
        {
            return this.value;
        }
    }
}

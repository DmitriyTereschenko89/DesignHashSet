namespace DesignHashSet
{
	internal class Program
	{
		public class MyHashSet
		{
			private class LinkedList
			{
				private class Node
				{
					public int val;
					public Node next;

					public Node(int val, Node next = null)
					{
						this.val = val;
						this.next = next;
					}
				}

				private Node head;
				public void Add(int val)
				{
					if (head is null)
					{
						head = new Node(val);
						return;
					}
					Node node = head;
					while(node.next != null)
					{
						node = node.next;
					}
					node.next = new Node(val);
				}

				public void Remove(int val)
				{
					if (head is null)
					{
						return;
					}
					if (head.val == val)
					{
						head = head.next;
						return;
					}
					Node node = head;
					while(node.next != null && node.next.val != val)
					{
						node = node.next;
					}
					node.next = node.next?.next;
				}

				public bool Contains(int val)
				{
					Node node = head;
					while(node != null)
					{
						if (node.val == val)
						{
							return true;
						}
						node = node.next;
					}
					return false;
				}
			}

			private readonly LinkedList[] linkedList;
			public MyHashSet()
			{
				linkedList = new LinkedList[10000];
				Array.Fill(linkedList, new LinkedList());
			}

			public void Add(int key)
			{
				key %= linkedList.Length;
				if (linkedList[key].Contains(key))
				{
					return;
				}
				linkedList[key].Add(key);
			}

			public void Remove(int key)
			{
				key %= linkedList.Length;
				linkedList[key].Remove(key);
			}

			public bool Contains(int key)
			{
				key %= linkedList.Length;
				return linkedList[key].Contains(key);
			}
		}
		static void Main(string[] args)
		{
			MyHashSet myHashSet = new();
			myHashSet.Add(1);      // set = [1]
			myHashSet.Add(2);      // set = [1, 2]
            Console.WriteLine(myHashSet.Contains(1)); // return True
            Console.WriteLine(myHashSet.Contains(3)); // return False, (not found)
            myHashSet.Add(2);      // set = [1, 2]
			Console.WriteLine(myHashSet.Contains(2)); // return True
			myHashSet.Remove(2);   // set = [1]
			Console.WriteLine(myHashSet.Contains(2)); // return False, (already removed)
		}
	}
}
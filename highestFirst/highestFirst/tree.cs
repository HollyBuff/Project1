//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;

//using first;

//namespace TreeSort
//{
//	public class EmptyClass
//	{
//		class Node
//		{
//			public string item;
//			public double cost;
//			public double value;
//			public Node leftc;
//			public Node rightc;
//			public void display()
//			{
//				Console.Write("[");
//				Console.Write(item);
//				Console.Write("]");
//			}
//		}

//		class Tree
//		{
//			public Node root;

//			public Tree()
//			{
//				root = null;
//			}

//			public Node ReturnRoot()
//			{
//				return root;
//			}

//			public void makeTree(List<item> knapsack)
//			{

//			}

//			public void Insert(string id, int c, int v)
//			{
//				Node newNode = new Node();
//				newNode.item = id;
//				newNode.cost = c;
//				newNode.value = v;
//				if (root == null)
//					root = newNode;
//				else
//				{
//					Node current = root;
//					Node parent;
//					while (true)
//					{
//						parent = current;
//						if (v < current.value)
//						{
//							current = current.leftc;
//							if (current == null)
//							{
//								parent.leftc = newNode;
//								return;
//							}
//						}
//						else
//						{
//							current = current.rightc;
//							if (current == null)
//							{
//								parent.rightc = newNode;
//								return;
//							}
//						}
//					}
//				}
//			}
//			public void Preorder(Node Root)
//			{
//				if (Root != null)
//				{
//					Console.Write(Root.item + " ");
//					Preorder(Root.leftc);
//					Preorder(Root.rightc);
//				}
//			}
//			public void Inorder(Node Root)
//			{
//				if (Root != null)
//				{
//					Inorder(Root.leftc);
//					Console.Write(Root.item + " ");
//					Inorder(Root.rightc);
//				}
//			}
//			public void Postorder(Node Root)
//			{
//				if (Root != null)
//				{
//					Postorder(Root.leftc);
//					Postorder(Root.rightc);
//					Console.Write(Root.item + " ");
//				}
//			}
//		}
//		}
//	}
//}

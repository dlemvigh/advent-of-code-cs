using System;
using System.Linq;

namespace AoC2019.Day9y2018 {
	public class ListNode {
		public int value;
		public ListNode next;
		public ListNode prev;

		public ListNode(int value) {
			this.value = value;
		}

		public ListNode AddAfter(int value) {
			var node = new ListNode(value);
			
			node.prev = this;
			node.next = this.next;

			this.next.prev = node;
			this.next = node;

			return node;
		}

		public ListNode Remove() {
			var prev = this.prev;
			var next = this.next;

			prev.next = next;
			next.prev = prev;

			return next;
		}

		public static ListNode Init() {
			var node = new ListNode(0);
			node.next = node;
			node.prev = node;
			return node;
		}


		public static long MarbleMania(int players, int turns) {
			// Console.WriteLine("Marbles");
			var init = ListNode.Init();
			var current = init;
			var scores = new long[players];

			Action<int> print = (turn) => {
				Console.Write($"[{turn}] ");				
				var it = init;
				do {
					Console.Write(it == current ? $"({it.value}) " : $"{it.value} ");
					it = it.next;
				} while(it != init);				
				Console.Write("\n");
			};

			for(int i = 1, player = 0; i <= turns; i++, player = (player + 1) % players) {
				if (i % 23 == 0) {
					scores[player] += i;
					current = current.prev.prev.prev.prev.prev.prev.prev;
					scores[player] += current.value;
					current = current.Remove();
				} else {
					current = current.next.AddAfter(i);
				}
				// print(i);
			}
			return scores.Max();
		}
	}

	
}
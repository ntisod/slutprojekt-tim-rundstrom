using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

/*
*	INCOMING MESSAGES
* W/B-S-[Selected cell] e.g. W-S-B4
* Send selected cell (S = Select)
* 
* W/B-M-[Selected cell] e.g. W-N-B4
* Send move (M = Move)
* 
*	RESPONSE MESSAGES
* 
* t/f
* Wether the selection or move is acceptable (t = true, f = false)
* 
* W/B-T e.g. W-T
* Who's turn it is (T = Turn)
*
*/


namespace chess_server {
	class Program {

		static Server server;

		static void Main(string[] args) {

			Thread mainThread = Thread.CurrentThread;

			server = new Server(mainThread);
			server.Start();

			Console.ReadKey();

			Console.CancelKeyPress += new ConsoleCancelEventHandler(CancelKeyPress);
		}

		public static void Print(string message) {
			Console.WriteLine(message);
		}

		static void CancelKeyPress(object sender, ConsoleCancelEventArgs e) {
			server.Stop();
			Console.WriteLine("Servern stängdes av!");
		}

	}
}

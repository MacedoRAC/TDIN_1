using Server.Payment;
using System.Runtime.Remoting;
using System.Windows.Forms;

class Program {
  static void Main(string[] args) {
    RemotingConfiguration.Configure("Server.exe.config", false);
    Application.Run(new PaymentMainWindow());
  }
}
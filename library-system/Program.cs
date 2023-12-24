namespace Lptrabalhopratico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Mensagem de Boas-Vindas ao Sistema
            Console.WriteLine("Bem-vindo ao Sistema da Livraria Francisco e Amigo\n");

            //Instanciar a classe Livraria
            Livraria livraria = new Livraria();

            //Método Sistema de Login
            livraria.EntrarUtilizador();
        }
    }
}

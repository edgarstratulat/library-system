using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lptrabalhopratico
{
    internal class Livraria
    {
        //Atributos
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int ISBN { get; set; }
        public int Stock { get; set; }
        public double Preco { get; set; }
        public double Total { get; set; }
        public double Iva { get; set; }
        public int UserId { get; set; }
        public string Funcao { get; set; }
        public string Password { get; set; }


        //Construtor parametrizado para livros
        public Livraria(int id, string codigo, string titulo, string autor, string genero, int isbn, int stock, double preco, double iva)
        {
            Id = id;
            Codigo = codigo;
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
            ISBN = isbn;
            Stock = stock;
            Preco = preco;
            Iva = iva;
        }

        //Construtor parametrizado para utilizadores 
        public Livraria(int userid, string funcao, string password)
        {
            UserId = userid;
            Funcao = funcao;
            Password = password;
        }

        #region Criação de Listas

        // criação de duas listas: uma com livros, outra com os utilizadores
        public List<Livraria> Utilizador = new List<Livraria>();
        public List<Livraria> Livros = new List<Livraria>();


        //Criação de instâncias para as listas (adicionar os utilizadores do sistema e os livros em stock)
        public Livraria()
        {
            Utilizador.Add(new Livraria(UserId = 1, Funcao = "Gerente", Password = "123gerente"));
            Utilizador.Add(new Livraria(UserId = 2, Funcao = "Repositor", Password = "222repositor"));
            Utilizador.Add(new Livraria(UserId = 3, Funcao = "Caixa", Password = "999caixa"));

            Livros.Add(new Livraria(1, "Z01", "O Rapaz do Pijama às Riscas", "John Boyne", "Romance Jovem", 978972415, 3, 13.30, 6));
            Livros.Add(new Livraria(2, "Z02", "O Último Grimm", "Álvaro Magalhães", "Romance", 978976567, 4, 14.40, 6));
            Livros.Add(new Livraria(3, "Z03", "As fadas Verdes", "Matilde Rosa Araújo", "poesia", 987345678, 5, 8.85, 23));
        }

        #endregion



        #region Utilizadores/Login

        //Criação de um método para um Sistema de Login do Utilizador (número de utilizador UserId e password)
        public void EntrarUtilizador()
        {
            try
            {
            Console.WriteLine("Número de Utilizador: ");
            int UserId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Password: ");
            string Password = Console.ReadLine();

            // Autenticar utilizador na livraria
            Livraria utilizadorAutenticado = Utilizador.Find(u => u.UserId == UserId && u.Password == Password);

                if (utilizadorAutenticado != null)
                {
                    Console.Clear();
                    Console.WriteLine($"\nBem-vindo, {utilizadorAutenticado.Funcao}!");
                    Menu();
                }
                else
                {
                    Console.WriteLine("Falha no Login. Número de Utilizador ou password incorretos.");
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Erro! Introduza números.");
            }
        }

        #endregion




        #region Criação de Menu

        //Criação de um método para simular um menu e tornar o sistema intuitivo para o utilizador
        public void Menu()
    {
        Console.WriteLine("\n:::::POR FAVOR ESCOLHA UMA DAS SEGUINTES OPÇÕES:::::::");
        Console.WriteLine("1- Registar Livros");
        Console.WriteLine("2- Atualizar Livro");
        Console.WriteLine("3- Consultar informações do livro, usando código");
        Console.WriteLine("4- Consultar livro por género");
        Console.WriteLine("5- Consultar livro por Autor");
        Console.WriteLine("6- Compra de Livros");
        Console.WriteLine("7- Vender Livros");
        Console.WriteLine("8- Consultar stock");
        Console.WriteLine("9- Consultar o total de livros vendidos e a sua receita");
        Console.WriteLine("10- Listar utilizadores do sistema");
        Console.WriteLine("11- Terminar sessão/Mudar de utilizador");
        Console.WriteLine("12- Sair");
        Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::::::::::");


        // Variável para escolher a opção no menu
        Console.Write("OPÇÃO: ");
        string escolheropcao = Console.ReadLine();

            switch (escolheropcao)
            {
                case "1":
                    RegistarLivro();
                    break;

                case "2":
                    Atualizarlivro();
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        

        #endregion


        #region RegistarLivro

        //Metodo para registar um novo livro
        public void RegistarLivro()
        {
            Console.WriteLine("\nOpção 1 Escolhida | REGISTAR LIVRO\n");
            //instanciar um novo objeto da classe Livraria para registar um novo livro
            Livraria registarlivro = new Livraria();
            //Recurso à estrutura while para registar um novo livro
            //enquanto o código do livro inserido for diferente de "0", o user pode continuar a adicionar livros
            while(registarlivro.Codigo != "0")
            {
                Console.WriteLine("Insira o código do livro (ou '0' para sair): ");
                registarlivro.Codigo = Convert.ToString(Console.ReadLine());

                if (registarlivro.Codigo == "0")
                {
                    Console.WriteLine("Saíste do Sistema");
                    break;
                }

                    Console.WriteLine("Qual o seu id:  ");
                    registarlivro.Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira o título:  ");
                    registarlivro.Titulo = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Insira o autor:  ");
                    registarlivro.Autor = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("ISBN:  ");
                    registarlivro.ISBN = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira o género:  ");
                    registarlivro.Genero = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Qual o preço?  ");
                    registarlivro.Preco = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Qual a taxa de Iva(6%, 23%)?  ");
                    registarlivro.Iva = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Qual a quantidade a registar?  ");
                    registarlivro.Stock = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Livro registado com sucesso!");
                    Livros.Add(registarlivro);
                
            }
        }
        #endregion


        #region AtualizarLivro
        public void Atualizarlivro()
        {
            // Frase para mostrar a opção escolhida
            Console.WriteLine("\nOpção 2 Escolhida | ATUALIZAR LIVRO\n");
            //uso do "while(true)" para que as nossas condições sejam cumpridas ou interrompidas pela instrução "break"
            while (true)
            {
                //inicia a variavel 'id' que vai armazenar o ID do livro a alterar
                var id = 0;
                Console.Write("Qual o ID que pretende alterar? (ou '0' para sair)");

                //Convertemos o 'id' inserido em um número inteiro
                // O uso do 'out' serve para armazenar o valor convertido na variavel 'id'
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    // Se o utilizador inserir '0', o loop termina
                    if (id == 0)
                        Console.WriteLine("Saíste do Sistema");
                       break;
                    //criação de variavel livro para armazenar o resultado pela busca do livro na lista
                    //uso da função Find para encontrar o livro na lista
                    var Livro = Livros.Find(livro => livro.Id == id);

                    //verificar se o ID inserido está na nossa lista
                    if (Livro != null)
                    {
                        Console.Write("Novo código: ");
                        Livro.Codigo = Convert.ToString(Console.ReadLine());
                        Console.Write("Novo Título: ");
                        Livro.Titulo = Convert.ToString(Console.ReadLine());
                        Console.Write("Novo Autor: ");
                        Livro.Autor = Convert.ToString(Console.ReadLine());
                        Console.Write("Novo Género: ");
                        Livro.Genero = Convert.ToString(Console.ReadLine());

                        //recurso ao bloco try-catch para tratar exceções ao converter o ISBN
                        try
                        {
                            Console.Write("Novo ISBN: ");
                            Livro.ISBN = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Por favor, insira um valor numérico para o ISBN!");
                            continue; // Continua para a próxima iteração do loop
                        }

                        Console.Write("Novo Stock: ");
                        Livro.Stock = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Novo Preço: ");
                        Livro.Preco = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Novo Iva: ");
                        Livro.Iva = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("Livro atualizado com sucesso!");


                    }
                    else //se o ID do livro não for encontrado na lista
                    {
                        Console.WriteLine("O ID inserido não é valido!");
                    }
                }

                //uso do foreach para percorrer todos os livros da lista "Livros" e os exibir na consola após atualizações
                //O 'l' é uma variável temporaria que representa cada elemento individual da lista  durante a iteração do loop
                foreach (Livraria l in Livros)
                    {
                        Console.WriteLine($"Código: {l.Codigo} | Título: {l.Titulo} | Autor: {l.Autor} | Género: {l.Genero} | ISBN: {l.ISBN} | Stock: {l.Stock} | Preço: {l.Preco} | Iva: {l.Iva}");
                    }

            }

        }

        #endregion



        #region ConsultarLivro_Código

        // Criação de um método para cosultar informações de livro pelo seu código
        public void ConsultarCodigo()
        {
            //recurso ao try-catch para lidar com exceções
            try
            {
                //recurso ao while para permitir ao utilizador consultar informações de livros pelo código, até digitar 'sair' para encerrar o programa
                while (true)
                {
                    //criação de variável codigo "vazia" para armazenar o codigo que o utilizador digitar
                    var code = "";
                    Console.WriteLine("Introduza o código do livro que pretende consultar: (ou 'sair' para encerrar)");
                    code = Convert.ToString(Console.ReadLine());

                    //Recurso ao 'if' para encerrar o programa, caso o utilizador digite 'sair'
                    if (code == "sair")
                    {
                        break;
                    }
                    //criação de variavel livro para armazenar o resultado pela busca do livro na lista
                    //uso da função Find para encontrar o livro na lista
                    var Livro = Livros.Find(livro => livro.Codigo == code);

                    // Se o código inserido corresponder a algum livro da lista, são mostradas as informações do livro
                    if (Livro != null)
                    {
                        Console.WriteLine($"Código: {Livro.Codigo} | Título: {Livro.Titulo} | Autor: {Livro.Autor} | Género: {Livro.Genero} | ISBN: {Livro.ISBN} | Stock: {Livro.Stock} | Preço: {Livro.Preco} | Iva: {Livro.Iva}");
                    }
                    //Se o código do livro não for encontrado na lista.
                    // O programa pede para introduzir novamente um código (até que o utilizador digite 'sair')
                    else
                    {
                        Console.WriteLine("O código inserido não é válido. Tente novamente!");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao consultar o código: {ex.Message}");
            }

        }
        #endregion


    }
}
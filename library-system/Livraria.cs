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
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public double Total { get; set; }
        public double Novototal { get; set; }
        public double Novoiva { get; set; }
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

            Livros.Add(new Livraria(1, "Z01", "O Rapaz do Pijama às Riscas", "John Boyne", "Ação", 978972415, 100, 13.30, 0.06));
            Livros.Add(new Livraria(2, "Z02", "O Último Grimm", "Álvaro Magalhães", "Romance", 978976567, 4, 14.40, 0.06));
            Livros.Add(new Livraria(3, "Z03", "As fadas Verdes", "Matilde Rosa Araújo", "Poesia", 987345678, 5, 8.85, 0.23));
        }

        #endregion



        #region Utilizadores/Login
        //Criação de um método para um Sistema de Login do Utilizador (número de utilizador UserId e password)
        public void EntrarUtilizador()
        {
            try
            {
                // Solicitar número de usuário e senha
                Console.WriteLine("Número de Utilizador: ");
                int UserId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Password: ");
                string Password = Console.ReadLine();

                // Autenticar utilizador na livraria
                Livraria utilizadorAutenticado = Utilizador.Find(u => u.UserId == UserId && u.Password == Password);

                if (utilizadorAutenticado != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Bem-vindo, {utilizadorAutenticado.Funcao}!");
                    Menu(); // Chama o menu principal após o login bem-sucedido
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

        public void MudarUtilizador()
        {
            Console.Clear();
            Console.WriteLine("Opção 11 Selecionada | TERMINAR SESSÃO/MUDAR DE UTILIZADOR");
            Console.WriteLine("Terminaste Sessão. Entra outra vez!");
            EntrarUtilizador();
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
            Console.WriteLine("8- Consultar stock geral");
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

                case "3":
                    ConsultarCodigo();
                    break;

                case "4":
                    ListarGenero();
                    break;

                case "5":
                    ListarAutor();
                    break;

                case "6":
                    ComprarLivros();
                    break;

                case "7":
                    VenderLivro();
                    break;

                case "8":
                    Consultarstockgeral();
                    break;

                case "9":
                    ConsultarVendasReceitas();
                    break;

                case "11":
                    MudarUtilizador();
                    break;

                case "12":
                    Console.WriteLine("Saíste do Sistema");
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
            // Frase para mostrar a opção escolhida
            Console.WriteLine("\nOpção 1 Escolhida | REGISTAR LIVRO");
            //instanciar um novo objeto da classe Livraria para registar um novo livro
            Livraria registarlivro = new Livraria();
            //Recurso à estrutura while para registar um novo livro
            //enquanto o código do livro inserido for diferente de "0", o user pode continuar a adicionar livros
            while (registarlivro.Codigo != "0")
            {
                Console.WriteLine("Insira o código do livro (ou '0' para sair): ");
                registarlivro.Codigo = Convert.ToString(Console.ReadLine());

                if (registarlivro.Codigo == "0")
                {
                    Console.WriteLine("Saíste do Sistema");
                    break;
                }
                // Verificar se o livro já existe na lista com base no codigo
                //Any => devolve 'true' se a condição 'livro => livro.Codigo == registarlivro.Codigo' for verificada.
                if (Livros.Any(livro => livro.Codigo == registarlivro.Codigo))
                {
                    Console.WriteLine("Já existe um livro com esse código. Por favor, tente novamente.");
                    continue;
                }

                Console.WriteLine("Qual o seu id:  ");
                registarlivro.Id = Convert.ToInt32(Console.ReadLine());

                // Verificar se o livro já existe na lista com base no ID
                //Any => devolve 'true' se a condição 'livro => livro.Id == registarlivro.Id' for verificada.
                //Ou seja, se a condição do ID do livro inserido ser igual ao id do livro da lista
                if (Livros.Any(livro => livro.Id == registarlivro.Id))
                {
                    Console.WriteLine("Já existe um livro com esse ID. Por favor, tente novamente.");
                    continue;
                }

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
            // Frase para mostrar a opção escolhida
            Console.WriteLine("Opção 3 Escolhida | CONSULTAR LIVROS ATRÁVES DO CÓDIGO");
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
                        Console.WriteLine("Irá abandonar o Sistema");
                        break;
                    }
                    //criação de variavel livro para armazenar o resultado pela busca do livro na lista
                    //uso da função Find para encontrar o livro na lista
                    var Livro = Livros.Find(livro => livro.Codigo == code);

                    // Se o código inserido corresponder a algum livro da lista, são mostradas as informações do livro
                    if (Livro != null)
                    {
                        Console.WriteLine($"\nCódigo: {Livro.Codigo} \nTítulo: {Livro.Titulo} \nAutor: {Livro.Autor} \nGénero: {Livro.Genero} \nISBN: {Livro.ISBN} \nStock: {Livro.Stock} \nPreço: {Livro.Preco}€ \nIva: {Livro.Iva}%\n");
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


        #region ConsultarLivro_género

        //método para listar os livros por género
        public void ListarGenero()
        {
            // Frase para mostrar a opção escolhida
            Console.WriteLine("Opção 4 Escolhida | CONSULTAR LIVROS ATRÁVES DO GÉNERO");
            // Recurso à estrutura While para permitir que o utilizador consulte vários livros consecutivamente até decidir sair.
            while (true)
            {
                //Questionar o utilizador qual o género que pretende consultar.
                var genero = "";
                Console.Write("Insira o género que deseja consultar: (ou escreva 'sair' para encerrar o programa)");
                genero = Convert.ToString(Console.ReadLine());


                //Recurso ao 'if' para encerrar o programa, caso o utilizador digite 'sair'
                if (genero == "sair")
                {
                    Console.WriteLine("Irá abandonar o Sistema");
                    break;
                }

                //criação de variavel livro para armazenar o resultado pela busca dos livros do genero que o utilizador pretende
                //uso da função Find para encontrar o livro na lista
                var Livro = Livros.Find(livro => livro.Genero == genero);

                // Se o Género inserido corresponder a algum livro da lista, são mostradas as informações do livro
                if (Livro != null)
                {
                    Console.WriteLine($"\nCódigo: {Livro.Codigo} \nTítulo: {Livro.Titulo} \nAutor: {Livro.Autor} \nGénero: {Livro.Genero} \nISBN: {Livro.ISBN} \nStock: {Livro.Stock} \nPreço: {Livro.Preco}€ \nIva: {Livro.Iva}%\n");
                }
                //Se o género do livro digitado não for encontrado na lista.
                // O programa pede para introduzir novamente um género (até que o utilizador digite 'sair')
                else
                {
                    Console.WriteLine("O género introduzido não foi encontrado na lista. Tente novamente!");
                }
            }

        }

        #endregion


        #region ConsultarLivro_Autor
        //método para listar os livros por autor
        public void ListarAutor()
        {
            // Frase para mostrar a opção escolhida
            Console.WriteLine("Opção 5 Escolhida | CONSULTAR LIVROS ATRÁVES DO AUTOR");
            // Recurso à estrutura While para permitir que o utilizador consulte livros de vários autores consecutivamente até decidir sair.
            while (true)
            {
                //Questionar o utilizador qual o autor que pretende consultar.
                var autor = "";
                Console.Write("\nEscreva o nome do autor que pretende consultar: (ou escreva 'sair' para encerrar o programa)");
                autor = Convert.ToString(Console.ReadLine());

                //Recurso ao 'if' para encerrar o programa, caso o utilizador digite 'sair'
                if (autor == "sair")
                {
                    Console.WriteLine("Irá abandonar o Sistema");
                    break;
                }

                //criação de variavel livro para armazenar os livros do autor que o utilizador pretende consultar
                //uso da função Find para encontrar os livros do autor na lista
                var Livro = Livros.Find(livro => livro.Autor == autor);

                // Se o autor tiver algum livro na nossa lista, são mostradas as informações do(s) livro(s)
                if (Livro != null)
                {
                    Console.WriteLine($"\nCódigo: {Livro.Codigo} \nTítulo: {Livro.Titulo} \nAutor: {Livro.Autor} \nGénero: {Livro.Genero} \nISBN: {Livro.ISBN} \nStock: {Livro.Stock} \nPreço: {Livro.Preco}€ \nIva: {Livro.Iva}%\n");
                }
                //Se o Autor do livro digitado não for encontrado na lista.
                // O programa pede para introduzir novamente um Autor  (até que o utilizador digite 'sair')
                else
                {
                    Console.WriteLine("O nome do autor introduzido não foi encontrado na lista. Tente novamente!");
                }
            }
        }

        #endregion


        #region CompraLivros
        //Método para comprar Livros (acrescentar ao stock)
        public void ComprarLivros()
        {
            // Frase para mostrar a opção escolhida
            Console.WriteLine("Opção 6 Escolhida | COMPRAR LIVROS - ACRESCENTAR  STOCK ");
            while (true)
            {

                //Questionar o utilizador qual o id do livro que pretende comprar
                Console.Write("\nQual o ID do livro que pretende? (ou escreva '0' para encerrar o programa\n");
                int id = Convert.ToInt32(Console.ReadLine());

                if (id == 0)
                {
                    Console.WriteLine("O programa será encerrado");
                    break;
                }

                //Utilização da função Find para encontrar os livros por ID na nossa lista de livros
                var livro = Livros.Find(livro => livro.Id == id);

                //Se o livro com o ID não existir, mostra a mensagem de ID invalido e pede novamente ao utilizador
                if (livro == null)
                {
                    Console.WriteLine("ID inválido! Livro não encontrado.");
                    continue;
                }

                Console.Write($"Que quantidade deseja comprar para {livro.Titulo}? ");

                //utilização do if para garantir que a quantidade inserida é um número inteiro positivo
                // '!int.TryParse(Console.ReadLine()' ==> verifica se a conversão do número inserido não foi bem sucedida, ou seja o utilizador não inseriu um número inteiro
                if (!int.TryParse(Console.ReadLine(), out int Quantidade) || Quantidade <= 0)
                {
                    Console.WriteLine("\nQuantidade inválida! Por favor, insira um número inteiro positivo.");
                    continue;
                }

                // Adiciona a quantidade ao stock do livro
                //livro.Stock = livro.Stock + livro.Quantidade;
                livro.Stock += Quantidade;

                Console.WriteLine($"\nCompra bem-sucedida! Stock atualizado para {livro.Stock} unidades.\n");

                Console.WriteLine($"Temos então: \nCódigo: {livro.Codigo} \nTítulo: {livro.Titulo} \nAutor: {livro.Autor} \nGénero: {livro.Genero} \nISBN: {livro.ISBN} \nStock: {livro.Stock} \nPreço: {livro.Preco}€ \nIva: {livro.Iva}%\n");

            }
        }

        #endregion


        #region VenderLivros
        //método para venda de livros (reduz ao stock)
        public void VenderLivro()
        {
            // Frase para mostrar a opção escolhida
            Console.WriteLine("\nOpção 7 Escolhida | MODO DE VENDA DE LIVROS ");
            while (true)
            {
                //Solicitar ao utilizador para inserir o id do livro que deseja vender
                Console.Write("\nQual o ID do livro que deseja vender? (ou '0' para encerrar\n");
                int id = Convert.ToInt32(Console.ReadLine());

                if (id == 0)
                {
                    Console.Write("O programa será encerrado!");
                    break;
                }

                //Utilização da função Find para encontrar os livros por ID na nossa lista de livros
                var livro = Livros.Find(livro => livro.Id == id);

                //Se o livro com o ID não existir, mostra a mensagem de ID invalido e pede novamente ao utilizador
                if (livro == null)
                {
                    Console.WriteLine("ID inválido! Livro não encontrado.");
                    continue; //Pede novamente o ID
                }

                //Questionar o utilizador que quantidade deseja vender
                Console.Write("Quantidade a ser vendida: ");
                livro.Quantidade = Convert.ToInt32(Console.ReadLine());
                if (livro.Stock < livro.Quantidade)
                {
                    Console.WriteLine("ERRO! A quantidade a ser vendida excede o número de livros em stock");
                    continue; //Pede novamente a quantidade
                }
                else
                {
                    //reduz o stock do livro da lista em relação à quantidade a ser vendida
                    livro.Stock -= livro.Quantidade;
                }

                //Calculo do valor sem IVA
                livro.Total = (livro.Quantidade * livro.Preco);
                //Calculo do valor do IVA
                livro.Novoiva = (livro.Total * livro.Iva);
                //Soma do valor do IVA ao total
                livro.Novototal = (livro.Total + livro.Novoiva);


                Console.WriteLine(":::::::::::::::::::::RESUMO DE VENDA::::::::::::::::::::::");

                //Aplicar o desconto de 10%, caso o valor seja igual ou superior a 50 euros
                if (livro.Novototal < 50)
                {
                    //Apresenta o valor total sem desconto, arredondado a duas casas decimais
                    Console.WriteLine($"Subtotal: {Math.Round(livro.Total, 2)} euros");
                    Console.WriteLine($"Valor do IVA: {Math.Round(livro.Novoiva, 2)} euros");
                    Console.WriteLine($"Desconto: 0%");
                }

                else
                {
                    livro.Novototal *= 0.9; //Aplica desconto de 10% ao total 

                    Console.WriteLine($"Subtotal: {Math.Round(livro.Total, 2)} euros");
                    Console.WriteLine($"Valor do IVA: {Math.Round(livro.Novoiva, 2)} euros");
                    Console.WriteLine($"Desconto: 10%");
                }

                Console.WriteLine($"Total: {Math.Round(livro.Novototal, 2)} euros");

                Console.WriteLine(":::::::::::::VENDA CONCLUÍDA COM SUCESSO:::::::::::::::::::");

            }

        }

        #endregion


        #region ConsultarStockGeral
        //método para consultar todos os livros em stock
        public void Consultarstockgeral()
        {
            // Frase para mostrar a opção escolhida
            Console.WriteLine("Opção 8 Escolhida | CONSULTAR O STOCK ");

            //Recurso à estrutura 'foreach' para iterar os elementos da nossa lista ('Livros') que se encontra dentro da nossa classe 'Livraria'
            //Durante a iteração, cada objeto é representado por 'livros'
            foreach (Livraria livros in Livros)
            {
                //dá informações apenas do id, título, autor,  e o stock disponível dos livros da lista
                Console.WriteLine($"ID: {livros.Id} | Título: {livros.Titulo} | Autor: {livros.Autor} | Stock: {livros.Stock}");
            }

        }
        #endregion


        #region ConsultarVendas
        //método para consultar os livros vendidos e a sua receita
        public void ConsultarVendasReceitas()
        {
            // Frase para mostrar a opção escolhida
            Console.WriteLine("Opção 9 Escolhida | CONSULTAR O TOTAL DE LIVROS VENDIDOS E A SUA RECEITA\n");

            try
            {
                while (true)
                {
                    int id = 0; //variavel de inicialização, onde será armazenado o valor que o utilizador digitar
                                //Questionar o utilizador sobre o id do livro que pretende consultar a receita e o total vendido
                    Console.Write("Insira o id do livro que deseja consultar o total vendido e a respetiva receita: (0 para encerrar)\n");
                    id = Convert.ToInt32(Console.ReadLine());

                    //Recurso ao 'if' para encerrar o programa, caso o utilizador digite '0'
                    if (id == 0)
                    {
                        Console.WriteLine("Irá abandonar o Sistema");
                        break;
                    }

                    //criação de variavel livro para armazenar o resultado pela busca do livro na lista
                    //uso da função Find para encontrar o livro na lista
                    var Livro = Livros.Find(livro => livro.Id == id);

                    // Se o ID inserido corresponder a algum livro da lista:
                    if (Livro != null)
                    {
                        int totallivrosvendidos = 0; //variavel inicia com zero. Armazena a quantidade de livros vendidos.
                                                     //Adicionar à variavel a quantidade vendida
                        totallivrosvendidos += Livro.Quantidade;
                        double TotalReceita = Math.Round(Livro.Total, 2);

                        Console.WriteLine($"Livro ID: {Livro.Id}");
                        Console.WriteLine($"Título: {Livro.Titulo}");
                        Console.WriteLine($"Quantidade Vendida: {totallivrosvendidos}");
                        Console.WriteLine($"Receita Total: {TotalReceita} euros");
                    }
                    else
                    {
                        Console.WriteLine("Livro não encontrado.");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro:{ex.Message}");
            }

        }
        #endregion






    }




}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabalhoASPNet.Models;

namespace TrabalhoAspNet.Controllers;

public class DadosController : Controller
{
    private readonly Contexto contexto;

    public DadosController(Contexto context)
    {
        contexto = context;
    }
    public IActionResult Autores()
    {
        contexto.Database.ExecuteSqlRaw("delete from Autor");
        contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Autor', RESEED, 0)");
        Random rand = new Random();

        string[] nomes = 
        {
            "Ana", "Bruno", "Carla", "Daniel", "Eduarda", "Felipe", "Gabriela", "Henrique", "Isabela", "João",
            "Larissa", "Marcelo", "Nathalia", "Otávio", "Patrícia", "Ricardo", "Sabrina", "Thiago", "Valéria", "Wesley",
            "Amanda", "Bernardo", "Camila", "Diego", "Eliane", "Fernando", "Giovana", "Heitor", "Ingrid", "José",
            "Letícia", "Marcos", "Natália", "Olívia", "Pedro", "Renata", "Samuel", "Tamires", "Vanessa", "Willian",
            "Aline", "Bianca", "Caio", "Denise", "Erick", "Fabiana", "Gustavo", "Helena", "Igor", "Juliana", "Leandro",
            "Manuela", "Nelson", "Paulo", "Rafael", "Sara", "Tatiana", "Vitor", "Yasmin", "Antônio", "Bárbara",
            "Catarina", "Diogo", "Eduardo", "Francisco", "Gisele", "Hudson", "Iara", "Julio", "Laura", "Miguel",
            "Nicole", "Osvaldo", "Priscila", "Renato", "Silvia", "Tiago", "Vitória", "Yuri", "Alice", "Bruna",
            "Cristiano", "Debora", "Evandro", "Fernanda", "Gabriel", "Hugo", "Ivana", "Jaqueline", "Leonardo",
            "Melissa", "Nicolas", "Rafaela", "Sebastião", "Tatiane", "Vinícius", "Zuleica", "Artur", "Beatriz", "César",
            "Diana"
        };

        string[] nacionalidades =
        {
            "Brasileira", "Americana", "Canadense", "Mexicana", "Argentina", "Chilena", "Uruguaia", "Portuguesa",
            "Espanhola", "Francesa", "Italiana", "Alemã", "Inglesa", "Irlandesa", "Holandesa", "Belga", "Sueca",
            "Norueguesa", "Dinamarquesa", "Finlandesa", "Austríaca", "Suíça", "Grega", "Turca", "Egípcia", "Marroquina",
            "Sul-Africana", "Angolana", "Moçambicana", "Nigeriana", "Indiana", "Chinesa", "Japonesa", "Coreana",
            "Tailandesa", "Vietnamita", "Filipina", "Indonésia", "Australiana", "Neozelandesa", "Russa", "Polonesa",
            "Tcheca", "Húngara", "Romena", "Búlgara", "Ucraniana", "Israelense", "Libanesa", "Saudita", "Peruana"
        };

        for (int i = 0; i < 100; i++)
        {
            Autor autor = new Autor();

            autor.Nome = nomes[i];
            autor.Nacionalidade = nacionalidades[rand.Next(0, nacionalidades.Length)];
            autor.Nascimento = DateOnly.Parse("01/01/1950").AddDays(rand.Next(18300));
            
            contexto.Autores.Add(autor);

        }
        contexto.SaveChanges();
        return View(contexto.Autores.ToList());
    }

    public IActionResult Generos()
    {
        contexto.Database.ExecuteSqlRaw("delete from Genero");
        contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Genero', RESEED, 0)");
        Random rand = new Random();

        string[] descricao =
        {
            "Ficção Científica", "Romance", "Fantasia", "Mistério", "Suspense", "Terror", "Aventura", "Histórico",
            "Biografia", "Autoajuda", "Poesia", "Drama", "Filosofia", "Psicologia", "Educação", "Humor", "Religião",
            "Infantil", "Jovem Adulto", "Clássico", "Conto", "Distopia", "Policial", "Mitologia", "Gastronomia",
            "Tecnologia", "Viagem", "Esporte", "Negócios", "Ciências"
        };

        for (int i = 0; i < 30; i++)
        {
            Genero genero = new Genero();
            
            genero.Descricao = descricao[i];
            
            contexto.Generos.Add(genero);
        }

        contexto.SaveChanges();
        
        return View(contexto.Generos.ToList());
    }

    public IActionResult Editoras()
    {
        contexto.Database.ExecuteSqlRaw("delete from Editora");
        contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Editora', RESEED, 0)");
        Random rand = new Random();

        string[] nomes =
        {
            "Companhia das Letras", "Editora Rocco", "Editora Intrínseca", "Editora Sextante", "Editora Record",
            "Editora Moderna", "Editora Saraiva", "Editora FTD", "Editora Aleph", "Editora Zahar", "Editora Planeta",
            "Editora Melhoramentos", "Editora L&PM", "Editora Conrad", "Editora DarkSide", "Editora Autêntica",
            "Editora Gente", "Editora Arqueiro", "Editora Objetiva", "Editora Globo Livros", "Editora Nova Fronteira",
            "Editora Paz e Terra", "Editora Vozes", "Editora Martins Fontes", "Editora Papirus"
        };

        string[] enderecos =
        {
            "Rua Bandeira Paulista, 702, Itaim Bibi, São Paulo, SP", "Rua do Catete, 347, Catete, Rio de Janeiro, RJ",
            "Rua Marquês de São Vicente, 99, Gávea, Rio de Janeiro, RJ",
            "Rua Voluntários da Pátria, 45, Botafogo, Rio de Janeiro, RJ",
            "Rua Argentina, 171, São Cristóvão, Rio de Janeiro, RJ",
            "Rua Padre Adelino, 758, Belenzinho, São Paulo, SP",
            "Rua Henrique Schaumann, 270, Pinheiros, São Paulo, SP",
            "Rua Major Maragliano, 191, Vila Mariana, São Paulo, SP",
            "Rua Dona Elisa Fláquer, 375, Centro, Santo André, SP",
            "Rua Marquês de São Vicente, 99, Gávea, Rio de Janeiro, RJ",
            "Avenida Paulista, 2.073, Bela Vista, São Paulo, SP", "Rua Tito, 479, Vila Romana, São Paulo, SP",
            "Rua Luiz Afonso, 1.200, Cidade Baixa, Porto Alegre, RS",
            "Rua Simão Álvares, 784, Pinheiros, São Paulo, SP",
            "Rua Marquês de São Vicente, 99, Gávea, Rio de Janeiro, RJ",
            "Rua Pouso Alegre, 2.700, Santa Efigênia, Belo Horizonte, MG",
            "Rua Pedro Soares de Almeida, 114, Vila Anglo Brasileira, São Paulo, SP",
            "Rua Dias Ferreira, 417, Leblon, Rio de Janeiro, RJ",
            "Rua Cosme Velho, 103, Cosme Velho, Rio de Janeiro, RJ",
            "Rua Marquês de São Vicente, 99, Gávea, Rio de Janeiro, RJ",
            "Rua Visconde de Ouro Preto, 5, Botafogo, Rio de Janeiro, RJ",
            "Rua José Higino, 416, Tijuca, Rio de Janeiro, RJ", "Rua Frei Luís de Souza, 100, Petrópolis, RJ",
            "Avenida Paulista, 2.073, Bela Vista, São Paulo, SP", "Rua Dr. Quirino, 1.560, Centro, Campinas, SP"
        };

        string[] telefones =
        {
            "(11) 3707-3500", "(21) 3525-2000", "(21) 3206-7400", "(21) 2537-5700", "(21) 2585-2000", "(11) 2790-1300",
            "(11) 3613-3000", "(11) 3056-7500", "(11) 4990-2000", "(21) 3206-7400", "(11) 2178-6200", "(11) 3874-0900",
            "(51) 3514-6000", "(11) 3085-6388", "(21) 3206-7400", "(31) 3225-6493", "(11) 3670-2500", "(21) 2540-6000",
            "(21) 2556-4114", "(21) 3206-7400", "(21) 2537-8787", "(21) 2575-2300", "(24) 2233-9000", "(11) 2178-6200",
            "(19) 3272-4500"
        };

        for (int i = 0; i < 25; i++)
        {
            Editora editora = new Editora();

            editora.Nome = nomes[i];
            editora.Endereco = enderecos[i];
            editora.Telefone = telefones[i];
            
            contexto.Editoras.Add(editora);
        }
        
        contexto.SaveChanges();
        
        return View(contexto.Editoras.ToList());
    }

    public IActionResult Livros()
    {
        contexto.Database.ExecuteSqlRaw("delete from Livro");
        contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Livro', RESEED, 0)");
        Random rand = new Random();

        string[] titulos =
        {
            "O Senhor dos Anéis", "O Pequeno Príncipe", "1984", "Orgulho e Preconceito", "Dom Quixote",
            "Cem Anos de Solidão", "A Revolução dos Bichos", "A Odisséia", "Moby Dick", "O Grande Gatsby", "Ulisses",
            "Jane Eyre", "A Ilíada", "O Conde de Monte Cristo", "Drácula", "Frankenstein",
            "As Aventuras de Huckleberry Finn", "O Morro dos Ventos Uivantes", "A Metamorfose",
            "O Apanhador no Campo de Centeio", "O Retrato de Dorian Gray", "O Sol é para Todos", "Crime e Castigo",
            "Guerra e Paz", "O Lobo da Estepe", "A Montanha Mágica", "Madame Bovary", "Os Miseráveis", "O Estrangeiro",
            "Coração das Trevas", "As Aventuras de Sherlock Holmes", "Viagem ao Centro da Terra",
            "Alice no País das Maravilhas", "O Jardim Secreto", "Anna Karenina", "O Vermelho e o Negro",
            "A Divina Comédia", "Memórias Póstumas de Brás Cubas", "Capitães da Areia", "Vidas Secas",
            "Grande Sertão: Veredas", "O Guarani", "Iracema", "O Primo Basílio", "O Cortiço", "Senhora", "Macunaíma",
            "Dom Casmurro", "O Tempo e o Vento", "A Moreninha", "Clarissa", "O Quinze", "Sagarana",
            "Memórias de um Sargento de Milícias", "Éramos Seis", "O Auto da Compadecida", "Marília de Dirceu",
            "Gabriela, Cravo e Canela", "Felicidade Clandestina", "Os Sertões", "Raízes do Brasil",
            "Casa Grande e Senzala", "Ensaio sobre a Cegueira", "O Evangelho Segundo Jesus Cristo",
            "A Casa dos Budas Ditosos", "Incidente em Antares", "O Amante", "A Insustentável Leveza do Ser",
            "O Processo", "A Cidade e as Serras", "Os Maias", "Silmarillion", "As Crônicas de Nárnia",
            "Harry Potter e a Pedra Filosofal", "Harry Potter e a Câmara Secreta",
            "Harry Potter e o Prisioneiro de Azkaban", "Harry Potter e o Cálice de Fogo",
            "Harry Potter e a Ordem da Fênix", "Harry Potter e o Enigma do Príncipe",
            "Harry Potter e as Relíquias da Morte", "Percy Jackson e o Ladrão de Raios",
            "Percy Jackson e o Mar de Monstros", "Percy Jackson e a Maldição do Titã",
            "Percy Jackson e a Batalha do Labirinto", "Percy Jackson e o Último Olimpiano",
            "A Menina que Roubava Livros", "O Código Da Vinci", "Anjos e Demônios", "Inferno", "Origem",
            "Comer, Rezar, Amar", "O Alquimista", "Brida", "Veronika Decide Morrer", "Onze Minutos",
            "O Vencedor Está Só", "A Cabana", "O Caçador de Pipas", "A Cidade do Sol", "A Arte da Guerra",
            "O Nome do Vento", "O Temor do Sábio", "A Guerra dos Tronos", "A Fúria dos Reis", "A Tormenta de Espadas",
            "O Festim dos Corvos", "A Dança dos Dragões", "Duna", "O Último Desejo", "O Sangue dos Elfos",
            "Tempo de Desprezo", "Deuses Americanos", "Belas Maldições", "Sandman: Prelúdios e Noturnos", "Watchmen",
            "V de Vingança", "O Diário de Anne Frank", "Maus", "O Chamado de Cthulhu", "O Livro da Selva",
            "O Médico e o Monstro", "Fahrenheit 451", "O Símbolo Perdido", "A Redoma de Vidro", "O Som e a Fúria",
            "A Letra Escarlate", "Um Estudo em Vermelho", "A Dama das Camélias", "O Conto da Aia", "O Homem Invisível",
            "O Sol também se Levanta", "A Máquina do Tempo", "O Pêndulo de Foucault", "Ilusões Perdidas",
            "A Dança da Morte", "O Pequeno Nicolau", "O Apocalipse", "A Lista de Schindler", "O Pianista",
            "Coração de Tinta", "Príncipe Caspian", "As Brumas de Avalon", "O Código Élfico", "O Mundo de Sofia",
            "Ponto de Impacto", "Admirável Mundo Novo", "O Jardim dos Finzi-Contini", "A Sociedade do Anel", "Hamlet",
            "Romeu e Julieta", "O Enigma de Andrômeda", "Seda", "Mar de Monstros", "Cidade dos Ossos", "O Encontro",
            "Estudo em Escarlate", "Eragon", "A Fortaleza Digital", "Segredos do Reino", "A Invenção de Hugo Cabret",
            "A Hospedeira", "O Livro das Sombras", "A Bússola de Ouro", "A Caverna", "O Enigma do Oito", "Morte Súbita",
            "A Revolta", "Jogos Vorazes", "Em Chamas", "As Filhas de Eva", "Lua Nova", "Eclipse", "A Mão e a Luva",
            "O Primo Basílio", "Papillon", "A Droga da Obediência", "O Saci", "Quem Mexeu no Meu Queijo?",
            "A Arte de Amar", "Cem Sonetos de Amor", "Querido John", "O Mundo de Sofia", "A Luta pelo Direito",
            "Razão e Sensibilidade", "Ponto de Impacto", "Mulherzinhas", "Desventuras em Série", "Diário de um Banana",
            "Memórias de um Sargento de Milícias", "Os Três Mosqueteiros", "O Inferno", "O Silêncio dos Inocentes",
            "A Torre Negra: O Pistoleiro", "Sob a Redoma", "Entrevista com o Vampiro", "A Viagem de Théo",
            "Terapia do Abraço", "O Palácio de Inverno", "Mãe", "O Perfume", "Sonho Febril", "O Aleph", "Anna Karenina",
            "A História Sem Fim", "O Velho e o Mar", "A Máquina do Tempo", "O Rei Lear", "A Bela e a Fera",
            "As Aventuras de Pi", "Cinco Dias", "Corações Feridos", "Depois Daquela Montanha", "Diário de um Banana 2",
            "Exercícios de Solidão", "Fogo e Sangue", "Grande Sertão Veredas", "Hibisco Roxo", "História do Futuro",
            "O Palácio da Memória", "Milagre nos Andes", "Mulheres que Correm com os Lobos", "Narrativas de Um Crime",
            "O Cavaleiro de Bronze", "O Homem que Calculava", "A Busca de Sentido", "Onde os Demônios Estão",
            "A Chave de Rebeca", "A Rainha Vermelha", "Guerra Mundial Z", "Zumbis e Vampiros", "Zumbi - A Origem",
            "Um Sonho de Liberdade", "A Guerra do Fim do Mundo", "A Estrada", "Morte na Mesopotâmia",
            "O Conde de Monte Cristo", "O Hobbit", "O Iluminado", "Névoa", "A Revolução dos Bichos",
            "A Hora da Estrela", "A História Secreta", "Comer, Rezar, Amar", "Belo Desastre", "O Bicho-da-Seda",
            "De Amor e Trevas", "O Mar Infinito", "Perdido em Marte", "O Outro Lado da Morte", "A Máquina do Tempo",
            "O Lago dos Sonhos", "Lavoura Arcaica", "O Marido", "A Ilha Misteriosa", "A Revolta de Atlas",
            "O Ladrão de Raios", "Anjos e Demônios", "O Caminho Jedi", "O Pequeno Príncipe", "O Signo dos Quatro",
            "A Máscara de Flandres", "Uma Breve História do Tempo", "Vinte Mil Léguas Submarinas", "Robinson Crusoé",
            "O Jogo da Amarelinha", "Mansfield Park", "Os Pilares da Terra", "O Código Da Vinci",
            "Sapiens: Uma Breve História da Humanidade"
        };

        for (int i = 0; i < 500; i++)
        {
            Livro livro = new Livro();

            livro.Titulo = titulos[rand.Next(0, titulos.Length)];
            livro.AutorId = rand.Next(0, 100);
            livro.GeneroId = rand.Next(0, 30);
            livro.EditoraId = rand.Next(0, 25);
            livro.AnoPublicacao = rand.Next(1980, 2021);
            livro.Preco = Math.Round(50 + (decimal)rand.NextDouble() * (300 - 10), 2);
            livro.QuantidadeEmEstoque = rand.Next(50, 501);
            
            contexto.Livros.Add(livro);
        }
        contexto.SaveChanges();
        return View(contexto.Livros.Include(a => a.Autor).Include(g => g.Genero).Include(e => e.Editora).ToList());
    }
}    
    
    
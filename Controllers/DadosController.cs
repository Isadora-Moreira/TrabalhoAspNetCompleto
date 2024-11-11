using System.Diagnostics.CodeAnalysis;
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

        for (int i = 0; i < 50; i++)
        {
            Autor autor = new Autor();

            autor.Nome = nomes[i];
            autor.Nacionalidade = nacionalidades[rand.Next(0, nacionalidades.Length)];
            autor.Nascimento = DateOnly.Parse("01/01/1990").AddDays(rand.Next(12420));
            
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

        for (int i = 0; i < 15; i++)
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

    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public IActionResult Livros()
    {
        contexto.Database.ExecuteSqlRaw("delete from Livro");
        contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Livro', RESEED, 0)");
        Random rand = new Random();

        string[] titulos =
        {
            "A Culpa é das Estrelas", "Divergente", "Orgulho e Preconceito", "1984", "O Caçador de Pipas",
            "A Sociedade do Anel", "Os Adoráveis Ossos", "Garota Exemplar", "A Ajuda", "Ratos e Homens", "O Alquimista",
            "Cinquenta Tons de Cinza", "A Garota no Trem", "A Menina que Roubava Livros", "Adoráveis Mulheres",
            "Comer, Rezar, Amar", "Água para Elefantes", "O Caderno", "A Vida de Pi",
            "O Guia do Mochileiro das Galáxias", "Morro dos Ventos Uivantes", "Onde Termina a Calçada",
            "As Vantagens de Ser Invisível", "Insurgente", "O Curioso Incidente do Cachorro à Noite", "E o Vento Levou",
            "Frankenstein", "O Guardião da Minha Irmã", "Mil Sóis Esplêndidos", "O Iluminado",
            "O Corredor do Labirinto", "Holes", "Razão e Sensibilidade", "A Hospedeira", "Eu Era Antes de Você",
            "O Diário de Bridget Jones", "Lar de Miss Peregrine para Crianças Peculiares", "O Retrato de Dorian Gray",
            "O Jardim Secreto", "Na Natureza Selvagem", "O Castelo de Vidro", "O Diabo Veste Prada",
            "Um Conto de Duas Cidades", "Cidades de Papel", "Convergente", "Steve Jobs", "Bossypants",
            "Cidade de Vidro", "Toda a Luz que Não Podemos Ver", "A Princesa Prometida", "Eleanor & Park",
            "A Fúria dos Reis", "Cinquenta Tons Mais Escuros", "Forasteiro", "O Conde de Monte Cristo",
            "As Aventuras de Tom Sawyer", "Terça-Feira com Morrie", "A Seleção", "Hora de Matar", "Treze Reasons Why",
            "Cinquenta Tons de Liberdade", "Cem Anos de Solidão", "Quarto", "Catch-22", "Se Eu Ficar",
            "As Vinhas da Ira", "A Estrada", "Os Miseráveis", "Ininterrupta: Uma História da Segunda Guerra Mundial",
            "O Mar de Monstros", "Deuses Americanos", "Perdido em Marte", "Isso", "Freakonomics",
            "A Batalha do Labirinto", "Anne de Green Gables", "Confissões de uma Viciada em Compras",
            "Uma Caminhada Inesquecível", "Combinado", "As Duas Torres", "Duna", "A Tormenta de Espadas",
            "A Irmandade das Calças Viajantes", "Antes que Eu Caia", "O Ponto da Virada", "Lolita", "O Retorno do Rei",
            "A Maldição do Titã", "Me Talk Pretty One Day", "Charlie e a Fábrica de Chocolate", "O Último Olimpiano",
            "Os Pilares da Terra", "Moça com Brinco de Pérola", "Um Voou Sobre o Ninho do Cuco", "Perversos", "Emma",
            "Middlesex", "Cinder", "O Pintassilgo", "O Nome do Vento", "O Herói Perdido", "O Circo Noturno",
            "A Filha do Guardião da Memória", "Jogador Pronto Um", "O Banquete dos Corvos", "Anna Karenina",
            "Ponto de Decepção", "A Firma", "A Dança da Morte", "Maravilha", "Pequenas Grandes Mentiras",
            "Laranja Mecânica", "Silêncio, Silêncio", "Feios", "Educado", "Crime e Castigo", "Matilda",
            "Belas Criaturas", "Segredos Divinos da Irmandade Ya-Ya", "Fortaleza Digital", "Querido John",
            "Academia de Vampiros", "A Redoma de Vidro", "Selvagem: Do Perdido ao Achado", "A Cabana", "Belo Desastre",
            "A Tenda Vermelha", "A Última Canção", "Morto até o Anoitecer", "A Dança dos Dragões",
            "A Vida Imortal de Henrietta Lacks", "Sidarta", "The Guernsey Literary and Potato Peel Pie Society",
            "Algo Emprestado", "As Cinzas de Angela", "Persuasão", "Lugares Sombrios", "Watchmen", "Fangirl",
            "A Cor Púrpura", "Um para o Dinheiro", "Outono", "O Pistoleiro", "Entrevista com um Vampiro", "O Rouxinol",
            "Clube da Luta", "A Outra Garota Bolena", "Objetos Cortantes", "O Segredo do Marido", "Bared to You",
            "Marley e Eu", "Trono de Vidro", "Cidade dos Anjos Caídos", "Outliers", "Blink", "O Diabo na Cidade Branca",
            "Miséria", "Marcado", "Shiver", "O Silêncio dos Inocentes", "A Arte de Correr na Chuva", "Expiação",
            "O Chamado do Cuco", "Inferno", "Uma Abundância de Katherines", "O Oceano no Fim do Caminho",
            "Ponte para Terabítia", "Flores para Algernon", "Delírio", "Rainha Vermelha",
            "Como Fazer Amigos e Influenciar Pessoas", "A Prova de Fogo", "O Menino do Pijama Listrado",
            "Os 7 Hábitos das Pessoas Altamente Eficazes", "Belas Maldições", "A Chave de Sarah", "Nunca Me Deixe Ir",
            "Guerra Mundial Z", "A Leste do Éden", "A Marca de Atena", "O Livro do Cemitério", "Rebecca",
            "Cidade das Almas Perdidas", "A Identidade Bourne", "A Sombra do Vento", "Lenda", "Nós Éramos Mentirosos",
            "Um Homem Chamado Ove", "Tudo Está Acontecendo Sem Mim?", "Junto Veio uma Aranha", "O Projeto Rosie",
            "O Cliente", "O Filho de Netuno", "Os Contos de Beedle, o Bardo", "O Amor nos Tempos do Cólera",
            "Extremamente Alto e Incrivelmente Perto", "Lugar Nenhum", "O Diário da Babá", "A Ilha do Tesouro",
            "22/11/63", "Uma Criança Chamada Isso", "Uma Árvore Cresce no Brooklyn", "A Luz Entre Oceanos", "Fundação",
            "Watership Down", "O Sobrinho do Mago", "Sim, por favor", "A 5ª Onda", "Graceling",
            "O Sol Também Se Levanta", "Você consegue guardar segredo?", "O medo do sábio", "Correndo com Tesouras",
            "Eu sei porque o pássaro engaiolado canta", "No Ar", "A Revolta de Atlas", "A Breve Pelicano", "Inheart",
            "James e o Pêssego Gigante", "Anna e o Beijo Francês", "Pet Cemitério", "Flor da Neve e o Leque Secreto",
            "A Elite", "Cadê Você, Bernadette", "Cutting for Stone", "Trem Órfão", "O Olho do Mundo",
            "O Maravilhoso Mágico de Oz", "Três xícaras de chá", "PS Eu te amo", "Diário de um Banana",
            "Onde crescem as samambaias vermelhas", "O Sortudo", "Beijo Sombrio", "Como Água para Chocolate",
            "Porto Seguro", "O Estranho Caso do Dr. Jekyll e Mr. Hyde", "O BGA", "Cama de Gato",
            "A Caçada ao Outubro Vermelho", "A faca sutil", "Sob o Sol da Toscana", "Beije as Garotas",
            "Poeira Estelar", "Eu sou Malala", "Quem mexeu no meu queijo?", "Eu sou o Número Quatro",
            "Will Grayson, Will Grayson", "O Poderoso Chefão", "Refletido em você", "A Cura Mortal",
            "Os Pássaros Espinhosos", "Ela se desfez", "Frostbite", "Um Passeio na Floresta", "O Segredo",
            "O Império Final", "Oliver Twist", "O Único", "O Crisol", "A Insustentável Leveza do Ser",
            "Será que os Andróides sonham com ovelhas elétricas?", "A descoberta das bruxas", "Otelo", "A vaga casual",
            "A Nascente", "Eu sei que isso é verdade", "Dezenove Minutos", "Lote de Salem", "As cartas do Screwtape",
            "Corte de Espinhos e Rosas", "A Pirâmide Vermelha", "A última palestra", "Oleandro Branco", "Amada",
            "Boa de Cama", "Sill Alice", "Stargirl", "Medo e Delírio em Las Vegas", "O primeiro a morrer",
            "Uma oração para Owen Meany", "A Importância de Ser Sério", "Um Dia", "As Bruxas", "Filha de Fumaça e Osso",
            "Assassinato no Expresso do Oriente", "Promessa de Sangue", "Machadinha", "Abadia de Northanger",
            "Amante Sombrio", "A Cor da Magia", "O Que Alice Esqueceu", "Perfume: A História de um Assassino",
            "E as montanhas ecoaram", "John Adams", "Norwegian Wood", "Um Estudo em Vermelho", "O céu é real",
            "O novo desenho do lado direito do cérebro", "O Nome da Rosa", "Quando a respiração se torna ar",
            "Mansfield Park", "Crescendo", "Brisingr", "O Pacto", "Evermore", "Estranho em uma Terra Estranha",
            "Spirit Bound", "Escarlate", "A Busca do Homem por Significado", "A Arte da Guerra",
            "O décimo terceiro conto", "Frente de Tempestade", "Os Três Mosqueteiros", "A luneta âmbar",
            "O Júri em Fuga", "Antes de Dormir", "Fried Green Tomatoes at the Whistle Shop Café", "Último Sacrifício",
            "Tudo, Tudo", "As coisas desmoronam", "Libélula em âmbar", "A Streetcar Names Desire", "Para onde ela foi",
            "Na Floresta", "Cristianismo Simples", "A História da Arte", "Cidade do Fogo Celestial", "V de Vingança",
            "Uma Breve História de Quase Tudo", "A Deusa Indomável", "Coroa da Meia-Noite", "Destrua-me",
            "Sem Esperança", "A Esposa de Paris", "Eu, Robô", "Estação Onze", "Pai Rico, Pai Pobre", "Kafka na Costa",
            "Odd Thomas", "Morto para o Mundo", "Adeus às armas", "Casinha na Pradaria", "Em Defesa de Jacob",
            "Neuromante", "O Historiador", "Por Quem os Sinos Dobram", "Química Perfeita", "Silêncio", "Guerra e Paz",
            "Peter Pan", "Betrayed", "A História Secreta", "Onde está o coração",
            "Vista sua família em veludo cotelê e jeans", "Apenas ouça", "A Invenção das Asas",
            "Mortos Vivos em Dallas", "Depois de Você", "Nu", "Vá perguntar a Alice", "As 5 Linguagens do Amor",
            "Maus 1: A survivor’s tale", "Bel Canto", "A Queda dos Gigantes", "O Diário da Princesa",
            "Uma Breve História do Tempo", "Robinson Crusoé", "Pretties", "Cress", "As coisas que eles carregavam",
            "Viajando", "Pequenos incêndios por toda parte", "Tess dos D'Urbervilles", "Armas, Germes e Aço",
            "Abelhinha", "Beleza Negra", "A Milha Verde", "O Esconderijo", "Escolhido", "O poder do hábito",
            "Madame Bovary", "O pedágio fantasma", "O Xará", "A Mulher na Cabana 10", "A Boa Terra", "O Príncipe",
            "Clube dos Mortos", "Untamed", "Agência nº 1 de detetives femininos", "Acidente de Neve",
            "O Caminho dos Reis", "Mensagem em uma Garrafa", "A Casa de Hades", "As Virgens Suicidas",
            "O Deus das Pequenas Coisas", "Montanha Fria", "Fácil", "Pandemônio", "O Poço da Ascensão", "Killing Floor",
            "A Confederação de Burros", "A Breve Vida Maravilhosa de Oscar Wao", "A Guerra dos Mundos",
            "A Pequena Casa na Grande Floresta", "2001: Uma Odisséia no Espaço", "A Casa da Cozinha",
            "O Experimento do Anjo", "O Cão dos Baskervilles", "O Clã do Urso das Cavernas",
            "Café da Manhã dos Campeões", "Lembre de mim?", "Um Milhão de Pedaços", "Deus, um Delírio",
            "Tuck Everlasting", "Uma Vida com Propósitos", "Eu te darei o sol", "Orador dos Mortos",
            "Para Todos os Garotos que Já Amei", "American Psycho", "A Verdade Sobre Para Sempre",
            "Os Irmãos Karamazov", "Os Raven Boys", "A Cepa de Andrômeda", "Tormento", "Todos os lugares brilhantes",
            "Obsidiana", "O diário absolutamente verdadeiro de um índio de meio período", "Atravessado",
            "O Restaurante no Fim do Universo", "Fast Food Nation", "Meia-Noite no Jardim do Bem e do Mal",
            "Os Mágicos", "Tudo o que eu nunca te disse", "O Herói das Eras", "Algo Azul", "Cândido",
            "O mundo segundo Garp", "Corte de Névoa e Fúria", "Vá definir um vigia", "Pensando, rápido e lento",
            "Slammed", "Sombra e Osso", "Pós-morte", "Cujo", "A Grande Caçada", "Hillbilly Elegy", "Cloud Atlas",
            "Deixados para Trás", "Oryx e Crake", "A Wizard of Earthsea", "Morto como um prego",
            "Aprendiz de Assassino", "É meio que uma história engraçada", "Muro e Paz", "No lugar dela",
            "The Walking Dead Vol. 1", "O Mestre e Margarita", "O Misterioso Caso de Styles", "O Processo",
            "Sra. Dalloway", "Eleanor Oliphant está completamente bem", "Herdeira do Fogo",
            "Café da manhã na Tiffany's", "O Profeta", "Leite e Mel", "Batman: Ano Um", "O Desenho dos Três",
            "Todos Juntos Mortos", "Herança", "Definitivamente Morto", "Saga Vol 1", "A Crônica do Pássaro de Corda",
            "O Silmarillion", "O Dragão Renascido", "David Copperfield", "Prodígio", "Pretty Little Liars",
            "O Príncipe das Marés", "À Porta Fechada", "Senhor Mercedes", "On Writing: A Memoir of the Craft",
            "Coisas Necessárias", "Amor redentor", "As Crônicas Marcianas", "A Linguagem das Flores",
            "O Fantasma da Ópera", "Incline-se", "Don Quixote", "As Brumas de Avalon", "Junto para o passeio",
            "O Rei de Ferro", "A magia que muda a vida da arrumação", "Vida Após a Vida", "Choke", "O Advogado Lincoln",
            "Franny e Zooey", "Cabana do Tio Tomás", "Você está aí Deus? Sou eu, Margaret",
            "A história da vida de AJ Fikry", "A Sutil Arte de Ligar o F*da-se", "Linha do tempo", "O bicho-da-seda",
            "Americanah", "Jonathan Strange & Mr Norrell", "Zen e a arte da manutenção de motocicletas", "Christine",
            "Loucamente Culpado", "O Jardim Esquecido", "O ódio que você dá", "Celular",
            "As Incríveis Aventuras de Kavalier & Clay", "Meninos Anansi", "A Breve Segunda Vida de Bree Tanner",
            "De Morto a Pior", "Dexter Sonhando Sombrio", "Relaxe", "Vinte Mil Léguas Submarinas",
            "A Vida, o Universo e Tudo Mais", "Quando você está envolvido em chamas", "Tambores de Outono",
            "Entrelaçados em Você", "Jonathan Livingston Gaivota", "Eu tenho o seu número", "Ascensão Vermelha",
            "O casal vizinho", "Cozinha Confidencial", "Eu diria que te amo, mas depois teria que te matar",
            "Níquel e Dimed", "Prelúdios e Noturnos", "Desaparecido", "Os Garotos do Barco", "Bestial", "Todos os dias",
            "Esta canção de ninar", "Jogos Patriotas", "Mortos e Mortos", "Mundo Sem Fim",
            "The DUFF: Designated Ugly Fat Friend", "Modos de Ver", "As Mentiras de Locke Lamora",
            "Garota Interrompida", "Firestarter", "Heidi", "Tropas Estelares", "Pequenas Grandes Coisas",
            "Orange is the New Black", "Howl's Moving Castle", "O homem de cem anos que escalou uma janela…",
            "O Vampiro Lestat", "Um Monstro Chama", "Mort", "A Supremacia Bourne", "A Ferrovia Subterrânea",
            "Aristóteles e Dante descobrem os segredos do universo", "Alta Fidelidade", "O Dilema do Onívoro",
            "A Morte do Caixeiro Viajante", "O Mundo de Sofia", "Rei Lear", "Amante Eterno", "1Q84", "Seis dos Corvos",
            "A Passagem", "Uma obra comovente de um gênio impressionante", "1776", "Simon vs. a Agenda Homo Sapiens",
            "O Resgate", "Dos arquivos confusos da Sra. Basil E. Frankenweiler", "Especiais", "O Círculo",
            "O Vento nos Salgueiros", "Linhagens", "História de um povo dos Estados Unidos", "Cidade Oca", "Wallbanger",
            "Uma Visita do Bom Esquadrão", "As Terras Desoladas", "Na Rua Dublin", "Shogun", "A Casa dos Espíritos",
            "Sonhos do meu pai", "Os Vestígios do Dia", "A Volta ao Mundo em Oitenta Dias", "Tudo é Iluminado",
            "Hunted", "A boa menina", "Desastre ambulante", "Sra Frisby e os Ratos de NIMH", "A Herdeira", "O Leitor",
            "O Despertar", "Blindness", "Rainha das Sombras", "Diferentes Estações", "Caído Demais", "O Rainmaker",
            "Saco de Ossos", "Sapiens: Uma Breve História da Humanidade", "The Guardian",
            "A autobiografia de Malcolm X", "Mais magro", "Batman: O Retorno do Cavaleiro das Trevas",
            "Neve Caindo Sobre Cedros", "A Lua Chamada", "Amante Desperto", "A Zona Morta",
            "A garota com todos os presentes", "O Sangue do Olimpo", "Firefly Lane", "Na Água", "Scott Pilgrim, Vol 1",
            "O Exorcista", "O Corcunda de Notre Dame", "Estado de Maravilha", "Presa", "Hipérbole e meia", "Esfera",
            "Tartarugas Até Lá Embaixo", "Pura Verdade", "Livraria 24 horas do Sr. Penumbra", "Veronika Decides to Die",
            "A Invenção de Hugo Cabret", "Hyperion", "A Invocação", "Fogo", "Tempted", "Mortos em Família",
            "Stiff: A Curiosa Vida dos Cadáveres Humanos", "Noites em Rodanthe", "Congo", "As regras da casa de cidra",
            "O Som e a Fúria", "Parteiras", "Pippy Meia Alta", "Batman: A Piada Mortal",
            "Você está aí, vodca? Sou eu, Chelsea", "Queda de Anjo", "Vamos fingir que isso nunca aconteceu",
            "Born a Crime: Stories from a South African Childhood", "O Nascimento da Sombra", "Adorável Malvada",
            "Nu na Morte", "Homens são de Marte, Mulheres são de Vênus", "As Correções",
            "Ame aquele com quem você está", "A Rainha Branca", "O contador de histórias", "Campeã",
            "O Mercador de Veneza", "Julie e Julia: 365 dias, 524 receitas, 1 apartamento minúsculo…",
            "A Long Way Gone: Memórias de um menino soldado", "Linger", "Belas Ruínas", "O Devir de Mara Dyer",
            "Noite de Reis", "Apenas Crianças", "Intérprete de Doenças", "A Escolha", "Liberdade", "Anexos", "Inverno",
            "Encontro Azul", "Homem Invisível", "À prova de bebê", "A é para Alibi", "Talvez um dia", "Elon Musk",
            "A Princesa Constante", "O Poder do Agora: Um Guia para a Iluminação Espiritual", "Mago e Vidro",
            "A Grande Janela", "Garota dos anos 20", "Palavras de esplendor", "Matéria Escura",
            "The Silver Linings Playbook", "O jogo de Westing", "A República", "Pense e Enriqueça", "Telefone Fixo",
            "O Conto de Despereaux", "Desvende-me", "O Tigre Branco", "Cordeiro: O Evangelho Segundo Biff",
            "Shutter Island", "Entre o mundo e eu", "Nascido para Correr", "No Limite do Nunca", "Febre Negra",
            "A Sombra de Ender", "A Cruz de Fogo", "Dois para a massa", "Origem", "Antes de sermos seus",
            "Sob a Bandeira do Céu", "O Apanhador de Sonhos", "O Trono de Fogo", "Romance Moderno", "Queimado",
            "No Jardim das Feras", "O Colecionador de Ossos", "Roube como um artista", "Fechadura e Chave", "Lua Tola",
            "Lola e o vizinho", "Gabriel’s Inferno", "Guardas! Guardas!", "Os contos de fadas completos de Grimm",
            "Paixão", "A Ordem da Morte", "Asiáticos Ricos Loucos", "Artemis Fowl e a Colônia Perdida", "Amor Feio",
            "Flores no sótão", "Persépolis: A História da Infância", "A Startup Enxuta", "Por que não eu?",
            "Os Quatro Compromissos", "Ponto de Retiro", "Doutor Sono", "O Olho Mais Azul", "Esperando Godot",
            "Raízes: A saga de uma família americana", "Em uma floresta escura, escura", "Wolf Hall", "O Casamento",
            "Precisamos Falar Sobre o Kevin", "O homem que confundiu sua mulher com um chapéu", "Um quarto com vista",
            "O Diário de Suzanne para Nicholas", "Acaba Conosco", "Uma Curva na Estrada", "O Homem do Castelo Alto",
            "Lobos de Calla", "Belo Bastardo", "Onyx", "Impensado", "A Elegância do Ouriço", "O Melhor de Mim",
            "Corte de Asas e Ruína", "Regras da Casa", "Cavalos meio quebrados", "Hex Hall", "As Garotas",
            "A Improvável Peregrinação de Harold Fry", "Eleven Minutes", "Fundação e Império", "Shantaram", "Elantris",
            "Pomba Solitária", "O Caminho das Sombras", "Uma Nova Terra: Despertando para o propósito da sua vida",
            "O Eco Negro", "Merda meu pai diz", "O Sentido de um Fim", "O Kife de nunca deixar ir", "Alcançado",
            "Seabiscuit: Uma Lenda Americana", "Guerra do Velho", "Sangues Azuis",
            "The Girls' Guide to Hunting and Fishing", "Três para se tornar mortal", "Vigilantes",
            "Crazy Love: Dominado por um Deus implacável", "Cérebro em Chamas: Meu Mês de Loucura",
            "Angus, tangas e amassos frontais", "Turno da Noite", "O Ninho", "A Sombra da Noite", "Xenocídio",
            "A Rainha dos Condenados", "A Era da Inocência", "Time de Rivais", "A própria lâmina",
            "Abrahan Lincoln: Caçador de Vampiros", "O Alquimista", "A Peste", "Espada de Vidro", "Nove Histórias",
            "Garotas de Xangai", "Uma brasa nas cinzas", "Os pés de feijão", "Espere por você",
            "Viagem ao Centro da Terra", "Prazeres Culpados", "Um Mais Um", "Sorriso", "Final",
            "O verão em que fiquei bonita", "A alegria de cozinhar", "A meio caminho da sepultura",
            "Contos de um nada da quarta série", "Olive Kitteridge", "A Audácia da Esperança", "Norte e Sul",
            "Adeus e obrigado por todos os peixes", "O livro de arte", "A Bruxa do Lago Blackbird",
            "É aqui que te deixo", "Trainspotting", "O Assassino Cego", "O moinho miserável", "Inferno", "Grey",
            "Não há país para velhos", "A Doçura no Fundo da Torta", "Como eu estava morrendo", "Insônia",
            "A Torre Negra", "Assassino Real", "Minha Vida ao Lado", "Entre Tons de Cinza", "O Alienista",
            "Estudo do Veneno", "Middlemarch", "Dama da Meia-Noite", "Um pouco de vida", "Naruto, Vol 1",
            "Quatro pontos", "A notícia do transporte", "A Última Resistência do Major Pettigrew",
            "A Lista de Schingler", "Meu Amigo Brilhante", "Caindo", "Continue", "A Carreira do Mal",
            "A história da minha vida", "Tubarão", "Anne de Avonlea", "Ano das Maravilhas",
            "Certamente você está brincando, Sr. Feynman!", "A Selva", "Davi e Golias", "Sobre um Garoto",
            "Fábulas, Vol 1", "Réquiem", "Grave Perigo", "Deja Dead", "Coração de Aço", "Hino",
            "Perigo claro e presente", "O Projeto Felicidade", "Garotas bonitas", "O Curioso George", "Visão em Branco",
            "Segunda Fundação", "A Garota Mais Sortuda do Mundo", "Days of Blood & Starlight",
            "Um Cavalheiro em Moscou", "As Horas", "Ritos iguais", "Eu sou o Mensageiro",
            "Harold and the Purple Crayon", "Jogo de Gerald", "Um Sopro de Neve e Cinzas", "Awakened",
            "A Academia Austera", "Crank", "Assassinato no Vicariato", "A Guerra Eterna", "O Fogo do Céu", "Retrabalho",
            "O Guardião do Segredo", "A garota que você deixou para trás", "Cerco e Tempestade", "Paraíso Perdido",
            "Bela Escuridão", "Mulher de Branco, A", "A Câmara", "Sobrenatural", "Por Mais Um Dia",
            "Um tom mais escuro de magia", "Shopaholic & Baby", "Encontro com Rama", "Ano do Pensamento Mágico, O",
            "The Big Short: Inside the Doomsday Machine", "O Poder dos Seis", "Amante Revelado",
            "Casa de Areia e Névoa", "O Gene Egoísta", "Uma Mente Brilhante", "Um Bom Equilíbrio",
            "A Garota que Amava Tom Gordon", "Bird Box", "Um retrato do artista quando jovem", "A História do Amor",
            "O Jantar", "A Espada do Verão", "Dead Reckoning", "Amante Livre", "Pessoas do Livro", "Meninas Lilás",
            "O Fim do Oceano", "Tempo de Saída", "Regras de Rodrick", "O Cirurgião", "Sem esforço",
            "A Filha do Bonesetter", "A tempestade que se aproxima", "Lobo da Estepe", "Reconstruindo Amelia",
            "Hot Six", "O Pimpinela Escarlate", "O Homem Invisível", "As Mentes Sombrias", "Ana da Ilha",
            "Sob um Céu Escarlate", "A Canção de Susannah", "Império das Tempestades", "O Décimo Círculo",
            "Minha Antonia", "Maniac Magee", "Longe da multidão enlouquecida", "O Olho da Agulha", "Dolores Claiborne",
            "Opala", "Nunca Demais", "O Fim da Infância", "Empurrando os limites", "Não é esse tipo de garota",
            "Cavaleiro de Verão", "Leviathan Wakes", "Jemina J", "As Torres da Meia-Noite",
            "Eu, Earl e a Garota Moribunda", "High Five", "O Elevador Ersatz", "Senhor do Caos",
            "Acabou a escola – Para sempre", "Maus II: E aqui começaram meus problemas", "SuperFreakonomics",
            "A Metade Negra", "Desespero", "Acenda-me", "Através do Universo", "Regras de Civilidade", "Ao Farol",
            "Fábulas de Esopo", "Diga aos lobos que estou em casa",
            "Helter Skelter: A verdadeira história dos assassinatos de Manson", "Feira das Vaidades",
            "A Coincidência de Callie & Kayden", "A vila vil", "Rio Místico", "Shopaholic toma Manhattan", "Contato",
            "Os Tommyknockers", "Lendo Lolita em Teerã", "Os Ladrões de Sonhos", "A vida como a conhecíamos",
            "A Trama do Casamento", "Uma Coroa de Espadas", "Aniquilação", "A Misteriosa Sociedade Benedict",
            "Holistic Detective Agency de Dirk Gently", "Seven Up", "A Filha de Ferro", "Commonwealth", "Filho de Ouro",
            "Desenraizado", "Todas as Criaturas Grandes e Pequenas", "Attack on Titan Vol 1", "Hard Eight",
            "Entre os Ocultos", "O Idiota", "Filha da Fortuna", "O Assassinato de Roger Ackroyd",
            "A probabilidade estatística do amor à primeira vista", "O Mar Infinito", "O Despertar",
            "Manuseie com cuidado", "A Bruxa Morta Caminhando", "O Mundo Perdido", "A Garota Ganso",
            "Fullmetal Alchemist Vol 1", "A Garota na Teia de Aranha", "O Ajuste de Contas",
            "O Arrebatamento de Gabriel", "O Caso Eyre", "O incolor Tsukuru Tazaki e seus anos de peregrinação",
            "Confesse", "O Amuleto de Samarcanda", "O Inverno do Mundo", "O Único Ivan", "A barganha do casamento",
            "Dublinenses", "Sob o Céu do Nunca", "O Grande Sono", "Mil mulheres brancas: os diários de Mary Dodd",
            "As Ruínas de Gorlan", "Dentes Brancos", "A Ascensão da Estrela Vespertina", "O Teste do Psicopata",
            "Casa das Folhas", "Moloka'i", "Chocolate", "Os Contos de Fadas Completos", "The Glass Menagerie",
            "Um banquete móvel", "O segredo da alegria", "A cor púrpura", "Um defeito de cor", "Um pé na cozinha",
            "A luz dos dias", "Emma", "A condição humana", "Paraíso perdido", "A vida pela frente"
        };
        
        for (int i = 0; i < 1000; i++)
        {
            Livro livro = new Livro();

            livro.Titulo = titulos[i];
            livro.AutorId = rand.Next(0, 50);
            livro.GeneroId = rand.Next(0, 30);
            livro.EditoraId = rand.Next(0, 15);
            livro.AnoPublicacao = rand.Next(2010, 2025);
            livro.Preco = Math.Round(50 + (decimal)rand.NextDouble() * (300 - 10), 2);
            livro.QuantidadeEmEstoque = rand.Next(50, 501);
            
            contexto.Livros.Add(livro);
        }
        contexto.SaveChanges();
        return View(contexto.Livros.Include(a => a.Autor).Include(g => g.Genero).Include(e => e.Editora).ToList());
    }
}    
    
    
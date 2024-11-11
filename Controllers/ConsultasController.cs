using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabalhoASPNet.Models;

namespace TrabalhoAspNet.Controllers;

public class ConsultasController : Controller
{
    private readonly Contexto contexto;

    public ConsultasController(Contexto context)
    {
        contexto = context;
    }
    
    // GET
    public IActionResult FiltrarAutor()
    {
        return View();  
    }

    public IActionResult ResultadoFiltrarAutor(int? id, string nome, DateOnly? dataInicial, 
                                                DateOnly? dataFinal, string nacionalidade)
    {
        List<Autor> listaAutores = new List<Autor>();

        if (dataInicial.HasValue && dataFinal.HasValue)
        {
            listaAutores = contexto.Autores
                .Where (a => a.Nascimento >= dataInicial && a.Nascimento <= dataFinal)
                .OrderBy (a => a.Nascimento)
                .ToList();
        }
        else if (id.HasValue)
        {
            listaAutores = contexto.Autores
                .Where(a => a.Id == id)
                .ToList();
        }
        else if (!string.IsNullOrEmpty(nome))
        {
            listaAutores = contexto.Autores
                .Where(a => a.Nome.Contains(nome))
                .OrderBy (a => a.Nome)
                .ToList();
        }
        else if (!string.IsNullOrEmpty(nacionalidade))
        {
            listaAutores = contexto.Autores
                .Where(a => a.Nacionalidade.Contains(nacionalidade))
                .OrderBy (a => a.Nacionalidade)
                .ToList();
        }
        else
        {
            listaAutores = contexto.Autores
                .OrderBy (a => a.Nome)
                .ToList();
        }
        
        return View(listaAutores);
    }

    public IActionResult FiltrarLivro()
    {
        return View();
    }

    public IActionResult ResultadoFiltrarLivro(int? id, string? titulo, int? anoInicial, int? anoFinal, string? nomeAutor,
        string? editora, string? genero, decimal? precoInicial, decimal? precoFinal, int? estoqueInicial, int? estoqueFinal)
    {
        List<Livro> listaLivros = new List<Livro>();

        if (id.HasValue)
        {
            listaLivros = contexto.Livros
                .Where(l => l.Id == id)
                .ToList();
        }
        else if (!string.IsNullOrEmpty(titulo))
        {
            listaLivros = contexto.Livros
            .Where(l => l.Titulo.Contains(titulo))
            .OrderBy (l => l.Titulo)
            .ToList();
        }
        else if (anoInicial != null && anoFinal != null)
        {
            listaLivros = contexto.Livros
                .Where(l => l.AnoPublicacao >= anoInicial && l.AnoPublicacao <= anoFinal)
                .OrderBy(l => l.AnoPublicacao)
                .ToList();
        }
        else if (!string.IsNullOrEmpty(nomeAutor))
        {
            listaLivros = contexto.Livros
                .Include(l => l.Autor)
                .Where(l => l.Autor.Nome.Contains(nomeAutor))
                .OrderBy(l => l.Autor.Nome)
                .ToList();
        }
        else if (!string.IsNullOrEmpty(editora))
        {
            listaLivros = contexto.Livros
                .Include(l => l.Editora)
                .Where(l => l.Editora.Nome.Contains(editora))
                .OrderBy(l => l.Editora.Nome)
                .ToList();
        }
        else if (!string.IsNullOrEmpty(genero))
        {
            listaLivros = contexto.Livros
                .Include(l => l.Genero)
                .Where(l => l.Genero.Descricao.Contains(genero))
                .OrderBy(l => l.Genero.Descricao)
                .ToList();
        }
        else if (precoInicial.HasValue && precoFinal.HasValue)
        {
            listaLivros = contexto.Livros
                .Where(l => l.Preco >= precoInicial && l.Preco <= precoFinal)
                .OrderBy(l => l.Preco)
                .ToList();
        }
        else if (estoqueInicial.HasValue && estoqueFinal.HasValue)
        {
            listaLivros = contexto.Livros
                .Where(l => l.QuantidadeEmEstoque >= estoqueInicial && l.QuantidadeEmEstoque <= estoqueFinal)
                .OrderBy(l => l.QuantidadeEmEstoque)
                .ToList();
        }
        else
        {
            listaLivros = contexto.Livros
                .OrderBy(a => a.Titulo)
                .ToList();
        }
        return View(listaLivros);
    }
}
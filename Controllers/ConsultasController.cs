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

    public IActionResult ResultadoFiltrarLivro(int? id, string titulo, int? anoInicial, int? anoFinal, string nomeAutor,
        string editora, string genero, decimal? precoInicial, decimal? precoFinal, int? estoqueInicial, int? estoqueFinal)
    {
        List<Livro> listaLivros = new List<Livro>();

        if (id.HasValue)
        {
            listaLivros = contexto.Livros
                .Where(a => a.Id == id)
                .ToList();
        }
        else if (!string.IsNullOrEmpty(titulo))
        {
            listaLivros = contexto.Livros
            .Where(a => a.Titulo.Contains(titulo))
            .OrderBy (a => a.Titulo)
            .ToList();
        }
        else if (anoInicial != null && anoFinal != null)
        {
            listaLivros = contexto.Livros
                .Where(a => a.AnoPublicacao >= anoInicial && a.AnoPublicacao <= anoFinal)
                .OrderBy(a => a.AnoPublicacao)
                .ToList();
        }
        else if (!string.IsNullOrEmpty(nomeAutor))
        {
            listaLivros = contexto.Livros
                .Include(l => l.Autor.Nome)
                .Where(n => n.Autor.Nome.Contains(nomeAutor))
                .OrderBy(a => a.Autor.Nome)
                .ToList();
        }
        else if (!string.IsNullOrEmpty(editora))
        {
            listaLivros = contexto.Livros
                .Include(l => l.Editora.Nome)
                .Where(n => n.Editora.Nome.Contains(editora))
                .OrderBy(a => a.Editora.Nome)
                .ToList();
        }
        else if (!string.IsNullOrEmpty(genero))
        {
            listaLivros = contexto.Livros
                .Include(l => l.Genero.Descricao)
                .Where(n => n.Genero.Descricao.Contains(genero))
                .OrderBy(a => a.Genero.Descricao)
                .ToList();
        }
        else if (precoInicial.HasValue && precoFinal.HasValue)
        {
            listaLivros = contexto.Livros
                .Where(p => p.Preco >= precoInicial && p.Preco <= precoFinal)
                .OrderBy(p => p.Preco)
                .ToList();
        }
        else if (estoqueInicial.HasValue && estoqueFinal.HasValue)
        {
            listaLivros = contexto.Livros
                .Where(e => e.QuantidadeEmEstoque >= estoqueInicial && e.QuantidadeEmEstoque <= estoqueFinal)
                .OrderBy(e => e.QuantidadeEmEstoque)
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
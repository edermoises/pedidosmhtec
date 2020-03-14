using Pedidos.Models;
using Pedidos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pedidos.ViewModels
{
    public class CatalogoProdutosViewModel : BaseViewModel
    {
        private List<Produto> _produtos;
        public ICommand OnDiminuirQtdProduto { get; }
        public ICommand OnAcrescentarQtdProduto { get; }

        public decimal Total
        {
            get { return Produtos.Sum(x => x.Total); }
        }


        public CatalogoProdutosViewModel()
        {
            CarregarProdutos();
            OnDiminuirQtdProduto = new Command(DiminuirQtdProduto);
            OnAcrescentarQtdProduto = new Command(AcrescentarQtdProduto);
        }

        private void AcrescentarQtdProduto(object obj)
        {
            var produto = (Produto)obj;
            Produtos.Where(y => y.Id == produto.Id).ToList().ForEach(x => x.Quantidade += 1);
            Produtos = Produtos.ToList();
        }

        private void DiminuirQtdProduto(object obj)
        {
            var produto = (Produto)obj;
            Produtos.Where(y => y.Id == produto.Id && y.Quantidade > 0).ToList().ForEach(x => x.Quantidade -= 1);
            Produtos = Produtos.ToList();
        }

        public List<Produto> Produtos
        {
            get { return _produtos; }
            set { _produtos = value; OnPropertyChanged(nameof(Produtos)); OnPropertyChanged(nameof(Total)); }
        }

        private void CarregarProdutos()
        {
            Produtos = ProdutoDataStore.produtos;
        }

    }
}

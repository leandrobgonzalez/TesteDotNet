using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteDotNet.Core.Models;
using TesteDotNet.Core.Repositories;

namespace TesteDotNet.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void AdicionarItem()
        {
            ItemModel valores = new ItemModel()
            {
                Nome = "Valor de Teste Unitário",
                Descricao = "Adicionando itens pelo UnityTest. Método AdicionarItem()",
                Categoria = "3",
                DataItem = "06/04/2018"
            };

            Assert.AreEqual(true, TesteRepository.AdicionarItem(valores), "Houve um problema na inclusão do Item");
        }

        [TestMethod]
        public void AlterarItem()
        {
            ItemModel valores = new ItemModel()
            {
                Codigo = 1,
                Nome = "Alteração de dados pelo teste unitário",
                Descricao = "Alteração de dados pelo teste unitário. Método AlterarItem()",
                Categoria = "Item 2",
                DataItem = "07/04/2018"
            };

            Assert.AreEqual(true, TesteRepository.AlterarItem(valores), "Houve um problema na alteração do Item");
        }

        [TestMethod]
        public void ExcluirItem()
        {
            ItemModel valores = new ItemModel(){ Codigo = 3 };

            Assert.AreEqual(true, TesteRepository.ExcluirItem(valores), "Houve um problema na exclusão do Item");
        }

        [TestMethod]
        public void ConsultarItemPorCodigo()
        {
            ItemModel filtros = new ItemModel()
            {
                Codigo = 1
            };

            var retorno = TesteRepository.ConsultarItem(filtros);
            int qtdeItens = 1;
            if (retorno.Count > 0)
                qtdeItens = retorno.Count;

            Assert.AreEqual(qtdeItens, retorno.Count, "Não foram encontrador registros com esse Código");
        }

        [TestMethod]
        public void ConsultarItemPorNome()
        {
            ItemModel filtros = new ItemModel()
            {
                Nome = "Teste2"
            };

            var retorno = TesteRepository.ConsultarItem(filtros);
            int qtdeItens = 1;
            if (retorno.Count > 0)
                qtdeItens = retorno.Count;

            Assert.AreEqual(qtdeItens, retorno.Count, "Não foram encontrador registros com esse Nome");
        }

        [TestMethod]
        public void ConsultarItemPorCategoria()
        {
            ItemModel filtros = new ItemModel()
            {
                Categoria = "Item 2"
            };

            var retorno = TesteRepository.ConsultarItem(filtros);
            int qtdeItens = 1;
            if (retorno.Count > 0)
                qtdeItens = retorno.Count;

            Assert.AreEqual(qtdeItens, retorno.Count, "Não foram encontrador registros com essa Categoria");
        }

        [TestMethod]
        public void ConsultarItemPorData()
        {
            ItemModel filtros = new ItemModel()
            {
                DataItem = "07/04/2018"
            };

            var retorno = TesteRepository.ConsultarItem(filtros);
            int qtdeItens = 1;
            if (retorno.Count > 0)
                qtdeItens = retorno.Count;

            Assert.AreEqual(qtdeItens, retorno.Count, "Não foram encontrador registros com essa Data");
        }
    }
}

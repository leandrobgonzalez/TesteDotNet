using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.Core.Models;

namespace TesteDotNet.Core.Repositories
{
    public class TesteRepository
    {
        private static string caminhoBase = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + ".\\bin\\Json\\DataJson.json";

        public static bool AdicionarItem(ItemModel item)
        {
            try
            {
                List<ItemModel> items = new List<ItemModel>();
                string fullJson = "";
                using (StreamReader r = new StreamReader(caminhoBase))
                {
                    items = JsonConvert.DeserializeObject<List<ItemModel>>(r.ReadToEnd());

                    int NovoCodigo = 1;
                    if (items.Count > 0)
                        NovoCodigo += items.Max(x => x.Codigo).Value;

                    items.Add(new ItemModel
                    {
                        Codigo = NovoCodigo,
                        Nome = item.Nome,
                        Descricao = item.Descricao,
                        Categoria = item.Categoria,
                        DataItem = DateTime.Now.ToString("dd/MM/yyyy")
                });

                    fullJson = JsonConvert.SerializeObject(items.ToArray());
                }
                using (StreamWriter escrever = new StreamWriter(caminhoBase, false))
                {
                    escrever.WriteLine(fullJson);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool AlterarItem(ItemModel item)
        {
            try
            {
                string fullJson = "";
                using (StreamReader r = new StreamReader(caminhoBase))
                {
                    var items = JsonConvert.DeserializeObject<List<ItemModel>>(r.ReadToEnd());

                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].Codigo == item.Codigo)
                        {
                            items[i].Nome = item.Nome;
                            items[i].Descricao = item.Descricao;
                            items[i].Categoria = item.Categoria;
                            items[i].DataItem = DateTime.Now.ToString("dd/MM/yyyy");
                        }
                    }

                    fullJson = JsonConvert.SerializeObject(items.ToArray());
                }

                using (StreamWriter escrever = new StreamWriter(caminhoBase, false))
                {
                    escrever.WriteLine(fullJson);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ExcluirItem(ItemModel item)
        {
            try
            {
                string fullJson = "";
                using (StreamReader r = new StreamReader(caminhoBase))
                {
                    var items = JsonConvert.DeserializeObject<List<ItemModel>>(r.ReadToEnd());

                    ItemModel itemExcluir = new ItemModel();

                    itemExcluir = items.Where(p => p.Codigo == item.Codigo).FirstOrDefault();

                    items.Remove(itemExcluir);

                    fullJson = JsonConvert.SerializeObject(items.ToArray());


                }

                using (StreamWriter escrever = new StreamWriter(caminhoBase, false))
                {
                    escrever.WriteLine(fullJson);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<ItemModel> ConsultarItem(ItemModel dadosFiltro)
        {
            List<ItemModel> retorno = new List<ItemModel>();
            using (StreamReader r = new StreamReader(caminhoBase))
            {
                var items = JsonConvert.DeserializeObject<List<ItemModel>>(r.ReadToEnd());

                if (dadosFiltro.Codigo != null)
                    retorno.AddRange(items.Where(p => p.Codigo == dadosFiltro.Codigo));
                else if (!string.IsNullOrEmpty(dadosFiltro.Nome))
                    retorno.AddRange(items.Where(p => p.Nome.Contains(dadosFiltro.Nome)));
                else if (!string.IsNullOrEmpty(dadosFiltro.Categoria))
                    retorno.AddRange(items.Where(p => p.Categoria == dadosFiltro.Categoria));
                else if (!string.IsNullOrEmpty(dadosFiltro.DataItem))
                    retorno.AddRange(items.Where(p => p.DataItem == dadosFiltro.DataItem));
                else
                    retorno.AddRange(items);

                return retorno;
            }
        }

    }
}

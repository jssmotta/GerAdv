//using Microsoft.Extensions.Options;
//using System.Security.Claims;

//namespace GerMDS.Services
//{
//    public class CidadeService : ICidadeService
//    {
//        private readonly string _uri;
//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public CidadeService(IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
//        {
//            _uri = appSettings.Value.Uri;
//            _httpContextAccessor = httpContextAccessor;
//        }

//        public Task<object?> GetColumn(int id, string field, object value)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<IEnumerable<Cidade>> GetAll(int max = 1000)
//        {
//            return await Task.Run(() =>
//            {
//                using var oCnn = Configuracoes.GetConnectionByUri(_uri);
//                if (oCnn == null)
//                {
//                    return new List<Cidade>();
//                }
//                var lista = DBCidade.Listar($"select TOP {max}, {DBCidade.SensivelCamposSqlX} FROM {DBCidade.PTabelaNome} ORDER BY {DBCidade.PTabelaNome}", string.Empty, string.Empty, Configuracoes.ConnectionByUri(_uri));

//                var result = new List<Cidade>();
//                foreach (var item in lista)
//                {
//                    if (item == null) continue;
//                    result.Add(MenphisSI.GerMDS.Readers.Cidade.Read(item)!);
//                }

//                return result;
//            });
//        }
//        /*

//         var update =
//	[
//		[FieldsAgenda.cliente, `Ajfan`],
//		[FieldsAgenda.funcionario, `1`]
//	]
//;

//         */
//        public async Task<bool> UpdateColumn(int id, IEnumerable<(string, object)> campos)
//        {
//            return await Task.Run(() =>
//            {
//                using var oCnn = Configuracoes.GetConnectionByUri(_uri);
//                if (oCnn == null)
//                {
//                    return false;
//                }
//                var dbRec = new DBCidade(id, oCnn);
//                foreach (var (field, value) in campos)
//                    dbRec.SetValueByNameField($"{DBCidadeDicInfo.TablePrefix}{field}", value);
//                return dbRec.Update(oCnn) == 0;
//            });
//        }

//        public async Task<IEnumerable<(string, object)>?> GetColumn(int id, IEnumerable<string> fields)
//        {
//            return await Task.Run(() =>
//            {
//                using var oCnn = Configuracoes.GetConnectionByUri(_uri);
//                if (oCnn == null)
//                {
//                    return null;
//                }
//                var result = new List<(string, object)>();
//                var dbRec = new DBCidade(id, oCnn);
//                foreach (var field in fields)
//                    result.Add((field, dbRec.GetValueByNameField($"{DBCidadeDicInfo.TablePrefix}{field}")));

//                return result;
//            });
//        }

//        public async Task<IEnumerable<Cidade>> Filter(MenphisSI.GerMDS.Filters.Cidade filtro)
//        {
//            return await Task.Run(() =>
//            {
//                using var oCnn = Configuracoes.GetConnectionByUri(_uri);
//                if (oCnn == null)
//                {
//                    return [];
//                }
//                var cidades = new List<Cidade>();
//                var cWhere = DBCidadeDicInfo.UFSql(filtro.UF); // Cada propriedade tem seu DB[tabela]DicInfo.[campo]Sql // Se for o Caso, concactena com filtro.Operador
//                var result = MenphisSI.GerMDS.Wheres.Cidade.Read(cWhere, oCnn);
//                if (result != null)
//                {
//                    cidades.AddRange(result);
//                }
//                return cidades;
//            });
//        }

//        public async Task<Cidade?> GetById(int id)
//        {
//            return await Task.Run(() =>
//            {
//                using var oCnn = Configuracoes.GetConnectionByUri(_uri);
//                if (oCnn == null)
//                {
//                    return null;
//                }
//                return MenphisSI.GerMDS.Readers.Cidade.Read(id, oCnn);
//            });
//        }

//        public async Task<Cidade?> GetByName(string name)
//        {
//            return await Task.Run(() =>
//            {
//                using var oCnn = Configuracoes.GetConnectionByUri(_uri);
//                if (oCnn == null)
//                {
//                    return null;
//                }
//                var cWhere = $"{DBCidadeDicInfo.CampoNome}='{name.PreparaParaSql()}'";
//                return MenphisSI.GerMDS.Readers.Cidade.Read(cWhere, oCnn);
//            });
//        }

//        public async Task<Cidade?> AddAndUpdateCidade(Cidade regCidade)
//        {
//            return await Task.Run(() =>
//            {
//                using var oCnn = Configuracoes.GetConnectionByUriRw(_uri);
//                if (oCnn == null)
//                {
//                    return null;
//                }
//                MenphisSI.GerMDS.Writers.Cidade.Write(regCidade, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
//                return regCidade;
//            });
//        }

//        public async Task<Cidade?> Delete(int id)
//        {
//            return await Task.Run(() =>
//            {
//                using var oCnn = Configuracoes.GetConnectionByUriRw(_uri);
//                if (oCnn == null)
//                {
//                    return null;
//                }
//                var cidade = MenphisSI.GerMDS.Readers.Cidade.Read(id, oCnn);
//                if (cidade != null)
//                {
//                    DBCidade.DeletarItem(cidade.Id, oCnn, null);
//                }
//                return cidade;
//            });
//        }

//        public async Task<IEnumerable<NomeID>> GetListN()
//        {
//            return await Task.Run(() =>
//            {
//                var lista = DBCidade.ListarN("", DBCidadeDicInfo.CampoNome, Configuracoes.ConnectionByUri(_uri));

//                var result = new List<NomeID>();
//                foreach (var item in lista)
//                {
//                    if (item == null) continue;
//                    result.Add(new NomeID { Nome = item.FNome!, ID = item.ID });
//                }
//                return result;
//            });
//        }

//    }
//}
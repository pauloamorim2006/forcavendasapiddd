using AutoMapper;
using ERP.Application.ViewModels;
using ERP.Domain.Models;

namespace SalesForce.Application.Configuration
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CidadeViewModel, Cidade>().
                ConstructUsing(c => new Cidade(c.Id, c.CodigoIbge, c.Descricao, c.Uf));
            CreateMap<UnidadeViewModel, Unidade>().
                ConstructUsing(u => new Unidade(u.Id, u.Descricao, u.Sigla));
            CreateMap<CondicaoPagamentoViewModel, CondicaoPagamento>().
                ConstructUsing(c => new CondicaoPagamento(c.Id, c.Descricao, string.Empty)) ;
            CreateMap<FormaPagamentoViewModel, FormaPagamento>().
                ConstructUsing(f => new FormaPagamento(f.Id, f.Nome, f.Ativo, f.Tipo, f.Tef, f.Credito, f.PermitirTroco, f.ConfiguracaoFiscal));
            CreateMap<ProdutoServicoViewModel, ProdutoServico>().
                ConstructUsing(p => new ProdutoServico(p.Id, p.Nome, p.Estoque, p.Valor, p.UnidadeId, p.Ativo, p.PermiteFracionar, p.CodigoInterno));
            CreateMap<ClienteViewModel, Cliente>().
                ConstructUsing(c => new Cliente(c.Id, c.Nome, c.CnpjCpfDi, c.Ativo, c.TipoPessoa, c.Telefone, c.Email, c.InscricaoEstadual, c.TipoInscricaoEstadual, c.ConsumidorFinal,
                new Domain.Models.Endereco(c.Logradouro, c.Numero, c.Bairro, c.Cep, c.Complemento, c.CidadeId)));
            CreateMap<Empresa, EmpresaViewModel>().ReverseMap();                        
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<PedidoItem, PedidoItemViewModel>().ReverseMap();
            
        }
    }
}

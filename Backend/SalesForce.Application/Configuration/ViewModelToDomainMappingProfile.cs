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
                ConstructUsing(u => new Unidade(u.Id, u.Descricao, u.Sigla)) ;
            CreateMap<CondicaoPagamentoViewModel, CondicaoPagamento>().
                ConstructUsing(c => new CondicaoPagamento(c.Id, c.Descricao, string.Empty)) ;
            CreateMap<ProdutoServico, ProdutoServicoViewModel>().ReverseMap();
            
            
            CreateMap<Empresa, EmpresaViewModel>().ReverseMap();
            CreateMap<FormaPagamento, FormaPagamentoViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<PedidoItem, PedidoItemViewModel>().ReverseMap();

            CreateMap<ProdutoServico, ProdutoServicoViewModel>()
                .ForMember(dest => dest.UnidadeSigla, opt => opt.MapFrom(src => src.Unidade.Sigla));
            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(dest => dest.CidadeDescricao, opt => opt.MapFrom(src => src.Cidade.Descricao))
                .ForMember(dest => dest.CidadeUf, opt => opt.MapFrom(src => src.Cidade.Uf));
            CreateMap<Pedido, PedidoViewModel>()
                .ForMember(dest => dest.FormaPagamentoNome, opt => opt.MapFrom(src => src.FormaPagamento.Nome))
                .ForMember(dest => dest.CondicaoPagamentoDescricao, opt => opt.MapFrom(src => src.CondicaoPagamento.Descricao))
                .ForMember(dest => dest.ClienteNome, opt => opt.MapFrom(src => src.Cliente.Nome));
            CreateMap<PedidoItem, PedidoItemViewModel>()
                .ForMember(dest => dest.ProdutoNome, opt => opt.MapFrom(src => src.Produto.Nome));
        }
    }
}

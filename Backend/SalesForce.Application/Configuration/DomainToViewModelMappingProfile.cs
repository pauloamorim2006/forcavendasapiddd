using AutoMapper;
using ERP.Application.ViewModels;
using ERP.Domain.Models;

namespace SalesForce.Application.Configuration
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Unidade, UnidadeViewModel>();
            CreateMap<ProdutoServico, ProdutoServicoViewModel>();
            CreateMap<Cidade, CidadeViewModel>();
            CreateMap<CondicaoPagamento, CondicaoPagamentoViewModel>();
            CreateMap<Empresa, EmpresaViewModel>();
            CreateMap<FormaPagamento, FormaPagamentoViewModel>();
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Pedido, PedidoViewModel>();
            CreateMap<PedidoItem, PedidoItemViewModel>();
            CreateMap<PedidoItem, PedidoItemViewModel>();

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

using AutoMapper;
using SalesForce.Application.ViewModels;
using SalesForce.Domain.Models;

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

            CreateMap<ProdutoServico, ProdutoServicoViewModel>()
                    .ForMember(dest => dest.UnidadeSigla, opt => opt.MapFrom(src => src.Unidade.Sigla));
            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(dest => dest.CidadeDescricao, opt => opt.MapFrom(src => src.Endereco.Cidade.Descricao))
                .ForMember(dest => dest.CidadeUf, opt => opt.MapFrom(src => src.Endereco.Cidade.Uf))
                .ForMember(dst => dst.Logradouro, opt => opt.MapFrom(src => src.Endereco.Logradouro))
                .ForMember(dst => dst.Numero, opt => opt.MapFrom(src => src.Endereco.Numero))
                .ForMember(dst => dst.CidadeId, opt => opt.MapFrom(src => src.Endereco.Cidade.Id))
                .ForMember(dst => dst.Complemento, opt => opt.MapFrom(src => src.Endereco.Complemento))
                .ForMember(dst => dst.Cep, opt => opt.MapFrom(src => src.Endereco.Cep))
                .ForMember(dst => dst.Bairro, opt => opt.MapFrom(src => src.Endereco.Bairro));
            CreateMap<Pedido, PedidoViewModel>()
                .ForMember(dest => dest.FormaPagamentoNome, opt => opt.MapFrom(src => src.FormaPagamento.Nome))
                .ForMember(dest => dest.CondicaoPagamentoDescricao, opt => opt.MapFrom(src => src.CondicaoPagamento.Descricao))
                .ForMember(dest => dest.ClienteNome, opt => opt.MapFrom(src => src.Cliente.Nome));
            CreateMap<PedidoItem, PedidoItemViewModel>()
                .ForMember(dest => dest.ProdutoNome, opt => opt.MapFrom(src => src.Produto.Nome));
        } 
    }
}

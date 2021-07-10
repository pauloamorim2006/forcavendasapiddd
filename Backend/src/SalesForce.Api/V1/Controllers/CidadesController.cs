using AutoMapper;
using SalesForce.Api.Controllers;
using SalesForce.Application.ViewModels;
using SalesForce.Core.Notificacoes;
using SalesForce.Domain.Models;
using SalesForce.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesForce.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/cidades")]
    public class CidadesController : MainController
    {
        private readonly ICidadeService _cidadeService;
        private readonly IMapper _mapper;

        public CidadesController(IMapper mapper,
                                      ICidadeService cidadeService,
                                      INotificador notificador,
                                      IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _cidadeService = cidadeService;
        }

        [HttpGet]
        public async Task<IEnumerable<CidadeViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CidadeViewModel>>(await _cidadeService.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CidadeViewModel>> ObterPorId(Guid id)
        {
            var cidade = await Obter(id);

            if (cidade == null) return NotFound();

            return cidade;
        }

        [HttpPost]
        public async Task<ActionResult<CidadeViewModel>> Adicionar(CidadeViewModel CidadeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cidadeService.Adicionar(_mapper.Map<Cidade>(CidadeViewModel));

            return CustomResponse(CidadeViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CidadeViewModel>> Atualizar(Guid id, CidadeViewModel CidadeViewModel)
        {
            if (id != CidadeViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(CidadeViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cidadeService.Atualizar(_mapper.Map<Cidade>(CidadeViewModel));

            return CustomResponse(CidadeViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CidadeViewModel>> Excluir(Guid id)
        {
            var CidadeViewModel = await Obter(id);

            if (CidadeViewModel == null) return NotFound();

            await _cidadeService.Remover(id);

            return CustomResponse(CidadeViewModel);
        }

        private async Task<CidadeViewModel> Obter(Guid id)
        {
            return _mapper.Map<CidadeViewModel>(await _cidadeService.Obter(id));
        }
    }
}

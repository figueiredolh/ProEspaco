using AutoMapper;
using ProEspaco.Application.DTOs;
using ProEspaco.Application.Interfaces;
using ProEspaco.Business.Entities;
using ProEspaco.Business.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEspaco.Application.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteAppService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        //Read
        public async Task<ClienteDTO> ObterPorIdAppService(int id, bool incluirAgendamentos = false)
        {
            try
            {
                return _mapper.Map<ClienteDTO>(await _clienteRepository.ObterPorId(id, incluirAgendamentos));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ClienteDTO>> ObterPorNomeAppService(string nome)
        {
            try
            {
                return _mapper.Map<IEnumerable<ClienteDTO>>(await _clienteRepository.ObterPorNome(nome));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ClienteDTO>> ObterTodosAppService(bool incluirAgendamentos = false)
        {
            try
            {
                return _mapper.Map<IEnumerable<ClienteDTO>>(await _clienteRepository.ObterTodos(incluirAgendamentos));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Create
        public async Task<ClienteDTO> AdicionarAppService(ClienteDTO modelCliente)
        {
            try
            {
                var evento = _mapper.Map<Cliente>(modelCliente);
                _clienteRepository.Adicionar(evento); //trocar para servico - business

                if (await _clienteRepository.SalvarAlteracoes())
                {
                    return _mapper.Map<ClienteDTO>(evento);
                }

                throw new Exception("Erro ao salvar as alterações no banco de dados");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }        
        }

        //Update
        public async Task<ClienteDTO> AtualizarAppService(int id, ClienteDTO modelCliente)
        {
            try
            {
                var clienteaAtualizar = await _clienteRepository.ObterPorId(id);

                if (clienteaAtualizar == null)
                {
                    return null;
                }

                clienteaAtualizar = _mapper.Map(modelCliente, clienteaAtualizar);
                clienteaAtualizar.Id = id;

                _clienteRepository.Atualizar(clienteaAtualizar); //trocar para servico - business

                if (await _clienteRepository.SalvarAlteracoes())
                {
                    var clienteAtualizado = await _clienteRepository.ObterPorId(id);
                    return _mapper.Map<ClienteDTO>(clienteAtualizado);
                }

                throw new Exception("Erro ao salvar as alterações no banco de dados");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }

        //Delete
        public async Task<ClienteDTO> ExcluirAppService(int id)
        {
            try
            {
                var clienteaExcluir = _mapper.Map<Cliente>(await _clienteRepository.ObterPorId(id));

                if (clienteaExcluir == null)
                {
                    return null;
                }

                _clienteRepository.Excluir(clienteaExcluir); //trocar para servico - business

                if (await _clienteRepository.SalvarAlteracoes())
                {
                    return _mapper.Map<ClienteDTO>(clienteaExcluir);
                }

                throw new Exception("Erro ao salvar as alterações no banco de dados");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO> ExcluirVariosAppService(IEnumerable<ClienteDTO> modelClientes)
        {
            throw new NotImplementedException();
        }
    }
}

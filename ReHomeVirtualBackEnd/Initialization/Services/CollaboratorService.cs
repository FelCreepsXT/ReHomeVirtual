using ReHomeVirtualBackEnd.General.Domain.Repositories;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Domain.Repositories;
using ReHomeVirtualBackEnd.Initialization.Domain.Services;
using ReHomeVirtualBackEnd.Initialization.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Initialization.Services
{
    public class CollaboratorService : ICollaboratorService
    {


        private readonly ICollaboratorRepository _collaboratorRepository;

        public readonly IUnitOfWork _unitOfWork;


        public CollaboratorService(ICollaboratorRepository collaboratorRepository, IUnitOfWork unitOfWork)
        {
            _collaboratorRepository = collaboratorRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<IEnumerable<Collaborator>> ListAsync()
        {
            return await _collaboratorRepository.ListAsync();
        }

        public async Task<CollaboratorResponse> GetByIdAsync(int id)
        {
            var existingCollaborator = await _collaboratorRepository.FindById(id);

            if (existingCollaborator == null)
                return new CollaboratorResponse("Collaborator not found");
            return new CollaboratorResponse(existingCollaborator);
        }

        public async Task<CollaboratorResponse> SaveAsync(Collaborator collaborator)
        {

            try
            {
                await _collaboratorRepository.AddAsync(collaborator);
                await _unitOfWork.CompleteAsync();

                return new CollaboratorResponse(collaborator);
            }
            catch (Exception ex)
            {
                return new CollaboratorResponse($"An error ocurred while saving collaborator: {ex.Message}");
            }
        }

        public async Task<CollaboratorResponse> UpdateAsync(int id, Collaborator collaborator)
        {
            var existingCollaborator = await _collaboratorRepository.FindById(id);
            if (existingCollaborator == null)

                return new CollaboratorResponse("Collaborator not found");

            existingCollaborator.Name = collaborator.Name;

            try
            {
                _collaboratorRepository.Update(existingCollaborator);
                await _unitOfWork.CompleteAsync();

                return new CollaboratorResponse(existingCollaborator);
            }
            catch (Exception ex)
            {
                return new CollaboratorResponse($"An error ocurred while updating role: {ex.Message}");
            }
        }



        public async Task<CollaboratorResponse> DeleteAsync(int id)
        {
            var existingCollaborator = await _collaboratorRepository.FindById(id);

            if (existingCollaborator == null)
                return new CollaboratorResponse("Role not found");

            try
            {
                _collaboratorRepository.Remove(existingCollaborator);
                await _unitOfWork.CompleteAsync();

                return new CollaboratorResponse(existingCollaborator);
            }
            catch (Exception ex)
            {
                return new CollaboratorResponse($"An error ocurred while deleting role: {ex.Message}");
            }
        }
    }
}

using AutoMapper;
using US.BLL.DTOs.AboutContents;
using US.BLL.Exceptions;
using US.BLL.Interfaces;
using US.DAL.Interfaces;

namespace  US.BLL.Services;

public class AboutContentService(
    IUnitOfWork unitOfWork,
    IMapper mapper) : IAboutContentService
{
    public async Task<AboutContentResponse> GetContentAsync(CancellationToken cancellationToken = default)
    {
        var content = await unitOfWork.AboutContents.GetContentAsync(cancellationToken)
                      ?? throw new NotFoundException("There is no content yet.");

        return mapper.Map<AboutContentResponse>(content);
    }

    public async Task<AboutContentResponse> UpdateAsync(int currentUserId, UpdateAboutContentRequest request, CancellationToken cancellationToken = default)
    {
        var content = await unitOfWork.AboutContents.GetContentAsync(cancellationToken)
                      ?? throw new NotFoundException("There is no content yet.");
        
        content.UpdateText(request.Text, currentUserId);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<AboutContentResponse>(content);
    }
}

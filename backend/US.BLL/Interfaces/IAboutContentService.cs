using US.BLL.DTOs.AboutContents;

namespace US.BLL.Interfaces;

public interface IAboutContentService
{
    Task<AboutContentResponse> GetContentAsync(CancellationToken cancellationToken = default);
    Task<AboutContentResponse> UpdateAsync(int currentUserId, UpdateAboutContentRequest request, CancellationToken cancellationToken = default);
}
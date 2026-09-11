using US.BLL.DTOs.AboutContents;

namespace US.BLL.Interfaces;

public interface IAboutContentService
{
    Task<AboutContentResponse> GetContentAsync(CancellationToken cancellationToken = default);
    Task<AboutContentResponse> UpdateAsync(int contentId, UpdateAboutContentRequest request, CancellationToken cancellationToken = default);
}
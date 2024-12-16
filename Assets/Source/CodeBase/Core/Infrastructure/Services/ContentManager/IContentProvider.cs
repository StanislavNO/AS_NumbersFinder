using Assets.Source.CodeBase.Core.Common.Configs;

namespace Assets.Source.CodeBase.Core.Infrastructure.Services.Score
{
    internal interface IContentProvider
    {
        Item GetTarget();
        Item GetContent();
    }
}

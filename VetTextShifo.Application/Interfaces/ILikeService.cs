﻿using VetTextShifo.Domain.Entities.ProductDetails;

namespace VetTextShifo.Application.Interfaces;

public interface ILikeService
{
    public Task AddLikeProduct(Likes like ,CancellationToken cancellationToken);

}

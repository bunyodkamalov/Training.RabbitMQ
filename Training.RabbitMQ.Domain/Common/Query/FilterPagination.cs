﻿namespace Training.RabbitMQ.Domain.Common.Query;

public class FilterPagination
{
    public uint PageSize { get; init; }
    public uint PageToken { get; init; }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is FilterPagination filterPagination && filterPagination.GetHashCode() == GetHashCode();
    }
}
namespace Domain.Entities;

public enum OrderStatus
{
    Pending,
    InPreparation,
    PendingPayment,
    AuthorizedPayment,
    UnauthorizedPayment,
    Completed,
    Canceled
}
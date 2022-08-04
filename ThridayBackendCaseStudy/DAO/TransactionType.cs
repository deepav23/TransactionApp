namespace ThridayBackendCaseStudy.DAO;

public enum CashflowDirection
{
    Outflow,
    Inflow
}

public enum TransactionType
{
    TRANSFER_OUTGOING,
    TRANSFER_INCOMING,
    PAYMENT_OUTGOING,
    PAYMENT_INCOMING
}

public enum TransactionStatus
{
    PENDING,
    POSTED
}
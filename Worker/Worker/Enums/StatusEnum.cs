namespace Worker.Enums
{
    public enum StatusEnum
    {
        WaitingForEmployee,
        WaitingForEmployerConfirmation,
        WaitingForEmployeeConfirmation,
        RejectedByEmployer,
        RejectedByEmployee,
        InProgress,
        Done,
        Removed
    }
}
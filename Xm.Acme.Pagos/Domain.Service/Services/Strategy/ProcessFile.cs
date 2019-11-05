namespace Domain.Service.Services.Strategy
{
    public class ProcessFile
    {
        private ProcessFileBankMovement processFileBankMovement;

        public ProcessFile(ProcessFileBankMovement pProcessFileBankMovement)
        {
            processFileBankMovement = pProcessFileBankMovement;
        }

        public void ProcessMulticashFile()
        {
            processFileBankMovement.ProcessMulticashFile();
        }

        public void ProcessBankFile()
        {
            processFileBankMovement.ProcessBankFile();
        }

        public void ProcessFileOccidente()
        {
            processFileBankMovement.ValidateProcessOccidente();
            processFileBankMovement.ProcessBankFile();
        }
    }
}

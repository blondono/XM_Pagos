namespace Domain.Service.Services.Strategy
{
    public abstract class ProcessFileBankMovement
    {
        #region Atributes

        #endregion

        #region Constructor
        public ProcessFileBankMovement()
        {

        }

        #endregion

        #region Methods

        public virtual void ProcessMulticashFile() { }

        public virtual void ProcessBankFile() { }

        public virtual void ValidateProcessOccidente() { }

        #endregion
    }
}

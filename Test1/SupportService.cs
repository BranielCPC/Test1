namespace Test1
{/*
  *
    public class SupportService
    {
        private readonly List<Engineer> _engineers;

        public SupportService(List<Engineer> engineers)
        {
            _engineers = engineers;
        }

        public (Engineer, Engineer) SelectEngineers()
        {
            // Ensure all engineers have completed one whole day of support in the last 2 weeks
            EnforceTwoWeekRule();

            // Select two engineers at random
            var selectedEngineers = _engineers.OrderBy(x => Guid.NewGuid()).Take(2);

            // Ensure the selected engineers can complete a half day of support
            if (!CanCompleteSupport(selectedEngineers.ElementAt(0)) || !CanCompleteSupport(selectedEngineers.ElementAt(1)))
            {
                throw new Exception("Selected engineers cannot complete a half day of support.");
            }

            // Ensure the selected engineers do not have half day shifts on consecutive days
            if (AreConsecutiveDays(selectedEngineers.ElementAt(0), selectedEngineers.ElementAt(1)))
            {
                throw new Exception("Selected engineers have half day shifts on consecutive days.");
            }

            return (selectedEngineers.ElementAt(0), selectedEngineers.ElementAt(1));
        }

        private void EnforceTwoWeekRule()
        {
            // Implement logic to enforce the two week rule here
        }
        
        private bool CanCompleteSupport(Engineer engineer)
        {
            // Implement logic to check if the engineer can complete a half day of support here
        }

        private bool AreConsecutiveDays(Engineer engineer1, Engineer engineer2)
        {
            // Implement logic to check if the selected engineers have half day shifts on consecutive days here
        } } */
    

}

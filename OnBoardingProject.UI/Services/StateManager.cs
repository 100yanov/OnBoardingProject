namespace OnBoardingProject.UI.Services
{
    public class StateManager
    {
        private int ReviewedProductsCount = 0;
        public event EventHandler<int> ReviewedProductsChanged;

        public void IncrementProductsReviewedCount()
        {
            ReviewedProductsCount++;
            ReviewedProductsChanged?.Invoke(this, ReviewedProductsCount);
        }
    }
}

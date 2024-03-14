namespace DSR_MAGALU_DATA.Entities
{
    public interface ViewModelBase<TViewModel, TModel> where TModel : class where TViewModel : class
    {
        static abstract TViewModel DeModel(TModel model);
    }
}

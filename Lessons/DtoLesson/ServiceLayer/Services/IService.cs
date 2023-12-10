namespace ServiceLayer.Services
{
    internal interface IService<TEntity, DtoReq, DtoRes>
    {
        public DtoRes Get(int Id);
        public DtoRes Update();
        public DtoRes GetAll();
        public DtoRes Delete(int Id);
    }
}

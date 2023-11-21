namespace Dynamics.Lesson
{
    internal partial class State
    {
        internal RegionDto CreateRegion(RegionReq req)
        {
            Region region = new(req.Name);
            return new RegionDto { Name = region.Name };
        }

        #region Nested Class
        private class Region
        {
            string _name;
            int _poplation;
            public string Name { get => _name; }
            public int Poplation { get => _poplation; }

            public Region(string Name)
            {
                _name = Name;
            }
        }

        #endregion
    }


}

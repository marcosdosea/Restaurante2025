﻿namespace Core.Service
{
    public interface IMesaService
    {
        uint Create(Mesa mesa);
        void Edit(Mesa mesa);
        void Delete(int id);
        Mesa Get(int id);
        IEnumerable<Mesa> GetAll();
    }
}

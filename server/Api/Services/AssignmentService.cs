using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using MongoDB.Driver;

namespace Api.Services
{
    public class AssignmentService: IAssignmentService
    {
        private readonly IMongoCollection<Assignment> _collection;

        public AssignmentService(IMongoDBContext context)
        {
            _collection = context.Database().GetCollection<Assignment>("Assignment");
        }

        public List<Assignment> Get() =>
            _collection.Find(c => true).ToList();

        //public List<Assignment> Get1() =>
        //   _collection1.Find(c => true).ToList();
        public Assignment Get(string id) =>
            _collection.Find<Assignment>(c => c.Id == id).FirstOrDefault();

        public Assignment Create(Assignment c)
        {
            _collection.InsertOne(c);
            return c;
        }

        public void Update(string id, Assignment _dataIn) =>
            _collection.ReplaceOne(c => c.Id == id,_dataIn);

       // public void Remove(Assignment _dataIn) =>
        //    _collection.DeleteOne(c => c.Id == _dataIn.Id);

        public void Remove(string id) =>
            _collection.DeleteOne(c => c.Id == id);

    }


    public interface IAssignmentService
    {
        List<Assignment> Get();

        Assignment Get(string id);


        Assignment Create(Assignment c);

        void Update(string id, Assignment _dataIn);

       // void Remove(Assignment _dataIn);

        void Remove(string id);

    }
}




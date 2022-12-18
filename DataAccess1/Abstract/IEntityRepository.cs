using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // generic constraint t parametresini sınırlandırma 
    public interface IEntityRepository <T> where T:class, IEntıty , new () 
        //interface genericyapı 
        // t ya ıentıty olabılır yada onun mırası alan 
    {
        List<T> GetAll(Expression<Func<T,bool >>filter=null); // filtre ,ile getirme expression. null olması filtre vermesse 
        T Get(Expression<Func<T, bool>> filter ); 
        
        void Add( T entity );
        void Update(T entity);
        void Delete(T entity );

        //List<T > GetallbyCategory(int categoryId); expressiün yazdık bu koda ihtiyaç yok
    }
}

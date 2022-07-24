# RadencyBooks

# AppSettings
```json
"AppSettings" : {
"SecretKey" : "your-secret-key"
}
```
# Create new query
```csharp 
public class NewQuery:Query<Entity>, ITypeResultQuery{
    protected override IQueryable<Book> GetQuery(DbSet<Entity> dbSet){
        //write your query
    }
}
```
## Invoke query
```csharp
var result = await _repository.ListAsync(new NewQuery());
```
### ITypeResultQuery can be:
 * ### ISingleResultQuery - the single result entity 
 * ### IListResultQuery - the list entity result
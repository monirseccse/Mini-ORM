using Assignment4;



Topic topic =new Topic().Instantiate();
Type type = new Necessary().TypeGetting(topic);
if(type!=null)
{
    var orm = new MyORM<int, Topic>();
    try
    {
       orm.Insert(topic);
      // orm.Update(topic);
       // orm.Delete(topic);
        //orm.Delete(topic.Id);
        //orm.GetById(topic.Id);
       // orm.GetAll();
        Console.WriteLine("Execution Successfully Done");
    }
    catch (Exception ex)
    {

        Console.WriteLine("Error Occured");
    }
   
}

else
{
    Console.WriteLine("Incorrect Class Name");
}






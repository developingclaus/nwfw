# How To Add Endpoint To NWFW api

With an Order endpoint as example:

1. Add ViewModel  
Create file ViewModels/OrderViewModel.cs, bringing in what fields you want from Models/Order.cs
2. Register Mapping  
Add mapping of Model to ViewModel (and reverse) in Mappings/AutoMapperProfileConfiguration.cs
3. Create Repo and Interface  
Create Repositories/Interfaces/IOrderRepo.cs which defines the methods you need for the Controller, and then Repositories/OrderRepo.cs which implements these methods.
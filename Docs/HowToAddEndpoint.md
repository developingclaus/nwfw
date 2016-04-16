# How To Add Endpoint To NWFW api

With an Order endpoint as example:

######1. Add ViewModel
Create file ViewModels/OrderViewModel.cs, bringing in what fields you want from Models/Order.cs. Make sure to change any collections or navigation properties to refer to the view model entities, not the model entities. E.g. OrderViewModel has an ICollection<OrderItemViewModel> property, not ICollection<OrderItem> property.  
######2. Register Mapping
Add mapping of Model to ViewModel (and reverse) in Mappings/AutoMapperProfileConfiguration.cs
######3. Create Repo and Interface
Create Repositories/Interfaces/IOrderRepo.cs which defines the methods you need for the Controller, and then Repositories/OrderRepo.cs which inherits from IOrderRepo and implements these methods.
######4. Register Repo
Add registration of Interface and Repo in ConfigureServices in startup like so:  
services.AddScoped<IOrderRepo, OrderRepo>();
######5. Add Controller
Create Controllers/OrderController.cs and call the repo methods corresponding to the HTTP verbs to finalize endpoint. Use OrderController.cs as template.
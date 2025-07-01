// See https://aka.ms/new-console-template for more information

using inventorySystem.Models;
using inventorySystem.Repositories;

const string mysql_connetion_string = 
    "Server=localhost;Port=3306;Database=inventory_db;uid=root;pwd=Ji3g4284;";

MySqlProductRepository ProductRepository = new MySqlProductRepository(mysql_connetion_string);






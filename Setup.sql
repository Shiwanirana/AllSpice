 use allspiceapi;

--  CREATE TABLE recipes (
--   id INT NOT NULL AUTO_INCREMENT,
--   Name VARCHAR(255) NOT NULL,
--   Description VARCHAR(255),
--   Price DECIMAL(5,2),
--   Image VARCHAR(255),
--   PRIMARY KEY (id)
-- );

CREATE TABLE ingredients (
  id INT NOT NULL AUTO_INCREMENT,
  Name VARCHAR(255) NOT NULL,
  Body VARCHAR(255),
  RecipeId INT NOT NULL,
  PRIMARY KEY(id),
  FOREIGN KEY (RecipeId) 
  REFERENCES recipes (id)
  ON DELETE CASCADE
)
-- INSERT INTO ingredients
-- (Name,Body,ProductId) VALUES
-- ("Paneer Tikka", "")

-- INSERT INTO recipes
-- (Name,Description,Price,Image) VALUES
-- ("Paneer Tikka","Made with Love",100,"https://plceholder");
-- SELECT * FROM recipes;

-- UPDATE recipes SET Description = "aasssaa",Name="sjd", Price= 12, Image="kdhf" WHERE id= 3;
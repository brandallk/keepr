CREATE TABLE users (
  id VARCHAR(255) NOT NULL,
  username VARCHAR(20) NOT NULL,
  email VARCHAR(255) NOT NULL,
  password VARCHAR(255) NOT NULL,
  PRIMARY KEY (id),
  UNIQUE KEY email (email)
);

CREATE TABLE vaults (
  id int NOT NULL AUTO_INCREMENT,
  name VARCHAR(20) NOT NULL,
  description VARCHAR(255) NOT NULL,
  userId VARCHAR(255),
  INDEX userId (userId),
  FOREIGN KEY (userId)
    REFERENCES users(id)
    ON DELETE CASCADE,
  PRIMARY KEY (id)
);

CREATE TABLE keeps (
  id int NOT NULL AUTO_INCREMENT,
  name VARCHAR(20) NOT NULL,
  description VARCHAR(255) NOT NULL,
  userId VARCHAR(255),

  -- new
  imageUrl VARCHAR(255) NOT NULL,
  link VARCHAR(255) NOT NULL,
  public TINYINT(1) NOT NULL,
  keepCount int NOT NULL,
  shareCount int NOT NULL,
  viewCount int NOT NULL,

  INDEX userId (userId),
  FOREIGN KEY (userId)
    REFERENCES users(id)
    ON DELETE CASCADE,
  PRIMARY KEY (id)
);

-- new
CREATE TABLE tags (
  id int NOT NULL AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL,
  PRIMARY KEY (id)
);

-- new
CREATE TABLE keeptags (
  id int NOT NULL AUTO_INCREMENT,
  keepId int NOT NULL,
  tagId int NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (keepId)
    REFERENCES keeps(id)
    ON DELETE CASCADE,
  FOREIGN KEY (tagId)
    REFERENCES tags(id)
    ON DELETE CASCADE
);

CREATE TABLE vaultkeeps (
  id int NOT NULL AUTO_INCREMENT,
  vaultId int NOT NULL,
  keepId int NOT NULL,
  userId VARCHAR(255) NOT NULL,

  PRIMARY KEY (id),
  INDEX (vaultId, keepId),
  INDEX (userId),
  
  FOREIGN KEY (userId)
    REFERENCES users(id)
    ON DELETE CASCADE,

  FOREIGN KEY (vaultId)
    REFERENCES vaults(id)
    ON DELETE CASCADE,

  FOREIGN KEY (keepId)
    REFERENCES keeps(id)
    ON DELETE CASCADE
);

-- -- USE THIS LINE FOR GET KEEPS BY VAULT ID
-- SELECT * FROM vaultkeeps
-- INNER JOIN keeps ON keeps.id = vaultkeeps.keepId
-- WHERE (vaultId = 2)   -- ("2" is just an example)
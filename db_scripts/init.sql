CREATE TABLE "Plants" (
    "Id" UUID PRIMARY KEY,
    "Name" VARCHAR(50) NOT NULL,
    "Location" VARCHAR(100) NOT NULL,
    "PlantingDate" TIMESTAMP NOT NULL,
    "NeedsWatering" BOOLEAN NOT NULL
);

CREATE TABLE "Tasks" (
    "Id" UUID PRIMARY KEY,
    "Description" VARCHAR(200) NOT NULL,
    "DueDate" TIMESTAMP NOT NULL,
    "IsCompleted" BOOLEAN NOT NULL,
    "PlantId" UUID NULL REFERENCES "Plants"("Id") ON DELETE SET NULL
);
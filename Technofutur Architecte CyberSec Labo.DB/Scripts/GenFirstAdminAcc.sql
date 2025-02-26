/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF ((SELECT COUNT(*) FROM [dbo].[Users]) = 0)
BEGIN
    INSERT INTO [dbo].[Users](Email, Pwd, Perms) VALUES ('admin@admin.com', [dbo].[HashPwd]('Admin1234='), 'Admin')
END
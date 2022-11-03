DELIMITER $$
DROP TRIGGER IF EXISTS befdeletePlato $$
CREATE TRIGGER befdeletePlato BEFORE DELETE ON plato
FOR EACH ROW
BEGIN
    DELETE FROM Restaurante
    WHERE idPlato = OLD.idPlato;
END $$
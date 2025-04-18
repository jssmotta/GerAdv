select  opoNome from oponentes group by opoNome having count(*) >1;

select opoCodigo, opoNome from oponentes
where opoNome like 'Brasil - U.S.A Comercializa��o de Resorts Ltda.' or 
opoNome like 'Brasil Properties Comercializa��o de Propriedade de F�rias Ltda.' or 
opoNome like 'Caixa Econ�mica Federal' or 
opoNome like 'Conselho Regional de Nutricionistas' or 
opoNome like 'Eunice Rodrigues' or 
opoNome like 'Ita� Unibanco S.A.' or 
opoNome like 'Lia Beatriz Rossi Mesquita' or 
opoNome like 'Minist�rio P�blico' or 
opoNome like 'Minist�rio P�blico Federal' or 
opoNome like 'Receita Federal'
order by opoNome;

-- Brasil - U.S.A Comercializa��o de Resorts Ltda.
UPDATE processos SET proOponente=2461 WHERE proOponente=2466;

-- Brasil Properties Comercializa��o de Propriedade de F�rias Ltda.
UPDATE processos SET proOponente=2462 WHERE proOponente=2465;

-- Caixa Econ�mica Federal
UPDATE processos SET proOponente=347 WHERE proOponente IN (4470, 4592, 4630);

-- Conselho Regional de Nutricionistas
UPDATE processos SET proOponente=2437 WHERE proOponente=2790;

-- Eunice Rodrigues
UPDATE processos SET proOponente=2430 WHERE proOponente=2439;

-- Ita� Unibanco S.A.
UPDATE processos SET proOponente=2508 WHERE proOponente=4479;

-- Lia Beatriz Rossi Mesquita
UPDATE processos SET proOponente=4334 WHERE proOponente=4339;

-- Minist�rio P�blico
UPDATE processos SET proOponente=256 WHERE proOponente IN (4428, 4623);

-- Minist�rio P�blico Federal
UPDATE processos SET proOponente=311 WHERE proOponente=4654;

-- Receita Federal
UPDATE processos SET proOponente=857 WHERE proOponente IN (2501, 3685);


DELETE FROM oponentes 
WHERE opoCodigo IN (
    2466, -- Brasil - U.S.A Comercializa��o de Resorts Ltda. (duplicado de 2461)
    2465, -- Brasil Properties Comercializa��o de Propriedade de F�rias Ltda. (duplicado de 2462)
    4470, 4592, 4630, -- Caixa Econ�mica Federal (duplicados de 347)
    2790, -- Conselho Regional de Nutricionistas (duplicado de 2437)
    2439, -- Eunice Rodrigues (duplicado de 2430)
    4479, -- Ita� Unibanco S.A. (duplicado de 2508)
    4339, -- Lia Beatriz Rossi Mesquita (duplicado de 4334)
    4428, 4623, -- Minist�rio P�blico (duplicados de 256)
    4654, -- Minist�rio P�blico Federal (duplicado de 311)
    2501, 3685 -- Receita Federal (duplicados de 857)
);
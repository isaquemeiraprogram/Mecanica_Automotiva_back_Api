create Database if not exists mecanica;
use mecanica;

INSERT INTO categoriasprodutos (ID, Nome)
VALUES
(UUID(), 'mecanica'),
(UUID(), 'eletrica'),
(UUID(), 'hidraulica'),
(UUID(), 'estrutural'),
(UUID(), 'interior e conforto');

INSERT INTO subcategoriasprodutos(ID,Nome,CategoriaProdutoID)
VALUES	

/*mecanica*/
(UUID(), 'motor', '1cba9249-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'transmissão', '1cba9249-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'suspensão', '1cba9249-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'freios', '1cba9249-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'direção', '1cba9249-680b-11f0-9a87-0ae0afa50356'),

/*eletrica*/
(UUID(), 'bateria', '1cba97fe-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'alternador', '1cba97fe-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'motor de partida', '1cba97fe-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'faróis', '1cba97fe-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'lanternas', '1cba97fe-680b-11f0-9a87-0ae0afa50356'),

/*hidraulica*/
(UUID(), 'óleo', '1cba9a21-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'fluido de freio', '1cba9a21-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'fluido de direção', '1cba9a21-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'Fluido de arrefecimento', '1cba9a21-680b-11f0-9a87-0ae0afa50356'),

/*estrutural*/
(UUID(), 'chassis', '1cba9bf7-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'carroceria', '1cba9bf7-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'portas', '1cba9bf7-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'capô', '1cba9bf7-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'para-choques', '1cba9bf7-680b-11f0-9a87-0ae0afa50356'),

/*interior e conforto*/
(UUID(), 'bancos', '1cba9e67-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'painel', '1cba9e67-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'volante', '1cba9e67-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'ar-condicionado', '1cba9e67-680b-11f0-9a87-0ae0afa50356'),
(UUID(), 'sistema de som', '1cba9e67-680b-11f0-9a87-0ae0afa50356');


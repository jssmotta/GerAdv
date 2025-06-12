import { IGUTAtividadesMatriz } from '../GUTAtividadesMatriz/Interfaces/interface.GUTAtividadesMatriz';
export interface GUTAtividadesMatriz
{
    id: number;
	gutmatriz : number;
	gutatividade : number;
	descricaogutmatriz?: string;
	nomegutatividades?: string;

}


export function GUTAtividadesMatrizEmpty(): IGUTAtividadesMatriz {
// 20250604
    
    return {
        id: 0,
		gutmatriz: 0,
		gutatividade: 0,
    };
}

export function GUTAtividadesMatrizTestEmpty(): IGUTAtividadesMatriz {
// 20250604
    
    return {
        id: 1,
		gutmatriz: 1,
		gutatividade: 1,
    };
}



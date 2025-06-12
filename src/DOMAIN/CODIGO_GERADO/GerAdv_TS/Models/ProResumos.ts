import { IProResumos } from '../ProResumos/Interfaces/interface.ProResumos';
export interface ProResumos
{
    id: number;
	processo : number;
	data : string;
	resumo : string;
	tiporesumo : number;
	bold : boolean;
	nropastaprocessos?: string;

}


export function ProResumosEmpty(): IProResumos {
// 20250604
    
    return {
        id: 0,
		processo: 0,
		data: '',
		resumo: '',
		tiporesumo: 0,
		bold: false,
    };
}

export function ProResumosTestEmpty(): IProResumos {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		data: 'X',
		resumo: 'X',
		tiporesumo: 1,
		bold: true,
    };
}



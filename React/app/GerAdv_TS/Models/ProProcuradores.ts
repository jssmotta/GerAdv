import { IProProcuradores } from '../ProProcuradores/Interfaces/interface.ProProcuradores';
export interface ProProcuradores
{
    id: number;
	advogado : number;
	processo : number;
	nome : string;
	data : string;
	substabelecimento : boolean;
	procuracao : boolean;
	bold : boolean;
	nomeadvogados?: string;
	nropastaprocessos?: string;

}


export function ProProcuradoresEmpty(): IProProcuradores {
// 20250604
    
    return {
        id: 0,
		advogado: 0,
		processo: 0,
		nome: '',
		data: '',
		substabelecimento: false,
		procuracao: false,
		bold: false,
    };
}

export function ProProcuradoresTestEmpty(): IProProcuradores {
// 20250604
    
    return {
        id: 1,
		advogado: 1,
		processo: 1,
		nome: 'X',
		data: 'X',
		substabelecimento: true,
		procuracao: true,
		bold: true,
    };
}



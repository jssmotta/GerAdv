import { IDocsRecebidosItens } from '../DocsRecebidosItens/Interfaces/interface.DocsRecebidosItens';
export interface DocsRecebidosItens
{
    id: number;
	contatocrm : number;
	nome : string;
	devolvido : boolean;
	seradevolvido : boolean;
	observacoes : string;
	bold : boolean;

}


export function DocsRecebidosItensEmpty(): IDocsRecebidosItens {
// 20250604
    
    return {
        id: 0,
		contatocrm: 0,
		nome: '',
		devolvido: false,
		seradevolvido: false,
		observacoes: '',
		bold: false,
    };
}

export function DocsRecebidosItensTestEmpty(): IDocsRecebidosItens {
// 20250604
    
    return {
        id: 1,
		contatocrm: 1,
		nome: 'X',
		devolvido: true,
		seradevolvido: true,
		observacoes: 'X',
		bold: true,
    };
}



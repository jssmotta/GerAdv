import { IBensMateriais } from '../BensMateriais/Interfaces/interface.BensMateriais';
export interface BensMateriais
{
    id: number;
	bensclassificacao : number;
	fornecedor : number;
	cidade : number;
	nome : string;
	datacompra : string;
	datafimdagarantia : string;
	nfnro : string;
	valorbem : number;
	nroserieproduto : string;
	comprador : string;
	garantialoja : boolean;
	dataterminodagarantiadaloja : string;
	observacoes : string;
	nomevendedor : string;
	bold : boolean;
	nomebensclassificacao?: string;
	nomefornecedores?: string;
	nomecidade?: string;

}


export function BensMateriaisEmpty(): IBensMateriais {
// 20250604
    
    return {
        id: 0,
		bensclassificacao: 0,
		fornecedor: 0,
		cidade: 0,
		nome: '',
		datacompra: '',
		datafimdagarantia: '',
		nfnro: '',
		valorbem: 0,
		nroserieproduto: '',
		comprador: '',
		garantialoja: false,
		dataterminodagarantiadaloja: '',
		observacoes: '',
		nomevendedor: '',
		bold: false,
    };
}

export function BensMateriaisTestEmpty(): IBensMateriais {
// 20250604
    
    return {
        id: 1,
		bensclassificacao: 1,
		fornecedor: 1,
		cidade: 1,
		nome: 'X',
		datacompra: 'X',
		datafimdagarantia: 'X',
		nfnro: 'X',
		valorbem: 1,
		nroserieproduto: 'X',
		comprador: 'X',
		garantialoja: true,
		dataterminodagarantiadaloja: 'X',
		observacoes: 'X',
		nomevendedor: 'X',
		bold: true,
    };
}



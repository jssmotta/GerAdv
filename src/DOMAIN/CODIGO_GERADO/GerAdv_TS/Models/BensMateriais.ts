import { Auditor } from "./Auditor";

import { IBensMateriais } from "../BensMateriais/Interfaces/interface.BensMateriais";
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
	auditor?: Auditor | null;
}

export function BensMateriaisEmpty(): IBensMateriais {
// 20250125
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
		auditor: null
    };
}

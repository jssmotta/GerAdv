import { Auditor } from "../../Models/Auditor";

export interface IBensMateriais {
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
